using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SNAConfig
{
    public partial class Form1 : Form
    {
        private DataTable scheduleTable;
        private const string ACCOUNTS_FILE = "accounts.txt";
        private const string LAST_LOADED_FILE = "last_loaded.txt";

        public Form1()
        {
            InitializeComponent();
            InitializeDataTable();
            ConfigureDataGridView();
            LoadAccountsList();
            LoadLastFile();

            // Définir des valeurs par défaut
            cmbPlatform.SelectedIndex = 0;
            cmbActivity.SelectedIndex = 0;
            cmbEndAction.SelectedIndex = 0; // Par défaut "close"

            // Heure de fin = heure de début + 10 minutes
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = dtpStartTime.Value.AddMinutes(10);

            // Activer l'action de fin par défaut
            chkAddEndAction.Checked = true;
        }

        private void InitializeDataTable()
        {
            scheduleTable = new DataTable();
            scheduleTable.Columns.Add("Date", typeof(string));
            scheduleTable.Columns.Add("Platform", typeof(string));
            scheduleTable.Columns.Add("Account", typeof(string));
            scheduleTable.Columns.Add("Activity", typeof(string));
            scheduleTable.Columns.Add("Path", typeof(string));
            scheduleTable.Columns.Add("Post Description", typeof(string));
        }

        private void ConfigureDataGridView()
        {
            dgvSchedule.DataSource = scheduleTable;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.MultiSelect = false;
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.ReadOnly = true;
        }

        private void LoadAccountsList()
        {
            try
            {
                if (File.Exists(ACCOUNTS_FILE))
                {
                    var accounts = File.ReadAllLines(ACCOUNTS_FILE, Encoding.UTF8)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Distinct()
                        .ToList();

                    cmbAccount.Items.Clear();
                    cmbAccount.Items.AddRange(accounts.ToArray());

                    if (cmbAccount.Items.Count > 0)
                    {
                        cmbAccount.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des comptes: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveAccountsList()
        {
            try
            {
                var accounts = cmbAccount.Items.Cast<string>().ToList();
                File.WriteAllLines(ACCOUNTS_FILE, accounts, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde des comptes: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadLastFile()
        {
            try
            {
                if (File.Exists(LAST_LOADED_FILE))
                {
                    string lastFile = File.ReadAllText(LAST_LOADED_FILE, Encoding.UTF8).Trim();
                    if (File.Exists(lastFile))
                    {
                        LoadFromCsv(lastFile);
                    }
                }
            }
            catch
            {
                // Ignore les erreurs au chargement initial
            }
        }

        private void SaveLastLoadedFile(string filePath)
        {
            try
            {
                File.WriteAllText(LAST_LOADED_FILE, filePath, Encoding.UTF8);
            }
            catch
            {
                // Ignore les erreurs de sauvegarde
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (cmbPlatform.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner une plateforme.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(cmbAccount.Text))
                {
                    MessageBox.Show("Veuillez entrer un nom de compte.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbActivity.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner une activité.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ajouter le compte à la liste s'il n'existe pas
                string accountName = cmbAccount.Text.Trim();
                if (!cmbAccount.Items.Contains(accountName))
                {
                    cmbAccount.Items.Add(accountName);
                    SaveAccountsList();
                }

                // Créer la date/heure de début formatée
                string startDateTime = $"{dtpStartTime.Value:yyyy-MM-dd HH:mm}";

                // Ajouter la ligne de début au DataTable
                DataRow startRow = scheduleTable.NewRow();
                startRow["Date"] = startDateTime;
                startRow["Platform"] = cmbPlatform.SelectedItem.ToString();
                startRow["Account"] = accountName;
                startRow["Activity"] = cmbActivity.SelectedItem.ToString();
                startRow["Path"] = txtMediaPath.Text;
                startRow["Post Description"] = txtDescription.Text;
                scheduleTable.Rows.Add(startRow);

                // Ajouter la ligne de fin si activée
                if (chkAddEndAction.Checked && dtpEndTime.Value > dtpStartTime.Value)
                {
                    string endDateTime = $"{dtpEndTime.Value:yyyy-MM-dd HH:mm}";

                    DataRow stopRow = scheduleTable.NewRow();
                    stopRow["Date"] = endDateTime;
                    stopRow["Platform"] = cmbPlatform.SelectedItem.ToString();
                    stopRow["Account"] = accountName;
                    stopRow["Activity"] = cmbEndAction.SelectedItem.ToString(); // stop ou close
                    stopRow["Path"] = "";
                    stopRow["Post Description"] = "";
                    scheduleTable.Rows.Add(stopRow);
                }

                // Réinitialiser les champs pour une nouvelle saisie
                dtpStartTime.Value = dtpEndTime.Value;
                dtpEndTime.Value = dtpStartTime.Value.AddMinutes(10);
                txtMediaPath.Clear();
                txtDescription.Clear();

                // Garder la même plateforme, compte et activité pour faciliter la saisie en série
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAddEndAction_CheckedChanged(object sender, EventArgs e)
        {
            // Activer/désactiver les contrôles de fin
            dtpEndTime.Enabled = chkAddEndAction.Checked;
            cmbEndAction.Enabled = chkAddEndAction.Checked;
        }

        private void btnDispatchTargets_Click(object sender, EventArgs e)
        {
            try
            {
                // Demander où se trouve FutureTargets.txt
                OpenFileDialog openDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    Title = "Sélectionner FutureTargets.txt",
                    FileName = "FutureTargets.txt"
                };

                if (openDialog.ShowDialog() != DialogResult.OK)
                    return;

                string futureTargetsPath = openDialog.FileName;
                string dataDir = Path.GetDirectoryName(futureTargetsPath);

                // Dialog pour choisir le nombre de fichiers
                using (var inputForm = new Form())
                {
                    inputForm.Text = "Dispatch Configuration";
                    inputForm.Width = 400;
                    inputForm.Height = 200;
                    inputForm.StartPosition = FormStartPosition.CenterParent;
                    inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    inputForm.MaximizeBox = false;
                    inputForm.MinimizeBox = false;

                    var label = new Label
                    {
                        Text = "Nombre de fichiers Targets_X.txt à créer:",
                        Location = new Point(20, 20),
                        AutoSize = true
                    };

                    var numericUpDown = new NumericUpDown
                    {
                        Location = new Point(20, 50),
                        Width = 100,
                        Minimum = 1,
                        Maximum = 50,
                        Value = 3
                    };

                    var btnOk = new Button
                    {
                        Text = "Dispatcher",
                        Location = new Point(150, 100),
                        DialogResult = DialogResult.OK
                    };

                    var btnCancel = new Button
                    {
                        Text = "Annuler",
                        Location = new Point(250, 100),
                        DialogResult = DialogResult.Cancel
                    };

                    inputForm.Controls.AddRange(new Control[] { label, numericUpDown, btnOk, btnCancel });
                    inputForm.AcceptButton = btnOk;
                    inputForm.CancelButton = btnCancel;

                    if (inputForm.ShowDialog() != DialogResult.OK)
                        return;

                    int numberOfFiles = (int)numericUpDown.Value;

                    // Lire FutureTargets.txt
                    var allTargets = File.ReadAllLines(futureTargetsPath)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(line => line.Trim())
                        .Distinct()
                        .ToList();

                    if (allTargets.Count == 0)
                    {
                        MessageBox.Show("❌ FutureTargets.txt est vide!",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Vérifier si des fichiers existent déjà
                    bool filesExist = false;
                    for (int i = 1; i <= numberOfFiles; i++)
                    {
                        if (File.Exists(Path.Combine(dataDir, $"Targets_{i}.txt")))
                        {
                            filesExist = true;
                            break;
                        }
                    }

                    // Si des fichiers existent, demander la stratégie
                    bool appendMode = false;
                    if (filesExist)
                    {
                        var strategyResult = MessageBox.Show(
                            $"Des fichiers Targets_X.txt existent déjà.\n\n" +
                            $"• Oui: AJOUTER les nouvelles targets (sans doublons)\n" +
                            $"• Non: ÉCRASER complètement les fichiers existants",
                            "Fichiers existants détectés",
                            MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question);

                        if (strategyResult == DialogResult.Cancel)
                            return;

                        appendMode = (strategyResult == DialogResult.Yes);
                    }

                    // Dispatcher les targets
                    var targetsPerFile = (int)Math.Ceiling((double)allTargets.Count / numberOfFiles);
                    int totalDispatched = 0;
                    int newTargetsAdded = 0;

                    for (int i = 0; i < numberOfFiles; i++)
                    {
                        var fileTargets = allTargets
                            .Skip(i * targetsPerFile)
                            .Take(targetsPerFile)
                            .ToList();

                        if (fileTargets.Count == 0)
                            break;

                        var targetFilePath = Path.Combine(dataDir, $"Targets_{i + 1}.txt");

                        if (appendMode && File.Exists(targetFilePath))
                        {
                            // Mode ajout : filtrer les doublons
                            var existingTargets = File.ReadAllLines(targetFilePath)
                                .Where(line => !string.IsNullOrWhiteSpace(line))
                                .Select(line => line.Trim())
                                .ToHashSet(StringComparer.OrdinalIgnoreCase);

                            var newTargets = fileTargets
                                .Where(t => !existingTargets.Contains(t))
                                .ToList();

                            if (newTargets.Count > 0)
                            {
                                File.AppendAllLines(targetFilePath, newTargets);
                                newTargetsAdded += newTargets.Count;
                            }

                            totalDispatched += fileTargets.Count;
                        }
                        else
                        {
                            // Mode écrasement ou création
                            File.WriteAllLines(targetFilePath, fileTargets);
                            totalDispatched += fileTargets.Count;
                            newTargetsAdded += fileTargets.Count;
                        }
                    }

                    string message = $"✅ Dispatch terminé!\n\n" +
                        $"• Targets dans FutureTargets.txt: {allTargets.Count}\n" +
                        $"• Fichiers traités: {numberOfFiles}\n" +
                        $"• Targets dispatchées: {totalDispatched}\n";

                    if (appendMode)
                        message += $"• Nouvelles targets ajoutées: {newTargetsAdded}\n";

                    message += $"• Moyenne par fichier: ~{targetsPerFile}";

                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors du dispatch:\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSchedule.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette entrée?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvSchedule.SelectedRows)
                        {
                            if (!row.IsNewRow)
                            {
                                dgvSchedule.Rows.Remove(row);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir vider tout le planning?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    scheduleTable.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du vidage: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (scheduleTable.Rows.Count == 0)
                {
                    MessageBox.Show("Le planning est vide. Rien à enregistrer.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string fileToSave = null;

                // Vérifier si un fichier a déjà été chargé
                if (File.Exists(LAST_LOADED_FILE))
                {
                    string lastFile = File.ReadAllText(LAST_LOADED_FILE, Encoding.UTF8).Trim();
                    if (!string.IsNullOrEmpty(lastFile) && File.Exists(lastFile))
                    {
                        // Utiliser le fichier chargé sans demander
                        fileToSave = lastFile;
                    }
                }

                // Si pas de fichier chargé, demander où enregistrer
                if (string.IsNullOrEmpty(fileToSave))
                {
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                        DefaultExt = "csv",
                        FileName = "Schedule.csv"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileToSave = saveDialog.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                // Enregistrer le fichier
                SaveToCsv(fileToSave);
                SaveLastLoadedFile(fileToSave);
                MessageBox.Show($"✅ {Path.GetFileName(fileToSave)}\nenregistré avec succès!\n\n{scheduleTable.Rows.Count} entrées sauvegardées.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'enregistrement: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveToCsv(string filePath)
        {
            StringBuilder csv = new StringBuilder();

            // En-têtes
            csv.AppendLine("Date,Platform,Account,Activity,Path,Post Description");

            // Trier les lignes par date
            var sortedRows = scheduleTable.AsEnumerable()
                .OrderBy(row => DateTime.ParseExact(row["Date"].ToString(),
                    "yyyy-MM-dd HH:mm", null));

            // Données
            foreach (var row in sortedRows)
            {
                var line = string.Join(",",
                    EscapeCsvField(row["Date"].ToString()),
                    EscapeCsvField(row["Platform"].ToString()),
                    EscapeCsvField(row["Account"].ToString()),
                    EscapeCsvField(row["Activity"].ToString()),
                    EscapeCsvField(row["Path"].ToString()),
                    EscapeCsvField(row["Post Description"].ToString())
                );
                csv.AppendLine(line);
            }

            File.WriteAllText(filePath, csv.ToString(), Encoding.UTF8);
        }

        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
                return "";

            // Échapper les guillemets et entourer de guillemets si nécessaire
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                field = field.Replace("\"", "\"\"");
                return $"\"{field}\"";
            }

            return field;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    DefaultExt = "csv"
                };

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadFromCsv(openDialog.FileName);
                    SaveLastLoadedFile(openDialog.FileName);
                    MessageBox.Show($"✅ Planning chargé avec succès!\n\n{scheduleTable.Rows.Count} entrées chargées.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement: {ex.Message}", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFromCsv(string filePath)
        {
            scheduleTable.Clear();

            using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
            {
                // Ignorer l'en-tête
                string headerLine = reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var fields = ParseCsvLine(line);

                    if (fields.Count >= 6)
                    {
                        DataRow row = scheduleTable.NewRow();
                        row["Date"] = fields[0];
                        row["Platform"] = fields[1];
                        row["Account"] = fields[2];
                        row["Activity"] = fields[3];
                        row["Path"] = fields[4];
                        row["Post Description"] = fields[5];
                        scheduleTable.Rows.Add(row);
                    }
                }
            }
        }

        private List<string> ParseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            bool inQuotes = false;
            StringBuilder currentField = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        currentField.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    fields.Add(currentField.ToString());
                    currentField.Clear();
                }
                else
                {
                    currentField.Append(c);
                }
            }

            fields.Add(currentField.ToString());
            return fields;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "Image/Video files|*.jpg;*.jpeg;*.png;*.gif;*.mp4;*.avi;*.mov|All files (*.*)|*.*",
                Title = "Sélectionner un fichier média"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txtMediaPath.Text = openDialog.FileName;
            }
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            // Mettre à jour automatiquement l'heure de fin (+ 10 minutes)
            if (chkAddEndAction.Checked)
            {
                dtpEndTime.Value = dtpStartTime.Value.AddMinutes(10);
            }
        }
    }
}
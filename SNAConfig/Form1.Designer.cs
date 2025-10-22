namespace SNAConfig
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            grpScheduleEntry = new GroupBox();
            cmbEndAction = new ComboBox();
            lblEndAction = new Label();
            chkAddEndAction = new CheckBox();
            btnBrowse = new Button();
            txtMediaPath = new TextBox();
            lblMediaPath = new Label();
            txtDescription = new TextBox();
            lblDescription = new Label();
            dtpEndTime = new DateTimePicker();
            lblEndTime = new Label();
            dtpStartTime = new DateTimePicker();
            lblStartTime = new Label();
            cmbActivity = new ComboBox();
            lblActivity = new Label();
            cmbAccount = new ComboBox();
            lblAccount = new Label();
            cmbPlatform = new ComboBox();
            lblPlatform = new Label();
            btnAdd = new Button();
            grpScheduleList = new GroupBox();
            dgvSchedule = new DataGridView();
            btnClear = new Button();
            btnRemove = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnDispatchTargets = new Button();
            grpScheduleEntry.SuspendLayout();
            grpScheduleList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // grpScheduleEntry
            // 
            grpScheduleEntry.Controls.Add(cmbEndAction);
            grpScheduleEntry.Controls.Add(lblEndAction);
            grpScheduleEntry.Controls.Add(chkAddEndAction);
            grpScheduleEntry.Controls.Add(btnBrowse);
            grpScheduleEntry.Controls.Add(txtMediaPath);
            grpScheduleEntry.Controls.Add(lblMediaPath);
            grpScheduleEntry.Controls.Add(txtDescription);
            grpScheduleEntry.Controls.Add(lblDescription);
            grpScheduleEntry.Controls.Add(dtpEndTime);
            grpScheduleEntry.Controls.Add(lblEndTime);
            grpScheduleEntry.Controls.Add(dtpStartTime);
            grpScheduleEntry.Controls.Add(lblStartTime);
            grpScheduleEntry.Controls.Add(cmbActivity);
            grpScheduleEntry.Controls.Add(lblActivity);
            grpScheduleEntry.Controls.Add(cmbAccount);
            grpScheduleEntry.Controls.Add(lblAccount);
            grpScheduleEntry.Controls.Add(cmbPlatform);
            grpScheduleEntry.Controls.Add(lblPlatform);
            grpScheduleEntry.Location = new Point(12, 12);
            grpScheduleEntry.Name = "grpScheduleEntry";
            grpScheduleEntry.Size = new Size(360, 490);
            grpScheduleEntry.TabIndex = 0;
            grpScheduleEntry.TabStop = false;
            grpScheduleEntry.Text = "Nouvelle entrée";
            // 
            // cmbEndAction
            // 
            cmbEndAction.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEndAction.FormattingEnabled = true;
            cmbEndAction.Items.AddRange(new object[] { "close", "stop" });
            cmbEndAction.Location = new Point(15, 260);
            cmbEndAction.Name = "cmbEndAction";
            cmbEndAction.Size = new Size(339, 23);
            cmbEndAction.TabIndex = 18;
            // 
            // lblEndAction
            // 
            lblEndAction.AutoSize = true;
            lblEndAction.Location = new Point(15, 241);
            lblEndAction.Name = "lblEndAction";
            lblEndAction.Size = new Size(81, 15);
            lblEndAction.TabIndex = 17;
            lblEndAction.Text = "Action de fin :";
            // 
            // chkAddEndAction
            // 
            chkAddEndAction.AutoSize = true;
            chkAddEndAction.Checked = true;
            chkAddEndAction.CheckState = CheckState.Checked;
            chkAddEndAction.Location = new Point(15, 195);
            chkAddEndAction.Name = "chkAddEndAction";
            chkAddEndAction.Size = new Size(228, 19);
            chkAddEndAction.TabIndex = 16;
            chkAddEndAction.Text = "Ajouter une action de fin automatique";
            chkAddEndAction.UseVisualStyleBackColor = true;
            chkAddEndAction.CheckedChanged += chkAddEndAction_CheckedChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(279, 321);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 15;
            btnBrowse.Text = "Parcourir...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtMediaPath
            // 
            txtMediaPath.Location = new Point(15, 321);
            txtMediaPath.Name = "txtMediaPath";
            txtMediaPath.Size = new Size(258, 23);
            txtMediaPath.TabIndex = 14;
            // 
            // lblMediaPath
            // 
            lblMediaPath.AutoSize = true;
            lblMediaPath.Location = new Point(15, 303);
            lblMediaPath.Name = "lblMediaPath";
            lblMediaPath.Size = new Size(91, 15);
            lblMediaPath.TabIndex = 13;
            lblMediaPath.Text = "Chemin média :";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(15, 368);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(339, 104);
            txtDescription.TabIndex = 12;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(15, 350);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(116, 15);
            lblDescription.TabIndex = 11;
            lblDescription.Text = "Description du post :";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(15, 216);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(339, 23);
            dtpEndTime.TabIndex = 10;
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(153, 195);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(62, 15);
            lblEndTime.TabIndex = 9;
            lblEndTime.Text = "Heure fin :";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(15, 169);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(339, 23);
            dtpStartTime.TabIndex = 8;
            dtpStartTime.ValueChanged += dtpStartTime_ValueChanged;
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Location = new Point(15, 151);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(79, 15);
            lblStartTime.TabIndex = 7;
            lblStartTime.Text = "Heure début :";
            // 
            // cmbActivity
            // 
            cmbActivity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActivity.FormattingEnabled = true;
            cmbActivity.Items.AddRange(new object[] { "target", "scroll", "publish", "story", "dm" });
            cmbActivity.Location = new Point(15, 125);
            cmbActivity.Name = "cmbActivity";
            cmbActivity.Size = new Size(339, 23);
            cmbActivity.TabIndex = 6;
            // 
            // lblActivity
            // 
            lblActivity.AutoSize = true;
            lblActivity.Location = new Point(15, 107);
            lblActivity.Name = "lblActivity";
            lblActivity.Size = new Size(53, 15);
            lblActivity.TabIndex = 5;
            lblActivity.Text = "Activité :";
            // 
            // cmbAccount
            // 
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(15, 81);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(339, 23);
            cmbAccount.TabIndex = 4;
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(15, 63);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(56, 15);
            lblAccount.TabIndex = 3;
            lblAccount.Text = "Compte :";
            // 
            // cmbPlatform
            // 
            cmbPlatform.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlatform.FormattingEnabled = true;
            cmbPlatform.Items.AddRange(new object[] { "Instagram", "TikTok" });
            cmbPlatform.Location = new Point(15, 37);
            cmbPlatform.Name = "cmbPlatform";
            cmbPlatform.Size = new Size(339, 23);
            cmbPlatform.TabIndex = 2;
            // 
            // lblPlatform
            // 
            lblPlatform.AutoSize = true;
            lblPlatform.Location = new Point(15, 19);
            lblPlatform.Name = "lblPlatform";
            lblPlatform.Size = new Size(71, 15);
            lblPlatform.TabIndex = 1;
            lblPlatform.Text = "Plateforme :";
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.Location = new Point(27, 490);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(339, 35);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "➕ Ajouter au planning";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpScheduleList
            // 
            grpScheduleList.Controls.Add(dgvSchedule);
            grpScheduleList.Controls.Add(btnClear);
            grpScheduleList.Controls.Add(btnRemove);
            grpScheduleList.Location = new Point(378, 12);
            grpScheduleList.Name = "grpScheduleList";
            grpScheduleList.Size = new Size(890, 560);
            grpScheduleList.TabIndex = 1;
            grpScheduleList.TabStop = false;
            grpScheduleList.Text = "Planning";
            // 
            // dgvSchedule
            // 
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Location = new Point(6, 22);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.Size = new Size(878, 491);
            dgvSchedule.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.ForeColor = Color.DarkRed;
            btnClear.Location = new Point(447, 519);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(437, 35);
            btnClear.TabIndex = 2;
            btnClear.Text = "\U0001f9f9 Vider tout le planning";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(6, 519);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(435, 35);
            btnRemove.TabIndex = 0;
            btnRemove.Text = "🗑️ Supprimer la sélection";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Location = new Point(378, 578);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(440, 40);
            btnSave.TabIndex = 2;
            btnSave.Text = "💾 Enregistrer le planning (CSV)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(824, 578);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(444, 40);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "📂 Charger un planning (CSV)";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnDispatchTargets
            // 
            btnDispatchTargets.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDispatchTargets.Location = new Point(12, 578);
            btnDispatchTargets.Name = "btnDispatchTargets";
            btnDispatchTargets.Size = new Size(360, 40);
            btnDispatchTargets.TabIndex = 4;
            btnDispatchTargets.Text = "📋 Dispatch Targets";
            btnDispatchTargets.UseVisualStyleBackColor = true;
            btnDispatchTargets.Click += btnDispatchTargets_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 630);
            Controls.Add(btnDispatchTargets);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(grpScheduleList);
            Controls.Add(grpScheduleEntry);
            Controls.Add(btnAdd);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SNAConfig - Planificateur de réseaux sociaux";
            grpScheduleEntry.ResumeLayout(false);
            grpScheduleEntry.PerformLayout();
            grpScheduleList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpScheduleEntry;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtMediaPath;
        private System.Windows.Forms.Label lblMediaPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.CheckBox chkAddEndAction;
        private System.Windows.Forms.ComboBox cmbEndAction;
        private System.Windows.Forms.Label lblEndAction;
        private System.Windows.Forms.GroupBox grpScheduleList;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDispatchTargets;
    }
}
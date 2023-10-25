namespace RunBatForm
{
    partial class frmDatabaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabaseForm));
            this.pnItems = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDrop = new System.Windows.Forms.RadioButton();
            this.rdbRestore = new System.Windows.Forms.RadioButton();
            this.rdbBackup = new System.Windows.Forms.RadioButton();
            this.rdbMigrate = new System.Windows.Forms.RadioButton();
            this.rdbDeploy = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.gbDatabaseGroup = new System.Windows.Forms.GroupBox();
            this.cbCatalog = new System.Windows.Forms.CheckBox();
            this.cbWorkingpaper = new System.Windows.Forms.CheckBox();
            this.cbCore = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gbDatabaseGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnItems
            // 
            this.pnItems.Location = new System.Drawing.Point(120, 23);
            this.pnItems.Name = "pnItems";
            this.pnItems.Size = new System.Drawing.Size(286, 203);
            this.pnItems.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDrop);
            this.groupBox1.Controls.Add(this.rdbRestore);
            this.groupBox1.Controls.Add(this.rdbBackup);
            this.groupBox1.Controls.Add(this.rdbMigrate);
            this.groupBox1.Controls.Add(this.rdbDeploy);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 214);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rdbDrop
            // 
            this.rdbDrop.AutoSize = true;
            this.rdbDrop.Location = new System.Drawing.Point(6, 146);
            this.rdbDrop.Name = "rdbDrop";
            this.rdbDrop.Size = new System.Drawing.Size(64, 24);
            this.rdbDrop.TabIndex = 4;
            this.rdbDrop.TabStop = true;
            this.rdbDrop.Text = "Drop";
            this.rdbDrop.UseVisualStyleBackColor = true;
            this.rdbDrop.CheckedChanged += new System.EventHandler(this.rdbDrop_CheckedChanged);
            // 
            // rdbRestore
            // 
            this.rdbRestore.AutoSize = true;
            this.rdbRestore.Location = new System.Drawing.Point(6, 116);
            this.rdbRestore.Name = "rdbRestore";
            this.rdbRestore.Size = new System.Drawing.Size(80, 24);
            this.rdbRestore.TabIndex = 3;
            this.rdbRestore.TabStop = true;
            this.rdbRestore.Text = "Restore";
            this.rdbRestore.UseVisualStyleBackColor = true;
            this.rdbRestore.CheckedChanged += new System.EventHandler(this.rdbRestore_CheckedChanged);
            // 
            // rdbBackup
            // 
            this.rdbBackup.AutoSize = true;
            this.rdbBackup.Location = new System.Drawing.Point(6, 86);
            this.rdbBackup.Name = "rdbBackup";
            this.rdbBackup.Size = new System.Drawing.Size(78, 24);
            this.rdbBackup.TabIndex = 2;
            this.rdbBackup.TabStop = true;
            this.rdbBackup.Text = "Backup";
            this.rdbBackup.UseVisualStyleBackColor = true;
            this.rdbBackup.CheckedChanged += new System.EventHandler(this.rdbBackup_CheckedChanged);
            // 
            // rdbMigrate
            // 
            this.rdbMigrate.AutoSize = true;
            this.rdbMigrate.Location = new System.Drawing.Point(6, 56);
            this.rdbMigrate.Name = "rdbMigrate";
            this.rdbMigrate.Size = new System.Drawing.Size(82, 24);
            this.rdbMigrate.TabIndex = 1;
            this.rdbMigrate.TabStop = true;
            this.rdbMigrate.Text = "Migrate";
            this.rdbMigrate.UseVisualStyleBackColor = true;
            this.rdbMigrate.CheckedChanged += new System.EventHandler(this.rdbMigrate_CheckedChanged);
            // 
            // rdbDeploy
            // 
            this.rdbDeploy.AutoSize = true;
            this.rdbDeploy.Location = new System.Drawing.Point(6, 26);
            this.rdbDeploy.Name = "rdbDeploy";
            this.rdbDeploy.Size = new System.Drawing.Size(78, 24);
            this.rdbDeploy.TabIndex = 0;
            this.rdbDeploy.TabStop = true;
            this.rdbDeploy.Text = "Deploy";
            this.rdbDeploy.UseVisualStyleBackColor = true;
            this.rdbDeploy.CheckedChanged += new System.EventHandler(this.rdbDeploy_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRun.Location = new System.Drawing.Point(470, 232);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(94, 55);
            this.btnRun.TabIndex = 5;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // gbDatabaseGroup
            // 
            this.gbDatabaseGroup.Controls.Add(this.cbCatalog);
            this.gbDatabaseGroup.Controls.Add(this.cbWorkingpaper);
            this.gbDatabaseGroup.Controls.Add(this.cbCore);
            this.gbDatabaseGroup.Location = new System.Drawing.Point(414, 23);
            this.gbDatabaseGroup.Name = "gbDatabaseGroup";
            this.gbDatabaseGroup.Size = new System.Drawing.Size(152, 203);
            this.gbDatabaseGroup.TabIndex = 11;
            this.gbDatabaseGroup.TabStop = false;
            this.gbDatabaseGroup.Text = "Database";
            this.gbDatabaseGroup.Visible = false;
            // 
            // cbCatalog
            // 
            this.cbCatalog.AutoSize = true;
            this.cbCatalog.Location = new System.Drawing.Point(12, 87);
            this.cbCatalog.Name = "cbCatalog";
            this.cbCatalog.Size = new System.Drawing.Size(83, 24);
            this.cbCatalog.TabIndex = 0;
            this.cbCatalog.Text = "Catalog";
            this.cbCatalog.UseVisualStyleBackColor = true;
            this.cbCatalog.CheckedChanged += new System.EventHandler(this.DatabaseCheckedChangeItem);
            // 
            // cbWorkingpaper
            // 
            this.cbWorkingpaper.AutoSize = true;
            this.cbWorkingpaper.Location = new System.Drawing.Point(12, 57);
            this.cbWorkingpaper.Name = "cbWorkingpaper";
            this.cbWorkingpaper.Size = new System.Drawing.Size(125, 24);
            this.cbWorkingpaper.TabIndex = 0;
            this.cbWorkingpaper.Text = "Workingpaper";
            this.cbWorkingpaper.UseVisualStyleBackColor = true;
            this.cbWorkingpaper.CheckedChanged += new System.EventHandler(this.DatabaseCheckedChangeItem);
            // 
            // cbCore
            // 
            this.cbCore.AutoSize = true;
            this.cbCore.Location = new System.Drawing.Point(12, 27);
            this.cbCore.Name = "cbCore";
            this.cbCore.Size = new System.Drawing.Size(62, 24);
            this.cbCore.TabIndex = 0;
            this.cbCore.Text = "Core";
            this.cbCore.UseVisualStyleBackColor = true;
            this.cbCore.CheckedChanged += new System.EventHandler(this.DatabaseCheckedChangeItem);
            // 
            // frmDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 296);
            this.Controls.Add(this.gbDatabaseGroup);
            this.Controls.Add(this.pnItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDatabaseGroup.ResumeLayout(false);
            this.gbDatabaseGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDrop;
        private System.Windows.Forms.RadioButton rdbRestore;
        private System.Windows.Forms.RadioButton rdbBackup;
        private System.Windows.Forms.RadioButton rdbMigrate;
        private System.Windows.Forms.RadioButton rdbDeploy;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox gbDatabaseGroup;
        private System.Windows.Forms.CheckBox cbCatalog;
        private System.Windows.Forms.CheckBox cbWorkingpaper;
        private System.Windows.Forms.CheckBox cbCore;
    }
}
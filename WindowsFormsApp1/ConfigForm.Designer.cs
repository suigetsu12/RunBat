namespace RunBatForm
{
    partial class ConfigForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPublicFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataBackupFolder = new System.Windows.Forms.TextBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectFolder = new System.Windows.Forms.TextBox();
            this.btnProjectBrowser = new System.Windows.Forms.Button();
            this.projectFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDevCmdPathBrowser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVSDevCmdPath = new System.Windows.Forms.TextBox();
            this.openVSDevCmdFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(176, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(341, 27);
            this.txtFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Main";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(523, 10);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(34, 29);
            this.btnBrowser.TabIndex = 2;
            this.btnBrowser.Text = "...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Public";
            // 
            // txtPublicFolder
            // 
            this.txtPublicFolder.Location = new System.Drawing.Point(176, 45);
            this.txtPublicFolder.Name = "txtPublicFolder";
            this.txtPublicFolder.ReadOnly = true;
            this.txtPublicFolder.Size = new System.Drawing.Size(341, 27);
            this.txtPublicFolder.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data Bakup";
            // 
            // txtDataBackupFolder
            // 
            this.txtDataBackupFolder.Location = new System.Drawing.Point(176, 78);
            this.txtDataBackupFolder.Name = "txtDataBackupFolder";
            this.txtDataBackupFolder.ReadOnly = true;
            this.txtDataBackupFolder.Size = new System.Drawing.Size(341, 27);
            this.txtDataBackupFolder.TabIndex = 5;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(423, 409);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(147, 29);
            this.btnSaveConfig.TabIndex = 7;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(320, 409);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(97, 29);
            this.btnRevert.TabIndex = 8;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Visible = false;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(12, 409);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(49, 20);
            this.lbError.TabIndex = 9;
            this.lbError.Text = "aaaaa";
            this.lbError.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Project Application";
            // 
            // txtProjectFolder
            // 
            this.txtProjectFolder.Location = new System.Drawing.Point(176, 111);
            this.txtProjectFolder.Name = "txtProjectFolder";
            this.txtProjectFolder.ReadOnly = true;
            this.txtProjectFolder.Size = new System.Drawing.Size(341, 27);
            this.txtProjectFolder.TabIndex = 10;
            // 
            // btnProjectBrowser
            // 
            this.btnProjectBrowser.Location = new System.Drawing.Point(523, 111);
            this.btnProjectBrowser.Name = "btnProjectBrowser";
            this.btnProjectBrowser.Size = new System.Drawing.Size(34, 29);
            this.btnProjectBrowser.TabIndex = 12;
            this.btnProjectBrowser.Text = "...";
            this.btnProjectBrowser.UseVisualStyleBackColor = true;
            this.btnProjectBrowser.Click += new System.EventHandler(this.btnProjectBrowser_Click);
            // 
            // btnDevCmdPathBrowser
            // 
            this.btnDevCmdPathBrowser.Location = new System.Drawing.Point(523, 144);
            this.btnDevCmdPathBrowser.Name = "btnDevCmdPathBrowser";
            this.btnDevCmdPathBrowser.Size = new System.Drawing.Size(34, 29);
            this.btnDevCmdPathBrowser.TabIndex = 15;
            this.btnDevCmdPathBrowser.Text = "...";
            this.btnDevCmdPathBrowser.UseVisualStyleBackColor = true;
            this.btnDevCmdPathBrowser.Click += new System.EventHandler(this.btnDevCmdPathBrowser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Visual Dev Cmd Path";
            // 
            // txtVSDevCmdPath
            // 
            this.txtVSDevCmdPath.Location = new System.Drawing.Point(176, 144);
            this.txtVSDevCmdPath.Name = "txtVSDevCmdPath";
            this.txtVSDevCmdPath.ReadOnly = true;
            this.txtVSDevCmdPath.Size = new System.Drawing.Size(341, 27);
            this.txtVSDevCmdPath.TabIndex = 13;
            // 
            // openVSDevCmdFileDialog
            // 
            this.openVSDevCmdFileDialog.FileName = "openVSDevCmdFileDialog";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.btnDevCmdPathBrowser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVSDevCmdPath);
            this.Controls.Add(this.btnProjectBrowser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProjectFolder);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDataBackupFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPublicFolder);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPublicFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataBackupFolder;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProjectFolder;
        private System.Windows.Forms.Button btnProjectBrowser;
        private System.Windows.Forms.FolderBrowserDialog projectFolderBrowserDialog;
        private System.Windows.Forms.Button btnDevCmdPathBrowser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVSDevCmdPath;
        private System.Windows.Forms.OpenFileDialog openVSDevCmdFileDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip5;
    }
}
namespace RunBatForm
{
    partial class frmFindBat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFindBat));
            this.dtgBatFile = new System.Windows.Forms.DataGridView();
            this.clSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProcess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBatFile)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgBatFile
            // 
            this.dtgBatFile.AllowUserToAddRows = false;
            this.dtgBatFile.AllowUserToDeleteRows = false;
            this.dtgBatFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBatFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clSelected,
            this.clName,
            this.clFileName,
            this.clMessage,
            this.clProcess});
            this.dtgBatFile.Location = new System.Drawing.Point(12, 12);
            this.dtgBatFile.Name = "dtgBatFile";
            this.dtgBatFile.RowHeadersWidth = 51;
            this.dtgBatFile.RowTemplate.Height = 29;
            this.dtgBatFile.Size = new System.Drawing.Size(776, 548);
            this.dtgBatFile.TabIndex = 0;
            this.dtgBatFile.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBatFile_CellContentClick);
            // 
            // clSelected
            // 
            this.clSelected.DataPropertyName = "ischecked";
            this.clSelected.HeaderText = "Select";
            this.clSelected.MinimumWidth = 6;
            this.clSelected.Name = "clSelected";
            this.clSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clSelected.Width = 125;
            // 
            // clName
            // 
            this.clName.DataPropertyName = "name";
            this.clName.HeaderText = "Name";
            this.clName.MinimumWidth = 6;
            this.clName.Name = "clName";
            this.clName.Width = 125;
            // 
            // clFileName
            // 
            this.clFileName.DataPropertyName = "file_name";
            this.clFileName.HeaderText = "File Name";
            this.clFileName.MinimumWidth = 6;
            this.clFileName.Name = "clFileName";
            this.clFileName.ReadOnly = true;
            this.clFileName.Width = 125;
            // 
            // clMessage
            // 
            this.clMessage.DataPropertyName = "message";
            this.clMessage.HeaderText = "Message";
            this.clMessage.MinimumWidth = 6;
            this.clMessage.Name = "clMessage";
            this.clMessage.ReadOnly = true;
            this.clMessage.Visible = false;
            this.clMessage.Width = 125;
            // 
            // clProcess
            // 
            this.clProcess.DataPropertyName = "processid";
            this.clProcess.HeaderText = "Procces";
            this.clProcess.MinimumWidth = 6;
            this.clProcess.Name = "clProcess";
            this.clProcess.ReadOnly = true;
            this.clProcess.Visible = false;
            this.clProcess.Width = 125;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(694, 566);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 29);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(12, 566);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(94, 29);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // frmFindBat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dtgBatFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFindBat";
            this.Text = "Find Bat";
            ((System.ComponentModel.ISupportInitialize)(this.dtgBatFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgBatFile;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProcess;
    }
}
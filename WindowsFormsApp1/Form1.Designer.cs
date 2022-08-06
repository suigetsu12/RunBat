
namespace RunBatForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSaveChange = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnCheckedAll = new System.Windows.Forms.Button();
            this.btnUnCheckedAll = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtgData = new System.Windows.Forms.DataGridView();
            this.clRun = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clProcessId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.Publish = new System.Windows.Forms.GroupBox();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnFindBat = new System.Windows.Forms.Button();
            this.btnResetProcess = new System.Windows.Forms.Button();
            this.btnServerConfig = new System.Windows.Forms.Button();
            this.btnCreateBaseData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).BeginInit();
            this.Publish.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveChange
            // 
            this.btnSaveChange.Location = new System.Drawing.Point(6, 63);
            this.btnSaveChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveChange.Name = "btnSaveChange";
            this.btnSaveChange.Size = new System.Drawing.Size(134, 31);
            this.btnSaveChange.TabIndex = 2;
            this.btnSaveChange.Text = "Update Changes";
            this.btnSaveChange.UseVisualStyleBackColor = true;
            this.btnSaveChange.Click += new System.EventHandler(this.btnSaveChange_Click);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.SystemColors.Control;
            this.btnRun.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRun.Location = new System.Drawing.Point(397, 127);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(114, 31);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnCheckedAll
            // 
            this.btnCheckedAll.Location = new System.Drawing.Point(6, 95);
            this.btnCheckedAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCheckedAll.Name = "btnCheckedAll";
            this.btnCheckedAll.Size = new System.Drawing.Size(134, 31);
            this.btnCheckedAll.TabIndex = 5;
            this.btnCheckedAll.Text = "Checked All";
            this.btnCheckedAll.UseVisualStyleBackColor = true;
            this.btnCheckedAll.Click += new System.EventHandler(this.btnCheckedAll_Click);
            // 
            // btnUnCheckedAll
            // 
            this.btnUnCheckedAll.Location = new System.Drawing.Point(7, 127);
            this.btnUnCheckedAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUnCheckedAll.Name = "btnUnCheckedAll";
            this.btnUnCheckedAll.Size = new System.Drawing.Size(133, 31);
            this.btnUnCheckedAll.TabIndex = 6;
            this.btnUnCheckedAll.Text = "UnChecked All";
            this.btnUnCheckedAll.UseVisualStyleBackColor = true;
            this.btnUnCheckedAll.Click += new System.EventHandler(this.btnUnCheckedAll_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(269, 127);
            this.btnReload.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(122, 31);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(146, 62);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(117, 31);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtgData
            // 
            this.dtgData.AllowUserToAddRows = false;
            this.dtgData.AllowUserToDeleteRows = false;
            this.dtgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clRun,
            this.clId,
            this.clName,
            this.clFileName,
            this.clProcessId,
            this.clMessage});
            this.dtgData.Location = new System.Drawing.Point(8, 171);
            this.dtgData.MultiSelect = false;
            this.dtgData.Name = "dtgData";
            this.dtgData.RowHeadersWidth = 51;
            this.dtgData.RowTemplate.Height = 29;
            this.dtgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgData.Size = new System.Drawing.Size(632, 524);
            this.dtgData.TabIndex = 9;
            this.dtgData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgData_CellContentClick);
            this.dtgData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgData_CellDoubleClick);
            this.dtgData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgData_CellFormatting);
            // 
            // clRun
            // 
            this.clRun.DataPropertyName = "ischecked";
            this.clRun.Frozen = true;
            this.clRun.HeaderText = "Run";
            this.clRun.MinimumWidth = 6;
            this.clRun.Name = "clRun";
            this.clRun.Width = 125;
            // 
            // clId
            // 
            this.clId.DataPropertyName = "id";
            this.clId.Frozen = true;
            this.clId.HeaderText = "Id";
            this.clId.MinimumWidth = 6;
            this.clId.Name = "clId";
            this.clId.ReadOnly = true;
            this.clId.Visible = false;
            this.clId.Width = 125;
            // 
            // clName
            // 
            this.clName.DataPropertyName = "name";
            this.clName.Frozen = true;
            this.clName.HeaderText = "Name";
            this.clName.MinimumWidth = 6;
            this.clName.Name = "clName";
            this.clName.ReadOnly = true;
            this.clName.Width = 125;
            // 
            // clFileName
            // 
            this.clFileName.DataPropertyName = "file_name";
            this.clFileName.Frozen = true;
            this.clFileName.HeaderText = "File Name";
            this.clFileName.MinimumWidth = 6;
            this.clFileName.Name = "clFileName";
            this.clFileName.ReadOnly = true;
            this.clFileName.Width = 125;
            // 
            // clProcessId
            // 
            this.clProcessId.DataPropertyName = "processid";
            this.clProcessId.HeaderText = "Process Id";
            this.clProcessId.MinimumWidth = 6;
            this.clProcessId.Name = "clProcessId";
            this.clProcessId.ReadOnly = true;
            this.clProcessId.Width = 125;
            // 
            // clMessage
            // 
            this.clMessage.DataPropertyName = "message";
            this.clMessage.HeaderText = "Message";
            this.clMessage.MinimumWidth = 6;
            this.clMessage.Name = "clMessage";
            this.clMessage.ReadOnly = true;
            this.clMessage.Width = 125;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(146, 95);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(117, 31);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(146, 127);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 31);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStop.Location = new System.Drawing.Point(397, 95);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(114, 31);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Enabled = false;
            this.btnStopAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStopAll.Location = new System.Drawing.Point(397, 63);
            this.btnStopAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(114, 31);
            this.btnStopAll.TabIndex = 13;
            this.btnStopAll.Text = "Stop All";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // Publish
            // 
            this.Publish.Controls.Add(this.btnDatabase);
            this.Publish.Controls.Add(this.btnPublish);
            this.Publish.Location = new System.Drawing.Point(7, 2);
            this.Publish.Name = "Publish";
            this.Publish.Size = new System.Drawing.Size(628, 52);
            this.Publish.TabIndex = 14;
            this.Publish.TabStop = false;
            this.Publish.Text = "Publish";
            // 
            // btnDatabase
            // 
            this.btnDatabase.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDatabase.ForeColor = System.Drawing.Color.Brown;
            this.btnDatabase.Location = new System.Drawing.Point(371, 16);
            this.btnDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(251, 31);
            this.btnDatabase.TabIndex = 16;
            this.btnDatabase.Text = "Databases";
            this.btnDatabase.UseVisualStyleBackColor = false;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPublish.ForeColor = System.Drawing.Color.DarkRed;
            this.btnPublish.Location = new System.Drawing.Point(113, 16);
            this.btnPublish.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(252, 31);
            this.btnPublish.TabIndex = 15;
            this.btnPublish.Text = "Projects";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(516, 63);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(119, 31);
            this.btnConfig.TabIndex = 15;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnFindBat
            // 
            this.btnFindBat.Location = new System.Drawing.Point(269, 95);
            this.btnFindBat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindBat.Name = "btnFindBat";
            this.btnFindBat.Size = new System.Drawing.Size(122, 31);
            this.btnFindBat.TabIndex = 16;
            this.btnFindBat.Text = "Find .bat";
            this.btnFindBat.UseVisualStyleBackColor = true;
            this.btnFindBat.Click += new System.EventHandler(this.btnFindBat_Click);
            // 
            // btnResetProcess
            // 
            this.btnResetProcess.ForeColor = System.Drawing.Color.Red;
            this.btnResetProcess.Location = new System.Drawing.Point(269, 63);
            this.btnResetProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnResetProcess.Name = "btnResetProcess";
            this.btnResetProcess.Size = new System.Drawing.Size(122, 31);
            this.btnResetProcess.TabIndex = 17;
            this.btnResetProcess.Text = "Reset Process";
            this.btnResetProcess.UseVisualStyleBackColor = true;
            this.btnResetProcess.Click += new System.EventHandler(this.btnResetProcess_Click);
            // 
            // btnServerConfig
            // 
            this.btnServerConfig.Location = new System.Drawing.Point(516, 95);
            this.btnServerConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnServerConfig.Name = "btnServerConfig";
            this.btnServerConfig.Size = new System.Drawing.Size(119, 31);
            this.btnServerConfig.TabIndex = 18;
            this.btnServerConfig.Text = "DB Config";
            this.btnServerConfig.UseVisualStyleBackColor = true;
            this.btnServerConfig.Click += new System.EventHandler(this.btnServerConfig_Click);
            // 
            // btnCreateBaseData
            // 
            this.btnCreateBaseData.Location = new System.Drawing.Point(516, 127);
            this.btnCreateBaseData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateBaseData.Name = "btnCreateBaseData";
            this.btnCreateBaseData.Size = new System.Drawing.Size(119, 31);
            this.btnCreateBaseData.TabIndex = 19;
            this.btnCreateBaseData.Text = "Base Data";
            this.btnCreateBaseData.UseVisualStyleBackColor = true;
            this.btnCreateBaseData.Visible = false;
            this.btnCreateBaseData.Click += new System.EventHandler(this.btnCreateBaseData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 709);
            this.Controls.Add(this.btnCreateBaseData);
            this.Controls.Add(this.btnServerConfig);
            this.Controls.Add(this.btnResetProcess);
            this.Controls.Add(this.btnFindBat);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.Publish);
            this.Controls.Add(this.btnStopAll);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dtgData);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnUnCheckedAll);
            this.Controls.Add(this.btnCheckedAll);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnSaveChange);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mini tool";
            ((System.ComponentModel.ISupportInitialize)(this.dtgData)).EndInit();
            this.Publish.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSaveChange;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnCheckedAll;
        private System.Windows.Forms.Button btnUnCheckedAll;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dtgData;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.GroupBox Publish;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnFindBat;
        private System.Windows.Forms.Button btnResetProcess;
        private System.Windows.Forms.Button btnServerConfig;
        private System.Windows.Forms.Button btnCreateBaseData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clRun;
        private System.Windows.Forms.DataGridViewTextBoxColumn clId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clProcessId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clMessage;
    }
}


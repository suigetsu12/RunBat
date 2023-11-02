namespace RunBatForm
{
    partial class frmReplaceJSONConfiguration
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnItems = new System.Windows.Forms.Panel();
            this.lbReplaced = new System.Windows.Forms.Label();
            this.lbFound = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Old Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Value";
            // 
            // txtOldValue
            // 
            this.txtOldValue.Location = new System.Drawing.Point(122, 12);
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.Size = new System.Drawing.Size(333, 27);
            this.txtOldValue.TabIndex = 3;
            // 
            // txtNewValue
            // 
            this.txtNewValue.Location = new System.Drawing.Point(122, 50);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(333, 27);
            this.txtNewValue.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnItems);
            this.groupBox1.Controls.Add(this.lbReplaced);
            this.groupBox1.Controls.Add(this.lbFound);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 285);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // pnItems
            // 
            this.pnItems.AutoScroll = true;
            this.pnItems.Location = new System.Drawing.Point(6, 54);
            this.pnItems.Name = "pnItems";
            this.pnItems.Size = new System.Drawing.Size(650, 225);
            this.pnItems.TabIndex = 2;
            // 
            // lbReplaced
            // 
            this.lbReplaced.AutoSize = true;
            this.lbReplaced.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbReplaced.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbReplaced.Location = new System.Drawing.Point(131, 23);
            this.lbReplaced.Name = "lbReplaced";
            this.lbReplaced.Size = new System.Drawing.Size(65, 28);
            this.lbReplaced.TabIndex = 1;
            this.lbReplaced.Text = "label4";
            this.lbReplaced.Visible = false;
            // 
            // lbFound
            // 
            this.lbFound.AutoSize = true;
            this.lbFound.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbFound.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbFound.Location = new System.Drawing.Point(6, 23);
            this.lbFound.Name = "lbFound";
            this.lbFound.Size = new System.Drawing.Size(65, 28);
            this.lbFound.TabIndex = 0;
            this.lbFound.Text = "label4";
            this.lbFound.Visible = false;
            // 
            // btnReplace
            // 
            this.btnReplace.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnReplace.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReplace.ForeColor = System.Drawing.Color.Red;
            this.btnReplace.Location = new System.Drawing.Point(461, 12);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(102, 65);
            this.btnReplace.TabIndex = 5;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = false;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnRevert
            // 
            this.btnRevert.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnRevert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRevert.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnRevert.Location = new System.Drawing.Point(572, 12);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(102, 65);
            this.btnRevert.TabIndex = 5;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = false;
            this.btnRevert.Visible = false;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // frmReplaceJSONConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 380);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNewValue);
            this.Controls.Add(this.txtOldValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReplaceJSONConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace JSON configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbReplaced;
        private System.Windows.Forms.Label lbFound;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Panel pnItems;
    }
}
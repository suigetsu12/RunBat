namespace RunBatForm
{
    partial class frmPublishForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPublishForm));
            this.rdbFeature = new System.Windows.Forms.RadioButton();
            this.rdbFunction = new System.Windows.Forms.RadioButton();
            this.btnPublish = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnItems = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbFeature
            // 
            this.rdbFeature.AutoSize = true;
            this.rdbFeature.Location = new System.Drawing.Point(20, 26);
            this.rdbFeature.Name = "rdbFeature";
            this.rdbFeature.Size = new System.Drawing.Size(79, 24);
            this.rdbFeature.TabIndex = 0;
            this.rdbFeature.TabStop = true;
            this.rdbFeature.Text = "Feature";
            this.rdbFeature.UseVisualStyleBackColor = true;
            this.rdbFeature.CheckedChanged += new System.EventHandler(this.rdbFeature_CheckedChanged);
            // 
            // rdbFunction
            // 
            this.rdbFunction.AutoSize = true;
            this.rdbFunction.Location = new System.Drawing.Point(116, 26);
            this.rdbFunction.Name = "rdbFunction";
            this.rdbFunction.Size = new System.Drawing.Size(86, 24);
            this.rdbFunction.TabIndex = 1;
            this.rdbFunction.TabStop = true;
            this.rdbFunction.Text = "Function";
            this.rdbFunction.UseVisualStyleBackColor = true;
            this.rdbFunction.CheckedChanged += new System.EventHandler(this.rdbFunction_CheckedChanged);
            // 
            // btnPublish
            // 
            this.btnPublish.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPublish.Enabled = false;
            this.btnPublish.Location = new System.Drawing.Point(544, 13);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(94, 55);
            this.btnPublish.TabIndex = 2;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbFunction);
            this.groupBox1.Controls.Add(this.rdbFeature);
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 65);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // pnItems
            // 
            this.pnItems.AutoScroll = true;
            this.pnItems.Location = new System.Drawing.Point(12, 73);
            this.pnItems.Name = "pnItems";
            this.pnItems.Size = new System.Drawing.Size(626, 365);
            this.pnItems.TabIndex = 4;
            // 
            // frmPublishForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.pnItems);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPublish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPublishForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Publish";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbFeature;
        private System.Windows.Forms.RadioButton rdbFunction;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnItems;
    }
}
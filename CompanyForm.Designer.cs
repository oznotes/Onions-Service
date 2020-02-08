namespace Onions
{
    partial class CompanyForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmpAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmpPhoneNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmpLogo = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please update your company details , This information will be used to interact wi" +
    "th your customers.";
            // 
            // cmpName
            // 
            this.cmpName.Location = new System.Drawing.Point(253, 18);
            this.cmpName.Name = "cmpName";
            this.cmpName.Size = new System.Drawing.Size(240, 20);
            this.cmpName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address :";
            // 
            // cmpAddress
            // 
            this.cmpAddress.Location = new System.Drawing.Point(253, 44);
            this.cmpAddress.Multiline = true;
            this.cmpAddress.Name = "cmpAddress";
            this.cmpAddress.Size = new System.Drawing.Size(240, 54);
            this.cmpAddress.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Phone :";
            // 
            // cmpPhoneNumber
            // 
            this.cmpPhoneNumber.Location = new System.Drawing.Point(253, 104);
            this.cmpPhoneNumber.Name = "cmpPhoneNumber";
            this.cmpPhoneNumber.Size = new System.Drawing.Size(240, 20);
            this.cmpPhoneNumber.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Logo :";
            // 
            // cmpLogo
            // 
            this.cmpLogo.Location = new System.Drawing.Point(253, 130);
            this.cmpLogo.Name = "cmpLogo";
            this.cmpLogo.Size = new System.Drawing.Size(240, 20);
            this.cmpLogo.TabIndex = 7;
            this.cmpLogo.Text = "Double click to select";
            this.cmpLogo.DoubleClick += new System.EventHandler(this.cmpLogo_DoubleClick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(510, 18);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 132);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.toolStripMenuItem1.Text = "Unlock";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 120);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // CompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 197);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmpLogo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmpPhoneNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmpAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmpName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CompanyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Company Details";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.CompanyForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompanyForm_FormClosing);
            this.Load += new System.EventHandler(this.CompanyForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CompanyForm_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cmpName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cmpAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cmpPhoneNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cmpLogo;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
namespace Onions
{
    partial class HeadForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadForm));
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Add_device_btn = new System.Windows.Forms.Button();
            this.Home_form_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginBox = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SettingsBox = new System.Windows.Forms.GroupBox();
            this.SettingsOK = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.NotificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.LoginBox.SuspendLayout();
            this.SettingsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.Image = global::Onions.Properties.Resources.icons8_user_32;
            this.button5.Location = new System.Drawing.Point(126, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(32, 32);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.AccountsButtonClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::Onions.Properties.Resources.icons8_settings_32;
            this.button4.Location = new System.Drawing.Point(164, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 32);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.SettingsButtonClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::Onions.Properties.Resources.icons8_code_32;
            this.button3.Location = new System.Drawing.Point(88, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(32, 32);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // Add_device_btn
            // 
            this.Add_device_btn.BackColor = System.Drawing.Color.Transparent;
            this.Add_device_btn.Image = global::Onions.Properties.Resources.icons8_plus_32;
            this.Add_device_btn.Location = new System.Drawing.Point(50, 12);
            this.Add_device_btn.Name = "Add_device_btn";
            this.Add_device_btn.Size = new System.Drawing.Size(32, 32);
            this.Add_device_btn.TabIndex = 1;
            this.Add_device_btn.UseVisualStyleBackColor = false;
            this.Add_device_btn.Click += new System.EventHandler(this.StartAddDevice);
            // 
            // Home_form_btn
            // 
            this.Home_form_btn.BackColor = System.Drawing.Color.Transparent;
            this.Home_form_btn.Image = global::Onions.Properties.Resources.icons8_home_32;
            this.Home_form_btn.Location = new System.Drawing.Point(12, 12);
            this.Home_form_btn.Name = "Home_form_btn";
            this.Home_form_btn.Size = new System.Drawing.Size(32, 32);
            this.Home_form_btn.TabIndex = 0;
            this.Home_form_btn.UseVisualStyleBackColor = false;
            this.Home_form_btn.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(12, 166);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(184, 268);
            this.dataGridView1.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Summary";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // LoginBox
            // 
            this.LoginBox.Controls.Add(this.textBox2);
            this.LoginBox.Controls.Add(this.textBox1);
            this.LoginBox.Controls.Add(this.LoginButton);
            this.LoginBox.Enabled = false;
            this.LoginBox.Location = new System.Drawing.Point(12, 50);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(184, 110);
            this.LoginBox.TabIndex = 6;
            this.LoginBox.TabStop = false;
            this.LoginBox.Text = "Login:";
            this.LoginBox.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 1;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(6, 81);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(172, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "OK";
            this.LoginButton.UseVisualStyleBackColor = true;
            // 
            // SettingsBox
            // 
            this.SettingsBox.Controls.Add(this.SettingsOK);
            this.SettingsBox.Controls.Add(this.comboBox1);
            this.SettingsBox.Enabled = false;
            this.SettingsBox.Location = new System.Drawing.Point(12, 50);
            this.SettingsBox.Name = "SettingsBox";
            this.SettingsBox.Size = new System.Drawing.Size(183, 106);
            this.SettingsBox.TabIndex = 7;
            this.SettingsBox.TabStop = false;
            this.SettingsBox.Text = "Settings";
            this.SettingsBox.Visible = false;
            // 
            // SettingsOK
            // 
            this.SettingsOK.Location = new System.Drawing.Point(6, 77);
            this.SettingsOK.Name = "SettingsOK";
            this.SettingsOK.Size = new System.Drawing.Size(170, 23);
            this.SettingsOK.TabIndex = 1;
            this.SettingsOK.Text = "OK";
            this.SettingsOK.UseVisualStyleBackColor = true;
            this.SettingsOK.Click += new System.EventHandler(this.SettingsOK_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(171, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.NotificationIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.NotificationIcon.Text = "notifyIcon1";
            this.NotificationIcon.Visible = true;
            this.NotificationIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotificationIconDoubleClick);
            // 
            // HeadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 446);
            this.Controls.Add(this.SettingsBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Add_device_btn);
            this.Controls.Add(this.Home_form_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HeadForm";
            this.Text = "Onions Service";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.HeadForm_Load);
            this.Resize += new System.EventHandler(this.HeadForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.LoginBox.ResumeLayout(false);
            this.LoginBox.PerformLayout();
            this.SettingsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Home_form_btn;
        private System.Windows.Forms.Button Add_device_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox LoginBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox SettingsBox;
        private System.Windows.Forms.Button SettingsOK;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.NotifyIcon NotificationIcon;
    }
}
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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Add_device_btn = new System.Windows.Forms.Button();
            this.Home_form_btn = new System.Windows.Forms.Button();
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
            this.Add_device_btn.Click += new System.EventHandler(this.Button2_Click);
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
            this.Home_form_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // HeadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 427);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Add_device_btn);
            this.Controls.Add(this.Home_form_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HeadForm";
            this.Text = "Onions Service";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Home_form_btn;
        private System.Windows.Forms.Button Add_device_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}
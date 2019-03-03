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
            this.Home_form_btn = new System.Windows.Forms.Button();
            this.Add_device_btn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Home_form_btn
            // 
            this.Home_form_btn.Location = new System.Drawing.Point(12, 12);
            this.Home_form_btn.Name = "Home_form_btn";
            this.Home_form_btn.Size = new System.Drawing.Size(196, 36);
            this.Home_form_btn.TabIndex = 0;
            this.Home_form_btn.Text = "Home";
            this.Home_form_btn.UseVisualStyleBackColor = true;
            this.Home_form_btn.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Add_device_btn
            // 
            this.Add_device_btn.Location = new System.Drawing.Point(214, 12);
            this.Add_device_btn.Name = "Add_device_btn";
            this.Add_device_btn.Size = new System.Drawing.Size(196, 36);
            this.Add_device_btn.TabIndex = 1;
            this.Add_device_btn.Text = "Add Device";
            this.Add_device_btn.UseVisualStyleBackColor = true;
            this.Add_device_btn.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(416, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 36);
            this.button3.TabIndex = 2;
            this.button3.Text = "Diagnostics";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(820, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 36);
            this.button4.TabIndex = 3;
            this.button4.Text = "Settings";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(618, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(196, 36);
            this.button5.TabIndex = 4;
            this.button5.Text = "empty";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // HeadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 59);
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
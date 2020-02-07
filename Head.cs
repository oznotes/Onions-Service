using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Configuration;
using System.Windows.Forms;

namespace Onions
{

    public partial class HeadForm : Form
    {
        MainForm mainForm = new MainForm();
        CompanyForm cmpForm = new CompanyForm();
        AddDeviceForm addfrm = new AddDeviceForm();

        string DevicesInService { get; set; } = "Devices in Service";
        string DevicesInCompleted { get; set; } = "Devices in Completed";
        public string stDeviceInService { get; set; }

        public HeadForm()
        {
            InitializeComponent();

            string Language = string.Empty;

            try
            {
                Language = string.Format(@".\Resources\Languages\{0}.resx", ConfigurationManager.AppSettings[WhatLanguageIsActivate.ThisLanguage].ToString());
            }
            catch { }

            try
            {
                if (!string.IsNullOrWhiteSpace(Language))
                {
                    using (ResXResourceSet x = new ResXResourceSet(Language))
                    {                       
                        DevicesInService = x.GetString("DevicesInService");
                        DevicesInCompleted = x.GetString("DevicesInCompleted");
                        dataGridView1.Columns["Column1"].HeaderText = x.GetString("Summary");
                        SettingsBox.Text = x.GetString("Setting");
                    }
                }
            }
            catch { }

            mainForm.Show();
            dataGridView1.RowHeadersVisible = false;
            WhatsMyStatus(mainForm.DevicesInService, mainForm.CompletedDevices);
        }
               
        public void WhatsMyStatus(int Service, int Completed)
        { 
            if (dataGridView1.RowCount > 0)
                dataGridView1.Rows.Clear();

            dataGridView1.Rows.Add(string.Format("  {0} {1}", Service, DevicesInService));
            dataGridView1.Rows.Add(string.Format("  {0} {1}", Completed, DevicesInCompleted));
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {

        }

        private void StartAddDevice(object sender, EventArgs e)
        {
            if (!addfrm.Visible)
            {
                addfrm.ShowDialog();
            }
            else
            {
                addfrm.BringToFront();
            }
        }

        private void AccountsButtonClick(object sender, EventArgs e)
        {
            if (SettingsBox.Visible)
            {
                SettingsBox.Visible = false;
                SettingsBox.Enabled = false;
            }
            LoginBox.Visible = true;
            LoginBox.Enabled = true;
        }

        private void SettingsButtonClick(object sender, EventArgs e)
        {
            if (LoginBox.Visible)
            {
                LoginBox.Visible = false;
                LoginBox.Enabled = false;
            }
            SettingsBox.Visible = true;
            SettingsBox.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            Point Loc = this.Location;
            Loc.X += 230;

            if (!MainFormVisible.IsVisible)
            {
                MainForm mainForm = new MainForm
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = Loc,
                };
                mainForm.Show();
                MainFormVisible.IsVisible = true;
            }
            else
            {
                mainForm.BringToFront();
            }
        }

        private void HeadForm_Load(object sender, EventArgs e)
        {
            var AvailableLanguages = ConfigurationManager.AppSettings;

            if (AvailableLanguages.Count != 0)
            {
                foreach (var key in AvailableLanguages.AllKeys)
                {
                    comboBox1.Items.Add(key);
                }
            }
            else
            {

            }
            if (CorporateDetails.ThisCompany.Length!=0)
            {
                var companyRegistered = CorporateDetails.ThisCompany.Split('\n');
                label1.Text = companyRegistered[0];
                //label1.Enabled = false;
            }

            this.WindowState  = FormWindowState.Minimized;
            this.Visible = false;
            this.ShowInTaskbar = false;

        }

        private void SettingsOK_Click(object sender, EventArgs e)
        {
            // check if same language no need to restart .
            if (comboBox1.SelectedItem.ToString() != WhatLanguageIsActivate.ThisLanguage)
            {
                DialogResult dialogResult = MessageBox.Show("Software must restart for these changes to take effect or you can choose 'NO' to take effect in your next start", "Restart for Language Update", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    WhatLanguageIsActivate.ThisLanguage = comboBox1.SelectedItem.ToString();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    WhatLanguageIsActivate.ThisLanguage = comboBox1.SelectedItem.ToString();
                }
                else if (dialogResult == DialogResult.Cancel)
                {

                }
            }
            else
            {

            }
        }

        private void HeadForm_Resize(object sender, EventArgs e)
        {
            NotificationIcon.BalloonTipTitle = "Onions";
            NotificationIcon.BalloonTipText = "Service Database is working";
            if (FormWindowState.Minimized == this.WindowState)
            {
                NotificationIcon.Visible = true;
                NotificationIcon.ShowBalloonTip(500);
                this.ShowInTaskbar = false;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                NotificationIcon.Visible = false;
            }
        }

        private void NotificationIconDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            // Back in game
            WhatsMyStatus(mainForm.DevicesInService, mainForm.CompletedDevices);
            if (CorporateDetails.ThisCompany.Length != 0)
            {
                var companyRegistered = CorporateDetails.ThisCompany.Split('\n');
                label1.Text = companyRegistered[0];
                //label1.Enabled = false;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // fill the form save the company .
        }

        private void HeadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationIcon.Visible = false;
            NotificationIcon.Dispose();
        }

        private void HeadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            NotificationIcon.Visible = false;
            NotificationIcon.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            cmpForm.ShowDialog();
        }

        private void HeadForm_Activated(object sender, EventArgs e)
        {
            TopMost = true;
        }
    }
}

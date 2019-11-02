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

            //Languages Spanish

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

            if (AvailableLanguages.Count == 0)
            {

            }
            else
            {
                foreach (var key in AvailableLanguages.AllKeys)
                {
                    comboBox1.Items.Add(key);
                }
            }
        }

        private void SettingsOK_Click(object sender, EventArgs e)
        {
            // check if same language no need to restart .
            if (comboBox1.SelectedItem.ToString() != WhatLanguageIsActivate.ThisLanguage)
            {
                WhatLanguageIsActivate.ThisLanguage = comboBox1.SelectedItem.ToString();
                // yes No .
                System.Diagnostics.Process.Start(Application.ExecutablePath);
                this.Close();

            }
            else
            {
                // return safe .

            }


        }
    }
}

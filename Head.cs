using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Device;


namespace Onions
{

    public partial class HeadForm : Form
    {

        MainForm mainfrm = new MainForm();
        AddDeviceForm addfrm = new AddDeviceForm();


        public HeadForm()
        {
            InitializeComponent();
            //label1.Text = ;
            //label2.Text = string.Format("{0} Devices Completed", mainfrm.CompletedDevices.ToString());
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Rows.Add(string.Format("  {0} Devices in Service", mainfrm.DevicesInService.ToString()));
            dataGridView1.Rows.Add(string.Format("  {0} Devices in Completed", mainfrm.CompletedDevices.ToString()));

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            Point Loc = this.Location;
            Loc.Y = Loc.Y + 100;

            if (mainfrm.Visible==true)
            {
                mainfrm.StartPosition = FormStartPosition.Manual;
                mainfrm.Location = Loc;
                mainfrm.ShowDialog();
            }
            else
            {
                mainfrm.BringToFront();
            }
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (SettingsBox.Visible)
            {
                SettingsBox.Visible = false;
                SettingsBox.Enabled = false;
            }
            LoginBox.Visible = true;
            LoginBox.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
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
            mainfrm.Visible = true;
        }
    }
}

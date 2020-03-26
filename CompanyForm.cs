using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Onions
{
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
        }

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            if (CorporateDetails.ThisCompany.Length != 0)
            {
                var CompanyDetails = CorporateDetails.ThisCompany.Split('\n');
                cmpName.Text = CompanyDetails[0];
                cmpAddress.Text = CompanyDetails[1];
                cmpPhoneNumber.Text = CompanyDetails[2];
                cmpLogo.Text = CompanyDetails[3];
                try
                {
                    Bitmap img = new Bitmap(CompanyDetails[3]);
                    var imageHeight = img.Height;
                    var imageWidth = img.Width;
                    if (imageHeight > 128)
                    {
                        pictureBox1.Image = img;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        pictureBox1.Image = img;
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                }
                catch (Exception ex)
                {
                    cmpLogo.ForeColor = Color.OrangeRed;
                    cmpLogo.Text = "Double Click to select the Logo";
                    Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    using (Graphics g = Graphics.FromImage(bm))
                    {
                        using (SolidBrush myBrush = new SolidBrush(Color.Black))
                        {
                            using (Font myFont = new Font("Arial", 14))
                            {
                                g.DrawString("Company \n Logo.", myFont, myBrush, 10, 10);
                                pictureBox1.Image = bm;
                            }
                        }
                    }

                    string message = "Load picture error\nMessage : " + ex.ToString();
                    string title = "Error Message: ";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    return;
                }
                cmpLogo.ForeColor = Color.Black;
                DisableFormItems();
            }
        }

        private bool ValidateFields()
        {
            var controls = new[]
            {
                cmpName,
                cmpAddress,
                cmpPhoneNumber,
                cmpLogo,
            };

            foreach (var control in controls.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                ShakeIT(control);
                return false;
            }
            return true;
        }

        private void ShakeIT(TextBox control)
        {
            for (int i = 0; i < 8; i++)
            {
                Point one = new Point(control.Location.X + 3, control.Location.Y);
                control.Location = one;
                control.Update();
                System.Threading.Thread.Sleep(25);
                Point two = new Point(control.Location.X - 6, control.Location.Y);
                control.Location = two;
                control.Update();
                System.Threading.Thread.Sleep(25);
                Point three = new Point(control.Location.X + 3, control.Location.Y);
                control.Location = three;
                control.Update();
                System.Threading.Thread.Sleep(25);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
            }
            else
            {
                var CompanyDetails = cmpName.Text + '\n' + cmpAddress.Text + '\n' + cmpPhoneNumber.Text + '\n' + cmpLogo.Text;
                CorporateDetails.ThisCompany = CompanyDetails;
                DisableFormItems();
                this.Hide();
            }
        }

        private void cmpLogo_DoubleClick(object sender, EventArgs e)
        {
            cmpLogo.Text = "";
            openFileDialog1.Filter = "Picture (*.jpg)| *.jpg; |Image File (*.png) | *.png; |All files(*.*) | *.*";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Select your company Logo or icon";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);
                string destFile = AppDomain.CurrentDomain.BaseDirectory + openFileDialog1.SafeFileName;
                if (openFileDialog1.FileName.Length != 0)
                {
                    try
                    {
                        Bitmap img = new Bitmap(openFileDialog1.FileName);
                        var imageHeight = img.Height;
                        var imageWidth = img.Width;
                        if (imageHeight > 128)
                        {
                            pictureBox1.Image = img;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            pictureBox1.Image = img;
                            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                        }
                        File.Copy(openFileDialog1.FileName, destFile, true);
                        cmpLogo.Text = destFile;
                    }
                    catch (Exception ex)
                    {
                        cmpLogo.ForeColor = Color.OrangeRed;
                        cmpLogo.Text = "Double Click to select the Logo";
                        string message = "Load picture error\nMessage : " + ex.ToString();
                        string title = "Error Message: ";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;

                        MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    // no file selected so ?
                }
            }
            else
            {
                ShakeIT(cmpLogo);
                Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(bm))
                {
                    using (SolidBrush myBrush = new SolidBrush(Color.Black))
                    {
                        using (Font myFont = new Font("Arial", 14))
                        {
                            g.DrawString("Company \n Logo.", myFont, myBrush, 10, 10);
                            pictureBox1.Image = bm;
                        }
                    }
                }
            }

            cmpLogo.ForeColor = Color.Black;
        }

        private void CompanyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void EnableFormItems()
        {
            saveButton.Visible = true;
            saveButton.Enabled = true;
            cmpLogo.Enabled = true;
            cmpAddress.Enabled = true;
            cmpName.Enabled = true;
            cmpPhoneNumber.Enabled = true;
            label1.Text = "" +
                "Please update your company details , " +
                "This information will be used to interact with your customers." +
                "";
        }

        private void DisableFormItems()
        {
            saveButton.Visible = false;
            saveButton.Enabled = false;
            cmpLogo.Enabled = false;
            cmpAddress.Enabled = false;
            cmpName.Enabled = false;
            cmpPhoneNumber.Enabled = false;
            label1.Text = "                          " +
                "If you want to change please right click and Unlock" +
                "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EnableFormItems();
        }

        private void CompanyForm_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        contextMenuStrip1.Show(this, new Point(e.X, e.Y));
                    }
                    break;
            }
        }

        private void CompanyForm_Activated(object sender, EventArgs e)
        {
            if (CorporateDetails.ThisCompany.Length != 0)
            {
                var CompanyDetails = CorporateDetails.ThisCompany.Split('\n');
                try
                {
                    //think about some even and connect this event...
                    //cmpName.Text = CompanyDetails[0];
                    //cmpAddress.Text = CompanyDetails[1];
                    //cmpPhoneNumber.Text = CompanyDetails[2];
                    //cmpLogo.Text = CompanyDetails[3];
                    //pictureBox1.ImageLocation = CompanyDetails[3];
                    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    string message = "Company Details Error.\nMessage : " + ex.ToString();
                    string title = "Error Message: ";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;

                    MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    return;
                }

                //DisableFormItems();
            }
        }
    }
}
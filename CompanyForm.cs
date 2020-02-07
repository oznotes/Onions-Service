﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                DisableFormItems();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var CompanyDetails =  cmpName.Text + '\n' + cmpAddress.Text + '\n' + cmpPhoneNumber.Text + '\n' + cmpLogo.Text;
            
            //checked the form elements

            CorporateDetails.ThisCompany = CompanyDetails;
            DisableFormItems();
            this.Hide();
        }

        private void cmpLogo_DoubleClick(object sender, EventArgs e)
        {
            cmpLogo.Text = "";
            openFileDialog1.Filter = "Picture (*.jpg)| *.jpg; |Image File (*.png) | *.png; |All files(*.*) | *.*";
            openFileDialog1.FileName = "";
            openFileDialog1.Title  = "Select your company Logo or icon";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);
                cmpLogo.Text = openFileDialog1.FileName;
                Bitmap img = new Bitmap(openFileDialog1.FileName);
                var imageHeight = img.Height;
                var imageWidth = img.Width;
                if (imageHeight>128)
                {
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    pictureBox1.Image = img;
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                Console.WriteLine(imageHeight.ToString());
                Console.WriteLine(imageWidth.ToString());
            }
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
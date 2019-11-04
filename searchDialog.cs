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
    public partial class searchDialog : Form
    {
        public searchDialog()
        {
            InitializeComponent();
            SearchDialogVisible.IsThisVisible = true;
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
                        this.Text = x.GetString("Search");                       
                    }
                }
            }
            catch { }
        }

        private void searchDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            SearchDialogVisible.IsThisVisible = false;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Escape)
            {
                MainForm frmMainForm = (MainForm)Application.OpenForms["MainForm"];
                frmMainForm.SearchByKeyStroke(textBox1.Text);
            }
            else
                Close();
        }
    }
}

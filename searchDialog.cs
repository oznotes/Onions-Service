using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onions
{
    public partial class searchDialog : Form
    {
        public searchDialog()
        {
            InitializeComponent();
            SearchDialogVisible.IsThisVisible = true;
        }

        private void searchDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            SearchDialogVisible.IsThisVisible = false;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                MainForm frmMainForm = (MainForm)Application.OpenForms["MainForm"];
                frmMainForm.SearchByKeyStroke(textBox1.Text);
            }
            else
                Close();
        }
    }
}

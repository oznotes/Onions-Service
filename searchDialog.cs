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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // each key event part of search ..
            // pre enter will hide
        }
    }
}

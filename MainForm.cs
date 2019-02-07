using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Device
{
    public partial class MainForm : Form
    {
        int Row_N;
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Onions Service Database - Home";
            if (File.Exists("devices.dat"))
                loadContacts("devices.dat");
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddDeviceForm addContactForm = new AddDeviceForm();
            addContactForm.ShowDialog();
            loadContacts("devices.dat");
        }

        /// <summary>
        /// Load from devices.dat to -> Data Grid View 
        /// </summary>
        private void loadContacts(string datasource)
        {
    
            string[] contacts = File.ReadAllLines(datasource);
            
            if (contacts.Length!=0)
            {
                dataGridView.Rows.Clear();
                foreach (string contact in contacts)
                {
                    string[] contactInfo = contact.Split('|');
                    dataGridView.Rows.Add(contactInfo);
                }
           
            }
            else
            {
                MessageBox.Show("No Data Found!");
            }

        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            remove_selected();
        }

        public void remove_selected()
        {
            string contactFileData = String.Empty; //These are all the new contacts
            string[] contacts = File.ReadAllLines("devices.dat"); //These are all the old contacts
            if (contacts.Length !=0 )
            {
                int index = dataGridView.SelectedRows[0].Index; //Gets the index of the deleted row
                for (int i = 0; i < contacts.Count(); i++) 
                {
                    if (index != i)
                        contactFileData += contacts[i] + System.Environment.NewLine;
                }
                File.WriteAllText("devices.dat", contactFileData); //Saves the contact file without the removed contact
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);// get the first line back again .

            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            
        }

        public void complete_selected(string cell)

        {
            string contactFileData = String.Empty; //These are all the new contacts
            string[] contacts = File.ReadAllLines("devices.dat"); //These are all the old contacts
            if (contacts.Length != 0)
            {
                int index = dataGridView.SelectedRows[0].Index; //Gets the index of the deleted row
                for (int i = 0; i < contacts.Count(); i++) // Line
                {
                    if (index == i)
                        contactFileData += contacts[i] + "|" + cell + System.Environment.NewLine;
                }
                File.AppendAllText("completed.dat", contactFileData); //Saves the contact file without the removed contact
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);// get the first line back again 
            }
            else
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void toolStripButtonCompleted_Click(object sender, EventArgs e)
        {
            // show another for with data gridview
            loadContacts("completed.dat");
            this.Text = "Onions Service Database - Completed JOBS";
            toolStripCompleteJOB.Enabled = false;
            toolStripButtonRemove.Enabled = false;
            toolStripButtonCompleted.Enabled = false;
            
        }

        private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {   //Update the ROW ID with the mouse event 

            int column = dataGridView.CurrentCell.ColumnIndex;
            Row_N = dataGridView.CurrentCell.RowIndex;
        }

        private void toolStripCompleteJOB_Click(object sender, EventArgs e)
        {
            // we are checking checked items to complete.
            // Row_N is from selected item
            // Check for price availability 
            int countColumn = dataGridView.ColumnCount;
            int countROW = dataGridView.RowCount;
            string data;
            List<string> CompletedDevices = new List<string>(); // we will save to another database
            for (int i = 0; i < countColumn; i++)
            {
                data = (string)dataGridView[i, Row_N].Value;
                CompletedDevices.Add(data);
            }
            //************************************
            //Debug Purpose 
            //Console.WriteLine(CompletedDevices[8]);
            //Console.WriteLine(string.Join("\t", CompletedDevices.Cast<string>().ToArray()));
            //***********************************
            complete_selected(CompletedDevices[8]);
            remove_selected();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Home.
            loadContacts("devices.dat");
            toolStripCompleteJOB.Enabled = true;
            toolStripButtonRemove.Enabled = true;
            toolStripButtonCompleted.Enabled = true;

            this.Text = "Onions Service Database - Home";
        }
    }
}
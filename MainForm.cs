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
            MainSetup();

        }
        public void MainSetup()

        {
            this.Text = "Onions Service Database - Home";
            if (File.Exists("devices.dat"))
            {
                loadContacts("devices.dat");

            }
            else
            {
                MessageBox.Show("No Data Found");
                toolStripCompleteJOB.Enabled = false;
                toolStripButtonRemove.Enabled = false;
            }
            if (File.Exists("completed.dat"))
            {
                toolStripButtonCompleted.Enabled = true;

            }
            else
            {
                toolStripButtonCompleted.Enabled = false;
            }
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
            string[] contacts;
            if (File.Exists(datasource))
            {
                toolStripCompleteJOB.Enabled = true;
                toolStripButtonRemove.Enabled = true;
                
                contacts = File.ReadAllLines(datasource);
                if (contacts.Length != 0)
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
                    dataGridView.Rows.Clear();
                    dataGridView.Refresh();
                }
            }
            else
            {
                MessageBox.Show("No File Found!");

                dataGridView.Rows.Clear();
                dataGridView.Refresh();
                toolStripCompleteJOB.Enabled = false;
                toolStripButtonRemove.Enabled = false;

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
            string CompletedDevices = String.Empty; //These are all the new contacts
            string PendingDevices = String.Empty;
            string[] device = File.ReadAllLines("devices.dat"); //These are all the old contacts
            if (device.Length != 0)
            {
                int index = dataGridView.SelectedRows[0].Index; //Gets the index of the deleted row
                for (int i = 0; i < device.Count(); i++) // Line
                {
                    if (index == i)
                    {
                        CompletedDevices += device[i] + "|" + cell + System.Environment.NewLine;
                    }
                    else
                    {
                        PendingDevices += device[i] + System.Environment.NewLine;
                    }
                }
                File.AppendAllText("completed.dat", CompletedDevices); //Saves the completed.dat file with completed device.
                File.WriteAllText("devices.dat", PendingDevices); //Saves the devices.dat file after removed device.
                dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);// get the first line back again .

            }
            else
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void toolStripButtonCompleted_Click(object sender, EventArgs e)
        {
            // show another for with data gridview

            this.Text = "Onions Service Database - Completed JOBS";
            loadContacts("completed.dat");
            
            // group  disabled.
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
            //Console.WriteLine(CompletedDevices[9]);
            //Console.WriteLine(string.Join("\t", CompletedDevices.Cast<string>().ToArray()));
            //***********************************
            complete_selected(CompletedDevices[9]);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Home.
            loadContacts("devices.dat");
            this.Text = "Onions Service Database - Home";
            MainSetup();

        }

    }
}
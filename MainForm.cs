using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Onions
{

    public partial class MainForm : Form
    {
        public int DevicesInService
        {
            get { return GiveMeTheCount("devices"); }
        }

        public int CompletedDevices
        {
            get { return GiveMeTheCount("completed"); }
        }

        public MainForm()
        {
            InitializeComponent();
            MainSetup();
            // deleted out all the binding code of the grid to focus on the interesting stuff

            dataGridView.CellEndEdit += new DataGridViewCellEventHandler(DataGridView_CellEndEdit);

            // Use the DataBindingComplete event to attack the SelectionChanged, 
            // avoiding infinite loops and other nastiness.
            dataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridView_DataBindingComplete);            
        }

        public void MainSetup()
        {

            this.Text = "Onions Service Database - Home";
            LoadContacts("devices");

            //Check if record in state completed
            if (CheckForRecordCompleted("completed"))
                toolStripButtonCompleted.Enabled = true;
            else
                toolStripButtonCompleted.Enabled = false;

        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddDeviceForm addContactForm = new AddDeviceForm();
            addContactForm.ShowDialog();
            LoadContacts("devices");
            UpdateHeadStatus();
        }

        /// <summary>
        /// Load from SQLite to -> Data Grid View 
        /// </summary>
        private void LoadContacts(string datasource)
        {
            try
            {
                //Query to customers table
                string SelectCustomer = string.Format("SELECT IdCustomer, CreationDate AS 'Date in Service', FirstName,LastName, PhoneNumber, Email AS 'e-Mail', Brand, Model, IMEI, Problem, Price,UpdateDate AS 'Update Date' FROM Customer WHERE Status = '{0}'", datasource);
                //Run query
                SQLiteDataAdapter objDa = new SQLiteDataAdapter(DatabaseAccess.fnSetConexion(SelectCustomer));
                //Hire will be data
                DataTable dtCustomer = new DataTable();
                //Fill with data
                objDa.Fill(dtCustomer);
                //bind to dataGridView
                dataGridView.DataSource = dtCustomer;
                //check if dataGridView has rows
                if (dataGridView.RowCount > 0)
                {
                    toolStripCompleteJOB.Enabled = true;
                    toolStripButtonRemove.Enabled = true;
                }
                else
                {
                    //MessageBox.Show("No Data Found!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toolStripCompleteJOB.Enabled = false;
                    toolStripButtonRemove.Enabled = false;
                }
                //Format grid
                fnconfigDGV();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, "Select Customers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                toolStripCompleteJOB.Enabled = false;
                toolStripButtonRemove.Enabled = false;
                toolStripButtonAdd.Enabled = false;
            }
            

        }

        /// <summary>
        /// Check for records in state Completed or Device
        /// </summary>
        /// <param name="datasource">state Completed | Device</param>
        /// <returns></returns>
        private bool CheckForRecordCompleted(string datasource)
        {
            try
            {
                //Query to customers table
                string SelectCustomer = string.Format("SELECT IdCustomer FROM Customer WHERE Status = '{0}'", datasource);
                //Run query
                SQLiteDataAdapter objDa = new SQLiteDataAdapter(DatabaseAccess.fnSetConexion(SelectCustomer));
                //Hire will be data
                DataTable dtCustomer = new DataTable();
                //Fill with data
                objDa.Fill(dtCustomer);
                //check if datatable has rows, if has, enable buttons
                if (dtCustomer.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, "Select Customers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }

        private void ToolStripButtonRemove_Click(object sender, EventArgs e)
        {
            Remove_selected();
        }

        public void Remove_selected()
        {
            try
            {
                //Get selected row
                DataGridViewRow Row = dataGridView.SelectedRows[0];
                //Get Id Customer by IdCustomer column
                int.TryParse(Row.Cells["IdCustomer"].Value.ToString(), out int IdCustomer);

                if (IdCustomer > 0)
                {
                    //Sql delete sentence
                    string DeleteCustomer = string.Format("DELETE FROM Customer WHERE IdCustomer = {0}", IdCustomer);
                    //Run Sentense
                    DatabaseAccess.fnSetConexion(DeleteCustomer).ExecuteNonQuery();
                }
                else
                    MessageBox.Show("No Customer Selected", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadContacts("devices");
        }

        public void Complete_selected()
        {
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            //Get selected row
            DataGridViewRow Row = dataGridView.SelectedRows[0];
            int Price = 0;
            //Get Id Customer by IdCustomer column
            int.TryParse(Row.Cells["IdCustomer"].Value.ToString(), out int IdCustomer);
            //Check if IdCustomer is.
            if (IdCustomer == 0)
                MessageBox.Show("No Customer Selected", "Completed Job", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            // Check the price cell if its stable .
            try
            {
                //Get Price
                Price = int.Parse(Row.Cells["Price"].Value.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter Price in numbers !", "Completed Job", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Enter Price information !", "Completed Job", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Update Customer sentence
            string UpdateCustomer = string.Format("UPDATE Customer SET Price = {0}, Status = '{1}', UpdateDate = '{2}' WHERE IdCustomer = {3}", Price, "completed", today,IdCustomer);

            //run sentence
            DatabaseAccess.fnSetConexion(UpdateCustomer).ExecuteNonQuery();           
        }

        private void ToolStripButtonCompleted_Click(object sender, EventArgs e)
        {
            // show another for with data gridview

            this.Text = "Onions Service Database - Completed JOBS";
            LoadContacts("completed");

            // group  disabled.
            toolStripCompleteJOB.Enabled = false;
            toolStripButtonRemove.Enabled = false;
            toolStripButtonCompleted.Enabled = false;
        }

        private void DataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {   

        }

        private void ToolStripCompleteJOB_Click(object sender, EventArgs e)
        {           
            Complete_selected();
            MainSetup();
            UpdateHeadStatus();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            this.Text = "Onions Service Database - Home";
            MainSetup();
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //resetRow = true;
            //currentRow = e.RowIndex;
        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dataGridView.SelectionChanged += new EventHandler(dataGridView_SelectionChanged);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }

        void fnconfigDGV()
        {
            dataGridView.Columns["Date in Service"].Width = 110;
            dataGridView.Columns["IdCustomer"].Visible = false;
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //No More Double Click
            //Make edit event.
        }

        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                dataGridView.Rows[e.RowIndex].Selected = true;               
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            }
        }
       

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dataGridView.SelectedRows[0];

            /// edit mode 

            AddDeviceForm addContactForm = new AddDeviceForm
            {
                TextBoxName = Row.Cells["FirstName"].Value.ToString(),
                TextBoxLastName = Row.Cells["LastName"].Value.ToString(),
                TextBoxPhoneNumber = Row.Cells["PhoneNumber"].Value.ToString(),
                TextBoxeMail = Row.Cells["e-Mail"].Value.ToString(),
                TextBoxBrand = Row.Cells["Brand"].Value.ToString(),
                TextBoxModel = Row.Cells["Model"].Value.ToString(),
                TextBoxIMEI = Row.Cells["IMEI"].Value.ToString(),
                TextBoxProblem = Row.Cells["Problem"].Value.ToString(),
                TextBoxPrice = Row.Cells["Price"].Value.ToString(),

                CustomerID = int.Parse(Row.Cells["IdCustomer"].Value.ToString())
            };
            addContactForm.EditMode(true);
            // send ID.

            addContactForm.ShowDialog();

            LoadContacts("devices");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Onions.HeadForm headform = new Onions.HeadForm();
            //headform.Show();         
        }

        private int GiveMeTheCount(string datasource)

        {
            //Query to customers table
            string SelectCustomer = string.Format("SELECT IdCustomer FROM Customer WHERE Status = '{0}'", datasource);
            //Run query
            SQLiteDataAdapter objDa = new SQLiteDataAdapter(DatabaseAccess.fnSetConexion(SelectCustomer));
            //Hire will be data
            DataTable dtCustomer = new DataTable();
            //Fill with data
            objDa.Fill(dtCustomer);
            Int32 count = dtCustomer.Rows.Count;
            return count;
        }

        void UpdateHeadStatus()
        {
            HeadForm headForm = (HeadForm)Application.OpenForms["HeadForm"];
            headForm.WhatsMyStatus(DevicesInService, CompletedDevices);
        }

    }
}
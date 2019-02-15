using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Device
{
    public partial class MainForm : Form
    { 
        public MainForm()
        {
            InitializeComponent();
            MainSetup();
            // deleted out all the binding code of the grid to focus on the interesting stuff

            dataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView_CellEndEdit);

            // Use the DataBindingComplete event to attack the SelectionChanged, 
            // avoiding infinite loops and other nastiness.
            dataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView_DataBindingComplete);
        }

        public void MainSetup()
        {
            this.Text = "Onions Service Database - Home";
            loadContacts("devices");

            //Check if record in state completed
            if (CheckForRecordCompleted("completed"))
                toolStripButtonCompleted.Enabled = true;
            else
                toolStripButtonCompleted.Enabled = false;
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            AddDeviceForm addContactForm = new AddDeviceForm();
            addContactForm.ShowDialog();
            loadContacts("devices");
        }

        /// <summary>
        /// Load from SQLite to -> Data Grid View 
        /// </summary>
        private void loadContacts(string datasource)
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
                    MessageBox.Show("No Data Found!", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    toolStripCompleteJOB.Enabled = false;
                    toolStripButtonRemove.Enabled = false;
                }
                //Format grid
                fnconfigDGV();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, "Select Customers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            remove_selected();
        }

        public void remove_selected()
        {
            try
            {
                //Get selected row
                DataGridViewRow Row = dataGridView.SelectedRows[0];
                int IdCustomer = 0;
                //Get Id Customer by IdCustomer column
                int.TryParse(Row.Cells["IdCustomer"].Value.ToString(), out IdCustomer);

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

            loadContacts("devices");
        }

        public void complete_selected()
        {
            string today = DateTime.Today.ToString("dd/MM/yyyy");
            //Get selected row
            DataGridViewRow Row = dataGridView.SelectedRows[0];
            int IdCustomer = 0;
            int Price = 0;
            //Get Id Customer by IdCustomer column
            int.TryParse(Row.Cells["IdCustomer"].Value.ToString(), out IdCustomer);
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

        private void toolStripButtonCompleted_Click(object sender, EventArgs e)
        {
            // show another for with data gridview

            this.Text = "Onions Service Database - Completed JOBS";
            loadContacts("completed");

            // group  disabled.
            toolStripCompleteJOB.Enabled = false;
            toolStripButtonRemove.Enabled = false;
            toolStripButtonCompleted.Enabled = false;
        }

        private void dataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {   //Update the ROW ID with the mouse event 
            //int column = dataGridView.CurrentCell.ColumnIndex;
            //Row_N = dataGridView.CurrentCell.RowIndex;
        }

        private void toolStripCompleteJOB_Click(object sender, EventArgs e)
        {           
            complete_selected();
            MainSetup();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Home.           
            this.Text = "Onions Service Database - Home";
            MainSetup();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //resetRow = true;
            //currentRow = e.RowIndex;
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dataGridView.SelectionChanged += new EventHandler(dataGridView_SelectionChanged);
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //if (resetRow)
            //{
            //    resetRow = false;
            //    dataGridView.CurrentCell = dataGridView.Rows[currentRow].Cells[0];
            //}
        }

        void fnconfigDGV()
        {
            dataGridView.Columns["Date in Service"].Width = 110;
            dataGridView.Columns["IdCustomer"].Visible = false;
        }
    }
}
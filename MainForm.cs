using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace Onions
{

    public partial class MainForm : Form
    {
        string MainFormTitle { get; set; } = "Orion Database Service";
        string SelectCustomers { get; set; } = "Select Customers";
        string NoCustomerSelected { get; set; } = "No Customer Selected";
        string DeleteCustomer { get; set; } = "Delete Customer";
        string CompletedJob { get; set; } = "Job";
        string EnterPriceNumbers { get; set; } = "Enter Price is a Number";
        string EnterPriceinformation { get; set; } = "Enter Price Information";
        string Home { get; set; } = "Home";

        string CreationDate { get; set; } = "Date in Service";
        string FirstName { get; set; } = "First Name";
        string LastName { get; set; } = "Last Name";
        string PhoneNumber { get; set; } = "PhoneNumber";       
        string Brand { get; set; } = "Brand";
        string Model { get; set; } = "Model";      
        string Problem { get; set; } = "Problem";
        string Price { get; set; } = "Price";
        string UpdateDate { get; set; } = "Update Date";

        public int DevicesInService
        {
            get { return GiveMeTheCount("devices"); }
        }

        public int CompletedDevices
        {
            get { return GiveMeTheCount("completed"); }
        }

        string searchKeyword { get; set; }


        public MainForm()
        {
            MainFormVisible.IsVisible = true;
            InitializeComponent();

            string Language = string.Empty;

            try
            {
                Language = string.Format(@".\Resources\Languages\{0}.resx", ConfigurationManager.AppSettings[WhatLanguageIsActivate.ThisLanguage].ToString());
            }
            catch { }

            //Languages Spanish

            try
            {
                if (!string.IsNullOrWhiteSpace(Language))
                {
                    using (ResXResourceSet x = new ResXResourceSet(Language))
                    {
                        toolStripHome.Text = x.GetString("Home");
                        toolStripButtonAdd.Text = x.GetString("NewRegistration");
                        toolStripButtonRemove.Text = x.GetString("DeleteSelected");
                        toolStripButtonCompleted.Text = x.GetString("Completed");                       
                        toolStripSearch.Text = x.GetString("Search");
                        toolStripCompleteJOB.Text = x.GetString("CompletedSelected");
                        MainFormTitle = x.GetString("MainFormTitle");
                        SelectCustomers = x.GetString("SelectCustomers");
                        NoCustomerSelected = x.GetString("NoCustomerSelected");
                        DeleteCustomer = x.GetString("DeleteCustomer");
                        CompletedJob = x.GetString("CompletedJob");
                        EnterPriceNumbers = x.GetString("EnterPriceNumbers");
                        EnterPriceinformation = x.GetString("EnterPriceinformation");
                        Home = x.GetString("Home");

                        CreationDate = x.GetString("CreationDate");
                        FirstName = x.GetString("FirstName");
                        LastName = x.GetString("LastName");
                        PhoneNumber = x.GetString("PhoneNumber");                      
                        Brand = x.GetString("Brand");
                        Model = x.GetString("Model");                       
                        Problem = x.GetString("Problem");
                        Price = x.GetString("Price");
                        UpdateDate = x.GetString("UpdateDate");
                    }
                }
            }
            catch { }

            MainSetup();

            this.Text = "";

            // Use the DataBindingComplete event to attack the SelectionChanged, 
            // avoiding infinite loops and other nastiness.
            dataGridView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGridView_DataBindingComplete);
        }

        public void MainSetup()
        {

            this.Text = string.Format("{0} - {1}",MainFormTitle, Home);
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
        private void LoadContacts(string datasource, string keyword = "")
        {
            try
            {
                //Query to customers table
                string SelectCustomer = string.Format("SELECT IdCustomer, CreationDate AS 'Date in Service', FirstName,LastName, PhoneNumber, Email AS 'e-Mail', Brand, Model, IMEI, Problem, Price,UpdateDate AS 'Update Date' FROM Customer WHERE Status = '{0}'", datasource);

                if(!string.IsNullOrWhiteSpace(keyword))
                {
                    SelectCustomer = string.Format("SELECT IdCustomer, CreationDate AS 'Date in Service', FirstName,LastName, PhoneNumber, Email AS 'e-Mail', Brand, Model, IMEI, Problem, Price,UpdateDate AS 'Update Date' FROM Customer WHERE Status = '{0}' AND (CreationDate LIKE '%{1}%' OR FirstName LIKE '%{1}%' OR LastName LIKE '%{1}%' OR PhoneNumber LIKE '%{1}%' OR Email LIKE '%{1}%' OR Brand LIKE '%{1}%' OR Model LIKE '%{1}%' OR IMEI LIKE '%{1}%' OR Problem LIKE '%{1}%' OR Price LIKE '%{1}%')", datasource, keyword);
                }

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

                //change Header text
                dataGridView.Columns["Date in Service"].HeaderText = CreationDate;
                dataGridView.Columns["FirstName"].HeaderText = FirstName;
                dataGridView.Columns["LastName"].HeaderText = LastName;
                dataGridView.Columns["PhoneNumber"].HeaderText = PhoneNumber;             
                dataGridView.Columns["Brand"].HeaderText = Brand;
                dataGridView.Columns["Model"].HeaderText = Model;
                dataGridView.Columns["Problem"].HeaderText = Problem;
                dataGridView.Columns["Price"].HeaderText = Price;
                dataGridView.Columns["Update Date"].HeaderText = UpdateDate;             


                //Format grid
                fnconfigDGV();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, SelectCustomers, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Error: " + Ex.Message, SelectCustomers, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show(NoCustomerSelected, DeleteCustomer, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, DeleteCustomer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(NoCustomerSelected, CompletedJob, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            // Check the price cell if its stable .
            try
            {
                //Get Price
                Price = int.Parse(Row.Cells["Price"].Value.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show(EnterPriceNumbers + " !", CompletedJob, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(EnterPriceinformation + " !", CompletedJob, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Update Customer sentence
            string UpdateCustomer = string.Format("UPDATE Customer SET Price = {0}, Status = '{1}', UpdateDate = '{2}' WHERE IdCustomer = {3}", Price, "completed", today, IdCustomer);

            //run sentence
            DatabaseAccess.fnSetConexion(UpdateCustomer).ExecuteNonQuery();
        }

        private void ToolStripButtonCompleted_Click(object sender, EventArgs e)
        {
            // show another for with data gridview

            this.Text = this.Text = string.Format("{0} - {1}", MainFormTitle, CompletedJob);
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
            this.Text = this.Text = string.Format("{0} - {1}", MainFormTitle, Home);
            MainSetup();
        }

        private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {

        }

        void fnconfigDGV()
        {
            dataGridView.Columns["Date in Service"].Width = 110;
            dataGridView.Columns["IdCustomer"].Visible = false;
        }


        private void DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainFormVisible.IsVisible = false;
            this.Dispose();
        }

        private void ToolStripSearch_Click(object sender, EventArgs e)
        {
            searchDialog searchDialogForm = new searchDialog();
            searchDialogForm.ShowDialog(this);

            // Check if grid has any data ..
            // Search 
        }

        public void SearchByKeyStroke(string letter)
        {
            searchKeyword = letter;
            txtSearchKey.Text = searchKeyword;
            LoadContacts("devices", txtSearchKey.Text);
            //MessageBox.Show(letter);
        }

        public static void SearchDialogVisibleChanged()
        {
            var OpenForms = Application.OpenForms;

            if (SearchDialogVisible.IsThisVisible == true)
            {
                OpenForms[0].Enabled = false;
            }
            else
            {
                OpenForms[0].Enabled = true;
            }

        }

    }

}
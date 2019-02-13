using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Onions;


namespace Device
{
    public partial class AddDeviceForm : Form
    {
        const string SqlInsertStament = "INSERT INTO Customer (Firstname,Lastname,PhoneNumber,Email,Brand,Model,IMEI,Problem,Status,CreationDate) VALUES ({0})";
        const string Status = "devices";

        public AddDeviceForm()
        {
            InitializeComponent();
            LoadDevices();
        }

        // Data and Static device selection list .
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string CustomerValues = String.Empty;
                string today = DateTime.Today.ToString("dd/MM/yyyy");

                CustomerValues = "'" + textBoxFirstName.Text + "'," +
                                      "'" + textBoxLastName.Text + "'," +
                                      "'" + textBoxPhoneNumber.Text + "'," +
                                      "'" + textBoxeMail.Text + "'," +
                                      "'" + textBoxDeviceBrand.Text + "'," +
                                      "'" + textBoxDeviceModel.Text + "'," +
                                      "'" + textBoxDeviceIMEI.Text + "'," +
                                      "'" + textBoxDeviceProblem.Text + "'," +
                                      "'" + Status + "'," +
                                      "'" + today + "'";

                //Create Sql Insert Command and insert the data in database
                DatabaseAccess.fnSetConexion(string.Format(SqlInsertStament, CustomerValues)).ExecuteNonQuery();
                this.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, "Create Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void textBoxDeviceModel_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxDeviceBrand.Enabled = false;
            var Response = System.IO.File.ReadAllText(string.Concat(Environment.CurrentDirectory, @"\", "Devices.json"));
            List<string> temp = new List<string>();
            var _Devices = JsonConvert.DeserializeObject<List<BRANDLIST>>(Response);

            foreach (var device in _Devices)
            {
                if (device.BRAND == textBoxDeviceBrand.Text.Trim())
                {
                    foreach (var model in device.MODELIST)
                    {
                        temp.Add(model.MODEL);
                    }
                    // add temp - > Auto Complete .
                    textBoxDeviceModel.AutoCompleteCustomSource.AddRange(temp.ToArray());
                }
            }

            textBoxDeviceBrand.Enabled = true;
        }

        private void textBoxDeviceBrand_TextChanged(object sender, EventArgs e)
        {
            textBoxDeviceModel.Text = string.Empty;
        }

        private void textBoxDeviceModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var Response = System.IO.File.ReadAllText(string.Concat(Environment.CurrentDirectory, @"\", "Devices.json"));

                var _Devices = JsonConvert.DeserializeObject<List<BRANDLIST>>(Response);

                foreach (var device in _Devices)
                {
                    if (device.BRAND == textBoxDeviceBrand.Text.Trim())
                    {
                        foreach (var model in device.MODELIST)
                        {
                           if(model.MODEL == textBoxDeviceModel.Text)
                            {
                                picDeviceModel.Load(model.URLIMAGE);
                                break;
                            }
                        }
                        break;
                    }                   
                }
            }
        }     
  
        void LoadDevices()
        {
            var Response = System.IO.File.ReadAllText(string.Concat(Environment.CurrentDirectory, @"\", "Devices.json"));

            var _Devices = JsonConvert.DeserializeObject<List<BRANDLIST>>(Response);

            foreach (var device in _Devices)
            {
                textBoxDeviceBrand.AutoCompleteCustomSource.Add(device.BRAND);
            }
        }
    }
}
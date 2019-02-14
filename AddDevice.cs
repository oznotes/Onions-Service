using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Onions;
using SharpAdbClient;


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

        public static int Mod10(string kid)
        {
            bool isOne = false;
            int controlNumber = 0;
            foreach (char number in kid.Reverse())
            {
                var intNumber = Int32.Parse(number.ToString());
                var sum = isOne ? intNumber : 2 * intNumber;
                if (sum > 9)
                {
                    sum = (sum % 10) + 1;
                }
                isOne = !isOne;
                controlNumber += sum;
            }
            return (10 - (controlNumber % 10)) % 10 == 0 ? 0 : 10 - (controlNumber % 10);
        }

        private void textBoxDeviceIMEI_TextChanged(object sender, EventArgs e)
        {

            string IMEI;
            int LuhnDigit;

            IMEI = textBoxDeviceIMEI.Text.ToString();
            if (IMEI.Length==15)
            {
                LuhnDigit = Mod10(IMEI.Substring(0,14));
                var checkDigit = Int32.Parse(IMEI[IMEI.Length - 1].ToString());
                if (LuhnDigit==checkDigit)
                {
                    label7.ForeColor = System.Drawing.Color.LimeGreen;
                }
                else
                {
                    label7.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                label7.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void textBoxDeviceIMEI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdbServer server = new AdbServer();
            //try -> check if tools exist.
            var result = server.StartServer(@"Tools\adb.exe", restartServerIfNewer: false);
            var device = AdbClient.Instance.GetDevices().First();
            var receiver = new ConsoleOutputReceiver();
            //////
            //ADB IMEI Query Samsung GT-I9507
            //adb shell content query --uri content://settings/system --where "name='bd_setting_i'" | sed 's/[^=0-9]*//g' | sed 's/[0-9]*=//g'
            //////
            //Command Set for ADB
            string imei = @"content query --uri content://settings/system --where " + '"' + "name='" + "bd_setting_i'" + '"' + " | sed '" + "s/[^=0-9]*//g' | sed 's/[0-9]*=//g'";
            string manufacturer = @"getprop ro.product.manufacturer";
            string model = @"getprop ro.product.model";

            //Instance.ExecuteRemoteCommand is adb shell -> 
            AdbClient.Instance.ExecuteRemoteCommand(manufacturer, device, receiver);
            AdbClient.Instance.ExecuteRemoteCommand(model, device, receiver);
            AdbClient.Instance.ExecuteRemoteCommand(imei, device, receiver);
            var received = receiver.ToString().ToUpper();
            List<string> s = new List<string>(received.Split(new string[] { "\n" }, StringSplitOptions.None));
            textBoxDeviceIMEI.Clear();
            textBoxDeviceBrand.Clear();
            textBoxDeviceModel.Clear();
            textBoxDeviceBrand.AppendText(s[0]);
            textBoxDeviceModel.AppendText(s[1]);
            textBoxDeviceIMEI.AppendText(s[2]);
        }
    }
}

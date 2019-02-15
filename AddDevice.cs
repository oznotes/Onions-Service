using System;
using System.Linq;
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
            circularProgressBar1.Value = 0;
            circularProgressBar1.Enabled = false;
            LoadDevices();
        }

        // Data and Static device selection list .
        private void Add_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                MessageBox.Show("Error: " + "Please Complete the Form", "Create Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
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
        }

        public bool ValidateFields()
        {
            var controls = new[] 
            {
                textBoxFirstName,
                textBoxLastName,
                textBoxPhoneNumber,
                textBoxeMail,
                textBoxDeviceBrand,
                textBoxDeviceModel,
                textBoxDeviceIMEI,
                textBoxDeviceProblem
            };

            foreach (var control in controls.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                return false;
            }
            return true;
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
                LoadPictureSequence();
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

        public void LoadPictureSequence()
        {
            var Response = System.IO.File.ReadAllText(string.Concat(Environment.CurrentDirectory, @"\", "Devices.json"));
            var _Devices = JsonConvert.DeserializeObject<List<BRANDLIST>>(Response);

            foreach (var device in _Devices)
            {
                if (device.BRAND == textBoxDeviceBrand.Text.Trim())
                {
                    foreach (var model in device.MODELIST)
                    {
                        if (model.MODEL == textBoxDeviceModel.Text)
                        {
                            try
                            {
                                // try block if no internet connection
                                picDeviceModel.Load(model.URLIMAGE);
                                break;
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                    break;
                }
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

        public void LuhnUI()
        {
            string IMEI;
            int LuhnDigit;

            IMEI = textBoxDeviceIMEI.Text.ToString();

            if (IMEI.Length == 15)
            {
                LuhnDigit = Mod10(IMEI.Substring(0, 14));
                var checkDigit = Int32.Parse(IMEI[IMEI.Length - 1].ToString());
                if (LuhnDigit == checkDigit)
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

        private void textBoxDeviceIMEI_TextChanged(object sender, EventArgs e)
        {
            LuhnUI();
        }

        private void textBoxDeviceIMEI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void ShowOFF()
        {
            for (int i = 0; i < 10000; i++)
            {
                Math.Pow(4, i);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AdbServer server = new AdbServer();
            textBoxDeviceIMEI.Clear();
            textBoxDeviceBrand.Clear();
            textBoxDeviceModel.Clear();
            circularProgressBar1.Value = 0;
            circularProgressBar1.ProgressColor1 = System.Drawing.Color.GreenYellow;
            circularProgressBar1.ProgressColor2 = System.Drawing.Color.LimeGreen;

            //try -> check if tools exist.
            if (System.IO.File.Exists(@"Tools\adb.exe"))
            {
                var result = server.StartServer(@"Tools\adb.exe", restartServerIfNewer: false);
                try
                {
                    var device = AdbClient.Instance.GetDevices().FirstOrDefault();
                    var receiver = new ConsoleOutputReceiver();
                    for (int i = 0; i < 100; i++)
                    {
                        circularProgressBar1.Value += 1;
                        circularProgressBar1.Update();
                        ShowOFF();
                    }
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

                    textBoxDeviceBrand.Text = s[0].Trim();
                    textBoxDeviceModel.Text = s[1].Trim();
                    textBoxDeviceIMEI.Text = s[2].Trim();
                    LuhnUI();

                }
                catch (System.ArgumentNullException)
                {
                    circularProgressBar1.ProgressColor1 = System.Drawing.Color.Red;
                    circularProgressBar1.ProgressColor2 = System.Drawing.Color.IndianRed;
                    circularProgressBar1.Update();
                }
            }
        }

        private void textBoxDeviceModel_TextChanged(object sender, EventArgs e)
        {
            LoadPictureSequence();
        }
    }
}
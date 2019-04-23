using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Newtonsoft.Json;
using Onions;
using SharpAdbClient;
using iMobileDevice;
using iMobileDevice.iDevice;
using iMobileDevice.Lockdown;
using iMobileDevice.Plist;


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
        // Validate form fields.
        private bool ValidateFields()
        {
            var controls = new[] 
            {
                textBoxFirstName,
                textBoxLastName,
                textBoxPhoneNumber,
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
        private void TextBoxDeviceModel_MouseClick(object sender, MouseEventArgs e)
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
        private void TextBoxDeviceBrand_TextChanged(object sender, EventArgs e)
        {
            // everytime brand is change model list is cleared .
            textBoxDeviceModel.AutoCompleteCustomSource.Clear();
            textBoxDeviceModel.Text = string.Empty;
        }
        private void TextBoxDeviceModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPictureSequence();
            }
        }
        private void LoadDevices()
        {
            var Response = System.IO.File.ReadAllText(string.Concat(Environment.CurrentDirectory, @"\", "Devices.json"));
            var _Devices = JsonConvert.DeserializeObject<List<BRANDLIST>>(Response);
            foreach (var device in _Devices)
            {
                textBoxDeviceBrand.AutoCompleteCustomSource.Add(device.BRAND);
            }
        }
        private void LoadPictureSequence()
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
        private static int Mod10(string kid)
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
        private void LuhnUI()
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
        private void TextBoxDeviceIMEI_TextChanged(object sender, EventArgs e)
        {
            LuhnUI();
        }
        private void TextBoxDeviceIMEI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ShowOFF()
        {
            for (int i = 0; i < 10000; i++)
            {
                Math.Pow(4, i);
            }
        }
        private void Failed()
        {
            circularProgressBar1.Value = 0;
            circularProgressBar1.ProgressColor1 = System.Drawing.Color.Red;
            circularProgressBar1.ProgressColor2 = System.Drawing.Color.IndianRed;
            circularProgressBar1.Update();
            for (int i = 0; i < 100; i++)
            {
                circularProgressBar1.Value += 1;
                circularProgressBar1.Update();
                ShowOFF();
            }
        }
        private bool iDeviceCheck()
        {
            circularProgressBar1.Value = 0;
            circularProgressBar1.ProgressColor1 = System.Drawing.Color.AliceBlue;
            circularProgressBar1.ProgressColor2 = System.Drawing.Color.Blue;
            circularProgressBar1.Update();
            for (int i = 0; i < 100; i++)
            {
                circularProgressBar1.Value += 1;
                circularProgressBar1.Update();
                ShowOFF();
            }
            NativeLibraries.Load();
            //ReadOnlyCollection<string> udids;
            int count = 0;

            var idevice = LibiMobileDevice.Instance.iDevice;
            var lockdown = LibiMobileDevice.Instance.Lockdown;
            var ret = idevice.idevice_get_device_list(out ReadOnlyCollection<string> udids, ref count);
            // iDevice Count == 0 
            if (count == 0)
            {
                Failed();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ADBCheck()
        {
            //try adb - not success 
            AdbServer server = new AdbServer();
            circularProgressBar1.Value = 0;
            circularProgressBar1.ProgressColor1 = System.Drawing.Color.GreenYellow;
            circularProgressBar1.ProgressColor2 = System.Drawing.Color.LimeGreen;
            for (int i = 0; i < 100; i++)
            {
                circularProgressBar1.Value += 1;
                circularProgressBar1.Update();
                ShowOFF();
            }
            //try -> check if tools exist.
            var result = server.StartServer(@"Tools\adb.exe", restartServerIfNewer: false);
            try
            {
                var mydevice = AdbClient.Instance.GetDevices().FirstOrDefault();
                var receiver = new ConsoleOutputReceiver();
                Console.WriteLine(String.IsNullOrEmpty(mydevice.ToString()));
                return true;
            }
            catch (Exception ex)
            {
                // There is no android adb device.
                if ( ex is System.ArgumentNullException || ex is System.NullReferenceException )
                {
                    // simply pass.
                }
                Failed();
                return false;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //bool DeviceFound = false;
            //int counter = 0;
            if (System.IO.File.Exists(@"Tools\adb.exe"))
            {
                if (ADBCheck() == true)
                {
                    textBoxDeviceIMEI.Clear();
                    textBoxDeviceBrand.Clear();
                    textBoxDeviceModel.Clear();

                    var device = AdbClient.Instance.GetDevices().FirstOrDefault();
                    var receiver = new ConsoleOutputReceiver();

                    //ADB IMEI Methods
                    Dictionary<int, string> imei = new Dictionary<int, string>()
                    {
                        { 1, "content query --uri content://settings/system --where " + '"' + "name='" + "bd_setting_i'" + '"' + " | sed '" + "s/[^=0-9]*//g' | sed 's/[0-9]*=//g'"},
                        { 2, "service call iphonesubinfo 1"}
                    };

                    string manufacturer = @"getprop ro.product.manufacturer";
                    string model = @"getprop ro.product.model";

                    //Instance.ExecuteRemoteCommand is adb shell -> 
                    AdbClient.Instance.ExecuteRemoteCommand(manufacturer, device, receiver);
                    AdbClient.Instance.ExecuteRemoteCommand(model, device, receiver);
                    AdbClient.Instance.ExecuteRemoteCommand(imei[1], device, receiver);

                    var received = receiver.ToString().ToUpper();
                    List<string> s = new List<string>(received.Split(new string[] { "\n" }, StringSplitOptions.None));

                    textBoxDeviceBrand.Text = s[0].Trim();
                    textBoxDeviceModel.Text = s[1].Trim();
                    try
                    {
                        // OLD Android

                        var intIMEI = Int32.Parse(s[2].Trim());
                        textBoxDeviceIMEI.Text = s[2].Trim();

                    }
                    catch (Exception)
                    {
                        // New Version Android 

                        AdbClient.Instance.ExecuteRemoteCommand(imei[2], device, receiver);
                        received = receiver.ToString().ToUpper();
                        s = new List<string>(received.Split(new string[] { "\n" }, StringSplitOptions.None));

                        string method1IMEI = ExtractIMEIfromMethod2(s);
                        if (method1IMEI!="-1")
                        {
                            textBoxDeviceIMEI.Text = method1IMEI.Trim();
                        }
                        else
                        {
                            textBoxDeviceIMEI.SelectAll();
                        }
                        
                    }

                    LuhnUI();
                }
                else
                {
                    if (iDeviceCheck())
                    {
                        Dictionary<string, string> data = new Dictionary<string, string>()
                        {
                            {"x86_64", "Simulator"},
                            {"i386", "Simulator"},
                            {"iPod1,1", "iPod Touch 1st Gen"},
                            {"iPod2,1", "iPod Touch 2nd Gen"},
                            {"iPod3,1", "iPod Touch 3rd Gen"},
                            {"iPod4,1", "iPod Touch 4th Gen"},
                            {"iPod5,1", "iPod Touch 5th Gen"},
                            {"iPod7,1", "iPod Touch 6th Gen"},
                            {"iPhone1,1", "iPhone"},
                            {"iPhone1,2", "iPhone 3G"},
                            {"iPhone2,1", "iPhone 3GS"},
                            {"iPhone3,1", "iPhone 4"},
                            {"iPhone3,2", "iPhone 4"},
                            {"iPhone3,3", "iPhone 4"},
                            {"iPhone4,1", "iPhone 4S"},
                            {"iPhone5,1", "iPhone 5 model A1428"},
                            {"iPhone5,2", "iPhone 5 model A1429"},
                            {"iPhone5,3", "iPhone 5C"},
                            {"iPhone5,4", "iPhone 5C"},
                            {"iPhone6,1", "iPhone 5S"},
                            {"iPhone6,2", "iPhone 5S"},
                            {"iPhone7,2", "iPhone 6"},
                            {"iPhone7,1", "iPhone 6 Plus"},
                            {"iPhone8,1", "iPhone 6S"},
                            {"iPhone8,2", "iPhone 6S Plus"},
                            {"iPhone8,4", "iPhone SE"},
                            {"iPhone9,1", "iPhone 7"},
                            {"iPhone9,2", "iPhone 7 Plus"},
                            {"iPhone9,3", "iPhone 7"},
                            {"iPhone9,4", "iPhone 7 Plus"},
                            {"iPhone10,1", "iPhone 8"},
                            {"iPhone10,4", "iPhone 8"},
                            {"iPhone10,2", "iPhone 8 Plus"},
                            {"iPhone10,5", "iPhone 8 Plus"},
                            {"iPhone10,3", "iPhone X"},
                            {"iPhone10,6", "iPhone X"},
                            {"iPhone11,2", "iPhone XS"},
                            {"iPhone11,4", "iPhone XS Max"},
                            {"iPhone11,6", "iPhone XS Max"},
                            {"iPhone11,8", "iPhone XR"},
                            {"iPad1,1", "iPad"},
                            {"iPad2,1", "iPad 2"},
                            {"iPad2,2", "iPad 2"},
                            {"iPad2,3", "iPad 2"},
                            {"iPad2,4", "iPad 2"},
                            {"iPad3,1", "iPad 3rd Gen"},
                            {"iPad3,2", "iPad 3rd Gen"},
                            {"iPad3,3", "iPad 3rd Gen"},
                            {"iPad3,4", "iPad 4th Gen"},
                            {"iPad3,5", "iPad 4th Gen"},
                            {"iPad3,6", "iPad 4th Gen"},
                            {"iPad4,1", "iPad Air"},
                            {"iPad4,2", "iPad Air"},
                            {"iPad4,3", "iPad Air"},
                            {"iPad2,5", "iPad Mini 1st Gen"},
                            {"iPad2,6", "iPad Mini 1st Gen"},
                            {"iPad2,7", "iPad Mini 1st Gen"},
                            {"iPad4,4", "iPad Mini 2nd Gen"},
                            {"iPad4,5", "iPad Mini 2nd Gen"},
                            {"iPad4,6", "iPad Mini 2nd Gen"},
                            {"iPad4,7", "iPad Mini 3rd Gen"},
                            {"iPad4,8", "iPad Mini 3rd Gen"},
                            {"iPad4,9", "iPad Mini 3rd Gen"},
                            {"iPad5,1", "iPad Mini 4"},
                            {"iPad5,2", "iPad Mini 4"},
                            {"iPad5,3", "iPad Air 2"},
                            {"iPad5,4", "iPad Air 2"},
                            {"iPad6,3", "iPad Pro 9.7 inch"},
                            {"iPad6,4", "iPad Pro 9.7 inch"},
                            {"iPad6,7", "iPad Pro 12.9 inch"},
                            {"iPad6,8", "iPad Pro 12.9 inch"},
                            {"iPad7,1", "iPad Pro 12.9 inch 2nd Gen"},
                            {"iPad7,2", "iPad Pro 12.9 inch 2nd Gen"},
                            {"iPad7,3", "iPad Pro 10.5 inch"},
                            {"iPad7,4", "iPad Pro 10.5 inch"},
                            {"iPad8,1", "iPad Pro 11 inch"},
                            {"iPad8,2", "iPad Pro 11 inch"},
                            {"iPad8,3", "iPad Pro 11 inch"},
                            {"iPad8,4", "iPad Pro 11 inch"},
                            {"iPad8,5", "iPad Pro 12.9 inch 3rd Gen"},
                            {"iPad8,6", "iPad Pro 12.9 inch 3rd Gen"},
                            {"iPad8,7", "iPad Pro 12.9 inch 3rd Gen"},
                            {"iPad8,8", "iPad Pro 12.9 inch 3rd Gen"}
                        };

                        textBoxDeviceIMEI.Clear();
                        textBoxDeviceBrand.Clear();
                        textBoxDeviceModel.Clear();

                        NativeLibraries.Load();

                        int count = 0;

                        var idevice = LibiMobileDevice.Instance.iDevice;
                        var lockdown = LibiMobileDevice.Instance.Lockdown;
                        var ret = idevice.idevice_get_device_list(out ReadOnlyCollection<string> udids, ref count);
                        if (ret == iDeviceError.NoDevice)
                        {
                            // Not actually an error in our case
                            return;
                        }

                        ret.ThrowOnError();

                        // Get the device name
                        foreach (var udid in udids)
                        {


                            idevice.idevice_new(out iDeviceHandle deviceHandle, udid).ThrowOnError();

                            lockdown.lockdownd_client_new_with_handshake(deviceHandle, out LockdownClientHandle lockdownHandle, "Quamotion").ThrowOnError();
                            lockdown.lockdownd_get_device_name(lockdownHandle, out string deviceName).ThrowOnError();

                            //Find serial number in plist
                            lockdown.lockdownd_get_value(lockdownHandle, null, "InternationalMobileEquipmentIdentity", out PlistHandle PlistIMEI);

                            //Find Product Type version in plist
                            lockdown.lockdownd_get_value(lockdownHandle, null, "ProductType", out PlistHandle PlistProductType);

                            //Get string values from plist
                            PlistIMEI.Api.Plist.plist_get_string_val(PlistIMEI, out string IMEI);
                            PlistProductType.Api.Plist.plist_get_string_val(PlistProductType, out string ProductType);

                            //Place data in textboxes
                            textBoxDeviceIMEI.Text = IMEI.Trim();
                            if(data.TryGetValue(ProductType.Trim(),out string FProductType))
                            {
                                textBoxDeviceBrand.Text = "APPLE";
                                textBoxDeviceModel.Text = FProductType;
                            }
                            deviceHandle.Dispose();
                            lockdownHandle.Dispose();
                        }
                    }
                }
            }
        }

        private string ExtractIMEIfromMethod2(List<string> list)
        {

            var s5 = list[5].Skip(51).Take(16);
            var s6 = list[6].Skip(51).Take(16);
            var s7 = list[7].Skip(51).Take(16);

            string part1 = "";
            string part2 = "";
            string part3 = "";


            foreach (var item in s5)
            {
                part1 = part1 + item.ToString();
            }
            foreach (var item in s6)
            {
                part2 = part2 + item.ToString();
            }
            foreach (var item in s7)
            {
                part3 = part3 + item.ToString();
            }

            part1 = part1.Replace(".", "");
            part1 = part1.Trim();
            part2 = part2.Replace(".", "");
            part2 = part2.Trim();
            part3 = part3.Replace(".", "");
            part3 = part3.Trim();

            // Test and fail return -1
            try
            {
                var intNumber = Int32.Parse(part1 + part2 + part3);
                return part1 + part2 + part3;

            }
            catch
            {
                return "-1";
            }

        }

        private void TextBoxDeviceModel_TextChanged(object sender, EventArgs e)
        {
            LoadPictureSequence();
        }
    }
}
﻿using iMobileDevice;
using iMobileDevice.iDevice;
using iMobileDevice.Lockdown;
using iMobileDevice.Plist;
using Newtonsoft.Json;
using SharpAdbClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace Onions
{
    public partial class AddDeviceForm : Form
    {
        private const string SqlInsertStament = "INSERT INTO Customer (Firstname,Lastname,PhoneNumber,Email,Brand,Model,IMEI,Problem,Price,Status,CreationDate) VALUES ({0})";
        private const string SqlUpdateStament = "UPDATE Customer SET Firstname = '{0}', Lastname = '{1}',PhoneNumber = '{2}',Email = '{3}',Brand = '{4}',Model = '{5}',IMEI = '{6}',Problem = '{7}',Price = '{8}',Status = '{9}',UpdateDate = '{10}' WHERE IdCustomer = {11}";

        private const string Status = "devices";
        private bool editEnabled = false;
        public int customerID;

        private string UpdateOption { get; set; } = "Update";
        private string CompleteForm { get; set; } = "Complete Form";
        private string CreateCustomer { get; set; } = "Create Customer";
        private string UpdateCustomer { get; set; } = "Update Customer";

        public AddDeviceForm()
        {
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
                        label1.Text = x.GetString("FirstName") + ":";
                        label2.Text = x.GetString("LastName") + ":";
                        label3.Text = x.GetString("PhoneNumber") + ":";
                        label4.Text = x.GetString("Email") + ":";
                        button1.Text = x.GetString("Brand") + ":";
                        label6.Text = x.GetString("Model") + ":";
                        label7.Text = x.GetString("IMEI") + ":";
                        label8.Text = x.GetString("Problem") + ":";
                        PriceLabel.Text = x.GetString("Price") + ":";
                        label9.Text = x.GetString("Customer");
                        Add.Text = x.GetString("Add");
                        this.Text = x.GetString("AddDeviceFormTitle");
                        UpdateOption = x.GetString("UpdateOption");
                        CompleteForm = x.GetString("CompleteForm");
                    }
                }
            }
            catch { }

            circularProgressBar1.Value = 0;
            circularProgressBar1.Enabled = false;
            LoadDevices();
        }

        public string TextBoxName
        {
            get { return textBoxFirstName.Text; }
            set { textBoxFirstName.Text = value; }
        }

        public string TextBoxLastName
        {
            get { return textBoxLastName.Text; }
            set { textBoxLastName.Text = value; }
        }

        public string TextBoxPhoneNumber
        {
            get { return textBoxPhoneNumber.Text; }
            set { textBoxPhoneNumber.Text = value; }
        }

        public string TextBoxeMail
        {
            get { return textBoxeMail.Text; }
            set { textBoxeMail.Text = value; }
        }

        public string TextBoxBrand
        {
            get { return textBoxDeviceBrand.Text; }
            set { textBoxDeviceBrand.Text = value; }
        }

        public string TextBoxModel
        {
            get { return textBoxDeviceModel.Text; }
            set { textBoxDeviceModel.Text = value; }
        }

        public string TextBoxIMEI
        {
            get { return textBoxDeviceIMEI.Text; }
            set { textBoxDeviceIMEI.Text = value; }
        }

        public string TextBoxProblem
        {
            get { return textBoxDeviceProblem.Text; }
            set { textBoxDeviceProblem.Text = value; }
        }

        public string TextBoxPrice
        {
            get { return textBoxPrice.Text; }
            set { textBoxPrice.Text = value; }
        }

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        private void ShakeIT(TextBox control)
        {
            for (int i = 0; i < 8; i++)
            {
                Point one = new Point(control.Location.X + 3, control.Location.Y);
                control.Location = one;
                control.Update();
                System.Threading.Thread.Sleep(25);
                Point two = new Point(control.Location.X - 6, control.Location.Y);
                control.Location = two;
                control.Update();
                System.Threading.Thread.Sleep(25);
                Point three = new Point(control.Location.X + 3, control.Location.Y);
                control.Location = three;
                control.Update();
                System.Threading.Thread.Sleep(25);
            }
        }

        public void EditMode(bool mode = false)
        {
            if (mode)
            {
                Add.Text = UpdateOption;
                button1.Enabled = false;
                editEnabled = true;
                PrintButton.Visible = true;
                label5.Text = customerID.ToString().PadLeft(8, '0');
            }
        }

        // Data and Static device selection list .
        private void Add_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
            {
                MessageBox.Show("Error: " + CompleteForm, CreateCustomer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!editEnabled)
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
                                              "'" + textBoxPrice.Text + "'," +
                                              "'" + Status + "'," +
                                              "'" + today + "'";

                        //Create Sql Insert Command and insert the data in database
                        DatabaseAccess.fnSetConexion(string.Format(SqlInsertStament, CustomerValues)).ExecuteNonQuery();
                        this.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Error: " + Ex.Message, CreateCustomer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    try
                    {
                        string today = DateTime.Today.ToString("dd/MM/yyyy");

                        //Create Sql Insert Command and insert the data in database
                        DatabaseAccess.fnSetConexion(string.Format(SqlUpdateStament, textBoxFirstName.Text, textBoxLastName.Text, textBoxPhoneNumber.Text, textBoxeMail.Text, textBoxDeviceBrand.Text, textBoxDeviceModel.Text, textBoxDeviceIMEI.Text, textBoxDeviceProblem.Text, textBoxPrice.Text, Status, today, CustomerID)).ExecuteNonQuery();
                        this.Close();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Error: " + Ex.Message, UpdateCustomer, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                ShakeIT(control);
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
            textBoxDeviceModel.Text = string.Empty;
            textBoxDeviceModel.AutoCompleteCustomSource.Clear();
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
                if (ex is System.ArgumentNullException || ex is System.NullReferenceException)
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
                        { 2, "service call iphonesubinfo 1"},
                        { 3, "getprop persist.radio.device.imei"}
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
                        if (method1IMEI != "-1")
                        {
                            textBoxDeviceIMEI.Text = method1IMEI.Trim();
                        }
                        else
                        {
                            //ASUS ZENFONE
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
                            {"iPod9,1", "iPod Touch 7th Gen"},
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
                            {"iPhone12,1", "iPhone 11"},
                            {"iPhone12,3", "iPhone 11 Pro"},
                            {"iPhone12,5", "iPhone 11 Pro Max"},
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
                            {"iPad8,8", "iPad Pro 12.9 inch 3rd Gen"},
                            {"iPad11,1", "iPad mini 5th Gen(WiFi)"},
                            {"iPad11,2", "iPad mini 5th Gen"},
                            {"iPad11,3", "iPad Air 3rd Gen(WiFi)" },
                            {"iPad11,4", "iPad Air 3rd Gen" }
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
                            if (data.TryGetValue(ProductType.Trim(), out string FProductType))
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
                part1 += item.ToString();
            }
            foreach (var item in s6)
            {
                part2 += item.ToString();
            }
            foreach (var item in s7)
            {
                part3 += item.ToString();
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
                var intNumber = Int64.Parse(String.Concat(part1, part2, part3));
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

        private void PrintButton_Click(object sender, EventArgs e)
        {
            TopMost = false;
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        #region Fonts

        private Font _titleFont = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
        public Font TitleFont => _titleFont;

        private Font _headerFont = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular);
        public Font HeaderFont => _headerFont;

        private Font _regularFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
        public Font RegularFont => _regularFont;

        private Font _boldFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        public Font BoldFont => _boldFont;

        #endregion Fonts

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var CompanyDetails = CorporateDetails.ThisCompany.Split('\n');
            var cmpName = CompanyDetails[0];
            var cmpAddress = CompanyDetails[1];
            var cmpPhoneNumber = CompanyDetails[2];
            var cmpLogo = CompanyDetails[3];

            Image i = Image.FromFile(cmpLogo);

            string today = DateTime.Today.ToString("dd/MM/yyyy");

            #region printing

            // in order to make language i need to use all variables .

            e.Graphics.DrawString("Service Receipt", TitleFont, Brushes.Black, new RectangleF(0, 20, e.PageBounds.Width, 40), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawImage(i, 40, 10, 110, 110);
            e.Graphics.DrawString(cmpName, HeaderFont, Brushes.Black, new RectangleF(0, 60, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawString(cmpAddress + " " + cmpPhoneNumber, RegularFont, Brushes.Black, new RectangleF(0, 80, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Center });
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(20, 100), new Point(800, 100));
            e.Graphics.DrawString("Receipt No: ", HeaderFont, Brushes.Black, new RectangleF(40, 130, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(customerID.ToString().PadLeft(8, '0'), RegularFont, Brushes.DimGray, new RectangleF(150, 130, e.PageBounds.Width, 30), new StringFormat() { Alignment = StringAlignment.Near }); ;
            e.Graphics.DrawString("Customer : ", RegularFont, Brushes.Black, new RectangleF(240, 130, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(textBoxFirstName.Text + " " + textBoxLastName.Text, RegularFont, Brushes.Black, new RectangleF(240, 150, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(textBoxPhoneNumber.Text, RegularFont, Brushes.Black, new RectangleF(240, 170, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Device Details : ", RegularFont, Brushes.Black, new RectangleF(440, 130, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Device : " + textBoxDeviceBrand.Text + " " + textBoxDeviceModel.Text, RegularFont, Brushes.Black, new RectangleF(440, 150, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("IMEI : " + textBoxDeviceIMEI.Text, RegularFont, Brushes.Black, new RectangleF(440, 170, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Problem : " + textBoxDeviceProblem.Text, RegularFont, Brushes.Black, new RectangleF(440, 190, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString("Price : ", RegularFont, Brushes.Black, new RectangleF(440, 210, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(textBoxPrice.Text, RegularFont, Brushes.DimGray, new RectangleF(520, 210, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawString(today, HeaderFont, Brushes.Black, new RectangleF(680, 130, e.PageBounds.Width, 20), new StringFormat() { Alignment = StringAlignment.Near });
            e.Graphics.DrawLine(new Pen(Color.Gray, 1), new Point(20, 250), new Point(800, 250));

            #endregion printing
        }
    }
}
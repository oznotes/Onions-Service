﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Device
{
    public partial class AddDeviceForm : Form
    {
        public AddDeviceForm()
        {
            InitializeComponent();
        }

        // Data and Static device selection list .
        private void Add_Click(object sender, EventArgs e)
        {
            string contactFileContents = String.Empty;
            string today = DateTime.Today.ToString("dd/MM/yyyy");

            if (File.Exists("devices.dat"))
            {
                contactFileContents = File.ReadAllText("devices.dat") + System.Environment.NewLine;
            }      
            contactFileContents += today + "|" +
                                   textBoxFirstName.Text + "|" +
                                   textBoxLastName.Text + "|" +
                                   textBoxPhoneNumber.Text + "|" +
                                   textBoxeMail.Text + "|" +
                                   textBoxDeviceBrand.Text + "|" +
                                   textBoxDeviceModel.Text + "|" +
                                   textBoxDeviceIMEI.Text + "|" +
                                   textBoxDeviceProblem.Text;
            File.WriteAllText("devices.dat", contactFileContents);
            this.Close();

        }

        private void textBoxDeviceModel_Click(object sender, EventArgs e)
        {


        }

        private void textBoxDeviceModel_MouseClick(object sender, MouseEventArgs e)
        {
            //Console.WriteLine(this.textBoxDeviceBrand.Text.ToString());

            //4 models of each row 
            //Python Script get the models from html tags extracted from gsmarena
            //import re
            //with open('source.txt', 'r') as myfile:
            //      s = myfile.read()

            //print(re.findall(r'<strong><span>(.*?)</span></strong>', s))


            if (this.textBoxDeviceBrand.Text.ToString() == "APPLE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "iPad Pro 12.9 (2018)", "iPad Pro 11", "iPhone XS Max", "iPhone XS",
                    "iPhone XR", "Watch Series 4", "Watch Series 4 Aluminum", "iPad 9.7 (2018)",
                    "iPhone X", "iPhone 8 Plus", "iPhone 8", "Watch Edition Series 3",
                    "Watch Series 3", "Watch Series 3 Aluminum", "iPad Pro 12.9 (2017)", "iPad Pro 10.5 (2017)",
                    "iPad 9.7 (2017)", "Watch Edition Series 2 42mm", "Watch Series 2 42mm", "Watch Edition Series 2 38mm",
                    "Watch Series 2 38mm", "Watch Series 2 Aluminum 42mm", "Watch Series 1 Aluminum 42mm", "Watch Series 2 Aluminum 38mm",
                    "Watch Series 1 Aluminum 38mm", "iPhone 7 Plus", "iPhone 7", "iPad Pro 9.7 (2016)",
                    "iPhone SE", "iPhone 6s Plus", "iPhone 6s", "iPad Pro 12.9 (2015)",
                    "Watch Edition 42mm (1st gen)", "iPad mini 4", "Watch Edition 38mm (1st gen)", "Watch 42mm (1st gen)",
                    "Watch 38mm (1st gen)", "Watch Sport42mm (1st gen)", "Watch Sport 38mm (1st gen)", "iPad Air 2",
                    "iPad mini 3", "iPhone 6 Plus", "iPhone 6", "iPhone 5s",
                    "iPhone 5c", "iPad Air", "iPad mini 2", "iPad mini Wi-Fi",
                    "iPad mini Wi-Fi + Cellular", "iPad 4 Wi-Fi", "iPhone 5", "iPad 4 Wi-Fi + Cellular",
                    "iPad 3 Wi-Fi + Cellular", "iPad 3 Wi-Fi", "iPhone 4s", "iPad 2 Wi-Fi + 3G",
                    "iPad 2 Wi-Fi", "iPad 2 CDMA", "iPhone 4", "iPhone 4 CDMA",
                    "iPad Wi-Fi+ 3G", "iPad Wi-Fi", "iPhone 3GS", "iPhone 3G",
                    "iPhone"
                });
            }

            else if (this.textBoxDeviceBrand.Text.ToString() == "ACER")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Chromebook Tab 10", "Iconia Talk S", "Liquid Z6 Plus", "Liquid Z6",
                    "Iconia Tab 10 A3-A40", "Liquid X2", "Liquid Jade 2", "Liquid Zes Plus",
                    "Liquid Zest", "Predator 8", "Liquid Jade Primo", "Liquid Z330",
                    "Liquid Z320", "Liquid Z630S", "Liquid Z630", "Liquid Z530S",
                    "Liquid Z530", "Liquid M330", "Liquid M320", "Iconia Tab 10 A3-A30",
                    "Iconia One 8 B1-820", "Iconia Tab A3-A20", "Iconia Tab A3-A20FHD", "Liquid Jade Z",
                    "Liquid Z520", "Liquid Z220", "Liquid M220", "Liquid Z410",
                    "Liquid Jade S", "Liquid Z500", "Liquid X1", "Liquid Jade",
                    "Liquid E700", "Liquid E600", "Liquid Z200", "Iconia Tab 8 A1-840FHD",
                    "Iconia Tab 7 A1-713", "Iconia Tab 7 A1-713HD", "Iconia One 7 B1-730", "Liquid E3 Duo Plus",
                    "Liquid E3", "Liquid Z4", "Iconia B1-721", "Iconia B1-720",
                    "Iconia A1-830",  "Liquid Z5", "Liquid S2", "Liquid Z3",
                    "Liquid S1", "Iconia Tab A3", "Iconia Tab A1-811", "Iconia Tab A1-810",
                    "Liquid E2", "Liquid Z2", "Liquid C1", "Liquid E1",
                    "Iconia Tab B1-710", "Iconia Tab B1-A71", "Iconia Tab A110", "Liquid Z110",
                    "Liquid Gallant E350", "Liquid Gallant Duo", "Liquid Glow E330", "CloudMobile S500",
                    "Iconia Tab A210", "Iconia Tab A200", "Iconia Tab A701", "Iconia Tab A700",
                    "Iconia Tab A511", "Iconia Tab A510", "Allegro", "Liquid Express E320",
                    "Iconia Tab A501", "Iconia Smart", "Iconia Tab A500", "Iconia Tab A101",
                    "Iconia Tab A100", "Liquid mini E310", "beTouch E210", "beTouch E140",
                    "beTouch T500", "Liquid mt", "beTouch E130", "beTouch E120",
                    "Stream", "Liquid E", "neoTouch P400", "beTouch E400",
                    "neoTouch P300", "beTouch E110", "Liquid", "neoTouch",
                    "beTouch E200", "beTouch E100", "beTouch E101", "DX650",
                    "M900", "F900", "X960", "DX900"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "AMAZON")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Fire HD 10 (2017)","Fire HD 8 (2017)","Fire 7 (2017)","Fire HD 10",
                    "Fire HD 8","Fire 7","Fire HDX 8.9 (2014)","Fire HD 7",
                    "Fire HD 6","Fire Phone","Kindle Fire HDX 8.9","Kindle Fire HDX",
                    "Kindle Fire HD (2013)","Kindle Fire HD 8.9 LTE","Kindle Fire HD 8.9",
                    "Kindle Fire HD", "Kindle Fire"

                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "COOLPAD")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Cool Play 8", "Mega 5A", "Note 6", "Cool 2",
                    "Cool Play 6", "Cool M7", "NX1", "Defiant",
                    "Note 5 Lite", "Cool1 dual", "Conjr", "Cool S1",
                    "Note 3s", "Mega 3", "Note 5", "Modena 2",
                    "Mega", "Torino", "Note 3 Plus", "Max",
                    "Porto S", "Torino S", "Note 3 Lite", "Roar",
                    "Note 3", "Shine", "Modena", "Porto",
                    "3632"
                });
            }

            else if (this.textBoxDeviceBrand.Text.ToString() == "HUAWEI")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "G6153", "G3621L", "Ascend G700", "G610s",
                    "U8687 Cronos", "Ascend G525", "MediaPad 7 Youth", "MediaPad 7 Vogue",
                    "Ascend P6", "Ascend Y300", "Premia 4G M931", "Ascend Y210D",
                     "Ascend P2", "Ascend G615", "Ascend G526", "Ascend G350",
                    "Ascend W1", "Ascend Mate", "Ascend G312", "Ascend D2",
                    "Ascend G510", "Ascend G500", "Ascend Y201 Pro", "MediaPad 10 Link",
                    "Ascend Y", "Summit", "Ascend P1 LTE", "Fusion 2 U8665",
                    "Ascend G600", "Ascend G330", "MediaPad 7 Lite", "Ascend Y100",
                    "Ascend Y200", "Ascend G330D U8825D", "Ascend G300", "Ascend P1 XL U9200E",
                    "Ascend P1", "Ascend Q M5660", "G6005", "G6800",
                    "G6310", "G5000", "Activa 4G", "G5520",
                    "G6609", "Fusion U8652", "MediaPad 10 FHD", "Ascend D1 XL U9500E",
                    "Ascend D1", "Ascend D quad XL", "Ascend D quad", "Ascend P1s",
                    "M886 Mercury", "G7300", "G7005", "MediaPad",
                    "MediaPad	S7-301w", "D51 Discovery", "U8520 Duplex",
                    "T8300", "U8350 Boulder", "Impulse 4G", "Pillar",
                    "U8850 Vision", "Ascend II", "U8800 Pro", "G7206",
                    "U5510", "G5500", "G6620", "U8650 Sonic",
                    "U8180 IDEOS X1", "G6608", "G7010", "U5900s",
                    "IDEOS S7 Slim", "IDEOS S7 Slim CDMA", "U9000 IDEOS X6", "U8800 IDEOS X5",
                    "U8510 IDEOS X3", "U8150 IDEOS", "U8500 IDEOS X2", "U7520",
                    "G6150", "G7002", "U8300", "IDEOS S7",
                    "C3200", "U3100", "U8110", "U8100",
                    "U8230", "U8220", "U7510", "U1270",
                    "U1250", "U9130 Compass", "G6600 Passport", "U7310",
                    "U9150", "U121", "U120", "U3300",
                    "U1310", "U1100", "U1000", "T156",
                    "T158", "T208", "T261L", "T211",
                    "T161L", "T330", "T201", "T552",
                    "Ascend W3", "G10", "Mulan"
                });

            }
            else
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
            }

        }
    }
}
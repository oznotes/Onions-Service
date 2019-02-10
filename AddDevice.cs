﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Device
{
    public partial class AddDeviceForm : Form
    {
        const string SqlInsertStament = "INSERT INTO Customer (Firstname,Lastname,PhoneNumber,Email,Brand,Model,IMEI,Problem,Status,CreationDate) VALUES ({0})";
        const string Status = "devices";

        public AddDeviceForm()
        {
            InitializeComponent();  
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
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message, "Create Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxDeviceModel_MouseClick(object sender, MouseEventArgs e)
        {

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
            else if (this.textBoxDeviceBrand.Text.ToString() == "ALCATEL")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "1x (2019)", "1c (2019)", "7", "5v",
                    "5", "3v", "3x", "3",
                    "1x", "3c", "1T 10", "1T 7",
                    "Idol 5s", "Idol 5", "A7 XL", "A7",
                    "U5 HD", "Pulsemix", "Idol 5s (USA)", "Flash (2017)",
                    "U5", "A5 LED", "A3", "A3 XL",
                    "Shine Lite", "Pixi 4 Plus Power", "Fierce 4", "X1",
                    "Pixi 4 (5)", "Flash Plus 2", "Pop 7 LTE", "Pop 4S",
                    "Pop 4+", "Pop 4", "Idol 4s Windows", "Idol 4s",
                    "Idol 4", "Fierce XL (Windows)", "CareTime", "Pixi 4 (7)",
                    "Pixi 4 (6) 3G", "Pixi 4 (6)", "Pixi 4 (4)", "Pixi 4 (3.5)",
                    "Pixi 3 (8) LTE", "Pop 3 (5.5)", "Pop 3 (5)", "Fierce XL",
                    "Watch", "GO Watch", "Flash 2", "10.16G",
                    "2007", "Idol 3C", "Pixi 3 (10)", "Pixi First",
                    "Pop Up", "Pop Star LTE", "Pop Star", "Go Play",
                    "Flash Plus", "Pop Astro", "Flash", "Idol 3 (5.5)",
                    "Idol 3 (4.7)", "Orange Klif", "Pixi 3 (5.5) LTE", "Pixi 3 (5.5)",
                    "Pixi 3 (8) 3G", "Pixi 3 (7) LTE", "Pixi 3 (7) 3G", "Pixi 3 (7)",
                    "Pop 10", "Pixi 3 (5)", "Pixi 3 (4.5)", "Pixi 3 (4)",
                    "Pixi 3 (3.5) Firefox", "Pixi 3 (3.5)", "Pop D3", "Pop D1",
                    "Pop Icon", "Fire C 2G", "Pop 2 (5) Premium", "Pop 2 (5)",
                    "Pop 2 (4)", "Pop 2 (4.5) Dual SIM", "Pop 2 (4.5)", "Fierce 2",
                    "Evolve 2", "Pop 8S", "Hero 8", "Hero 2",
                    "Pixi 2", "Pop D5", "Pop C2", "Pixi 8",
                    "2012", "2010", "2052", "2040",
                    "2005", "Pop 7S", "Pixi 7", "Pop S9",
                    "Pop S7", "Pop S3", "Fire 7", "Fire S",
                    "Fire E", "Fire C", "Idol 2 S", "Idol 2",
                    "Idol 2 Mini S", "Idol 2 Mini", "Pop Fit", "2001",
                    "2000", "Idol X+", "Pop C9", "Pop 8",
                    "Pop 7", "Fierce", "Evolve", "Pop C7",
                    "Pop C5", "Pop C3", "Pop C1", "Idol Alpha",
                    "One Touch Evo 8HD", "Hero", "Idol S", "Idol Mini",
                    "One Touch T10", "One Touch Snap LTE", "One Touch Pixi", "One Touch Snap",
                    "Idol X", "One Touch Fire", "One Touch Star", "One Touch Scribe Easy",
                    "One Touch Evo 7", "One Touch Evo 7 HD", "One Touch Tab 8 HD", "One Touch Tab 7",
                    "One Touch Tab 7 HD", "One Touch Idol Ultra", "One Touch Idol", "One Touch T Pop",
                    "One Touch S Pop", "One Touch M Pop", "One Touch X Pop", "One Touch Scribe HD-LTE",
                    "One Touch Scribe X", "One Touch Scribe HD", "View", "OT-983",
                    "OT-997D", "OT-997", "OT-992D", "OT-978",
                    "OT-988 Shockwave", "OT-993", "OT-903", "OT-838",
                    "OT-668", "OT-605", "OT-986", "OT-991",
                    "OT-916", "OT-720", "OT-902", "OT-819 Soul",
                    "OT-870", "OT-595", "OT-358", "OT-310",
                    "OT-318D", "OT-317D", "OT-308", "OT-282",
                    "OT-292", "OT-228", "OT-915", "OT-985",
                    "OT-810D", "OT-810", "OT-906", "OT-995",
                    "OT-990", "OT-910", "OT-908F", "OT-908",
                    "OT-905", "OT-900", "OT-891 Soul", "OT-918",
                    "OT-918D", "OT-890D", "OT-890", "OT-888",
                    "OT-818", "OT-813F", "OT-807", "OT-813D",
                    "OT-803", "OT-799 Play", "OT-690", "OT-665",
                    "OT-602", "OT-585", "OT-506", "OT-385",
                    "OT-361", "OT-355", "OT-330", "OT-306",
                    "OT-223", "OT-217", "OT-213", "OT-209",
                    "OT-117", "OT-113", "OT-112", "OT-109",
                    "OT-105", "OT-706", "Net", "OT-808",
                    "OT-606 One Touch CHAT", "OT-255", "OT-252", "OT-710",
                    "OT-108", "OT-216", "OT-206", "OT-909 One Touch MAX",
                    "Miss Sixty", "OT-880 One Touch XTRA", "OT-208", "OT-301",
                    "OT-300", "OT-980", "OT-806", "OT-802 Wave",
                    "OT-305", "OT-380", "OT-505", "OT-508A",
                    "OT-565", "OT-106", "OT-800 One Touch CHROME", "OT-800 One Touch Tribe",
                    "OT-708 One Touch MINI", "OT-660", "OT-383", "OT-203",
                    "OT-103", "OT-600", "Crystal", "Miss Sixty 2009",
                    "ELLE GlamPhone", "OT-363", "Roadsign", "OT-303",
                    "OT-222", "OT-280", "OT-202", "OT-S121",
                    "OT-111", "OT-102", "Mandarina Duck Moon", "Mandarina Duck",
                    "OT-I650 SPORT", "OT-I650 PRO", "OT-V770", "OT-V670",
                    "OT-V607A", "OT-V570", "OT-V270", "OT-V212",
                    "OT-S626A", "OT-S521A", "OT-S520", "OT-S621",
                    "OT-S920", "OT-S320", "OT-S319", "OT-S218",
                    "OT-S215A", "OT-S211", "OT-S210", "OT-S120",
                    "OT-S107", "ELLE No 3", "OT-C825", "OT-C717",
                    "OT-C707", "OT-C701", "OT-C700A", "OT-C507",
                    "OT-E227", "OT-E225", "OT-E221", "OT-E207",
                    "OT-E205", "OT-E201", "OT-E101", "Lollipops",
                    "OT-E220", "OT-E805", "OT-E230", "OT-C635",
                    "OT-C630", "OT-E801", "OT-E100", "OT-C550",
                    "OT-E265", "OT-E105", "OT-E260", "OT-C750",
                    "OT-S853", "OT-S850", "OT-C560", "OT-C555",
                    "OT-C552", "OT-C551", "OT-C656", "OT-C652",
                    "OT-C651", "OT-E259", "OT-E256", "OT-E257",
                    "OT-E160", "OT-E252", "OT-E159", "OT-E158",
                    "OT-E157", "OT 757", "OT 355", "OT 156",
                    "OT 155", "OT 153", "OT 756", "OT 557",
                    "OT 565", "OT 556", "OT 835", "OT 735i",
                    "OT 735", "OT 535", "OT 531", "OT 332",
                    "OT 331", "OT 526", "OT 320", "OT 525",
                    "OT 715", "OT 512", "OT 311", "OT 511",
                    "OT 700", "OT 500", "OT 300", "OT View db @",
                    "OT Pocket", "OT View db", "OT Max db", "OT Easy db",
                    "OT Gum db", "OT Club db", "OT COM", "OT Pro",
                    "OT Easy HF", "OT Easy", "OT Club", "OT Club +",
                    "OT Max", "OT View", "HC 1000", "HC 800"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ALLVIEW")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "A10 Lite 2019", "Allwatch Hybrid T", "Allwatch Hybrid S", "A10 Plus",
                    "Soul X5 Style", "Allwatch V", "Soul X5 Mini", "P10 Style",
                    "X5 Soul", "Soul X5 Pro", "P8 Pro", "X4 Soul Infinity Plus",
                    "X4 Soul Infinity L", "X4 Soul Infinity N", "X4 Soul Infinity S", "X4 Soul Infinity Z",
                    "X4 Soul Vision", "V3 Viper", "X4 Soul Mini S", "X4 Xtreme",
                    "P9 Energy Lite (2017)", "X4 Soul Lite", "X4 Soul Mini", "X4 Soul Style",
                    "P6 Energy Mini", "X4 Soul", "Allwatch", "V2 Viper Xe",
                    "V2 Viper S", "P9 Energy mini", "P9 Energy Lite", "P9 Energy",
                    "P7 Pro", "X3 Soul Style", "X3 Soul Plus", "X3 Soul Lite",
                    "P6 Energy Lite", "AX501Q", "Viva H1001 LTE", "V2 Viper i4G",
                    "V2 Viper e", "P6 Lite", "X3 Soul Pro", "X3 Soul mini",
                    "P8 Energy Pro", "P6 eMagic", "P5 eMagic", "P4 eMagic",
                    "X3 Soul", "X2 Soul Style + Platinum", "X2 Soul Style", "X2 Soul Lite",
                    "V2 Viper X+", "V2 Viper X", "V2 Viper", "V2 Viper i",
                    "P8 Energy mini", "P5 Pro", "AX4 Nano Plus", "Viva C701",
                    "P6 Pro", "P8 Energy", "P5 Energy", "E4",
                    "E4 Lite", "E3 Living", "A5 Easy", "E2 Jump",
                    "E3 Sign", "P4 Life", "P5 Life", "P6 Energy",
                    "Viper E", "Viper L", "V1 Viper i4G", "V1 Viper S4G",
                    "X2 Soul Pro", "W1i", "W1s", "X2 Xtreme",
                    "P6 Life", "C5 Smiley", "C6 Quad 4G", "E2 Living",
                    "Twin X2", "P7 Seon", "X1 Xtreme Mini", "X2 Soul Mini",
                    "Impera M", "Impera S", "Impera i", "A6 Quad",
                    "X2 Soul", "P7 Xtreme", "X1 Xtreme", "V1 Viper S",
                    "Wi10N PRO", "Wi8G", "Wi7", "Viva i10G",
                    "Viva H10 HD", "Viva H10 LTE", "Viva H8 LTE", "Viva H7S",
                    "Viva H7 LTE", "Viva D8", "AX4 Nano", "AX3 Party",
                    "Viva i8", "Viva Q7 Life", "3 Speed Quad HD", "City Life",
                    "2 Speed Quad", "City+", "Viva H8", "Viva Q8",
                    "Start M7", "P6 Quad Plus", "A5 Quad", "P5 Symbol",
                    "X1 Soul Mini", "X1 Soul", "A4 Duo", "A5 Duo",
                    "H2 Qubo", "Viper i V1", "Viper V1", "P5 Qmax",
                    "P6 Quad", "Simply S5", "A4ALL", "P5 Quad",
                    "P6 Stony", "P4 Duo", "P5 Mini", "P5 AllDro",
                    "P4 AllDro", "P3 AllDro", "P2 AllDro", "P1 AllDro",
                    "L4 Class", "M6 Stark"
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
            else if (this.textBoxDeviceBrand.Text.ToString() == "AMOI")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "E860", "E78", "E76", "E72",
                    "WMA8701A", "WMA8703", "WMA8508", "CMA8170",
                    "M33", "A203", "A200", "A102",
                    "A100", "A10", "E850", "V810",
                    "H815", "H812", "H810", "H802",
                    "H801", "H8", "H80", "A675",
                    "M636", "A865", "A869", "6201",
                    "M360", "M650", "M630", "F620",
                    "A320", "F320", "A310", "A211",
                    "A210", "2561", "CS6", "2560",
                    "A90", "F99b"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ARCHOS")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Saphir 50X", "Diamond Omega", "Diamond Alpha +", "Diamond Tab",
                    "Diamond Alpha", "Sense 55s", "Diamond Gamma", "Sense 50x",
                    "50 Saphir", "55 Graphite", "50 Graphite", "55b Cobalt",
                    "50b Cobalt", "Diamond 2 Plus", "55 Cobalt Plus", "50 Cobalt",
                    "Diamond Plus", "Diamond S", "50d Helium 4G", "50b Helium 4G",
                    "50 Diamond", "40 Cesium", "45c Platinum", "40c Titanium",
                    "50b Platinum", "80 Helium 4G", "64 Xenon", "50c Oxygen",
                    "40b Titanium", "50 Helium 4G", "45 Helium 4G", "50 Oxygen",
                    "53 Platinum", "50 Platinum", "45 Platinum", "53 Titanium",
                    "50 Titanium", "45 Titanium", "40 Titanium"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ASUS")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Zenfone Max Pro (M2) ZB631KL", "Zenfone Max (M2) ZB633KL", "Zenfone Max (M1) ZB556KL", "ZenFone Lite (L1) ZA551KL",
                    "ROG Phone", "ZenFone Live (L1) ZA550KL", "Zenfone Max Pro (M1) ZB601KL/ZB602K", "Zenfone 5z ZS620KL",
                    "Zenfone 5 ZE620KL", "Zenfone 5 Lite ZC600KL", "Zenfone Max (M1) ZB555KL", "Zenfone Max Plus (M1) ZB570TL",
                    "Zenfone V V520KL", "Zenfone 4 Pro ZS551KL", "Zenfone 4 ZE554KL", "Zenfone 4 Selfie Lite ZB553KL",
                    "Zenfone 4 Selfie ZB553KL", "Zenfone 4 Selfie Pro ZD552KL", "Zenfone 4 Selfie ZD553KL", "Zenfone 4 Max ZC520KL",
                    "Zenfone 4 Max Plus ZC554KL", "Zenfone 4 Max Pro ZC554KL", "Zenfone 4 Max ZC554KL", "Zenpad Z8s ZT582KL",
                    "Zenpad 3s 8.0 Z582KL", "Zenfone Go ZB552KL", "Zenfone Live ZB501KL", "Zenfone 3s Max ZC521TL",
                    "Zenpad 3S 10 Z500KL", "Zenfone AR ZS571KL", "Zenfone 3 Zoom ZE553KL", "Zenfone Go ZB690KG",
                    "Zenpad 3 8.0 Z581KL", "Zenfone Go ZB500KL", "Zenfone 3 Max ZC553KL", "Zenfone 3 Deluxe 5.5 ZS550KL",
                    "Zenpad Z10 ZT500KL", "Zenwatch 3 WI503Q", "Zenpad 3S 10 Z500M", "Zenfone 3 Max ZC520TL",
                    "Zenfone 3 Laser ZC551KL", "Zenfone 3 ZE520KL", "Zenfone Pegasus 3", "Zenpad Z8",
                    "Zenfone 3 Ultra ZU680KL", "Zenfone 3 Deluxe ZS570KL", "Zenfone 3 ZE552KL", "Zenfone Max ZC550KL (2016)",
                    "Zenfone Go ZB450KL", "Zenfone Go ZB452KG", "Zenfone Go ZB551KL", "Zenfone Go T500",
                    "Zenfone Go ZC451TG", "Live G500TG", "Zenwatch 2 WI501Q", "Zenwatch 2 WI502Q",
                    "Zenwatch WI500Q", "Zenfone 2 Laser ZE551KL", "Zenfone Zoom ZX551ML", "Zenpad 8.0 Z380M",
                    "Zenpad 10 Z300M", "Zenpad 10 Z300C", "Zenfone Go ZC500TG", "Zenfone Max ZC550KL",
                    "Zenfone 2 Deluxe ZE551ML", "Zenfone 2 Laser ZE601KL", "Zenfone 2 Laser ZE600KL", "Zenfone 2 Laser ZE550KL",
                    "Zenfone 2 Laser ZE500KG", "Zenfone 2 Laser ZE500KL", "Zenpad 7.0 Z370CG", "Zenfone 2E",
                    "Pegasus 2 Plus", "Zenpad S 8.0 Z580CA", "Zenpad S 8.0 Z580C", "Zenpad 8.0 Z380KL",
                    "Zenpad 8.0 Z380C", "Zenpad C 7.0 Z170MG", "Zenpad C 7.0", "Zenfone Selfie ZD551KL",
                    "Zenfone 2 ZE500CL", "Zenfone 2 ZE550ML", "Zenfone 2 ZE551ML", "Fonepad 7 FE375CL",
                    "Zenfone C ZC451CG", "Fonepad 7 FE171CG", "Zenfone Zoom ZX550", "Pegasus",
                    "Zenfone 5 Lite A502CG (2014)", "Memo Pad 10 ME103K", "PadFone X mini", "Memo Pad 7 ME572CL",
                    "Memo Pad 7 ME572C", "Zenfone 5 A500KL (2014)", "Zenfone 4 A450CG (2014)", "Memo Pad 8 ME581CL",
                    "Memo Pad 8 ME181C", "Memo Pad 7 ME176C", "Fonepad 8 FE380CG", "Fonepad 7 FE375CXG",
                    "Fonepad 7 FE375CG", "Transformer Pad TF303CL", "Transformer Pad TF103C", "Fonepad 7 (2014)",
                    "PadFone X", "PadFone S", "PadFone Infinity Lite", "PadFone E",
                    "Zenfone 6 A601CG", "Zenfone 6 A600CG", "Zenfone 5 A501CG (2015)", "Zenfone 5 A500CG (2014)",
                    "Zenfone 4 (2014)", "PadFone mini 4G (Intel)", "PadFone mini (Intel)", "PadFone mini",
                    "Transformer Book Trio", "PadFone Infinity 2", "Memo Pad 10", "Memo Pad 8 ME180A",
                    "Fonepad 7", "Google Nexus 7 (2013)", "Fonepad Note FHD6", "Transformer Pad TF701T",
                    "Memo Pad FHD10", "Memo Pad HD7 8 GB", "Memo Pad HD7 16 GB", "Fonepad",
                    "PadFone Infinity", "Memo Pad Smart 10", "Memo Pad ME172V", "Google Nexus 7 Cellular",
                    "VivoTab RT TF600T", "PadFone 2", "Google Nexus 7", "Transformer Pad Infinity 700 LTE",
                    "Transformer Pad Infinity 700 3G", "Transformer Pad TF300TG", "Transformer Pad TF300T", "Transformer Pad Infinity 700",
                    "Memo", "Transformer Prime TF700T", "Transformer Prime TF201", "PadFone",
                    "P835", "Transformer TF101", "E600", "P565",
                    "P552w", "P320", "M930", "P550",
                    "P750", "P527", "Z801", "J502",
                    "V88i", "M530w", "P526", "J501",
                    "P735", "Z810", "P535", "P525",
                    "P505", "M303", "M307", "M310",
                    "V80", "V75", "V66", "V55",
                    "Zenfone Pegasus 3s"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "AT&T")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Quickfire", "SMT5700", "Mustang", "8525"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BENEFON")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "TWIG Discovery Pro", "TWIG Discovery", "Q", "Track",
                    "Twin+", "Twin", "Esc!", "iO",
                    "Vega"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BENQ")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "F52", "B502", "T3", "F5",
                    "F3", "A3", "E55", "C36",
                    "E53", "T60", "M7", "E72",
                    "C30", "T51", "T33", "EL71",
                    "M580", "U700", "Z2", "M315",
                    "M220", "S80", "A520", "M350",
                    "A500", "S680C", "P50", "P31",
                    "P30", "S700", "M300", "M100",
                    "S670C", "S660C", "M775C"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BENQ-SIEMENS")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "SF71", "E52", "C32", "C31",
                    "SL80", "AL26", "A53", "SL91",
                    "E81", "E71", "EF61", "M81",
                    "A58", "A38", "EF71", "P51",
                    "EL71", "CL71", "CF61", "C81",
                    "E61", "EF91", "S81", "EF51",
                    "EF81", "S88", "S68"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BIRD")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "M32", "D636", "D706", "D615",
                    "S768", "S758", "S618", "D736",
                    "D716", "D720", "D611", "D515",
                    "D612", "M29", "M01", "M07",
                    "S1130", "V5518+", "S663", "S661",
                    "S669", "S668", "S667", "S296+",
                    "S296", "D680", "D660", "M11",
                    "M08", "S890", "S798", "S698",
                    "S198", "S299", "MP300", "M19",
                    "V109", "S799", "S699", "V79",
                    "S1186", "S199", "S789", "V5510",
                    "DV10", "S590", "S580", "A150",
                    "A130", "A120", "V09", "S570",
                    "SC24", "G118", "S1190", "S1180c",
                    "S1160 Plus", "S1160", "S788", "S288 Plus",
                    "S288"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BLACKBERRY")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "KEY2 LE", "Evolve X", "Evolve", "KEY2",
                    "Motion", "Aurora", "Keyone", "DTEK60",
                    "DTEK50", "Priv", "Leap", "Classic Non Camera",
                    "Porsche Design P 9983", "Passport", "Classic", "Z3",
                    "Porsche Design P 9982", "Z30", "9720", "Q5",
                    "Z10", "Q10", "4G LTE Playbook", "Curve 9320",
                    "Curve 9220", "Curve 9380", "Bold 9790", "Porsche Design P 9981",
                    "Curve 9370", "Curve 9360", "Curve 9350", "Torch 9810",
                    "Torch 9860", "Torch 9850", "Bold Touch 9900", "Bold Touch 9930",
                    "4G Playbook HSPA+", "Playbook Wimax", "Playbook", "Bold 9780",
                    "Style 9670", "Curve 3G 9330", "Curve 3G 9300", "Torch 9800",
                    "Pearl 3G 9105", "Pearl 3G 9100", "Bold 9650", "Bold 9700",
                    "Storm2 9520", "Storm2 9550", "Curve 8530", "Curve 8520",
                    "Tour 9630", "Curve 8900", "Curve 8980", "Storm3",
                    "Storm 9500", "Storm 9530", "Pearl Flip 8230", "Pearl Flip 8220",
                    "Bold 9000", "Volt", "Pearl 8130", "Pearl 8110",
                    "Pearl 8120", "Curve 8330", "Curve 8320", "Curve 8310",
                    "Curve 8300", "8820", "8830 World Edition", "8800",
                    "Pearl 8100", "7130g", "7130c", "7130v",
                    "8707v", "8700c", "7100x", "7100t",
                    "7100v", "7290", "7730", "7230",
                    "6720", "6230", "Curve Touch", "Porsche Design P 9531",
                    "Curve Touch CDMA", "Playbook 2012", "A10", "Z20"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BLACKVIEW")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "S6", "S8", "P6000", "A10",
                    "A7 Pro", "A7",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BLU")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Dash C Music", "Win JR", "Win HD", "Studio 5.0 C HD",
                    "Studio C Mini", "Studio 5.0 C", "Studio 5.0 CE", "Vivo IV",
                    "Life 8", "Life Pure XL", "Studio 5.0 LTE", "Studio 6.0 HD",
                    "Neo 4.5", "Neo 3.5", "Studio 5.0 S II", "Studio 5.0 E",
                    "Studio 5.5 S", "Life Pure Mini", "Vivo 4.8 HD", "Life View Tab",
                    "Life Play S", "Life One X", "Life One M", "Life Play X",
                    "Life Pure", "Studio 5.0 II", "Advance 4.0", "Life Pro",
                    "Studio 5.5", "Samba W", "Samba TV", "Jenny TV 2.8",
                    "Zoey", "Dash 5.0", "Dash Music 4.0", "Dash JR",
                    "Dash 4.5", "Amour", "Studio 5.3 S", "Studio 5.0 S",
                    "Studio 5.0", "Dash Music", "Diva X", "Diva",
                    "Tattoo S", "Life View", "Life One", "Life Play",
                    "Studio 5.3 II", "Tank 4.5", "Quattro 5.7 HD", "Quattro 4.5 HD",
                    "Quattro 4.5", "Hero II", "Dash 4.0", "Dash 3.2",
                    "Brooklyn", "Vivo 4.65 HD", "Touch Book 9.7", "Touch Book 7.0 Plus",
                    "Touch Book 7.0 Lite", "Dash 3.5", "Elite 3.8", "Dash",
                    "Hero", "Jenny TV", "Vivo 4.3", "Tank",
                    "Jenny", "Studio 5.3", "Touch Book 7.0", "Neo Pro",
                    "Neo XT", "Neo", "Deco Pro", "Deco XT",
                    "Deco", "Deco Mini", "Electro", "Spark",
                    "Deejay Touch", "Deejay Flip", "Tattoo Mini", "Samba Elite",
                    "Samba JR", "Lindy", "Swing", "Bar Q",
                    "Magic", "Touch", "Diesel 3G", "Deejay II",
                    "Samba Q", "Ultra", "Tango", "Speed",
                    "Smart", "Cubo", "Flash", "Samba Mini",
                    "Samba", "Tattoo", "Tattoo TV", "Disco2GO II",
                    "Deejay", "Click", "Brilliant", "Slim TV",
                    "TV2Go Lite", "TV2Go", "Texting 2 GO", "EZ2Go",
                    "Kick", "Vida1", "Gol", "Dual SIM Lite"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BOSCH")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "909 Dual S", "909 Dual", "Com 908", "Com 509",
                    "World 718", "Com 738", "Com 906", "Com 608",
                    "Com 607", "Com 207"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "BQ")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Aquaris X2 Pro", "Aquaris X2", "Aquaris VS Plus", "Aquaris VS",
                    "Aquaris U2 Lite", "Aquaris U2", "Aquaris V Plus", "Aquaris V",
                    "Aquaris X Pro", "Aquaris X", "Aquaris U Lite", "Aquaris U",
                    "Aquaris U Plus", "Aquaris X5 Plus", "Aquaris E5s", "Aquaris X5",
                    "Aquaris M5", "Aquaris M5.5", "Aquaris M4.5", " Aquaris M10"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "CASIO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "G'zOne CA-201L", "G'zOne Commando", "G'zOne Ravine 2", "G'zOne Ravine",
                    "G'zOne Brigade"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "CAT")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "B35", "S41", "S31", "S61",
                    "S60", "S30", "S40", "B30",
                    "B15 Q", "S50", "B15", "B100",
                    "B25"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "CELKON")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "A403", "Campus Prime", "Millennia Everest", "Millennia Hero",
                    "Millennia Xplore", "Q455L", "2GB Xpress", "A35k Remote",
                    "Q3K Power", "Q5K Power", "Q452", "A402",
                    "Q54+", "Q519", "Q450", "Q405",
                    "A518", "A407", "A359", "A355",
                    "Campus Buddy A404", "Millennia OCTA510", "Win 400", "Campus Whizz Q42",
                    "Millennia Epic Q550", "Xion s CT695", "Campus Colt A401", "Campus Crown Q40",
                    "Glory Q5", "Campus One A354C", "Campus Nova A352E", "A43",
                    "A42", "Q500 Millennium Ultra", "Q44", "A500",
                    "A21", "A115", "Q455", "Q470",
                    "Q3000", "A35k", "A125", "C7010",
                    "C5055", "C9 Jumbo", "C7 Jumbo", "C6 Star",
                    "C44 Duos", "C366", "C619", "C51",
                    "C340", "C348+", "C349+", "C779",
                    "C66+", "C44+", "A64", "A66",
                    "A9 Dual", "A 107+", "C4040", "ARR35",
                    "CT 7", "CT-888", "C820", "C720",
                    "S1", "A40", "AR50", "AR40",
                    "AR45", "A15", "C7045", "C605",
                    "C399", "C76", "C64", "C63",
                    "Monalisa 5", "A112", "A63", "A60",
                    "A20", "A10", "C5050 Star", "C7030",
                    "A105", "C349i", "C297", "C69",
                    "C67+", "C74", "CT-910+", "A118",
                    "A107", "A9+", "A119Q Signature HD", "A119 Signature HD",
                    "CT-910", "A87", "A86", "A69",
                    "A67", "A98", "A225", "C7050",
                    "C7070", "C44 Star", "C54", "GC10",
                    "C3333", "C356", "C355", "A75",
                    "A59", "A220", "A27", "A79",
                    "A83", "A77", "CT 9", "A200",
                    "C19", "A900", "A85", "A22",
                    "CT 2", "C52", "C9 Star", "A89",
                    "CT 1", "C24", "C3000", "A97i",
                    "A19", "C607", "C262", "C360",
                    "C359", "C350", "A97", "A95",
                    "A90", "A99+", "C770N", "C705",
                    "C606", "C570", "C504", "C206",
                    "C203", "C17", "C75", "i4",
                    "A7", "A88", "C770 Dj", "C769",
                    "C349", "C337", "C260", "C70",
                    "C55", "A9", "A99", "C3030",
                    "C90", "C909", "C60", "C305",
                    "C220", "C303", "C201", "C202",
                    "C404", "C5050", "C227", "i9",
                    "C2010", "C207", "A1", "C609",
                    "C102", "C77", "C100", "C555",
                    "C205", "C44", "C101", "C33",
                    "C550", "C66", "C339", "C10",
                    "C770", "C20", "C369", "C88",
                    "C2000", "C007", "C999", "C777",
                    "C1", "C444", "C2", "C225",
                    "C111", "C99", "C3", "C669",
                    "C9", "C11", "C333", "C6",
                    "C509", "C5", "C7", "C22",
                    "C347", "C357", "C367", "C409",
                    "C449", "C517", "C567", "C747",
                    "C867"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "CHEA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "A90", "JMS-110", "328", "318",
                    "308", "228", "218", "208",
                    "198", "188", "178", "168"
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
            else if (this.textBoxDeviceBrand.Text.ToString() == "DELL")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Venue 10 7000", "Venue 8 7000", "Venue 8", "Venue 7 8 GB",
                    "Venue 7", "XPS 10", "Streak Pro D43", "Streak 10 Pro",
                    "Streak 7", "Streak 7 Wi-Fi", "Venue", "XCD35",
                    "XCD28", "Smoke", "Flash", "Venue Pro",
                    "Streak", "Aero", "Mini 3i", "Mini 3iX"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "EMPORIA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Glam", "Flip Basic", "Eco", "Click Plus",
                    "Essence Plus", "Solid Plus", "Care Plus", "Elegance Plus",
                    "Elegance", "Connect", "Click", "Talk Comfort Plus",
                    "Talk Comfort", "RL1", "Talk Premium"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ENERGIZER")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Ultimate U620S Pop", "Ultimate U650S", "Ultimate U630S Pop", "Ultimate U620S",
                    "Ultimate U570S", "Hardcase H591S", "Hardcase H570S", "Hardcase H501S",
                    "Hardcase H280S", "Hardcase H241", "Hardcase H242", "Hardcase H242S",
                    "Power Max P490S", "Power Max P490", "Hardcase H500S", "Energy E500S",
                    "Energy E500", "Energy E11", "Energy E10+", "Power Max P20",
                    "Power Max P16K Pro", "Hardcase H240S", "Hardcase H550S", "Power Max P600S",
                    "Power Max P550S", "Energy S550", "Energy S500E", "Energy E520 LTE",
                    "Energy 100 (2017)", "Energy 400 LTE", "Energy E10", "Energy E20",
                    "Energy 500", "Energy 400", "Energy 240", "Energy 200",
                    "Energy 100"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ERICSSON")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "R600", "T68", "T66", "T65",
                    "T39", "A3618", "T29s", "R520m",
                    "T20e", "A2628", "T20s", "T36",
                    "R380", "R320", "R310s", "A2618",
                    "R250s PRO", "T28 World", "T28s", "T18s",
                    "T10s", "A1018s", "I 888", "SH 888",
                    "S 868", "GF 788e", "GF 788", "PF 768",
                    "GF 768", "GH 688", "GA 628", "GF 388",
                    "GH 388", "GS 337", "GF 337", "GH 337",
                    "GA 318", "GS 18", "GO 118", "GH 218"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ETEN")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "glofiish X610", "glofiish V900", "glofiish X900", "glofiish DX900",
                    "glofiish M750", "glofiish M810", "glofiish X650", "glofiish M800",
                    "glofiish X600", "glofiish X500+", "glofiish X800", "glofiish M700",
                    "glofiish X500", "M550", "G500+", "M600+",
                    "G500", "M600", "M500", "P300B",
                    "P300", "P700"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "FUJITSU-SIEMENS")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "T830","T810"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "GARMIN-ASUS")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "A10", "nuvifone A50", "nuvifone M10", "nuvifone G60",
                    "nuvifone M20"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "GIGABYTE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "GSmart Essence 4", "GSmart Classic Lite", "GSmart Essence", "GSmart Classic",
                    "GSmart Guru GX", "GSmart Mika MX", "GSmart Roma RX", "GSmart Akta A4",
                    "GSmart Mika M3", "GSmart GX2", "GSmart Guru (White Edition)", "GSmart T4 (Lite Edition)",
                    "GSmart Arty A3", "GSmart Mika M2", "GSmart T4", "GSmart Saga S3",
                    "GSmart Rey R3", "GSmart Guru", "GSmart Alto A2", "GSmart Roma R2",
                    "GSmart Aku A1", "GSmart Tuku T2", "GSmart Maya M1 v2", "GSmart Sierra S1",
                    "GSmart Simba SX1", "GSmart Maya M1", "GSmart Rio R1", "GSmart GS202",
                    "GSmart G1362", "GSmart G1355", "GSmart G1345", "GSmart G1342 Houston",
                    "GSmart M3447", "GSmart G1310", "GSmart G1317 Rola", "GSmart G1315 Skate",
                    "GSmart S1205", "GSmart G1305 Boston", "GSmart MS802", "GSmart MW702",
                    "GSmart S1200", "GSmart MS820", "GSmart MW998", "GSmart MS800",
                    "GSmart MW700", "GSmart", "GSmart i350", "GSmart q60",
                    "GSmart t600", "GSmart i120", "GSmart i300", "GSmart 2005",
                    "GSmart i", "GSmart i (128)", "g-YoYo", "g-Cam",
                    "Barbie", "g-re (b)", "g-re (o)", "Snoopy",
                    "Keroro", "Doraemon", "g-X5"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "GIONEE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "F205", "S11S", "S11", "S11 lite",
                    "M7 Plus", "M7 Power", "M7", "X1s",
                    "X1", "P8 Max", "A1 Lite", "S10",
                    "S10B", "S10C", "M6s Plus", "A1 Plus",
                    "A1", "F5", "M2017", "Steel 2",
                    "P7", "S9", "P7 Max", "F103 Pro",
                    "S6s", "M6 Plus", "M6", "S6 Pro",
                    "P5 Mini", "W909", "S8", "Marathon M5 mini",
                    "Marathon M5 enjoy", "Marathon M5 Plus", "Marathon M5 lite", "Pioneer P5W",
                    "S6", "Elife S Plus", "F103", "Elife E8",
                    "S5.1 Pro", "Marathon M4", "Marathon M5", "Pioneer P4S",
                    "Elife S7", "Pioneer P3S", "Pioneer P2M", "Pioneer P2S",
                    "S96", "L800", "L700", "Marathon M3",
                    "Elife S5.1", "Pioneer P6", "Pioneer P5L", "Pioneer P4",
                    "Ctrl V6L", "Ctrl V5", "Elife S5.5", "Elife E7 Mini",
                    "Elife E7", "Elife E6", "Elife E5", "Elife E3",
                    "M2", "Gpad G5", "Gpad G4", "Gpad G3",
                    "Gpad G2", "Gpad G1", "Pioneer P3", "Pioneer P2",
                    "Pioneer P1", "Ctrl V1", "Ctrl V2", "Ctrl V3",
                    "Ctrl V4s", "Ctrl V4", "Dream D1"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "GOOGLE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Pixel 3 XL", "Pixel 3", "Pixel 2", "Pixel 2 XL",
                    "Pixel XL", "Pixel", "Pixel C"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "HAIER")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "C300", "Hurricane", "G8", "L8",
                    "I6", "L7", "G7", "G51",
                    "U69", "U60", "U56", "U53",
                    "K3", "A66", "V730", "V700",
                    "M320+", "M306", "M300", "M180",
                    "M160", "M150", "A7", "M600 Black Pearl",
                    "P8", "A600", "M2000", "M1200",
                    "M1100", "M1000", "M80", "M260",
                    "N90", "N70", "N60", "T3000",
                    "V280", "F1100", "L1000", "P7",
                    "V7000", "V6200", "V6100", "V6000",
                    "P6", "V2000", "V200", "V190",
                    "V160", "V100", "Z300", "Z100",
                    "V1000", "P5", "Z7100", "Z7000",
                    "Z3000", "Z8000", "D6000"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "HONOR")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "View 20", "Magic 2", "Play 8A", "10 Lite",
                    "8C", "8X", "8X Max", "Note 10",
                    "9N (9i)", "Play", "7s", "10",
                    "7A", "7C", "9 Lite", "7X",
                    "View 10", "6C Pro", "9", "6A (Pro)",
                    "8 Pro", "Magic", "V8", "Pad 2",
                    "6X", "Holly 3", "Note 8", "8",
                    "5A", "5c", "Holly 2 Plus", "5X",
                    "7i", "7", "Bee", "4C",
                    "6 Plus", "4X", "Holly", "4 Play",
                    "3C Play", "6", "3X Pro", "3C 4G",
                    "3X G750", "3C", "3", "2",
                    "U8860"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "HP")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Elite x3", "Slate 17", "Pro Slate 12", "Pro Slate 10 EE G1",
                    "Pro Slate 8", "Slate6 VoiceTab II", "10 Plus", "7 VoiceTab",
                    "7 Plus", "8", "Slate7 VoiceTab Ultra", "Slate7 VoiceTab",
                    "Slate6 VoiceTab", "Slate8 Pro", "Slate10 HD", "Slate7 Extreme",
                    "Slate7 Plus", "Slate 7", "TouchPad 4G", "Veer 4G",
                    "Veer", "Pre 3 CDMA", "Pre 3", "TouchPad",
                    "iPAQ Glisten", "iPAQ Voice Messenger", "iPAQ Data Messenger", "iPAQ 910c",
                    "iPAQ 610c", "iPAQ 514", "iPAQ rw6815", "iPAQ rw6828",
                    "iPAQ rw6818", "iPAQ hw6915", "iPAQ hw6910", "iPAQ hw6515",
                    "iPAQ hw6510", "iPAQ h6325", "iPAQ h6320", "iPAQ h6315",
                    "iPAQ h6310"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "HTC")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Desire 12s", "Exodus 1", "U12 life", "U12+",
                    "Desire 12+", "Desire 12", "U11 Eyes", "U11+",
                    "U11 Life", "U11", "One X10", "U Ultra",
                    "U Play", "10 evo", "Desire 650", "Desire 10 Pro",
                    "Desire 10 Compact", "Desire 10 Lifestyle", "One A9s", "Desire 728 Ultra",
                    "Desire 628", "One M9 Prime Camera", "Desire 830", "One S9",
                    "10 Lifestyle", "10", "Desire 825", "Desire 630",
                    "Desire 530", "Desire 625", "One X9", "One M9s",
                    "Desire 828 dual sim", "Desire 728 dual sim", "One E9s dual sim", "Butterfly 3",
                    "One A9", "One M9+ Supreme Camera", "Desire 626 (USA)", "Desire 626s",
                    "Desire 526", "Desire 520", "One ME", "Desire 820G+ dual sim",
                    "Desire 326G dual sim", "One M9+", "One M8s", "One E9+",
                    "One E9", "One M9", "Desire 820s dual sim", "Desire 626G+",
                    "Desire 626", "Desire 526G+ dual sim ", "Desire 826 dual sim", "Desire 320",
                    "Desire 620G dual sim", "Desire 620", "Nexus 9", "Desire 816G dual sim",
                    "One (M8 Eye)", "Desire Eye", "Desire 612", "Desire 820q dual sim",
                    "Desire 820 dual sim", "Desire 820", "One (E8) CDMA", "Desire 510",
                    "One (M8) for Windows", "One (M8) for Windows (CDMA)", "Butterfly 2", "One Remix",
                    "One (M8) dual sim", "Desire 516 dual sim", "One (E8)", "One mini 2",
                    "Desire 616 dual sim", "Desire 210 dual sim", "One (M8) CDMA", "One (M8)",
                    "Desire 310 dual sim", "Desire 310", "Desire 816 dual sim", "Desire 816",
                    "Desire 610", "Desire 501 dual sim", "Desire 700", "Desire 700 dual sim",
                    "Desire 601 dual sim", "Desire 501", "One Max", "Desire 300",
                    "Desire 601", "Desire 500", "One mini", "Desire L",
                    "Desire P", "Desire Q", "8XT", "Butterfly S",
                    "Desire 200", "Desire 600 dual sim", "First", "One Dual Sim",
                    "One", "Desire U", "Desire 400 dual sim", "Butterfly",
                    "DROID DNA", "One SV CDMA", "One SV", "Desire SV",
                    "One VX", "One X+", "Windows Phone 8X CDMA", "Windows Phone 8X",
                    "Windows Phone 8S", "One ST", "One SC", "Desire X",
                    "Desire VT", "Desire XC", "Desire VC", "Desire V",
                    "Desire C", "J", "DROID Incredible 4G LTE", "Evo 4G LTE",
                    "One XC", "One X", "One X AT&T", "One XL",
                    "One S C2", "One S", "Velocity 4G Vodafone", "One V",
                    "Velocity 4G", "Titan II", "Rezound", "Vivid",
                    "EVO Design 4G", "Sensation XL", "Explorer", "Amaze 4G",
                    "Raider 4G", "Rhyme", "Hero S", "Rhyme CDMA",
                    "Sensation XE", "Jetstream", "Lead", "Titan",
                    "Radar", "Panache", "Glacier", "Status",
                    "Trophy", "DROID Incredible 2", "Sensation 4G", "Sensation",
                    "EVO 3D", "EVO 3D CDMA", "Prime", "HD7S",
                    "Merge", "Incredible S", "Desire S", "Wildfire S",
                    "Salsa", "ChaCha", "Flyer", "Flyer Wi-Fi",
                    "EVO View 4G", "Inspire 4G", "Freestyle", "ThunderBolt 4G",
                    "EVO Shift 4G", "Gratia", "HD7", "7 Pro",
                    "7 Surround", "7 Mozart", "7 Trophy", "Arrive",
                    "Desire HD", "Desire Z", "Paradise", "Evo 4G+",
                    "Aria", "Wildfire CDMA", "Wildfire", "Desire",
                    "HD mini", "Legend", "Rider", "Google Nexus One",
                    "Smart", "HD2", "Evo 4G", "Droid Incredible",
                    "DROID ERIS", "Pure", "Tattoo", "Touch2",
                    "Hero CDMA", "Hero", "Ozone", "Snap",
                    "Schubert", "Magic", "Tilt2", "Touch Pro2 CDMA",
                    "Touch Pro2", "Touch Diamond2 CDMA", "Touch Diamond2", "Dream",
                    "Touch Cruise 09", "MAX 4G", "Touch HD T8285", "Touch HD",
                    "Touch 3G", "Touch Viva", "S740", "Touch Pro CDMA",
                    "Touch Pro", "Touch Diamond CDMA", "Touch Diamond", "Advantage X7510",
                    "P3470", "Touch Cruise", "Touch Dual", "P6500",
                    "S730", "TyTN II", "S630", "Touch",
                    "P6300", "Shift", "Advantage X7500", "S710",
                    "P3350", "P3400", "P4350", "P3600i",
                    "P3600", "P3300", "S620", "S310",
                    "TyTN", "MTeoR", "Ville", "Zeta",
                    "A12", "Desire HD2", "Ignite", "Primo",
                    "Tiara", "One M8 Prime", "One (M8i)"
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
            else if (this.textBoxDeviceBrand.Text.ToString() == "I-MATE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "810-F", "Ultimate 9502", "Ultimate 8502", "JAMA 201",
                    "JAMA 101", "JAMA", "Ultimate 9150", "Ultimate 8150",
                    "Ultimate 7150", "Ultimate 6150", "Ultimate 5150", "JAQ4",
                    "PDAL", "JAQ3", "SPL", "JAQ",
                    "JASJAM", "SPJAS", "Smartflip", "JAMin",
                    "JASJAR", "K-JAM", "SP5", "SP5m",
                    "SP4m", "JAM Black", "JAM", "PDA2",
                    "PDA2k", "SP3i", "SP3", "Pocket PC",
                    "Smartphone2", "Smartphone"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "I-MOBILE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "i858", "8500", "5230", "Hitz 2206",
                    "5220", "TV658 Touch&Move", "Hitz 212", "Hitz 210",
                    "TV650 Touch", "TV550 Touch", "TV 630", "TV 628",
                    "TV 620", "TV 536", "638CG", "Hitz 232CG",
                    "TV 535", "627", "TV 533", "TV 530",
                    "TV 523", "522", "320", "319",
                    "TV 626", "902", "625", "903",
                    "613", "520", "518", "510",
                    "318", "315", "202", "201",
                    "101"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ICEMOBILE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "G8 LTE", "Mash", "G8", "Prime 5.0 Plus",
                    "Prime 5.0", "Prime 4.0 Plus", "Gravity 4.0", "Rock 2.4",
                    "Prime 5.5", "Prime 3.5", "Prime 4.0", "Apollo Touch 3G",
                    "Apollo 3G", "G7 Pro", "G3", "Prime 4.5",
                    "Charm II", "G10", "Gravity Pro", "Sol III",
                    "Hydro", "Rock Bold", "G2", "Gprime Extreme",
                    "G7", "G5", "Tropical 3", "Quattro",
                    "Prime Plus", "Submarine", "Charm", "Apollo Touch",
                    "Apollo", "Sol II", "Diamond Dust", "Blizzard",
                    "Rock Lite", "Cenior", "Acqua", "Prime",
                    "Rock Mini", "Twilight II", "Fuego", "Hurricane II",
                    "Sol", "Twister", "Wave", "Tornado II",
                    "Storm", "Clima II", "Flurry II", "Shine",
                    "Crystal", "Comet II", "Viento II", "Rock",
                    "Tropical", "Tropical II", "Rainbow II", "Rainbow",
                    "Twilight"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "INFINIX")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Smart 2 HD", "Hot 6X", "Note 5 Stylus", "S3X",
                    "Hot 6", "Note 5", "Smart 2 Pro", "Smart 2",
                    "Hot 6 Pro", "Hot S3", "Zero 5 Pro", "Zero 5",
                    "Hot 5 Lite", "Hot 5", "Note 4 Pro", "Note 4",
                    "Smart", "Zero 4 Plus", "Zero 4", "S2 Pro",
                    "Hot 4 Pro", "Hot 4", "Note 3 Pro", "Note 3",
                    "Hot S"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "INNOSTREAM")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "INNO A20", "INNO P10", "INNO A10", "INNO 75",
                    "INNO 50", "INNO 36", "INNO 79", "INNO 78",
                    "INNO 30", "INNO 55", "INNO 70", "INNO 99",
                    "INNO 90", "INNO 89", "INNO 80", "INNO 120",
                    "INNO 110", "INNO 100"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "INQ")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Cloud Touch", "Cloud Q", "Chat 3G", "Mini 3G",
                    "iNQ1"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "INTEX")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Aqua Craze", "Aqua GenX", "Aqua Ace", "Aqua Trend",
                    "IRist Smartwatch", "Aqua 4G+", "Aqua Xtreme II", "Aqua Y2 Remote",
                    "Aqua Xtreme", "Aqua Star L", "Aqua Star 2", "Aqua Speed",
                    "Aqua Power", "Aqua Power +", "Aqua 4.5E",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "JOLLA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Jolla C", "Tablet", "Jolla"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "KARBONN")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Titanium Mach Two S360", "Titanium Wind W4", "Titanium S99", "Sparkle V",
                    "Titanium S19", "Smart A12 Star", "Titanium S1 Plus", "Titanium Hexa",
                    "Titanium Octane Plus", "Titanium Octane", "Titanium X", "A16",
                    "A12+", "Titanium S5 Plus", "S7 Titanium", "S9 Titanium",
                    "A10", "A5", "A37", "A34",
                    "A25", "A7 Star", "A4+", "A2+",
                    "A27 Retina", "A111", "A6", "A4",
                    "A3", "A2", "S5 Titanium", "S1 Titanium",
                    "Smart Tab 9", "Smart Tab 8", "Smart Tab 10", "Smart Tab2",
                    "Smart Tab 7", "KT21 Express", "K65 Buzz", "K9 Jumbo",
                    "A9", "KT62", "K52 Groovster", "K309 Boombastic",
                    "K4+ Titan", "K707 Spy II", "K451+ Sound Wave", "K102+ Flair",
                    "KC540 Blaze", "K1+ Stereo", "A1+", "A21",
                    "A11", "K36+ Jumbo Mini", "K101+ Media Champ", "K440",
                    "A9+", "K11+", "A15", "A30"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "KYOCERA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "DuraForce Pro 2", "DuraForce Pro", "DuraForce XD", "DuraForce",
                    "Hydro Life", "Brigadier", "Hydro Elite", "Hydro Xtrm",
                    "Torque E6710", "Hydro C5170", "Rise C5155", "Milano C5121",
                    "Milano C5120", "Presto S1350", "Brio", "Echo",
                    "DuraCore E4210", "DuraMax", "E4600", "Solo E4000",
                    "E3500", "E2500", "S1600", "TG 200"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "LAVA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Z92", "Z81", "Z60s", "Z61",
                    "Z91 (2GB)", "Z91", "Z50", "Z90",
                    "Z80", "Z60", "A97 2GB+", "A44",
                    "A77", "Z25", "Z10", "X28 Plus",
                    "A73", "X19", "A55", "A50",
                    "X50 Plus", "X41 Plus", "A51", "A76+",
                    "A97", "X28", "P7+", "A48",
                    "X38", "A32", "A68", "X50",
                    "X17", "X81", "X46", "A89",
                    "A82", "A79", "A59", "A67",
                    "V2 s", "V2 3GB", "A76", "A72",
                    "X11", "A88", "Iris Fuel F2", "A71",
                    "P7", "V5", "X3", "Iris Atom 3",
                    "Iris Atom", "X10", "Iris Atom 2X", "Iris Atom X",
                    "Fuel F1", "Iris Fuel F1 Mini", "Flair E2", "Pixel V2",
                    "Iris Atom 2", "Flair Z1", "Pixel V1", "Flair P1i",
                    "Iris X1 Atom S", "Icon", "Iris X1 Grand", "Iris X1 mini",
                    "Iris Alfa", "Iris X8", "Iris 470", "Iris 465",
                    "Iris 401", "Iris 350", "Iris 348", "Iris 325 Style",
                    "Iris Fuel 60", "Iris Win1", "Iris 250", "Iris 400s",
                    "Iris 352 Flair", "Iris 404 Flair", "Iris 400Q", "Iris 410",
                    "Iris Fuel 50", "Iris 310 Style", "Iris 360 Music", "Iris 460",
                    "Iris X5", "Iris Pro 30+", "Iris 402e", "Iris 350m",
                    "3G 412", "Iris X1", "3G 415", "3G 354",
                    "Iris 504q+", "Iris 356", "Iris 450 Colour", "Iris 406Q",
                    "Iris 550Q", "Iris Pro 20", "Iris Pro 30", "Iris 401e",
                    "Iris 349S", "Iris 349+", "Iris 404e", "Iris 503e",
                    "Iris 506Q", "Iris 505", "Iris 504q", "3G 402+",
                    "3G 402", "Iris 405+", "Iris 503"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "LEECO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Le Pro 3 AI Edition", "Le Pro3 Elite", "Le S3", "Le Pro3",
                    "Le Max 2", "Le 2 Pro", "Le 2", "Le Max",
                    "Le 1s"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "LENOVO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "S5 Pro GT", "Z5s", "Z5 Pro GT", "Z5 Pro",
                    "S5 Pro", "K5 Pro", "K9", "Z5",
                    "K5 Note (2018)", "A5", "K5", "K5 play",
                    "S5", "K320t", "moto tab", "Tab 7 Essential",
                    "Tab 7", "K8 Plus", "K8", "K8 Note",
                    "Tab 4 10 Plus", "Tab 4 10", "Tab 4 8 Plus", "Tab 4 8",
                    "Tab3 8 Plus", "ZUK Edge", "A6600 Plus", "A6600",
                    "B", "A Plus", "P2", "K6 Note",
                    "K6 Power", "K6", "Yoga Tab 3 Plus", "Vibe A",
                    "C2 Power", "C2", "Phab2 Plus", "Phab2",
                    "Phab2 Pro", "ZUK Z2", "Vibe C", "ZUK Z2 Pro",
                    "Tab3 10", "Tab3 8", "Tab3 7", "Vibe K5 Plus",
                    "Vibe K5", "A7000 Turbo", "Vibe P1 Turbo", "K5 Note",
                    "Lemon 3", "Vibe S1 Lite", "Vibe K4 Note", "Vibe X3 c78",
                    "Vibe X3", "A3690", "Yoga Tab 3 Pro", "Yoga Tab 3 8.0",
                    "A1000", "Phab", "Phab Plus", "Vibe P1",
                    "A6010 Plus", "A6010", "Vibe P1m", "Vibe S1",
                    "ZUK Z1", "A2010", "A616", "A3900",
                    "K80", "S60", "A6000 Plus", "A1900",
                    "K3 Note", "Vibe Shot", "A7000 Plus", "A7000",
                    "A5000", "Tab 2 A10-70", "Tab 2 A8-50", "P70",
                    "Tab 2 A7-30", "Tab 2 A7-20", "Tab 2 A7-10", "A6000",
                    "P90", "Vibe X2 Pro", "K3", "Golden Warrior Note 8",
                    "A916", "A319", "S856", "S580",
                    "S90 Sisley", "A606", "Yoga Tablet 2 Pro", "Yoga Tablet 2 10.1",
                    "Yoga Tablet 2 8.0 ", "Tab S8", "Vibe X2", "Vibe Z2",
                    "A850+", "Vibe Z2 Pro", "Golden Warrior A8", "Golden Warrior S8",
                    "S939", "S750", "A889", "A680",
                    "A316i", "A328", "A536", "A526",
                    "A10-70 A7600", "A8-50 A5500", "A7-50 A3500", "A7-30 A3300",
                    "Yoga Tablet 10 HD+", "S860", "S850", "S660",
                    "A880", "A859", "S930", "S650",
                    "Vibe Z K910", "Yoga Tablet 10", "Yoga Tablet 8", "A630",
                    "A516", "Vibe X S960", "S5000", "A850",
                    "A706", "P780", "S820", "A390",
                    "A369i", "A269i", "S920", "IdeaTab S6000H",
                    "IdeaTab S6000F", "IdeaTab S6000L", "IdeaTab S6000", "IdeaTab A3000",
                    "IdeaTab A1000", "K900", "S890", "IdeaTab A2107",
                    "A830", "A820", "A800", "A789",
                    "A690", "S720", "P770", "A60+",
                    "S560", "S880", "A660", "K860",
                    "P700i", "A65", "A335", "A185",
                    "S800", "Q350", "Q330", "A336",
                    "E156", "LePhone S2", "A60", "K800",
                    "IdeaPad S2", "LePad S2010", "LePad S2007", "LePad S2005",
                    "IdeaPad A1", "IdeaPad K1", "ThinkPad", "A5860",
                    "ideapad", "Vibe Z3 Pro", "ZUK Z1 mini"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "LG")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Q9", "V40 ThinQ", "Watch W7", "Tribute Empire",
                    "Candy", "G7 Fit", "G7 One", "Q8",
                    "K11 Plus", "Q Stylo 4", "Q Stylus", "V35 ThinQ",
                    "Q7", "G7 ThinQ", "V30S ThinQ", "Zone 4",
                    "K30", "K10 (2018)", "K8 (2018)", "Aristo 2",
                    "X4+", "V30", "Q8 (2017)", "Q6",
                    "G Pad IV 8.0 FHD", "X venture", "G6", "X power2",
                    "Watch Sport", "Watch Style", "Stylo 3 Plus", "Stylus 3",
                    "Harmony", "K20 plus", "K10 (2017)", "K8 (2017)",
                    "K7 (2017)", "K4 (2017)", "K3 (2017)", "G Pad III 10.1 FHD",
                    "U", "V20", "X Skin", "X5",
                    "X max", "X mach", "G Pad III 8.0 FHD", "G Pad X 8.0",
                    "X power", "X style", "Stylus 2 Plus", "Stylo 2",
                    "K5", "K3", "G5 SE", "G5",
                    "X cam", "X screen", "K8", "Stylus 2",
                    "K10", "K7", "K4", "G Pad II 8.3 LTE",
                    "Ray", "G Vista 2", "G Watch R W110", "Watch Urbane W150",
                    "Watch Urbane 2nd Edition LTE", "V10", "Nexus 5X", "Zero",
                    "G Pad II 10.1", "G Pad II 8.0 LTE", "Wine Smart", "Tribute 2",
                    "Bello II", "G4 Beat", "G360", "G350",
                    "G4c", "G4 Dual", "G4", "G Stylo",
                    "G4 Stylus", "AKA", "Watch Urbane LTE", "G Watch W100",
                    "Magna", "Spirit", "Leon", "Joy",
                    "G Flex2", "Tribute", "L Prime", "G2 Lite",
                    "G3 Dual-LTE", "G3 Screen", "F60", "L60",
                    "L60 Dual", "G3 Stylus", "L Bello", "L Fino",
                    "G Pad 8.0 LTE", "G Vista", "G3 A", "G Pad 7.0 LTE",
                    "L50", "L30", "L20", "G Vista (CDMA)",
                    "G3 LTE-A", "G3 S Dual", "G3 S", "L65 D280",
                    "G3 (CDMA)", "G3", "450", "L35",
                    "Volt", "G Pad 10.1 LTE", "G Pad 10.1", "G Pad 8.0",
                    "G Pad 7.0", "L80", "L80 Dual", "Lucid 3 VS876",
                    "L65 Dual D285", "G Pad 8.3 LTE", "F70 D315", "G2 mini LTE (Tegra)",
                    "G2 mini LTE", "G2 mini", "L90 Dual D410", "L90 D405",
                    "L70 D320N", "L70 Dual D325", "L45 Dual X132", "L40 D160",
                    "L40 Dual D170", "G Pro 2", "Optimus L4 II Tri E470", "Optimus L1 II Tri E475",
                    "Optimus F3Q", "GX F310L", "Nexus 5", "G Flex",
                    "Fireweb", "G Pro Lite", "G Pro Lite Dual", "Optimus L2 II E435",
                    "Vu 3 F300L", "G Pad 8.3", "G2", "Optimus L9 II",
                    "Enact VS890", "Optimus GJ E975W", "Optimus L4 II Dual E445", "Optimus L4 II E440",
                    "Optimus Zone VS410", "Optimus F3", "Lucid2 VS870", "Optimus F7",
                    "Optimus F6", "Optimus F5", "Optimus G Pro E985", "Optimus L7 II Dual P715",
                    "Optimus L7 II P710", "Optimus L5 II Dual E455", "Optimus L5 II E460", "Optimus L3 II Dual E435",
                    "Optimus L3 II E430", "Optimus L1 II E410", "Nexus 4 E960", "A390",
                    "A395", "C299", "Tri Chip C333", "Spectrum II 4G VS930",
                    "Mach LS860", "Optimus L9 P769", "Optimus Vu II", "Optimus Vu II F200",
                    "Optimus G E970", "Optimus G LS970", "Optimus G E975", "Intuition VS950",
                    "Splendor US730", "Escape P870", "Optimus L5 Dual E615", "Optimus L9 P760",
                    "Motion 4G MS770", "Optimus Vu P895", "Optimus L3 E405", "C199",
                    "T385", "T375 Cookie Smart", "Optimus Elite LS696", "T370 Cookie Smart",
                    "Optimus LTE2", "Optimus True HD LTE P936", "Xpression C395", "Lucid 4G VS840",
                    "Optimus M+ MS695", "Optimus 4X HD P880", "Optimus 3D Max P720", "Optimus 3D Cube SU870",
                    "Optimus L7 P700", "Optimus L5 E610", "Optimus Vu F100S", "Optimus LTE Tag",
                    "Optimus L3 E400", "Optimus Pad LTE", "Rumor Reflex  LN272", "Connect 4G MS840",
                    "Viper 4G LTE LS840", "Spectrum VS920", "X350", "Prada 3.0",
                    "Nitro HD", "Optimus 4G LTE P935", "Optimus 2 AS680", "Extravert VN271",
                    "DoublePlay", "Enlighten VS700", "S367", "Jil Sander Mobile",
                    "Optimus Slider", "Optimus LTE SU640", "Optimus LTE LU6200", "Optimus EX SU880",
                    "Optimus Q2 LU6500", "Optimus Hub E510", "Optimus Sol E730", "Optimus Net Dual",
                    "Optimus Net", "Esteem MS910", "Marquee LS855", "Optimus Black (White version)",
                    "Optimus Pro C660", "S365", "A350", "A258",
                    "A250", "A270", "A230", "A290",
                    "A190", "A200", "T515 Cookie Duo", "T510",
                    "T505", "EGO T500", "EGO Wi-Fi", "C375 Cookie Tweet",
                    "C365", "C360", "A100", "Optimus Big LU6800",
                    "Cosmos 2", "US760 Genesis", "Phoenix P505", "Thrive P506",
                    "Thrill 4G P925", "T315", "Optimus 3D P920", "Optimus Pad V900",
                    "A180", "A165", "A160", "A140",
                    "Optimus Chat C550", "Optimus Me P350", "Optimus Black P970", "Optimus 2X SU660",
                    "Optimus 2X", "Optimus Mach LU3000", "Revolution", "X335",
                    "C310", "Cookie WiFi T310i", "GU200", "A120",
                    "A155", "S310", "P525", "P520",
                    "Axis", "Apex", "Cosmos Touch VN270", "Vortex VS660",
                    "C320 InTouch Lady", "GT550 Encore", "GS390 Prime", "Quantum",
                    "C900 Optimus 7Q ", "E900 Optimus 7", "Town C300", "Optimus Chic E720",
                    "Octane", "Optimus M", "Optimus S", "Optimus T",
                    "Optimus One P500", "GW910", "A130", "GW370 Rumour Plus",
                    "GD550 Pure", "KS365", "GM650s", "Scarlet II TV",
                    "Flick T320", "Cookie 3G T320", "Wink 3G T320", "C710 Aloha",
                    "Cookie Style T310", "Wink Style T310", "Cookie Lite T300", "C105",
                    "GX300", "GU292", "GM360 Viewty Snap", "Fathom VS750",
                    "Vu Plus", "GT400 Viewty Smile", "SU420 Cafe", "Optimus Z",
                    "SU920", "KM570 Cookie Gig", "Optimus Q LU2300", "GX500",
                    "GT950 Arena", "KH3900 Joypop", "GB280", "GS155",
                    "GS107", "GS106", "KP108", "GD350",
                    "KH5200 Andro-1", "GT540 Optimus", "GS290 Cookie Fresh", "GT405",
                    "GW990", "GS500 Cookie Plus", "GX200", "KF305",
                    "GW880", "GD880 Mini", "Wink Plus GT350i", "Etna C330",
                    "Town GT350", "KU2100", "GD580 Lollipop", "GS200",
                    "GS190", "GW820 eXpo", "GD710 Shine II", "GU230 Dimsun",
                    "GB160", "GU285", "8575 Samba", "KM555E",
                    "GD310 ", "GD510 Pop", "BL20 New Chocolate", "CF360",
                    "GW620", "GM750", "BL40 New Chocolate", "GW300",
                    "GB270", "GB190", "GB109", "GB170",
                    "GW550", "KB775 Scarlet", "GT500 Puccini", "GT505",
                    "GW520", "GD900 Crystal", "GC900 Viewty Smart", "GB230 Julia",
                    "GD330", "KS660", "GB125", "Xenon GR500",
                    "GB210", "GM200 Brio", "KC560", "KM900 Arena",
                    "GM730 Eigen", "KC910i Renoir", "GB250", "GB220",
                    "GB102", "KT770", "GB130", "GM310",
                    "GM210", "KM330", "GB110", "GB106",
                    "GD910", "CT810 Incite", "KP152", "KS500",
                    "KF900 Prada", "KC780", "KP500 Cookie", "KP501 Cookie",
                    "KP502 Cookie", "KC910 Renoir", "KB770", "CB630 Invision",
                    "KP270", "KF311", "CP150", "KP265",
                    "KP260", "KP199", "KP170", "GT365 Neon",
                    "KS360", "Univa E510", "KF390", "KF350",
                    "KF245", "KF240", "U370", "HB620T",
                    "KC550", "KF757 Secret", "KF750 Secret", "KF755 Secret",
                    "CU915 Vu", "KF700", "KF600", "KF510",
                    "KT610", "KP320", "KT520", "KM710",
                    "MG295", "KF310", "KF300", "KM500",
                    "KM386", "KM380", "KM338", "KG375",
                    "KP235", "KP220", "KP215", "KP210",
                    "KP130", "KP110", "KP105", "KP100",
                    "KU385", "KU380", "U960", "KG290",
                    "KG288", "KS20", "KU990 Viewty", "KE990 Viewty",
                    "KE590", "KE500", "KG280", "KG275",
                    "MG160", "KU580", "KE850 Prada", "KE970 Shine",
                    "KU970 Shine", "KE770 Shine", "CU720 Shine", "KU950",
                    "KS10", "KU311", "Trax CU575", "CU515",
                    "CU500V", "CE110", "KU250", "KE260",
                    "KE800", "KE820", "KU800", "U830",
                    "L343i", "L600v", "KP200", "KP202",
                    "CU500", "U400", "U310", "U300",
                    "KG800", "KG810", "KE600", "KG330",
                    "KG320", "KG300", "CG180", "KG270",
                    "KG200", "KG195", "KG920", "KU730",
                    "U900", "V9000", "KG245", "KG240",
                    "KG225", "KG220", "KG210", "KG190",
                    "KG130", "KG120", "KG110", "C2600",
                    "U890", "U8550", "M6100", "C2500",
                    "C1150", "S5300", "S5200", "S5100",
                    "S5000", "U880", "P7200", "B2250",
                    "B2070", "B2050", "M4410", "M4330",
                    "M4300", "F3000", "F2410", "F2250",
                    "L342i", "L341i", "C3400", "C3380",
                    "C3320", "C3310", "C3300", "U8380",
                    "U8360", "U8330", "U8290", "U8210",
                    "U8200", "U8180", "B2150", "B2100",
                    "B2000", "F2400", "F1200", "F7250",
                    "A7150", "L5100", "C2200", "C2100",
                    "G1800", "G1700", "G1610", "F2300",
                    "F2100", "L3100", "C3100", "G3100",
                    "L1100", "C1400", "C1200", "C1100",
                    "G1600", "T5100", "G7200", "G7120",
                    "U8150", "U8138", "U8120", "U8110",
                    "U8100", "G7100", "G7070", "G7050",
                    "G7030", "G1500", "G5500", "G5400",
                    "G5310", "G5300", "G8000", "G7020",
                    "W7020", "G7000", "W7000", "G5200",
                    "W5200", "G3000", "W3000", "B1200",
                    "LG 510w", "LG-600", "LG-500", "LG-200",
                    "Fantasy E740", "E2", "X3", "Optimus LTE",
                    "G4 Pro"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MAXON")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "MX-C90", "MX-C80", "MX-C180", "MX-A30",
                    "MX-C60", "MX-C20", "MX-C110", "MX-E10",
                    "MX-V30", "MX-V10", "MX-7990", "MX-E80",
                    "MX-7750", "MX-C11", "MX-C160", "MX-7940",
                    "MX-7920", "MX-7830", "MX-7600", "MX-6899"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MAXWEST")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Nitro 55M", "Nitro 55 LTE", "Nitro 5M", "Astro 5s",
                    "Gravity 5 LTE", "Astro X4", "Astro X55", "Vice",
                    "Gravity 5.5 LTE", "Gravity 5", "Astro 6", "Astro X5",
                    "Blade", "Astro 3.5", "Nitro 5", "Astro 4.5",
                    "Nitro Phablet 71", "Nitro 5.5", "Astro 5", "MX-110",
                    "Astro 4", "Astro JR", "Virtue Z5", "Gravity 5.5",
                    "Gravity 6", "Orbit 330G", "Orbit 6200T", "Android 330",
                    "Tab Phone 72DC", "MX-210TV", "Android 320", "Orbit 6200",
                    "Orbit 5400T", "Orbit 4400", "Orbit 3000", "Orbit X50",
                    "Orbit Z50", "Orbit 5400", "Orbit 4600", "MX-200TV",
                    "MX-100"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MEIZU")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "C9 Pro", "Zero", "C9", "Note 8",
                    "X8", "V8 Pro", "V8", "16X",
                    "16", "16 Plus", "M6T", "M8c",
                    "15 Plus", "15", "15 Lite", "E3",
                    "M6s", "M6", "M6 Note", "Pro 7 Plus",
                    "Pro 7", "M5c", "E2", "M5s",
                    "M5 Note", "M3x", "Pro 6 Plus", "MX5e",
                    "U10", "U20", "Pro 6s", "M5",
                    "M3 Max", "M3e", "MX6", "M3s",
                    "M3", "Pro 6", "M3 Note", "PRO 5 mini",
                    "M1 Metal", "PRO 5", "M2", "MX5",
                    "M2 Note", "M1", "M1 Note", "MX4 Pro",
                    "MX4", "MX3", "MX2", "MX 4-core",
                    "MX"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MICROMAX")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Infinity N12", "Infinity N11", "Bharat 5 Infinity", "Bharat Go",
                    "Canvas 1 2018", "Canvas Infinity Life", "Bharat 5 Pro", "Bharat 5 Plus",
                    "Bharat 5", "Canvas Infinity Pro", "Bharat 2 Ultra", "Dual 4 E4816",
                    "Canvas Selfie 3 Q460", "Bharat 4 Q440", "Bharat 3 Q437", "Bharat 2+",
                    "Selfie 2 Note Q4601", "Canvas Infinity", "Evok Dual Note E4815", "Selfie 2 Q4311",
                    "Canvas 1", "Canvas 2 Q4310", "Canvas Evok Power Q4260", "Canvas Evok Note E453",
                    "Bharat 2 Q402", "Dual 5", "Spark Vdeo Q415", "Vdeo 5",
                    "Vdeo 4", "Vdeo 3", "Vdeo 2", "Vdeo 1",
                    "Canvas Spark 4G Q4201", "Canvas Fire 6 Q428", "Canvas 5 Lite Q462", "Bolt Q381",
                    "Canvas Mega 2 Q426", "Canvas Spark 2 Plus Q350", "Canvas Spark 3 Q385", "Canvas Amaze 2 E457",
                    "Canvas xp 4G Q413", "Bolt Supreme 2 Q301", "Bolt Supreme Q300", "Canvas Evok E483",
                    "Bolt Selfie Q424", "Bolt supreme 4 Q352", "Canvas Selfie 4", "Unite 4 plus",
                    "Canvas Unite 4", "Canvas Unite 4 Pro", "Canvas Fire 5 Q386", "Canvas 6 Pro E484",
                    "Canvas 6", "Canvas Juice 4G Q461", "Canvas Amaze 4G Q491", "Canvas Juice 4 Q382",
                    "Canvas Pulse 4G E451", "Canvas Mega 4G Q417", "Canvas Fire 4G Plus Q412", "Canvas Nitro 3 E352",
                    "Canvas Xpress 4G Q413", "Canvas Blaze 4G+ Q414", "Canvas Pace 4G Q416", "Canvas 5 E481",
                    "Canvas Mega E353", "Canvas Amaze Q395", "Canvas Play 4G Q469", "Bolt Q332",
                    "Canvas Juice 3+ Q394", "Bolt Q339", "Bolt Q338", "Bolt Q331",
                    "Bolt S302", "Canvas Fire 4G Q411", "Canvas Blaze 4G Q400", "Canvas Juice 3 Q392",
                    "Canvas Spark 2 Q334", "Canvas Nitro 4G E455", "Canvas Selfie 3 Q348", "Canvas Selfie 2 Q340",
                    "Canvas Xpress 2 E313", "Bolt D303", "Bolt S301", "Canvas Selfie Lens Q345",
                    "Canvas Sliver 5 Q450", "Canvas Tab P690", "Canvas Knight 2 E471", "Canvas A1 AQ4502",
                    "Q391 Canvas Doodle 4", "Canvas Nitro 2 E311", "Q372 Unite 3", "Canvas Play Q355",
                    "Canvas Spark Q380", "Bolt S300", "Bolt D320", "Bolt D321",
                    "Canvas Juice 2 AQ5001", "Bolt Q324", "Bolt A82", "Canvas Pep Q371",
                    "Bolt A067", "Canvas 4 Plus A315", "A109 Canvas XL2", "Canvas Fire 4 A107",
                    "Canvas Tab P666", "Canvas Tab P470", "Canvas Selfie A255", "Bolt A066",
                    "Canvas Hue", "A104 Canvas Fire 2", "A99 Canvas Xpress", "A290 Canvas Knight Cameo",
                    "Canvas A1", "A310 Canvas Nitro", "A092 Unite", "A65 Bolt",
                    "A108 Canvas L", "A190 Canvas HD Plus", "A093 Canvas Fire", "A300 Canvas Gold",
                    "Canvas Win W121", "Canvas Win W092", "A089 Bolt", "A106 Unite 2",
                    "A105 Canvas Entice", "X352", "A121 Canvas Elanza 2", "A120 Canvas 2 Colors",
                    "A102 Canvas Doodle 3", "A47 Bolt", "X281", "X267",
                    "X098", "A114R Canvas Beat", "A59 Bolt", "A36 Bolt",
                    "A28 Bolt", "A350 Canvas Knight", "Canvas Turbo Mini", "A94 Canvas MAd",
                    "A119 Canvas XL", "A114 Canvas 2.2", "A61 Bolt", "A77 Canvas Juice",
                    "A117 Canvas Magnus", "Canvas Turbo", "Canvas Tab P650", "A113 Canvas Ego",
                    "A76", "A74 Canvas Fun", "A67 Bolt", "A63 Canvas Fun",
                    "A240 Canvas Doodle 2", "A92", "Canvas 4 A210", "A88",
                    "A110Q Canvas 2 Plus", "X322", "X321", "X295",
                    "X286", "X278", "X099", "GC333",
                    "X396", "X335C", "A111 Canvas Doodle", "Funbook 3G P600",
                    "Funbook 3G P560", "Funbook Talk P362", "Funbook Talk P360", "Viva A72",
                    "Ninja A91", "Ninja A54", "Bolt A62", "Bolt A51",
                    "Bolt A35", "Bolt A27", "A115 Canvas 3D", "A116 Canvas HD",
                    "A101", "A110 Canvas 2", "A89 Ninja", "A87 Ninja 4.0",
                    "A57 Ninja 3.0", "Funbook Infinity P275", "Funbook Alfa P250", "Funbook Pro",
                    "A100", "A90s", "A90", "A84",
                    "A80 ", "Superfone Punk A44", "A25", "X101",
                    "X291", "X277", "X276", "X246",
                    "X234+", "A56", "A52", "A45",
                    "X660", "X640", "X368", "X335",
                    "X288", "X274", "X233", "X231",
                    "X102", "A50 Ninja", "A78", "Funbook P300",
                    "A73", "X650", "X490", "X333",
                    "X275", "X271", "X11i", "A75",
                    "X270", "X256", "X78", "X55 Blade",
                    "X285", "A55", "X40", "X450",
                    "X222", "Q80", "A85", "A70",
                    "X410", "X395", "X266", "X265",
                    "M2", "Q66", "X370", "X226+",
                    "Q50", "X560", "A60", "X600",
                    "X550 Qube", "X510 Pike", "X500", "X310",
                    "X2i", "X118", "X100", "X1i",
                    "GC700", "GC400", "GC360", "GC275",
                    "Q75", "Q6", "Q7", "G4",
                    "W900", "X330", "H360", "Q1",
                    "Q2", "Q3", "Q5 fb", "Q55 Bling",
                    "X1i plus", "X2i plus", "X111", "X114",
                    "X215", "X220", "X225", "X235",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MICROSOFT")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Lumia 650", "Lumia 950 XL Dual SIM", "Lumia 950 XL", "Lumia 950 Dual SIM",
                    "Lumia 950", "Lumia 550", "Lumia 540 Dual SIM", "Lumia 430 Dual SIM",
                    "Lumia 640 XL LTE Dual SIM", "Lumia 640 XL LTE", "Lumia 640 XL Dual SIM", "Lumia 640 XL",
                    "Lumia 640 LTE Dual SIM", "Lumia 640 LTE", "Lumia 640 Dual SIM", "Lumia 532 Dual SIM",
                    "Lumia 532", "Lumia 435 Dual SIM", "Lumia 435", "Lumia 535 Dual SIM",
                    "Lumia 535", "Surface 2", "Surface", "Kin TWOm",
                    "Kin ONEm", "Kin Two", "Kin One", "Lumia 1030",
                    "Lumia 1330", "Lumia 850",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MITAC")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "MIO Explora K75", "MIO Explora K70", "MIO Leap G50", "MIO Leap K1",
                    "MIO A502", "MIO A501", "MIO A702", "MIO A701",
                    "MIO 8870", "MIO 8860", "MIO 8390", "MIO 8380"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MITSUBISHI")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "M430i/M900", "M800", "M420i/M760", "M528",
                    "M520", "M350", "M750", "M342i",
                    "M341i/M720", "M330", "m21i", "M320",
                    "Trium Eclipse", "Trium Sirius", "Trium Neptune", "Trium Mars",
                    "Trium Geo-@", "Trium Mondo", "Trium xs", "Trium fx",
                    "Trium Cosmo", "Trium Aria", "Trium Geo", "Trium Astral",
                    "Trium Galaxy"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MODU")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "T", "Night jacket", "Sport jacket", "Speedy jacket",
                    "Shiny jacket", "Mini jacket", "Express jacket", "Phone",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "MOTOROLA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Moto G7 Plus", "Moto G7", "Moto G7 Power", "Moto G7 Play",
                    "One (P30 Play)", "One Power (P30 Note)", "Moto Z3", "Moto Z3 Play",
                    "Moto E5 Play Go", "Moto E5 Play", "Moto E5 Plus", "Moto E5",
                    "Moto G6 Play", "P30", "Moto G6 Plus", "Moto G6",
                    "Moto X4", "Moto X5", "Moto G5S Plus", "Moto G5S",
                    "Moto Z2 Force", "Moto E4 Plus", "Moto E4 Plus (USA)", "Moto E4",
                    "Moto E4 (USA)", "Moto Z2 Play", "Moto C Plus", "Moto C",
                    "Moto G5 Plus", "Moto G5", "Moto M", "Moto E3 Power",
                    "Moto Z Play", "Moto E3", "Moto Z Force", "Moto Z",
                    "Moto G4 Plus", "Moto G4", "Moto G4 Play", "Moto G Turbo",
                    "Moto X Force", "Droid Turbo 2", "Droid Maxx 2", "Moto X Style",
                    "Moto X Play Dual SIM", "Moto X Play", "Moto G Dual SIM (3rd gen)", "Moto 360 Sport (1st gen)",
                    "Moto 360 46mm (2nd gen)", "Moto 360 42mm (2nd gen)", "Moto 360 (1st gen)", "Moto G (3rd gen)",
                    "Moto E Dual SIM (2nd gen)", "Moto E (2nd gen)", "Moto G 4G (2nd gen)", "Moto G 4G Dual SIM (2nd gen)",
                    "Moto Maxx", "DROID Turbo", "Nexus 6", "Moto X (2nd Gen)",
                    "Moto G Dual SIM (2nd gen)", "Moto G (2nd gen)", "Moto G 4G", "Luge",
                    "Moto E", "Moto E Dual SIM", "Moto G Dual SIM", "Moto G",
                    "Moto X", "DROID Ultra", "DROID Maxx", "DROID Mini",
                    "RAZR D3 XT919", "RAZR D1", "Electrify M XT905", "RAZR i XT890",
                    "DROID RAZR MAXX HD", "DROID RAZR HD", "RAZR HD XT925", "DROID RAZR M",
                    "RAZR M XT905", "DEFY XT XT556", "Electrify 2 XT881", "Photon Q 4G LTE XT897",
                    "Defy Pro XT560", "ATRIX HD MB886", "XT760", "ATRIX TV XT687",
                    "ATRIX TV XT682", "MotoGO TV EX440", "Motosmart Me XT303", "MOTOKEY 3-CHIP EX117",
                    "RAZR V XT885", "RAZR V XT889", "RAZR V MT887", "MOTOSMART MIX XT550",
                    "MotoGO EX430", "Motosmart Flip XT611", "XT390", "RAZR MAXX",
                    "DEFY XT535", "GLEAM+ WX308", "DROID 4 XT894", "DROID RAZR MAXX",
                    "Motoluxe MT680", "Motoluxe XT389", "Motoluxe", "Defy Mini XT321",
                    "Defy Mini XT320", "XT319", "WX306", "Fire",
                    "MT917", "XT928", "DROID XYBOARD 8.2 MZ609 ", "DROID XYBOARD 10.1 MZ617",
                    "XT532", "MOTO XT615", "EX226", "Motokey Social",
                    "XOOM 2 Media Edition 3G MZ608", "XOOM 2 Media Edition MZ607", "XOOM 2 3G MZ616", "XOOM 2 MZ615",
                    "XOOM Media Edition MZ505", "RAZR XT910", "DROID RAZR XT912", "ATRIX 2 MB865",
                    "Admiral XT603", "ME632", "PRO+", "DEFY+",
                    "EX212", "EX119", "MOTOKEY XT EX118", "MOTOKEY Mini EX109",
                    "MOTOKEY Mini EX108", "WX294", "FIRE XT", "FIRE XT311",
                    "SPICE Key XT317", "SPICE Key", "MILESTONE 3 XT860", "DROID 3",
                    "Triumph", "Photon 4G MB855", "EX232", "WILDER",
                    "MOTO MT870", "MOTO MT620", "Milestone XT883", "MOTO XT882",
                    "MOTO XT316", "XPRT MB612", "GLEAM", "PRO",
                    "XOOM MZ604", "XOOM MZ601", "XOOM MZ600", "ATRIX",
                    "ATRIX 4G", "Cliq 2", "DROID BIONIC XT875", "DROID X ME811",
                    "DROID BIONIC XT865", "MOTO ME525", "MILESTONE 2 ME722", "DROID 2 Global",
                    "EX122", "EX128", "MOTOTV EX245", "DROID PRO XT610",
                    "XT301", "SPICE XT300", "FLIPSIDE MB508", "MOTO MT716",
                    "BRAVO MB520", "CITRUS WX445", "EX300", "EX210",
                    "EX201", "EX115", "EX112", "CUPE",
                    "DEFY", "MILESTONE 2", "DROID 2", "MT810lx",
                    "XT810", "XT806", "A1260", "A1680",
                    "Grasp WX404", "Rambler", "CHARM", "ES400",
                    "DROID X2", "DROID X", "MILESTONE XT720", "XT720 MOTOROI",
                    "Quench XT5 XT502", "Quench XT3 XT502", "FlipOut", "WX295",
                    "WX290", "WX265", "WX260", "WX181",
                    "WX161", "QUENCH", "BACKFLIP", "XT800 ZHISHANG",
                    "XT701", "MT710 ZHILING", "MOTO XT702", "MILESTONE",
                    "WX395", "WX390", "WX288", "WX280",
                    "WX180", "WX160", "Motocubo A45", "DEXT MB220",
                    "ROKR ZN50", "Karma QA1", "L800t", "W7 Active Edition",
                    "ROKR W6", "MC55", "ZN300", "E11",
                    "A3100", "A3000", "Tundra VA76r", "W233 Renew",
                    "COCKTAIL VE70", "VE66", "EM35", "Aura",
                    "Q 11", "VE538", "RAZR2 V9x", "ZN200",
                    "W396", "W231", "EM30", "EM28",
                    "EM25", "PEBL VU20", "MOTOACTV W450", "VE75",
                    "ZN5", "A1210", "A1600", "A1890",
                    "A1800", "A810", "W388", "Z9",
                    "Z6w", "Z6c", "W181", "W177",
                    "W161", "W270", "W230", "RIZR Z10",
                    "ROKR E8", "W377", "W213", "W180",
                    "W160", "U9", "V1100", "PEBL U3",
                    "RAZR2 V9", "RAZR2 V8", "ROKR W5", "W490",
                    "W395", "W380", "W360", "W218",
                    "RIZR Z8", "KRZR K3", "SLVR L9", "Q 9h",
                    "Q8", "W510", "W215", "W205",
                    "ROKR Z6", "ROKR E6", "SLVR L7e", "RAZR maxx V6",
                    "RAZR V3xx", "RIZR Z3", "KRZR K1", "W375",
                    "W209", "W208", "MOTOFONE F3", "W220",
                    "V195", "V191", "ROKR E2", "RAZR V3i",
                    "ROKR E1", "A910", "A1200", "A728",
                    "A732", "E895", "V3x", "E1070",
                    "E770", "SLVR L7", "PEBL U6", "A1010",
                    "E1060", "E1120", "V1050", "C261",
                    "C257", "C168", "C139", "C123",
                    "C118", "C117", "C113a", "C113",
                    "C390", "E680i", "V560", "V557",
                    "V361", "V360", "L6", "L2",
                    "V235", "V230", "V186", "V176",
                    "E378i", "V635", "A668", "V980",
                    "C980", "V535", "V547", "E375",
                    "RAZR V3", "A780", "Droid Bionic Targa", "Droid XTreme",
                    "V975", "C975", "V620", "V555",
                    "A840", "E680", "E398", "C650",
                    "V226", "V188", "V171", "C155",
                    "C116", "C115", "MPx", "MPx220",
                    "MPx100", "V872", "V1000", "E1000",
                    "A1000", "A768i", "A630", "C380/C385",
                    "V80", "C289", "C205", "V400p",
                    "V220", "V180", "V878", "A925",
                    "A920", "V750", "MPx200", "V690",
                    "V525", "V501", "V500", "V303",
                    "V300", "V600", "V150", "E390",
                    "C550", "C450", "C250", "C230",
                    "C200", "A835", "A830", "A760",
                    "V295", "V291", "V290", "A388c",
                    "C350", "T725", "T720i", "T720",
                    "T190", "E380", "E365", "E360",
                    "V70", "C336", "C333", "C332",
                    "C331", "C300", "V60i", "V66i",
                    "Accompli 388", "V60", "Accompli 008", "Timeport 280",
                    "Timeport 260", "Timeport 250", "Talkabout T192", "Talkabout T191",
                    "Accompli 009", "V.box(V100)", "V66", "V50",
                    "T180", "A6188", "v8088", "Talkabout T2288",
                    "V2288", "Timeport P7389", "Timeport L7089", "V3690",
                    "V3688", "StarTAC 130", "StarTAC 85", "StarTAC Rainbow",
                    "StarTAC 75+", "StarTAC 75", "SlimLite", "cd930",
                    "cd920", "M3188", "M3288", "M3588",
                    "M3688", "M3788", "M3888", "d520"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "NEC")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Terrain", "804N", "e1108", "N344i",
                    "e373", "e636", "N500i", "N500iS",
                    "N908", "N938", "e353", "e121",
                    "e122", "e949/L1", "N600i", "e540/N411i",
                    "N401i", "N343i", "N900iG", "N200",
                    "N160", "N923", "N150", "e238",
                    "N940", "N930", "N630", "N850",
                    "N840", "N750", "802", "N342i",
                    "N500", "e101", "N110", "N109",
                    "N100", "N920", "e338", "N620",
                    "N610", "e228", "N410i", "N400i",
                    "N331i", "e313", "N910", "N900",
                    "N830", "N820", "N710", "N700",
                    "N600", "c616v", "e616", "e808y",
                    "e808", "e606", "e530", "e525",
                    "e232", "N341i", "N223i", "N22i",
                    "N21i", "DB7000", "DB6000", "DB5000",
                    "DB4100", "DB4000", "DB2000", "DB500",
                    "G9D+"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "NIU")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Andy C5.5E2I", "Andy 3.5E2I", "Andy 4E2I", "Andy 5EI",
                    "Andy 5T", "C21A", "F10", "Z10",
                    "Tek 5D", "Tek 4D2", "Niutek 3.5D2", "GO 21",
                    "Niutek 4.5D", "Niutek 4.0D", "Niutek 3.5D", "GO 20",
                    "Niutek 3.5B", "LIV 10", "GO 50", "Niutek 3G 3.5 N209",
                    "Niutek 3G 4.0 N309", "Pana 3G TV N206", "GO 80", "Domo N102",
                    "Bingo N103", "Lotto N104", "Pana N105", "Pana TV N106",
                    "NiutekQ N108", "Niutek N109"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "NOKIA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "8.1 (Nokia X7)", "106 (2018)", "3.1 Plus", "7.1",
                    "6.1 Plus (Nokia X6)", "5.1 Plus (Nokia X5)", "5.1", "3.1",
                    "2.1", "8110 4G", "8 Sirocco", "7 plus",
                    "6.1", "1", "3310 4G", "2",
                    "7", "3310 3G", "8", "105 (2017)",
                    "130 (2017)", "3", "5", "6",
                    "3310 (2017)", "150", "216", "230 Dual SIM",
                    "230", "222 Dual SIM", "222", "105 Dual SIM (2015)",
                    "105 (2015)", "215", "215 Dual SIM", "Lumia 638",
                    "N1", "Lumia 730 Dual SIM", "Lumia 735", "Lumia 830",
                    "130 Dual SIM", "130", "Lumia 530 Dual SIM", "Lumia 530",
                    "X2 Dual SIM", "225", "225 Dual SIM", "Lumia 930",
                    "Lumia 635", "Lumia 630 Dual SIM", "Lumia 630", "XL",
                    "X+", "X", "Asha 230", "220",
                    "Lumia Icon", "Lumia 525", "Lumia 1520", "Lumia 1320",
                    "Lumia 2520", "Asha 503 Dual SIM", "Asha 503", "Asha 502 Dual SIM",
                    "Asha 500 Dual SIM", "Asha 500", "108 Dual SIM", "515",
                    "107 Dual SIM", "106", "Lumia 625", "Lumia 1020",
                    "208", "207", "Lumia 925", "Lumia 928",
                    "Asha 501", "Asha 210", "Lumia 720", "Lumia 520",
                    "301", "105", "Asha 310", "Lumia 505",
                    "Lumia 620", "114", "206", "Asha 205",
                    "109", "Lumia 822", "Lumia 510", "Lumia 810",
                    "Asha 309", "Asha 308", "Lumia 920", "Lumia 820",
                    "Asha 311", "Asha 306", "Asha 305", "113",
                    "112", "111", "110", "Lumia 610 NFC",
                    "103", "808 PureView", "800c", "Lumia 610",
                    "Asha 302", "Asha 203", "Asha 202", "Lumia 900",
                    "Lumia 900 AT&T", "801T", "X2-02", "Lumia 800",
                    "Lumia 710 T-Mobile", "Lumia 710", "Asha 303", "Asha 300",
                    "Asha 201", "Asha 200", "603", "C2-05",
                    "X2-05", "C5-06", "C5-05", "C5-04",
                    "101", "100", "701", "700",
                    "600", "C3-01 Gold Edition", "500", "N9",
                    "C5 5MP", "C2-06", "C2-03", "C2-02",
                    "702T", "T7", "N950", "Oro",
                    "X1-01", "X7-00", "E6", "C7 Astound",
                    "X1-00", "X2-01", "C2-01", "C5-03",
                    "E7", "C6-01", "C7", "C3-01 Touch and Type",
                    "5250", "X3 Touch and Type S", "X3-02 Touch and Type", "X6 8GB (2010)",
                    "X5-01", "5233", "E73 Mode", "C2-00",
                    "C1-02", "C1-01", "C1-00", "N8",
                    "X2-00", "C6", "E5", "C3",
                    "C5", "C5 TD-SCDMA", "X5 TD-SCDMA", "6303i classic",
                    "5132 XpressMusic", "X6 16GB (2010)", "2710 Navigation Edition", "X6 (2009)",
                    "6700 slide", "7230", "5330 Mobile TV Edition", "2690",
                    "2220 slide", "1800", "1616", "1280",
                    "5235 Comes With Music", "6788", "N97 mini", "X3",
                    "N900", "5230", "3208c", "5800 Navigation Edition",
                    "6350", "Mural", "6760 slide", "6790 Surge",
                    "3720 classic", "5530 XpressMusic", "E72", "3710 fold",
                    "6730 classic", "6600i slide", "7020", "2720 fold",
                    "2730 classic", "E52", "6216 classic", "5730 XpressMusic",
                    "5330 XpressMusic", "5030 XpressRadio", "N86 8MP", "E75",
                    "E55", "6720 classic", "6710 Navigator", "5630 XpressMusic",
                    "6700 classic", "6303 classic", "2700 classic", "6208c",
                    "8800 Gold Arte", "N97", "6260 slide", "E63",
                    "7100 Supernova", "5130 XpressMusic", "2330 classic", "2323 classic",
                    "1662", "1661", "1202", "5800 XpressMusic",
                    "N85", "N79", "8800 Carbon Arte", "3610 fold",
                    "7610 Supernova", "7510 Supernova", "7310 Supernova", "7210 Supernova",
                    "E71", "E66", "6600 fold", "703",
                    "6600 slide", "3600 slide", "5320 XpressMusic", "5220 XpressMusic",
                    "6212 classic", "5000", "7070 Prism", "2680 slide",
                    "1680 classic", "6300i", "N96", "N78",
                    "6220 classic", "6210 Navigator", "6124 classic", "6650 fold",
                    "3555", "3120 classic", "7900 Crystal Prism", "2600 classic",
                    "1209", "3110 Evolve", "N82", "8800 Sapphire Arte",
                    "8800 Arte", "6301", "E51", "E51 camera-free",
                    "6263", "N81 8GB", "N81", "N95 8GB",
                    "5610 XpressMusic", "5310 XpressMusic", "6555", "7900 Prism",
                    "7500 Prism", "8600 Luna", "6500 slide", "6500 classic",
                    "N810", "3500 classic", "2630", "N87",
                    "6267", "2760", "2660", "1650",
                    "1208", "1200", "6120 classic", "6121 classic",
                    "5700", "5070", "E90", "E65",
                    "E61i", "N77", "6110 Navigator", "N800",
                    "3109 classic", "3110 classic", "N76", "N93i",
                    "6290", "6086", "6300", "2626",
                    "N95", "N75", "5300", "5200",
                    "6288", "6085", "8800 Sirocco", "7390",
                    "7373", "6151", "6080", "1110i",
                    "E50", "5500 Sport", "N93", "N73",
                    "N72", "2610", "2310", "1112",
                    "6136", "6133", "6131", "6126",
                    "6070", "6125", "6103", "6233",
                    "6234", "6282", "9300i", "N92",
                    "N80", "N71", "7380", "7370",
                    "7360", "E70", "E62", "E61",
                    "E60", "3250", "6708", "6280",
                    "6270", "6111", "6060", "N91",
                    "N90", "N70", "2652", "1600",
                    "1110", "1101", "5140i", "8800",
                    "6230i", "6021", "6030", "6680",
                    "6681", "6101", "6822", "7710",
                    "6020", "3230", "6670", "7280",
                    "7270", "7260", "9300", "6630",
                    "6260", "6170", "3128", "2650",
                    "2600", "3220", "N-Gage QD", "3120",
                    "7610", "9500", "5140", "6610i",
                    "3108", "7700", "7200", "6230",
                    "6820", "6810", "3660", "7600",
                    "3200", "2300", "1100", "6620",
                    "6600", "3100", "7250i", "6108",
                    "6220", "3300", "N-Gage", "7250",
                    "8910i", "6800", "6100", "5100",
                    "2100", "6650", "3650", "3530",
                    "3510i", "6610", "3610", "9210i Communicator",
                    "7210", "6310i", "3510", "3410",
                    "7650", "8910", "6510", "6500",
                    "8855", "5210", "5510", "8310",
                    "6310", "3350", "3330", "8250",
                    "9210 Communicator", "3310", "8890", "8210",
                    "8850", "6250", "8810", "6210",
                    "7110", "9110i Communicator", "9000 Communicator", "3210",
                    "6150", "6130", "6110", "5110",
                    "3110", "8110", "2110"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "NVIDIA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Shield K1", "Shield LTE", "Shield"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "O2")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "XDA Serra", "XDA Guide", "XDA Zest", "XDA Ignito",
                    "XDA Stellar", "XDA Orbit II", "XDA Comet", "XDA Nova",
                    "XDA Terra", "XDA Argon", "XDA Star", "Cocoon",
                    "XDA Flame", "XDA Atom Life", "XDA Zinc", "XDA Graphite",
                    "XDA Orbit", "Cosmo", "XDA Stealth", "Jet",
                    "Ice", "XDA Atom Exec", "XDA Trion", "XDA Neo",
                    "XDA Atom", "XDA Orion", "XDA Exec", "XDA mini S",
                    "X2i", "X7", "XDA phone", "Xphone IIm",
                    "X1b", "XM", "X4", "XDA II mini",
                    "XDA IIs", "XDA IIi", "Xphone II", "X3",
                    "X2", "X1i", "XDA II", "Xphone",
                    "XDA"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ONEPLUS")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "6T McLaren", "6T", "6", "5T",
                    "5", "3T", "3", "X",
                    "2", "One"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "OPPO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "A7", "R15x", "RX17 Neo", "K1",
                    "A7x", "RX17 Pro", "R17", "F9 (F9 Pro)",
                    "A3s", "A5", "Find X Lamborghini", "Find X",
                    "F7 Youth", "A3", "F7", "R15 Pro",
                    "R15", "A1", "A71 (2018)", "A83",
                    "F5 Youth", "F5", "R11s Plus", "R11s",
                    "A71", "A77", "R11 Plus", "R11",
                    "A77 (Mediatek)", "A39", "F3", "F3 Plus",
                    "A57", "F1s", "R9s Plus", "R9s",
                    "A37", "A59", "R9 Plus", "F1 Plus",
                    "F1", "A53", "A33", "Neo 7",
                    "R7s", "R7 lite", "R5s", "Mirror 5s",
                    "Mirror 5", "Joy 3", "R7 Plus", "R7",
                    "Neo 5 (2015)", "Neo 5s", "Joy Plus", "Mirror 3",
                    "A31", "R1x", "U3", "R5",
                    "N3", "R1S", "Neo 3", "Find 5 Mini",
                    "R2001 Yoyo", "R1001 Joy", "Neo 5", "N1 mini",
                    "R3", "Find 7", "Find 7a", "Neo",
                    "R1 R829T", "N1", "R819", "Find 5",
                    "U705T Ulike 2", "R601", "R821T FInd Muse", "R811 Real",
                    "T29", "R817 Real", "R815T Clover", "Find",
                    "U701 Ulike"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ORANGE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Rono", "Gova", "Reyo", "Hiro",
                    "San Diego", "Tahiti", "Monte Carlo", "San Francisco II",
                    "Sydney", "Miami", "Malibu", "Dallas",
                    "San Francisco", "Stockholm", "Atlanta", "Rio II",
                    "Barcelona", "Rio"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "PALM")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Palm", "Pre 2", "Pre 2 CDMA", "Pixi Plus",
                    "Pre Plus", "Pixi", "Pre", "Treo Pro",
                    "Centro", "Treo 500v", "Treo 750", "Treo 680",
                    "Treo 750v", "Treo 650", "Treo 600", "Treo 270"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "PANASONIC")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "P85 Nxt", "Eluga Z1 Pro", "Eluga Ray 530", "Eluga Ray 600",
                    "Eluga X1 Pro", "P90", "P95", "Eluga I7",
                    "Eluga Ray 550", "P101", "P100", "Eluga I9",
                    "Eluga C", "P91", "Eluga I5", "Eluga A4",
                    "P99", "Eluga I4", "Eluga Ray 500", "Eluga Ray 700",
                    "P9", "Eluga I2 Activ", "Eluga A3 Pro", "Eluga A3",
                    "P55 Max", "Eluga i3 Mega", "P85", "Eluga Ray",
                    "Eluga Mark 2", "Eluga Ray X", "Eluga Ray Max", "Eluga Pulse X",
                    "Eluga Pulse", "P88", "P55 Novo", "P77",
                    "Eluga Tapp", "Eluga Arc 2", "Eluga Note", "Eluga A2",
                    "Eluga I3", "Eluga I2 (2016)", "Eluga Arc", "P66",
                    "Eluga Turbo", "T50", "Eluga Mark", "Eluga Switch",
                    "Eluga L2", "Eluga I2", "T45", "Eluga Icon",
                    "Eluga Z", "Eluga L 4G", "Eluga S mini", "Eluga U2",
                    "Eluga S", "P61", "T41", "T40",
                    "P55", "Eluga I", "Lumix Smart Camera CM1", "Eluga A",
                    "Eluga U", "P81", "T31", "T21",
                    "P11", "T11", "P51", "P41",
                    "Eluga Power", "Eluga DL1", "Toughpad FZ-A1", "Toughpad JT-B1",
                    "KX-TU311", "KX-TU301", "VS7", "VS6",
                    "VS3", "VS2", "MX7", "MX6",
                    "SA7", "SA6", "SC3", "A210",
                    "X800", "Z800", "X700", "X500",
                    "X400", "X300", "X200", "X100",
                    "A500", "A200", "A100 Series", "P341i",
                    "X68/X77", "X11", "G70", "G51",
                    "X88", "X66", "X70", "G60",
                    "G50", "GD55", "GD87", "GD67",
                    "GD95", "GD75", "GD35", "GD93",
                    "GD92", "GD90", "GD70", "GD30",
                    "G600"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "PANTECH")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Breeze IV", "Vega No 6", "Discover", "Vega R3 IM-A850L",
                    "Flex  P8010", "Renue", "Marauder", "Vega Racer 2 IM-A830L",
                    "Vega LTE EX IM-A820L", "Burst", "Element", "Hotshot",
                    "Link II", "Pocket P9060", "Jest II", "Pursuit II",
                    "Breakout", "Breeze III", "Vega Xpress IM-A720L", "S902",
                    "Crux", "Laser P9050", "P4000", "P1000",
                    "SKY Izar IM-A630K", "Jest", "Link", "Ease",
                    "Pursuit", "Impact", "C790 Reveal", "Matrix Pro",
                    "Slate", "Matrix", "Duo", "U-4000",
                    "PG-3300", "PU-5000", "PG-1600", "PG-1800",
                    "PG-1300", "PG-3900", "PG-1900", "PG-2800",
                    "PG-3600V", "PG-3600", "PG-3500", "PG-1500",
                    "PG-8000", "PG-6200", "PG-6100", "PG-1400",
                    "PG-1200", "PG-3200", "PG-1000s", "GF500",
                    "PG3000", "GF100", "G670", "GI100",
                    "GF200", "GB300", "GB200", "GB100",
                    "G900", "G600", "G800", "G700",
                    "G500", "G300", "G200", "Q80"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "PARLA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Minu P124", "Sonic 3.5S", "Minu P123", "Sonic 3.5",
                    "Zum Bianco", "Minu", "Gala", "Spriz",
                    "Mist", "Zum",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "PHILIPS")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "S337", "S309", "V377", "V787",
                    "S616", "I928", "V526", "I908",
                    "S396", "S388", "S308", "W6610",
                    "W8578", "W3500", "W8555", "W7555",
                    "W9588", "W8568", "W8500", "W6500",
                    "W3568", "T3566", "W7376", "X1560",
                    "X2560", "X2301", "X2300", "X1510",
                    "E1500", "D833", "W8560", "W8510",
                    "T939", "W6360", "W5510", "W8355",
                    "W832", "W737", "W736", "W6350",
                    "W536", "W337", "T539", "E133",
                    "W732", "X333", "W930", "X130",
                    "X332", "X331", "D633", "W632",
                    "W635", "X528", "T129", "W820",
                    "D822", "W727", "X125", "W626",
                    "X623", "W920", "V726", "X622",
                    "W625", "X223", "X525", "D813",
                    "W725", "W715", "X526", "D613",
                    "Xenium X519", "F322", "X128", "D612",
                    "Xenium X523", "X516", "F515", "X815",
                    "X518", "D812", "X216", "Xenium X713",
                    "V816", "T910", "X116", "F718",
                    "Xenium X513", "Xenium F511", "D900", "F610",
                    "X712", "X703", "X809", "Xenium X503",
                    "Xenium K600", "X606", "X510", "X605",
                    "V900", "X100", "C702", "X603",
                    "D908", "Xenium X806", "X312", "X320",
                    "X650", "Xenium X501", "Xenium K700", "V808",
                    "X550", "E102", "Xenium X830", "C700",
                    "TM700", "X630", "C600", "W186",
                    "X810", "Xenium X520", "Xenium X600", "E210",
                    "Xenium X700", "Xenium X530", "X710", "X620",
                    "193", "E100", "X500", "M200",
                    "Xenium X300", "Xenium 9@9q", "298", "X800",
                    "M600", "Xenium 9@9v", "192", "191",
                    "Xenium 9@9j", "392", "Xenium 9@9u", "692",
                    "699 Dual SIM", "892", "399", "390",
                    "Xenium 9@9k", "Xenium 9@9z", "Xenium 9@9w", "Xenium 9@9m",
                    "Xenium 9@9r", "Xenium 9@9h", "292", "290",
                    "Xenium 9@9g", "Xenium 9@9f", "580", "S890",
                    "S660", "180", "Xenium 9@9s", "680",
                    "S900", "S880", "598", "588",
                    "Xenium 9@9t", "Xenium 9@9d", "Xenium 9@9a", "S800",
                    "S220", "S200", "768", "960",
                    "Xenium 9@9e", "160", "968", "362",
                    "868", "766", "760", "568",
                    "655", "Xenium 9@9i", "Xenium 9@98", "162",
                    "650", "859", "855", "759",
                    "755", "550", "659", "639",
                    "636", "535", "355", "350",
                    "530", "Xenium 9@9 ++", "630", "330",
                    "Fisio 825", "Fisio 625", "Fisio 820", "Fisio 620",
                    "Fisio 121", "Fisio 120", "Fisio 610", "Xenium 9@9",
                    "Xenium", "Azalis 268", "Azalis 238", "Ozeo 8@8",
                    "Ozeo", "Savvy DB", "Savvy Vogue", "Genie 2000",
                    "Genie db", "Genie Sport", "Genie", "Savvy",
                    "Diga", "Spark", "Fizz", "S337",
                    "S309", "V787", "V377", "S616",
                    "I928", "V526", "I908", "S396",
                    "S388", "S308", "W6610", "W8578",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "PLUM")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Tag 2 3G", "Phantom 2", "Optimax 13", "Flipper 2",
                    "Ram 8", "Gator 5", "Tag 3G", "Optimax 11",
                    "Optimax 12", "Optimax 2", "Compass 2", "Flipper (2018)",
                    "Axe 4", "Compass LTE", "Gator 4", "Phantom",
                    "Ram 6", "Ram 7 - 3G", "Play", "Compass",
                    "Hero", "Gator 3", "Axe Plus 2", "Optimax 10",
                    "Optimax 8.0", "Optimax 7.0", "Ram 4", "Star",
                    "Might Plus II", "Axe LTE", "Check LTE", "Boot 2",
                    "Ram 3G", "Sync 4.0b", "Gator Plus II", "Ram Plus",
                    "Coach Pro", "Trigger Plus III", "Might LTE", "Sync 5.0",
                    "Sync 4.0", "Sync 3.5", "Might Pro", "Coach Plus II",
                    "Link Plus", "Trigger Plus", "Trigger Pro", "Gator",
                    "Z708", "Coach Plus", "Pilot Plus", "Might Plus",
                    "Check Plus", "Axe Plus", "Boot", "Slick",
                    "Trigger Z104", "Bar 3G", "Velocity II", "Sync",
                    "Axe II", "Ten 3G", "Link II", "Volt 3G",
                    "Mouse", "Dazzle", "Ram", "Z710",
                    "Trigger", "Glow", "Panther", "Caliber II",
                    "Signal", "Hammer", "Flipper", "Debut",
                    "Link", "Might", "Axe", "Capacity",
                    "Wicked", "Flix", "Orbit", "Velocity",
                    "Caliber", "Switch", "Galactic", "Tracer II",
                    "Tingle", "Geo", "Genius", "Blast",
                    "Whiz", "Stubby", "Stubby II", "Strike",
                    "Profile", "Inspire", "Spare", "Boom",
                    "Snap", "Buzz", "Tweek", "Kazzom",
                    "Trip", "Trion", "Bubby"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "POSH")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Memo Pro LTE L600", "Equal Plus X700", "Ultra Max LTE L550", "Kick Pro LTE L520",
                    "Optima LTE L530", "Icon HD X551", "Volt LTE L540", "Volt Max LTE L640",
                    "Equal Pro LTE L700", "Primo Plus C353", "Kick X511", "Kick Lite S410",
                    "Icon S510", "Titan Max HD E550", "Ultra 5.0 LTE L500", "Micro X S240",
                    "Titan Max HD E600", "Titan HD E500", "Equal S700", "Equal Lite W700",
                    "Memo S580", "Orion Max X550", "Orion Pro X500", "Revel Pro X510",
                    "Revel S500", "Orion S450", "Pegasus 4G S400", "Orion Mini S350",
                    "Pegasus Plus C351", "Lynx A100"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "PRESTIGIO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "MultiPhone 5508 Duo", "MultiPhone 5504 Duo", "MultiPhone 5503 Duo", "MultiPhone 8500 Duo",
                    "MultiPhone 8400 Duo", "MultiPad 4 Quantum 10.1 3G", "MultiPad 4 Quantum 9.7 Colombia", "MultiPad 4 Ultra Quad 8.0 3G",
                    "MultiPhone 7600 Duo", "MultiPhone 7500", "MultiPhone 5501 Duo", "MultiPhone 5500 Duo",
                    "MultiPhone 5451 Duo", "MultiPhone 5450 Duo", "MultiPhone 3400 Duo", "MultiPhone 5430 Duo",
                    "MultiPhone 5400 Duo", "MultiPhone 5300 Duo", "MultiPhone 5044 Duo", "MultiPhone 5000 Duo",
                    "MultiPhone 4505 Duo", "MultiPhone 4500 Duo", "MultiPhone 4322 Duo", "MultiPhone 4300 Duo",
                    "MultiPhone 4055 Duo", "MultiPhone 4044 Duo", "MultiPhone 4040 Duo", "MultiPhone 3540 Duo",
                    "MultiPad 4 Ultimate 8.0 3G", "MultiPad 7.0 Prime Duo 3G", "Multipad 4 Quantum 10.1", "Multipad 4 Quantum 9.7",
                    "Multipad 4 Quantum 7.85", "MultiPad Note 8.0 3G", "MultiPad 2 Pro Duo 8.0 3G", "MultiPad 2 Ultra Duo 8.0 3G",
                    "MultiPad 2 Ultra Duo 8.0", "MultiPad 10.1 Ultimate 3G", "MultiPad 10.1 Ultimate", "MultiPad 7.0 Prime 3G",
                    "MultiPad 2 Prime Duo 8.0", "MultiPad 7.0 Ultra Duo", "MultiPad 8.0 Ultra Duo", "MultiPad 9.7 Ultra Duo",
                    "MultiPad 7.0 Prime Duo", "MultiPad 8.0 Pro Duo", "MultiPad 7.0 Pro Duo", "MultiPad 8.0 HD",
                    "MultiPad 7.0 Ultra + New", "MultiPad 7.0 HD +", "MultiPad 7.0 HD", "MultiPad 7.0 Ultra +",
                    "MultiPad 7.0 Ultra", "MultiPad 7.0 Prime +", "MultiPad 7.0 Prime", "MultiPad 7.0 Pro"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "QMOBILE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Noir A1", "Noir E2", "J7 Pro", "M6",
                    "M6 Lite", "King Kong Max", "Energy X2", "M350 Pro",
                    "E1", "Noir S6 Plus", "Noir J7", "Noir Z12 Pro",
                    "Noir Z14", "Noir LT680", "Noir LT700 Pro", "Noir S4",
                    "Noir LT750", "Noir i6 Metal HD", "Noir A6", "Noir S9",
                    "Noir Z9 Plus", "Noir Z12", "Noir Z10", "Noir E8",
                    "Noir S2", "Noir S5", "Linq L15", "Noir Z9",
                    "A1", "Noir S1", "Power3", "T50 Bolt",
                    "T200 Bolt", "Noir X950", "QTab V10", "Explorer 3G",
                    "Noir i8", "Noir X450", "Noir Z8 Plus", "Noir X350",
                    "Noir LT600", "Noir M300", "W1", "Noir Z8",
                    "Noir A750", "Linq X70", "Noir Z7", "Linq L10",
                    "Noir LT250", "Noir LT150", "Noir X600", "Noir X700",
                    "Noir X900", "Noir X60", "Noir X80", "Noir X90",
                    "Noir X550", "Linq X300", "Linq X100", "Noir X35",
                    "Noir X400", "Noir X500", "M800", "Noir i7",
                    "Noir M90", "Noir X800", "B100TV", "Noir A115 ATV",
                    "Noir i10", "B800", "Noir A8i", "Noir Z5",
                    "Noir i12", "Noir Z6", "QTab X50", "Noir A120",
                    "E990 Sirocco Edition", "Noir A110", "Noir i9", "Noir i6",
                    "Noir A75", "Noir i5i", "Noir i5", "Noir A550",
                    "Noir V4", "Noir Z4", "Noir Z3", "Noir A15 3D",
                    "Noir A950", "Noir A500",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "SAMSUNG")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Galaxy M20", "Galaxy M10", "Galaxy A8s", "Galaxy A6s",
                    "Galaxy A9 (2018)", "Galaxy A7 (2018)", "Galaxy Note9", "Galaxy Watch",
                    "Galaxy J6+", "Galaxy J4 Core", "Galaxy J4+", "Galaxy J2 Core",
                    "Galaxy Tab S4 10.5", "Galaxy Tab A 10.5", "Galaxy On6", "Galaxy J7 (2018)",
                    "Galaxy J3 (2018)", "Galaxy A8 Star (A9 Star)", "Galaxy S Light Luxury", "Galaxy J8",
                    "Galaxy J6", "Galaxy J4", "Galaxy A6+ (2018)", "Galaxy A6 (2018)",
                    "Galaxy J7 Duo", "Galaxy J7 Prime 2", "Galaxy S9+", "Galaxy S9",
                    "Galaxy J2 Pro (2018)", "Galaxy A8+ (2018)", "Galaxy A8 (2018)", "Galaxy J2 (2017)",
                    "Galaxy Tab Active 2", "Galaxy Tab A 8.0 (2017)", "Galaxy C7 (2017)", "Gear Sport",
                    "Galaxy Note8", "Galaxy S8 Active", "Galaxy J7 V", "Galaxy Note FE",
                    "Galaxy J7 Max", "Galaxy J7 Pro", "Galaxy J7 (2017)", "Galaxy J5 (2017)",
                    "Galaxy J3 (2017)", "Galaxy Folder2", "Z4", "Galaxy S8",
                    "Galaxy S8+", "Gear S3 classic LTE", "Galaxy C5 Pro", "Galaxy Xcover 4",
                    "Galaxy Tab S3 9.7", "Galaxy J1 mini prime", "Galaxy J3 Emerge", "Galaxy C7 Pro",
                    "Galaxy A7 (2017)", "Galaxy A5 (2017)", "Galaxy A3 (2017)", "Galaxy Grand Prime Plus",
                    "Galaxy J2 Prime", "Galaxy C9 Pro", "Galaxy C10", "Galaxy A8 (2016)",
                    "Galaxy On8", "Galaxy On7 (2016)", "Gear S3 classic", "Gear S3 frontier",
                    "Gear S3 frontier LTE", "Galaxy J5 Prime", "Galaxy J7 Prime", "Z2",
                    "Galaxy Note7 (USA)", "Galaxy Note7", "Galaxy On7 Pro", "Galaxy On5 Pro",
                    "Galaxy Tab J", "Galaxy J Max", "Galaxy J2 Pro (2016)", "Galaxy J2 (2016)",
                    "Z3 Corporate", "Galaxy Xcover 3 G389F", "Galaxy S7 active", "Galaxy J3 Pro",
                    "Galaxy C7", "Galaxy C5", "Galaxy A9 Pro (2016)", "Galaxy J7 (2016)",
                    "Galaxy J5 (2016)", "Galaxy Tab A 10.1 (2016)", "Galaxy Tab A 7.0 (2016)", "Galaxy S7",
                    "Galaxy S7 edge", "Galaxy S7 edge (USA)", "Galaxy S7 (USA)", "Galaxy J1 Nxt",
                    "Gear S2 classic 3G", "Galaxy Tab E 8.0", "Galaxy J1 (2016)", "Galaxy A9 (2016)",
                    "Galaxy A7 (2016)", "Galaxy A5 (2016)", "Galaxy A3 (2016)", "Galaxy Express Prime",
                    "Galaxy J3 (2016)", "Galaxy View", "Galaxy On7", "Galaxy On5",
                    "Z3", "Galaxy J1 Ace", "Gear S2 classic", "Gear S2",
                    "Gear S2 3G", "Galaxy Note5 (USA)", "Galaxy Note5", "Galaxy Note5 Duos",
                    "Galaxy S6 edge+ (USA)", "Galaxy S6 edge+", "Galaxy S6 edge+ Duos", "Galaxy S5 Neo",
                    "Galaxy S4 mini I9195I", "Galaxy Folder", "Galaxy Tab S2 9.7", "Galaxy Tab S2 8.0",
                    "Galaxy A8 Duos", "Galaxy A8", "Galaxy V Plus", "Galaxy J7",
                    "Galaxy J7 Nxt", "Galaxy J5", "Galaxy Tab 4 10.1 (2015)", "Galaxy Tab E 9.6",
                    "Guru Plus ", "Metro 360", "Xcover 550", "Galaxy S6 active",
                    "Galaxy Tab 3 V", "Galaxy Tab A 9.7 & S Pen", "Galaxy Tab A 9.7", "Galaxy Tab A 8.0 & S Pen",
                    "Galaxy Tab A 8.0", "Galaxy Xcover 3", "Galaxy S6 edge (USA)", "Galaxy S6 (USA)",
                    "Galaxy S6 edge", "Galaxy S6 Plus", "Galaxy S6 Duos", "Galaxy S6",
                    "Galaxy J1 4G", "Galaxy J1", "Galaxy J2", "Galaxy Tab 3 Lite 7.0 VE",
                    "Z1", "Galaxy A7 Duos", "Galaxy A7", "Galaxy Grand Max",
                    "Galaxy E7", "Galaxy E5", "Galaxy Core Prime", "Galaxy A5 Duos",
                    "Galaxy A5", "Galaxy A3 Duos", "Galaxy A3", "Galaxy S5 Plus",
                    "Galaxy Pocket 2", "Galaxy V", "Galaxy Grand Prime Duos TV", "Galaxy Grand Prime",
                    "Galaxy Ace Style LTE G357", "Galaxy Note Edge", "Galaxy C5", "Galaxy A9 Pro (2016)",
                    "Galaxy J7 (2016)", "Galaxy J5 (2016)", "Galaxy Tab A 10.1 (2016)", "Galaxy Tab A 7.0 (2016)",
                    "Galaxy S7", "Galaxy S7 edge", "Galaxy S7 edge (USA)", "Galaxy S7 (USA)",
                    "Galaxy J1 Nxt", "Gear S2 classic 3G", "Galaxy Tab E 8.0", "Galaxy J1 (2016)",
                    "Galaxy A9 (2016)", "Galaxy A7 (2016)", "Galaxy A5 (2016)", "Galaxy A3 (2016)",
                    "Galaxy Express Prime", "Galaxy J3 (2016)", "Galaxy View", "Galaxy On7",
                    "Galaxy On5", "Z3", "Galaxy J1 Ace", "Gear S2 classic",
                    "Gear S2", "Gear S2 3G", "Galaxy Note5 (USA)", "Galaxy Note5",
                    "Galaxy Note5 Duos", "Galaxy S6 edge+ (USA)", "Galaxy S6 edge+", "Galaxy S6 edge+ Duos",
                    "Galaxy S5 Neo", "Galaxy S4 mini I9195I", "Galaxy Folder", "Galaxy Tab S2 9.7",
                    "Galaxy Tab S2 8.0", "Galaxy A8 Duos", "Galaxy A8", "Galaxy V Plus",
                    "Galaxy J7", "Galaxy J7 Nxt", "Galaxy J5", "Galaxy Tab 4 10.1 (2015)",
                    "Galaxy Tab E 9.6", "Guru Plus ", "Metro 360", "Xcover 550",
                    "Galaxy S6 active", "Galaxy Tab 3 V", "Galaxy Tab A 9.7 & S Pen", "Galaxy Tab A 9.7",
                    "Galaxy Tab A 8.0 & S Pen", "Galaxy Tab A 8.0", "Galaxy Xcover 3", "Galaxy S6 edge (USA)",
                    "Galaxy S6 (USA)", "Galaxy S6 edge", "Galaxy S6 Plus", "Galaxy S6 Duos",
                    "Galaxy S6", "Galaxy J1 4G", "Galaxy J1", "Galaxy J2",
                    "Galaxy Tab 3 Lite 7.0 VE", "Z1", "Galaxy A7 Duos", "Galaxy A7",
                    "Galaxy Grand Max", "Galaxy E7", "Galaxy E5", "Galaxy Core Prime",
                    "Galaxy A5 Duos", "Galaxy A5", "Galaxy A3 Duos", "Galaxy A3",
                    "Galaxy S5 Plus", "Galaxy Pocket 2", "Galaxy V", "Galaxy Grand Prime Duos TV",
                    "Galaxy Grand Prime", "Galaxy Ace Style LTE G357", "Galaxy Note Edge", "Galaxy Grand 2",
                    "I9230 Galaxy Golden", "Galaxy Express 2", "C3590", "I9506 Galaxy S4",
                    "Galaxy Light", "Galaxy Round G910S", "Galaxy Fresh S7390", "Galaxy Core Plus",
                    "Galaxy Fame Lite Duos S6792L", "Galaxy Fame Lite S6790", "Galaxy Star Pro S7260", "Galaxy Note 10.1 (2014)",
                    "Galaxy Note 3", "Ch@t 333", "Galaxy Prevail 2", "Gravity Q T289",
                    "ATIV S Neo", "Galaxy S4 zoom", "Galaxy S II TV", "Galaxy Ace 3",
                    "I9190 Galaxy S4 mini", "I9295 Galaxy S4 Active", "Galaxy Tab 3 8.0", "Galaxy Tab 3 10.1 P5220",
                    "Galaxy Tab 3 10.1 P5200", "Galaxy Tab 3 10.1 P5210", "Galaxy Exhibit T599", "Galaxy Core I8260",
                    "Galaxy Tab 3 7.0 WiFi", "Galaxy Tab 3 7.0", "Galaxy Mega 6.3 I9200", "Galaxy Mega 5.8 I9150",
                    "Galaxy Trend II Duos S7572", "Galaxy Win I8550", "Galaxy Pocket Neo S5310", "Galaxy Star S5280",
                    "I9505 Galaxy S4", "I9500 Galaxy S4", "I9502 Galaxy S4", "Galaxy S4 CDMA",
                    "Galaxy Note 8.0", "Galaxy Note 8.0 Wi-Fi", "Galaxy Y Plus S5303", "Rex 90 S5292",
                    "Rex 80 S5222R", "Rex 70 S3802", "Rex 60 C3312R", "Metro E2202",
                    "E1282T", "E1207T", "Galaxy Young S6310", "Galaxy Fame S6810",
                    "Galaxy Express I8730", "S7710 Galaxy Xcover 2", "I9105 Galaxy S II Plus", "Ativ Odyssey I930",
                    "Galaxy Grand I9082", "Galaxy Grand I9080", "Star Deluxe Duos S5292", "Galaxy Note LTE 10.1 N8020",
                    "A997 Rugby III", "Galaxy Axiom R830", "Galaxy Stratosphere II I415", "Galaxy Discover S730M",
                    "Galaxy Pop SHV-E220", "Galaxy Premier I9260", "Google Nexus 10 P8110", "Ativ Tab P8510",
                    "Comment 2 R390C", "I8190 Galaxy S III mini", "Galaxy Music S6010", "Galaxy Music Duos S6012",
                    "Galaxy Rugby Pro I547", "Galaxy Express I437", "Ch@t 357", "I9305 Galaxy S III",
                    "Galaxy Victory 4G LTE L300", "Galaxy S Relay 4G T699", "Champ Neo Duos C3262", "Galaxy Pocket Duos S5302",
                    "Galaxy Note II N7100", "Galaxy Note II CDMA", "Ativ S I8750", "Galaxy Camera GC100",
                    "Galaxy Rush M830", "Galaxy Stellar 4G I200", "Galaxy Reverb M950", "Galaxy Tab 2 7.0 I705",
                    "Galaxy Note 10.1 N8000", "Galaxy Note 10.1 N8010", "Array M390", "Galaxy S Lightray 4G R940",
                    "Galaxy S Duos S7562", "Manhattan E3300", "E2262", "E1260B",
                    "E1200 Pusha", "E2252", "Galaxy Chat B5330", "U485 Intensity III",
                    "Galaxy I8250", "Galaxy Ace Advance S6800", "Galaxy Ace Duos S6802", "Galaxy Appeal I827",
                    "Galaxy Tab 8.9 4G P7320T", "C3780", "C3782 Evan", "Galaxy Proclaim S720C",
                    "Omnia M S7530", "I9500 Fraser", "Focus 2 I667", "Galaxy S III T999",
                    "Galaxy S III I747", "Galaxy S III CDMA", "I9300 Galaxy S III", "E2350B",
                    "U380 Brightside", "Galaxy Player 70 Plus", "Galaxy Pocket plus S5301", "Galaxy Pocket S5300",
                    "I8530 Galaxy Beam", "Galaxy Tab 2 10.1 P5110", "Galaxy Tab 2 10.1 CDMA", "Galaxy Tab 2 10.1 P5100",
                    "Rugby Smart I847", "W999", "Galaxy Ace II X S7560M", "Galaxy Ace 2 I8160",
                    "Galaxy mini 2 S6500", "Galaxy Ace Duos I589", "Galaxy Pop Plus S5570i", "Galaxy Tab 2 7.0 P3110",
                    "Galaxy Tab 2 7.0 P3100", "I9070 Galaxy S Advance", "C3312 Duos", "Star 3 s5220",
                    "Star 3 Duos S5222", "Galaxy Nexus I9250M", "Galaxy Attain 4G", "Galaxy S Blaze 4G T769",
                    "Galaxy Tab 7.7 LTE I815", "Galaxy Nexus LTE L700", "Exhilarate i577", "Galaxy S II Skyrocket HD I757",
                    "Galaxy Note T879", "Galaxy Note I717", "Galaxy M Style M340S", "Galaxy Ace Plus S7500",
                    "I929 Galaxy S II Duos", "Galaxy Y Duos S6102", "Galaxy Y Pro Duos B5512", "E2600",
                    "M370", "R680 Repp", "I110 Illusion", "E1050",
                    "E1232B", "E1230", "Focus S I937", "Focus Flash I677",
                    "Galaxy S II Skyrocket i727", "C3330 Champ 2", "Exhibit II 4G T679", "C3350",
                    "C3520", "Galaxy Nexus i515", "Galaxy Nexus I9250", "I9100G Galaxy S II",
                    "I405 Stratosphere", "R730 Transfix", "i927 Captivate Glide", "DoubleTime I857",
                    "M930 Transform Ultra", "P6210 Galaxy Tab 7.0 Plus", "P6200 Galaxy Tab 7.0 Plus", "Omnia W I8350",
                    "Galaxy S II HD LTE", "Ch@t 527", "P6810 Galaxy Tab 7.7", "P6800 Galaxy Tab 7.7",
                    "Galaxy Note N7000", "Galaxy S II I777", "Galaxy S II X T989D", "Galaxy S II T989",
                    "Galaxy S II Epic 4G Touch", "S8600 Wave 3", "Wave M S7250", "Wave Y S5380",
                    "Galaxy S II LTE i727R", "Galaxy S II LTE I9210", "Galaxy Tab 8.9 LTE I957", "Galaxy W I8150",
                    "Galaxy M Pro B7800", "Galaxy Y Pro B5510", "Galaxy Y TV S5367", "Galaxy Y S5360",
                    "Gravity TXT T379", "Galaxy Q T589R", "S5610", "S3770",
                    "S5690 Galaxy Xcover", "Galaxy S II 4G I9100M", "I9103 Galaxy R", "R720 Admire",
                    "Convoy 2", "Conquer 4G", "R640 Character", "R380 Freeform III",
                    "Trender", "Gravity SMART", "Exhibit 4G", "C414",
                    "E1195", "E1190", "C3560", "Dart T499",
                    "C3322", "R260 Chrono", "E2232", "E1182",
                    "I9001 Galaxy S Plus", "DuosTV I6712", "C6712 Star II DUOS", "Ch@t 222",
                    "Ch@t 220", "M580 Replenish", "Galaxy Prevail", "M220L Galaxy Neo",
                    "Google Nexus S I9020A", "Google Nexus S I9023", "E2230", "P1010 Galaxy Tab Wi-Fi",
                    "P7500 Galaxy Tab 10.1 3G", "Galaxy Tab 10.1 LTE I905", "Galaxy Tab 10.1 P7510", "Galaxy Tab 8.9 P7300",
                    "Galaxy Tab 8.9 P7310", "Google Nexus S 4G", "M260 Factor", "S3850 Corby II",
                    "Galaxy Pro B7510", "I9100 Galaxy S II", "E2652W Champ Duos", "E2652 Champ Duos",
                    "S5780 Wave 578", "P7100 Galaxy Tab 10.1v", "Galaxy S WiFi 5.0", "Ch@t 350",
                    "E3213 Hero", "E3210", "E2330", "I9003 Galaxy SL",
                    "Galaxy Ace S5830I", "Galaxy Ace S5830", "Galaxy Fit S5670", "Galaxy Gio S5660",
                    "Galaxy Mini S5570", "Galaxy Pop i559", "Galaxy S 4G T959", "S5260 Star II",
                    "I997 Infuse 4G", "R910 Galaxy Indulge", "Droid Charge I510", "Google Nexus S",
                    "M190S Galaxy S Hoppin", "Ch@t 335", "C3630", "C3530",
                    "I9010 Galaxy S Giorgio Armani", "A817 Solstice II", "A667 Evergreen", "E2530",
                    "I100 Gem", "R710 Suede", "U750 Zeal", "Continuum I400",
                    "Ch@t 322 Wi-Fi", "Ch@t 322", "E1252", "Breeze B209",
                    "Hero Plus B159", "W169 Duos", "Mpower Muzik 219", "Mpower Txt M369",
                    "Mpower TV S239", "E1225 Dual Sim Shift", "Guru E1081T", "Focus",
                    "I8700 Omnia 7", "S5750 Wave575", "S8530 Wave II", "M210S Wave2",
                    "Galaxy Tab T-Mobile T849", "P1000 Galaxy Tab", "Galaxy Tab CDMA P100", "Galaxy Tab 4G LTE",
                    "T249", "R580 Profile", "R570 Messenger III", "I909 Galaxy S",
                    "A200K Nori F", "A220 F Nori", "M130K Galaxy K", "Mesmerize i500",
                    "M920 Transform", "R360 Freeform II", "Guru Dual 26", "Galaxy 551",
                    "Xcover 271", "R900 Craft", "S7230E Wave 723", "C3750",
                    "C3752", "M130L Galaxy U", "E2152", "S5530",
                    "U360 Gusto", "Fascinate", "Vibrant", "A927 Flight II",
                    "T669 Gravity T", "T479 Gravity 3", ":) Smiley", "C5010 Squash",
                    "i897 Captivate", "B7350 Omnia PRO 4", "B6520 Omnia PRO 5", "U320 Haven",
                    "U460 Intensity II", "M350 Seek", "Epic 4G", "Acclaim",
                    "Intercept", "R360 Messenger Touch", "i225 Exec", "M570 Restore",
                    "R351 Freeform", "T369", "S5330 Wave533", "S5250 Wave525",
                    "I5500 Galaxy 5", "I5801 Galaxy Apollo", "I5800 Galaxy 3", "B7722",
                    "A847 Rugby II", "C3300K Champ", "W960 AMOLED 3D", "M110S Galaxy S",
                    "Galaxy A", "I9000 Galaxy S", "I6500U Galaxy", "S3370",
                    "Metro TV", "E1170", "Corby TV F339", "S3650W Corby",
                    "W9705", "A687 Strive", "A697 Sunburst", "S8500 Wave",
                    "I8520 Galaxy Beam", "B3410W Ch@t", "M3710 Corby Beat", "E2370 Xcover",
                    "E2550 Monte Slider", "C3200 Monte Bar", "S5620 Monte", "S5550 Shark 2",
                    "S3550 Shark 3", "S5350 Shark", "E1150", "C6112",
                    "M2520 Beat Techno", "C3510 Genoa", "M5650 Lindy", "S7070 Diva",
                    "C3730C", "S5150 Diva folder", "C5130", "B5722",
                    "M3310L", "M3310", "A897 Mythic", "S5500 Eco",
                    "T139", "A797 Flight", "B3410", "M715 T*OMNIA II",
                    "A886 Forever", "S5560 Marvel", "S5630C", "I5700 Galaxy Spica",
                    "E1390", "E1160", "E2130", "E1130B",
                    "T401G", "B7620 Giorgio Armani", "T939 Behold 2", "M8920",
                    "W880 AMOLED 12M", "Vodafone 360 H1", "Vodafone 360 M1", "B5310 CorbyPRO",
                    "B3210 CorbyTXT", "F480i", "B7330 OmniaPRO", "E1085T",
                    "E1080T", "S5510", "S5230W Star WiFi", "S7550 Blue Earth",
                    "S3650 Corby", "C5030", "T659 Scarlet", "B3310",
                    "C3212", "U450 DoubleTake", "i220 Code", "R860 Caliber",
                    "R520 Trill", "M900 Moment", "i350 Intrepid", "M850 Instinct HD",
                    "U450 Intensity", "U960 Rogue", "S3100", "A887 Solstice",
                    "E2120", "S5233T", "I6220 Star TV", "S9110",
                    "T469 Gravity 2", "T559 Comeback", "T746 Impact", "S5600v Blade",
                    "S6700", "C5510", "M2510", "M2310",
                    "W850", "S8000 Jet", "I8000 Omnia II", "B7610 OmniaPRO",
                    "B7320 OmniaPRO", "B7300 OmniaLITE", "M8910 Pixon12", "E1107 Crest Solar",
                    "M2710 Beat Twist", "S5050", "T349", "S5200",
                    "i637 Jack", "S3310", "C3060R", "A167",
                    "A177", "I7500 Galaxy", "J165", "I6210",
                    "E1360", "E1210", "A657", "A877 Impression",
                    "A257 Magnet", "Propel Pro", "B2100 Xplorer", "S5230 Star",
                    "S5600 Preston", "i8910 Omnia HD", "S8300 UltraTOUCH", "M7600 Beat DJ",
                    "M6710 Beat DISC", "S7350 Ultra s", "S7220 Ultra b", "C5220",
                    "S3500", "S3110", "P250", "i7410",
                    "T929 Memoir", "C3050 Stratus", "C3010", "C3110",
                    "C6625", "E1310", "E1120", "E1100",
                    "E1070", "E2210B", "E1125", "E2100B",
                    "B520", "B5702", "C5212", "SCH-W699",
                    "W259 Duos", "W299 Duos", "S9402 Ego", "S3030 Tobi",
                    "U810 Renown", "i770 Saga", "A867 Eternity", "A777",
                    "T919 Behold", "T459 Gravity", "E2510", "T219",
                    "E1410", "U450 Intensity", "U960 Rogue", "S3100",
                    "A887 Solstice", "E2120", "S5233T", "I6220 Star TV",
                    "S9110", "T469 Gravity 2", "T559 Comeback", "T746 Impact",
                    "S5600v Blade", "S6700", "C5510", "M2510",
                    "M2310", "W850", "S8000 Jet", "I8000 Omnia II",
                    "B7610 OmniaPRO", "B7320 OmniaPRO", "B7300 OmniaLITE", "M8910 Pixon12",
                    "E1107 Crest Solar", "M2710 Beat Twist", "S5050", "T349",
                    "S5200", "i637 Jack", "S3310", "C3060R",
                    "A167", "A177", "I7500 Galaxy", "J165",
                    "I6210", "E1360", "E1210", "A657",
                    "A877 Impression", "A257 Magnet", "Propel Pro", "B2100 Xplorer",
                    "S5230 Star", "S5600 Preston", "i8910 Omnia HD", "S8300 UltraTOUCH",
                    "M7600 Beat DJ", "M6710 Beat DISC", "S7350 Ultra s", "S7220 Ultra b",
                    "C5220", "S3500", "S3110", "P250",
                    "i7410", "T929 Memoir", "C3050 Stratus", "C3010",
                    "C3110", "C6625", "E1310", "E1120",
                    "E1100", "E1070", "E2210B", "E1125",
                    "E2100B", "B520", "B5702", "C5212",
                    "SCH-W699", "W259 Duos", "W299 Duos", "S9402 Ego",
                    "S3030 Tobi", "U810 Renown", "i770 Saga", "A867 Eternity",
                    "A777", "T919 Behold", "T459 Gravity", "E2510",
                    "T219", "E1410", "G800", "C500",
                    "Serenata", "D880 Duos", "i780", "i560",
                    "i550", "F330", "F250", "i450",
                    "Armani", "J610", "P260", "J400",
                    "J750", "A737", "A517", "T639",
                    "T509", "T439", "T429", "T409",
                    "T739 Katalyst", "T729 Blast", "T539 Beat", "L600",
                    "Z630", "G600", "M610", "M600",
                    "M110", "B500", "B100", "S730i",
                    "S720i", "J200", "L760", "F700",
                    "E950", "F210", "F200", "i620",
                    "A411", "ZV60", "Z240", "Z170",
                    "J600", "i400", "U700", "U600",
                    "U300", "U100", "i710", "i520",
                    "F520", "F510", "P110", "E840",
                    "E830", "E740", "E590", "E230",
                    "E210", "E200", "C520", "C450",
                    "C275", "C270", "C260", "C250",
                    "i600", "i617 BlackJack II", "i607 BlackJack", "F500",
                    "F300", "P940", "P930", "E790",
                    "E490", "E480", "E390", "X550",
                    "X540", "E250", "X520", "X530",
                    "C300", "M300", "E690", "E570",
                    "E420", "X830", "E890", "E898",
                    "P310", "Z720", "Z650i", "Z620",
                    "Z370", "Z360", "P200", "S501i",
                    "S401i", "X510", "X500", "D840",
                    "C400", "C240", "C180", "C170",
                    "C160", "C140", "D830", "D900i",
                    "D900", "X820", "C130", "E500",
                    "E380", "D870", "D780 flip", "E900",
                    "Z400", "Z550", "i320", "i310",
                    "ZV50", "ZV40", "Z560", "P920",
                    "P900", "P910", "T629", "D520",
                    "D300", "Z710", "Z600", "Z520",
                    "Z350", "Z230", "Z330", "Z310",
                    "Z150", "X680", "X630", "X300",
                    "X210", "X160", "E870", "E780",
                    "i300x", "D820", "D810", "D800",
                    "Z540", "Z510", "P300", "E770",
                    "E370", "E360", "ZV30", "ZV10",
                    "Z320i", "S400i", "S500i", "E860",
                    "Serene", "D600", "P850", "E730",
                    "D510", "X700", "X670", "X660",
                    "X490", "X650", "X200", "X150",
                    "Z500", "Z300", "Z130", "Z140",
                    "D550", "P860", "Z700", "D730",
                    "i750", "D720", "E760", "E750",
                    "E720", "i300", "E880", "E350",
                    "E640", "E620", "E530", "E340",
                    "X810", "X800", "C120", "C230",
                    "C210", "X640", "X480", "X620",
                    "X140", "S410i", "S342i", "SCH-B100",
                    "D500", "P730", "P710", "D488",
                    "D428", "E630", "E850", "E810",
                    "E800", "Z110", "D710", "C200",
                    "i530", "i505", "i500", "i250",
                    "i700", "X910", "X900", "X610",
                    "X460", "X120", "E330", "E310",
                    "E300", "C110", "Z107", "Z105",
                    "E610", "E600", "P510", "E410",
                    "X450", "X430", "P705", "D410",
                    "X600", "X100", "E715", "E700",
                    "C100", "D700", "P500", "E105",
                    "E100", "X410", "X400", "S200",
                    "E400", "D100", "Watch Phone", "V200",
                    "Z100", "P100", "P400", "T700",
                    "T500", "S500", "S300", "T400",
                    "T200", "V100", "S100", "Q300",
                    "A800", "A500", "T100", "Q200",
                    "N620", "N500", "N400", "Q105",
                    "N300", "A400", "A300", "R220",
                    "R210", "R200", "A200", "Q100",
                    "N105", "N100", "M100", "A110",
                    "A100", "SGH-2400", "SGH-2200", "SGH-2100",
                    "SGH-810", "SGH-800", "SGH-600", "SGH-500",
                    "SGH-250", "Galaxy Tab 3 Plus 10.1 P8220", "Galaxy F", "Galaxy Grand 3",
                    "Galaxy S7 mini", "Galaxy J5 Prime (2017)", "Galaxy On5 (2016)", "Galaxy S9 Active"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "SHARP")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Aquos Zero", "Aquos R2 compact", "Aquos D10", "Aquos B10",
                    "Aquos C10", "Aquos S3 High", "Aquos R2", "Aquos S3",
                    "Aquos S3 mini", "Pi", "R1S", "Aquos S2",
                    "Z3", "Z2", "MS1", "Aquos Xx",
                    "Aquos Crystal 2", "Aquos Crystal", "SH530U", "SE-02",
                    "Aquos SH80F", "Aquos SH8298U", "FX", "AQUOS  941SH",
                    "940SH", "936SH", "934SH", "930SH",
                    "923SH", "825SH", "SX862", "GX18",
                    "880SH", "GX34", "GX33", "705SH",
                    "904", "770SH", "550SH", "GX29",
                    "903", "703", "GX17", "GX40",
                    "902", "802", "TM200", "GX25/GZ200",
                    "TM150", "TM100", "V801SH", "GX30",
                    "GX15/GZ100", "GX22", "GX20", "GX10i",
                    "GX10", "GX1"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "SONIM")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "XP8", "XP7", "XP6", "XP3400 Armor",
                    "XP5300 Force 3G", "XP3340 Sentinel", "XP3300 Force", "XP1300 Core",
                    "XP3 Sentinel", "XP2.10 Spirit", "XP3.20 Quest Pro", "XP3.20 Quest",
                    "XP3 Enduro", "XP1"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "SONY")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Xperia XZ3", "Xperia XA2 Plus", "Xperia XZ2 Premium", "Xperia XZ2",
                    "Xperia XZ2 Compact", "Xperia XA2 Ultra", "Xperia XA2", "Xperia L2",
                    "Xperia R1 (Plus)", "Xperia XZ1", "Xperia XA1 Plus", "Xperia XZ1 Compact",
                    "Xperia L1", "Xperia XZs", "Xperia XZ Premium", "Xperia XA1 Ultra",
                    "Xperia XA1", "Xperia X Compact", "Xperia XZ", "Xperia E5",
                    "Xperia XA Ultra", "Xperia X Performance", "Xperia X", "Xperia XA Dual",
                    "Xperia XA", "Xperia Z5 Premium Dual", "Xperia Z5 Premium", "Xperia Z5 Dual",
                    "Xperia Z5", "Xperia Z5 Compact", "Xperia M5 Dual", "Xperia M5",
                    "Xperia C5 Ultra Dual", "Xperia C5 Ultra", "Xperia Z4v", "Xperia Z3+ dual",
                    "Xperia Z3+", "Xperia C4 Dual", "Xperia C4", "Xperia M4 Aqua Dual",
                    "Xperia M4 Aqua", "Xperia Z4 Tablet WiFi", "Xperia Z4 Tablet LTE", "Xperia E4g",
                    "Xperia E4g Dual", "Xperia E4 Dual", "Xperia E4", "Xperia E3 Dual",
                    "Xperia E3", "Xperia Z3 Tablet Compact", "Xperia Z3 Dual", "Xperia Z3v",
                    "Xperia Z3", "Xperia Z3 Compact", "Xperia M2 Aqua", "Xperia C3 Dual",
                    "Xperia C3", "Xperia Z2a", "Xperia T3", "SmartWatch 3 SWR50",
                    "SmartWatch 2 SW2", "Xperia M2", "Xperia M2 dual", "Xperia Z2 Tablet LTE",
                    "Xperia Z2 Tablet Wi-Fi", "Xperia Z2", "Xperia E1 dual", "Xperia E1",
                    "Xperia T2 Ultra dual", "Xperia T2 Ultra", "Xperia Z1s", "Xperia Z1 Compact",
                    "Xperia Z1", "Xperia Z Ultra", "Xperia C", "Xperia M",
                    "Xperia ZR", "Xperia L", "Xperia SP", "Xperia Tablet Z LTE",
                    "Xperia Tablet Z Wi-Fi", "Xperia Z", "Xperia ZL", "Xperia E dual",
                    "Xperia E", "Xperia T LTE", "Xperia Tablet S 3G", "Xperia Tablet S",
                    "Xperia V", "Xperia J", "Xperia TX", "Xperia T",
                    "Xperia SL", "Xperia tipo dual", "Xperia tipo", "Xperia miro",
                    "Xperia go", "Xperia acro S", "Xperia SX SO-05D", "Xperia GX SO-04D",
                    "Xperia acro HD SO-03D", "Xperia acro HD SOI12", "Xperia neo L", "Xperia sola",
                    "Xperia U", "Xperia P", "Xperia S", "Xperia ion HSPA",
                    "Xperia ion LTE", "Tablet P", "Tablet P 3G", "Tablet S 3G",
                    "Tablet S", "CMD Z7", "CMD J70", "Xperia LT29i Hayabusa",
                    "CMD J7", "CMD MZ5", "CMD J6", "CMD J5",
                    "CMD Z5", "CMD CD5", "CMD C1", "CMD Z1 plus",
                    "CMD Z1", "CM-DX 2000", "CM-DX 1000", "Xperia Z4 Compact",
                    "Xperia C670X", "D 2403", "Xperia Z4 Ultra", "Xperia E1 II",
                    "Xperia X Premium", "Xperia M Ultra", "Xperia H8541", "Xperia X Ultra"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "SONY ERICSSON")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Xperia Arc S", "Xperia neo V", "Live with Walkman", "Xperia ray",
                    "Xperia active", "txt", "Mix Walkman", "txt pro",
                    "Xperia mini", "Xperia mini pro", "WT18i", "W8",
                    "Xperia PLAY", "Xperia pro", "Xperia Neo", "Xperia Arc",
                    "Xperia PLAY CDMA", "A8i", "Xperia X8", "Cedar",
                    "Yendo", "BRAVIA S004", "S003", "Zylo",
                    "Spiro", "Xperia X10 mini pro", "Xperia X10 mini", "Vivaz pro",
                    "Aspen", "Vivaz", "Hazel", "Elm",
                    "Xperia Pureness", "Xperia X10", "Xperia X2", "Jalou D&G edition",
                    "Jalou", "T715", "C901 GreenHeart", "J105 Naite",
                    "Satio (Idou)", "Aino", "Yari", "S312",
                    "W205", "T707", "W995", "C903",
                    "C901", "W395"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "SPICE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Smart Pulse (M-9010)", "Fire One (Mi-FX-1)", "N-300", "Smart Flo 508 (Mi-508)",
                    "Smart Flo 503 (Mi-503)", "Smart Flo 359 (Mi-359)", "Smart Flo 358 (Mi-358)", "Stellar 439 (Mi-439)",
                    "Stellar 361 (Mi-361)", "Stellar 507 (Mi-507)", "Stellar 509 (Mi-509)", "Stellar 600 (Mi-600)",
                    "Stellar 526 (Mi-526)", "Stellar 520 (Mi-520)", "Stellar 520n (Mi-520n)", "Stellar 440 (Mi-440)",
                    "Stellar 470 (Mi-470)", "Mi-449 3G", "Mi-451 3G", "Mi-498 Dream Uno",
                    "Mi-506 Stellar Mettle Icon", "Mi-356 Smart Flo Mettle 3.5X", "Mi-426 Smart Flo Mettle 4.0X", "Mi-438 Stellar Glide",
                    "Mi-504 Smart Flo Mettle 5X", "Mi-451 Smartflo Poise", "Mi-496 Spice Coolpad 2", "Mi-423 Smart Flo Ivory 2",
                    "Mi-349 Smart Flo Edge", "Mi-550 Pinnacle Stylus", "Mi-502n Smart FLO Pace3", "Mi-492 Stellar Virtuoso Pro+",
                    "Mi-437 Stellar Nhance 2", "Mi-436 Stellar Glamour", "Mi-354 Smartflo Space", "Mi-525 Pinnacle FHD",
                    "Mi-515 Coolpad", "Mi-510 Stellar Prime", "Mi-505 Stellar Horizon Pro", "Mi-491 Stellar Virtuoso Pro",
                    "Mi-450 Smartflo Ivory", "Mi-422 Smartflo Pace", "Mi-353 Stellar Jazz", "Mi-725 Stellar Slatepad",
                    "Mi-502 Smartflo Pace2", "Mi-535 Stellar Pinnacle Pro", "Mi-530 Stellar Pinnacle", "Mi-1010 Stellar Pad",
                    "Mi-495 Stellar Virtuoso", "Mi-500 Stellar Horizon", "Mi-285 Stellar", "M-5665 T2",
                    "M-5566 Flo Entertainer", "M-5900 Flo TV Pro", "M-6688 Flo Magic", "M-5460 Flo",
                    "M-5455 Flo", "M-5365 Boss Killer", "M-5400 Boss TV", "M-5200 Boss Don",
                    "M-5390 Boss Double XL", "M-5250 Boss Item", "M-5363 Boss", "Mi-355 Stellar Craze",
                    "Mi-425 Stellar", "M-6868N FLO ME", "M-5600 FLO TV", "Mi-280",
                    "Mi-350", "M-6900 Knight", "M-6868", "M-6700",
                    "M-9000 Popkorn", "M-6450", "M-5750", "M-5350",
                    "M-5180", "M-5115", "M-4262", "Mi-720",
                    "Mi-410", "M-6800 FLO", "Mi-270", "Mi-310",
                    "M-4250", "M-5170", "QT-65", "M-5262",
                    "QT-58", "QT-61", "M-5454", "M-5161n",
                    "QT-95", "M-67 3D", "QT-68", "M-4580n",
                    "Mi-300", "M-6 Sports", "M-6363", "QT-56",
                    "G-6565", "QT-52", "QT-60", "M-5161",
                    "M-5055", "S-7000", "QT-50", "M-6262",
                    "S-1200", "M-4242", "M-940n", "S-5010",
                    "D-6666", "M 4580", "S-5110", "S-5420",
                    "S-6005", "D-1111", "M-5252", "KT-5353"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "T-MOBILE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Revvl", "Prism II", "Concord", "myTouch Q 2",
                    "myTouch 2", "Prism", "Move Balance", "Arizona",
                    "myTouch 4G Slide", "Vivacity", "Energy", "SpringBoard",
                    "myTouch Q", "myTouch", "G-Slate", "G2x",
                    "Move", "Sidekick 4G", "Vairy Text II", "Vibe E200",
                    "Comet", "myTouch 4G", "G2", "myTouch 3G Slide",
                    "Garminfone", "Pulse Mini", "myTouch 3G Fender Edition", "HD2",
                    "Tap", "Pulse", "Vairy Text", "Vairy Touch II",
                    "G2 Touch", "Dash 3G", "myTouch 3G 1.2", "myTouch 3G",
                    "MDA Vario V", "MDA Compact V", "Sidekick LX 2009", "Shadow 2",
                    "Vairy Touch", "MDA Basic", "G1", "Shadow",
                    "MDA Vario IV", "MDA Compact IV", "Sidekick", "Sidekick Slide",
                    "Sidekick LX", "Sidekick 3", "Wing", "Dash",
                    "myTouch qwerty"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "TECNO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Camon 11 Pro", "Camon 11", "Pop 1s", "Pop 1 Pro",
                    "Pop 1", "F2 LTE", "F2", "Pop 1 Lite",
                    "Pouvoir 2 Pro", "Pouvoir 2", "Pouvoir 1", "Spark Pro",
                    "Spark Plus", "Spark CM", "Spark 2", "Spark",
                    "Camon X Pro", "Camon X", "Camon CX Manchester City LE", "Camon CX Air",
                    "Camon CX", "Camon CM", "Phantom 8", "Phantom 6 Plus",
                    "Phantom 6"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "TOSHIBA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Excite Go", "Excite 7c AT7-B8", "Excite Pro", "Excite Write",
                    "Excite Pure", "Excite 10 SE", "Excite 13 AT335", "Excite 10 AT305",
                    "Excite 7.7 AT275", "Excite AT200", "Thrive 7", "Windows Phone IS12T",
                    "Thrive", "K01", "TG02", "TG01",
                    "G810", "G910 / G920", "G450", "G710",
                    "G900", "G500", "TS605", "TX80",
                    "TS32", "TS705", "TS608", "TX62",
                    "904T", "903T", "705T", "TS921",
                    "TS808", "TS803", "TS10"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "UNNECTO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Bolt", "Neo V", "Quattro S", "Quattro V",
                    "Drone XS", "Primo 2G", "Omnia", "Swift",
                    "Quattro X", "Drone XL", "Drone X", "Air 5.5",
                    "Air 5.0", "Air 4.5", "Rush", "Quattro Z",
                    "Drone Z", "Quattro", "Blaze", "Drone",
                    "Tap", "Pro Z", "Pro", "Edge",
                    "Shell", "Pebble", "Drift", "Eco",
                    "Primo 3G", "Primo"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "VERTU")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Signature Touch (2015)", "Aster", "Signature Touch", "Constellation 2013",
                    "Ti", "Constellation", "Ascent Ferrari GT", "Constellation Quest",
                    "Ascent 2010", "Constellation Ayxta", "Ascent Ti Damascus Steel", "Signature S",
                    "Ascent Ti", "Constellation 2006", "Diamond", "Ascent",
                    "Signature"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "VERYKOOL")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "s5702 Royale Quattro", "s5037 Apollo Quattro", "s5036 Apollo", "s5200 Orion",
                    "s5031 Bolt Turbo", "sl5029 Bolt Pro LTE", "s5029 Bolt Pro", "s5205 Orion Pro",
                    "s6005X Cyprus Pro", "s5527 Alpha Pro", "s5528 Cosmo", "SL5565 Rocket",
                    "T7445", "s4009 Crystal", "s5526 Alpha", "s5034 Spear Jr.",
                    "s5035 Spear", "s5028 Bolt", "s5027 Bolt Pro", "s5007 Lotus Plus",
                    "s4513 Luna II", "SL5560 Maverick Pro", "s5021 Wave Pro", "s5019 Wave",
                    "s4008 Leo V", "Sl5200 Eclipse", "sl5050 Phantom", "s6004 Cyprus Jr.",
                    "s5524 Maverick III Jr.", "s5525 Maverick III", "Kolorpad LTE TL8010", "s4007 Leo IV",
                    "s6005 Cyprus II", "s5530 Maverick II", "s5030 Helix II", "SL5011 Spark LTE",
                    "SL6010 Cyprus LTE", "s5025 Helix", "s5020 Giant", "s5001 Lotus",
                    "SL4502 Fusion II", "SL5550 Maverick LTE", "s5518Q Maverick", "s5017Q Dorado",
                    "sl5009 Jet", "R28 Denali", "T7440 Kolorpad II", "s5017 Dorado",
                    "s3504 Mystic II", "s5518 Maverick", "s5012 Orbit", "SL4500 Fusion",
                    "i330 Sunray", "s4510 Luna", "s5014 Atlas", "s6001 Cyprus",
                    "s5015 Spark II", "s4010 Gazelle", "s4002 Leo", "s3501 Lynx",
                    "R27", "s5511 Juno Quatro", "s5510 Juno", "s354",
                    "SL5000 Quantum", "s401", "s352", "s351",
                    "i129", "s505", "s450", "T742",
                    "s353", "R80L Granite II", "i240", "i603",
                    "i128", "i133", "s400", "i127",
                    "s470", "i316", "RS90", "i126",
                    "RS75", "i607", "s732", "s758",
                    "s350", "R623", "i601", "i121C",
                    "i121", "R25", "s735", "s135",
                    "i320", "i315N", "s635", "s728",
                    "i625", "i130", "R800", "i123",
                    "s757", "i675", "i674", "i672",
                    "R16", "s700", "i605", "i604",
                    "i125", "S815", "R23", "R620",
                    "i285", "i725", "CD611", "i800",
                    "i720", "i705", "R80", "R13",
                    "s810", "i650", "i610", "i600",
                    "i410", "i310", "i315", "i305",
                    "i277", "i280", "i270", "i122",
                    "i119", "i117", "i115"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "VIVO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Y89", "NEX Dual Display", "Y93 (Mediatek)", "Y93s",
                    "Y95", "Z1 Lite", "Y93", "Y91 (Mediatek)",
                    "Y91", "Y81i", "Z3", "Z3i",
                    "Y71i", "V11i", "Y97", "X23",
                    "V11 (V11 Pro)", "Y83 Pro", "V9 6GB", "Z1i",
                    "NEX S", "NEX A", "Z1", "Y83",
                    "Y81", "X21i", "Y53i", "Y71",
                    "V9 Youth", "V9", "X21 UD", "X21",
                    "V7", "X20 Plus", "X20 Plus UD", "X20",
                    "V7+", "Y65", "Y69", "Y53",
                    "X9s Plus", "X9s", "V5s", "Y25",
                    "Y55L (vivo 1603)", "Y55s", "V5 Lite (vivo 1609)", "V5 Plus",
                    "Y67", "Xplay6", "X9 Plus", "X9",
                    "V5", "X7 Plus", "X7", "V3Max",
                    "V3", "X6S Plus", "X6S", "Xplay5 Elite",
                    "Xplay5", "Y51", "X6", "X6Plus",
                    "V1", "Y15S", "V1 Max", "Y31",
                    "Y35", "Y37", "X5Max Platinum Edition", "X5Pro",
                    "X5Max+", "X5Max", "Y11", "X5",
                    "Xplay3S", "Xshot", "X3S", "Y28",
                    "Y27", "Y22", "Y15", "Xplay7"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "VODAFONE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Smart E9", "Smart X9", "Smart N9", "Smart N9 lite",
                    "Smart Tab N8", "Smart E8", "Smart V8", "Smart N8",
                    "Tab Prime 7", "Smart Turbo 7", "Smart Platinum 7", "Smart ultra 7",
                    "Smart prime 7", "Smart first 7", "Smart speed 6", "Smart ultra 6",
                    "Tab Prime 6", "Smart prime 6", "Smart first 6", "Smart 4 max",
                    "Smart Tab 4G", "Smart 4G", "Smart 4 turbo", "Smart 4 power",
                    "Smart 4", "Smart 4 mini", "Smart Tab III 10.1", "Smart Tab III 7",
                    "Chat 655", "Smart Mini", "Smart III 975", "Smart Tab II 10",
                    "Smart Tab II 7", "V860 Smart II", "Smart Tab 10", "Smart Tab 7",
                    "155", "555 Blue", "858 Smart", "945",
                    "553", "360 H2", "845", "547",
                    "546", "543", "350 Messaging", "345 Text",
                    "248", "247 Solar", "246", "250",
                    "150", "1240", "840", "541",
                    "540", "340", "360 H1", "360 M1",
                    "533 Crystal", "1231", "V-X760", "Indie",
                    "835", "736", "735", "235",
                    "V720", "533", "830i", "526",
                    "332", "231", "1210", "725",
                    "810", "716", "527", "511",
                    "228", "710", "227", "226",
                    "225"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "WIKO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "View2 Go", "View2 Plus", "View Max", "View2 Pro",
                    "View2", "View Prime", "View XL", "View",
                    "WIM", "WIM Lite", "Upulse", "Upulse lite",
                    "Tommy2 Plus", "Tommy2", "Harry", "Jerry2",
                    "Jerry", "Kenny", "Lenny3 Max", "Lenny4",
                    "Lenny4 Plus", "Ufeel fab", "Ufeel go", "Ufeel",
                    "U Feel Prime", "U Feel Lite", "Tommy", "Sunny2 Plus",
                    "Sunny2", "Sunny", "Sunny Max", "Robby2",
                    "Robby", "Lenny3", "Fever SE", "Pulp Fab 4G",
                    "Pulp Fab", "Pulp", "Pulp 4G", "Fever 4G",
                    "Lenny2", "Rainbow Jam", "Rainbow Jam 4G", "Rainbow Lite 4G",
                    "Selfy 4G", "Rainbow UP 4G", "Sunset2", "Bloom2",
                    "Ridge 4G", "Ridge Fab 4G", "Highway Star 4G", "Highway Pure 4G",
                    "Lenny", "Birdy", "Goa", "Jimmy",
                    "Getaway", "Rainbow 4G", "Rainbow", "Highway 4G",
                    "Highway Signs", "Wax", "Highway"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "XIAOMI")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Redmi Go", "Redmi Note 7", "Mi Play", "Black Shark Helo",
                    "Mi Mix 3", "Redmi Note 6 Pro", "Mi 8 Pro", "Mi 8 Lite",
                    "Pocophone F1", "Mi A2 (Mi 6X)", "Mi A2 Lite (Redmi 6 Pro)", "Mi Max 3",
                    "Mi Pad 4", "Mi Pad 4 Plus", "Redmi 6", "Redmi 6A",
                    "Mi 8 Explorer", "Mi 8", "Mi 8 SE", "Redmi S2 (Redmi Y2)",
                    "Mi Mix 2S", "Redmi Note 5 AI Dual Camera", "Redmi Note 5 Pro", "Black Shark",
                    "Redmi Note 5 (Redmi 5 Plus)", "Redmi 5", "Redmi 5A", "Redmi Y1 (Note 5A)",
                    "Redmi Y1 Lite", "Mi Note 3", "Mi Mix 2", "Mi A1 (Mi 5X)",
                    "Mi Max 2", "Redmi 4 (4X)", "Mi 6", "Mi Pad 3",
                    "Mi 5c", "Redmi Note 4X", "Redmi Note 4", "Redmi 4A",
                    "Redmi 4 (China)", "Redmi 4 Prime", "Mi 6 Plus", "Mi Mix",
                    "Mi Note 2", "Mi 5s Plus", "Mi 5s", "Redmi Note 4 (MediaTek)",
                    "Redmi Pro", "Redmi 3x", "Redmi 3s Prime", "Redmi 3s",
                    "Redmi 3 Pro", "Mi 5", "Mi Max", "Mi 4s",
                    "Redmi Note 3", "Redmi 3", "Redmi Note Prime", "Mi Pad 2",
                    "Redmi Note 3 (MediaTek)", "Mi 4c", "Redmi Note 2", "Redmi 2 Pro",
                    "Redmi 2 Prime", "Mi 4i", "Mi Note Pro", "Mi Note",
                    "Redmi 2A", "Redmi 2", "Mi 4 LTE", "Redmi Note 4G",
                    "Mi 4", "Mi Pad 7.9", "Redmi Note", "Mi 3",
                    "Redmi 1S", "Redmi", "Mi 2A", "Mi 2S",
                    "Mi 2", "Mi 1S", "Mi 6c", "Mi Note Plus",
                    "Redmi Pro 2"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "XOLO")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Era 2X", "Era 2", "Era 1X", "Era X",
                    "Era 4K", "Era 4G", "One HD", "Black 3GB",
                    "Black 1X", "Black", "Era", "Cube 5.0",
                    "Prime", "LT2000", "A1010", "Win Q1000",
                    "8X-1020", "Q700 Club", "Q520s", "Q900s Plus",
                    "Omega 5.5", "Omega 5.0", "Opus 3", "Q710s",
                    "Q1020", "One", "Q2100", "Opus HD",
                    "Play 8X-1100", "Q510s", "Q700s plus", "Q1000s plus",
                    "Q610s", "A1000s", "Play 8X-1200", "Hive 8X-1000",
                    "A550S IPS", "Q900s", "Q500s IPS", "A700s",
                    "Play 6X-1000", "Q2000L", "Win Q900s", "Q1000 Opus2",
                    "Q1011", "Q1200", "Q600s", "A500S Lite",
                    "Q900T", "Q1010i", "A510s", "Q2500",
                    "A500 Club", "Q1010", "Q1100", "Q700s",
                    "Q3000", "LT900", "Q1000 Opus", "Play Tegra Note",
                    "Q500", "Q800 X-Edition", "A500S IPS", "Q2000",
                    "Q900", "A600", "A500L", "Q700i",
                    "Play Tab 7.0", "Tab", "Q1000s", "A500S",
                    "Play", "Q600", "X1000", "X910",
                    "X500", "Q1000", "Q800", "Q700",
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "YEZZ")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Max 1", "Andy 4E7", "Andy 5E5", "Epic T",
                    "Andy 4E4", "4.5EL LTE", "5M", "C21",
                    "Andy 5EI3 (2016)", "Andy 5E3", "Andy 4.7T", "Andy 5M LTE",
                    "CC40", "Andy 5.5M LTE VR", "Monte Carlo 55 LTE VR", "Monte Carlo 55 LTE",
                    "Classic C23A", "Andy 4E3I", "Andy 5E2I", "Andy 4EI2",
                    "Andy 3.5EI2", "Andy 6EL LTE", "Andy 5E LTE", "Andy C5E LTE",
                    "Andy 5EI3", "Andy 4EL2 LTE", "Classic Z51", "Andy 5EL LTE",
                    "Andy 4.5EL LTE", "Andy 3.5EI3", "Classic C60", "Andy 4E LTE",
                    "Andy 4E2I", "Andy 3.5E2I", "Z50", "ZC20",
                    "Billy 5S LTE", "Andy C5ML", "Andy C5QL", "Classic C50",
                    "Classic C22", "Classic C21A", "Monaco 47", "Billy 4",
                    "Andy 5T", "Andy C5VP", "Andy C5V", "Andy 5.5EI",
                    "Andy 4.5M", "Billy 4.7", "Andy 4EI", "Andy 3.5EH",
                    "Andy 5EI", "Andy 3.5EI", "Andy 6Q", "Classic C21",
                    "Andy A5QP", "Andy AZ4.5", "Epic T7FD", "Andy A3.5EP",
                    "Epic T7ED", "Andy A6M 1GB", "Andy A6M", "Andy A4M",
                    "Andy A4E", "Andy A5 1GB", "Andy A4.5 1GB", "Andy A4.5",
                    "Andy A4", "Andy A3.5", "Classic CC10", "Andy A5",
                    "Epic T7", "Classic C30", "Bonito YZ500", "Exclusive Z10",
                    "Andy 3G 3.5 YZ1110", "Andy 3G 4.0 YZ1120", "Ritmo 3 TV YZ433", "Ritmo 2 YZ420",
                    "Andy 3G 2.8 YZ11", "Classic C20", "Chico 2 YZ201", "Andy YZ1100",
                    "Fashion F10", "Bono 3G YZ700", "Moda YZ600", "Ritmo YZ400",
                    "Zenior YZ888", "Clasico YZ300", "Chico YZ200"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "YOTA")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "YotaPhone 3", "YotaPhone 2", "YotaPhone"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "YU")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "Ace", "Yureka 2", "Yunique 2", "Yureka Black",
                    "Yunique Plus", "Yureka S", "Yunicorn", "Yureka Note",
                    "Yutopia", "Yunique", "Yuphoria", "Yureka Plus",
                    "Yureka"
                });
            }
            else if (this.textBoxDeviceBrand.Text.ToString() == "ZTE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[]
                {
                    "nubia Red Magic Mars", "nubia X", "nubia Z18", "Axon 9 Pro",
                    "nubia Red Magic", "nubia Z18 mini", "nubia V18", "nubia N3",
                    "Blade V9 Vita", "Blade V9", "Tempo Go", "Blade A3",
                    "Blade A6", "Maven 2", "Blade X", "Axon M",
                    "nubia Z17s", "nubia Z17 miniS", "nubia Z17 lite", "Blade Z Max",
                    "Blade Force", "Tempo X", "Blade A601", "Grand X View 2",
                    "Blade V7 Plus", "Quartz", "nubia N2", "nubia M2",
                    "nubia M2 lite", "nubia M2 Play", "nubia Z17", "Axon 7s",
                    "Max XL", "nubia Z17 mini", "Blade A520", "nubia N1 lite",
                    "Blade V8 Mini", "Blade V8 Lite", "Blade A2 Plus", "Hawkeye",
                    "Blade V8 Pro", "Blade V8", "Axon 7 Max", "Grand X4",
                    "Blade V7 Max", "nubia Z11 mini S", "Axon 7 mini", "Warp 7",
                    "Zmax Pro", "nubia N1", "nubia Z11 Max", "Axon 7",
                    "nubia Z11", "Blade L110 (A110)", "Grand X Max 2", "nubia Z11 mini",
                    "Blade L5 Plus", "Blade V Plus", "Blade A610", "Blade A512",
                    "Blade A452", "Blade V7", "Blade A2", "Blade A910",
                    "Blade V7 Lite", "Axon Max", "nubia Prague S", "Grand X 3",
                    "Avid Plus", "Blade X9", "Blade X5", "Blade X3",
                    "Axon Watch", "Axon", "Blade S7", "Axon mini",
                    "Zmax 2", "Axon Elite", "nubia My Prague", "Axon Lux",
                    "Boost Max+", "Blade A460", "Blade D6", "Axon Pro",
                    "Blade A410", "Obsidian", "Grand X2", "Sonata 2",
                    "Blade Apex 3", "Maven", "Blade Q Pro", "Blade Qlux 4G",
                    "nubia Z9", "Blade S6 Plus", "nubia Z9 Max", "nubia Z9 mini",
                    "Open L", "Grand S3", "Blade L3 Plus", "Blade L3",
                    "Blade G Lux", "Blade G", "V5 Lux", "Blade S6",
                    "Imperial II", "Grand X Max+", "Star 2", "Grand X Plus Z826",
                    "Speed", "Grand S II", "Grand S Pro", "Zinger",
                    "Grand Xmax", "Zmax", "Blade Vec 4G", "Blade Vec 3G",
                    "Kis 3 Max", "nubia Z5S mini NX405H", "nubia Z7", "nubia Z7 Max",
                    "nubia Z7 mini", "Blade L2", "Kis 3", "Blade G2",
                    "Redbull V5 V9180", "Star 1", "nubia X6", "Grand Memo II LTE",
                    "Open C", "Open II", "Iconic Phablet", "Sonata 4G",
                    "Grand S II S291", "nubia Z5S", "nubia Z5S mini NX403A", "Grand S Flex",
                    "Blade Q Maxi", "Blade Q", "Blade Q Mini", "Warp 4G",
                    "Blade V", "Blade G V880G", "Reef", "Imperial",
                    "Vital N9810", "Grand X Pro", "Grand X2 In", "Grand X Quad V987",
                    "Blade III Pro", "Geek V975", "Grand Memo V9815", "Open",
                    "Blade C V807", "Director", "V81", "Grand S",
                    "Avid 4G", "V889M", "V887", "Kis III V790",
                    "Groove X501", "nubia Z5", "Flash", "Anthem 4G",
                    "Warp Sequent", "Grand Era U895", "Blade III", "Grand X IN",
                    "N880E", "Grand X LTE T82", "Grand X V970", "U880E",
                    "Score M", "Light Tab 300", "V96", "PF 100",
                    "T98", "Light Tab 3 V9S", "Era", "PF112 HD",
                    "Skate Acqua", "Orbit", "Kis V788", "V880E",
                    "Nova 3.5", "Nova 4 V8000", "Nova Messenger", "Style Q",
                    "Style Messanger", "V875", "Blade II V880+", "N910",
                    "PF200", "Optik", "Light Tab 2 V9A", "Light Tab V9C",
                    "FTV Phone", "Chorus", "Memo", "Tania",
                    "Warp", "Score", "Avail", "V9+",
                    "V9", "N721", "Skate", "V821",
                    "Amigo", "Racer II", "U900", "Libra",
                    "Rio", "Blade", "Sage", "X990D",
                    "N290", "N280", "R230", "R228 Dual SIM",
                    "R228", "R221", "R220", "S213",
                    "Salute F350", "F107", "E N72", "Racer",
                    "F951", "X990", "Bingo", "X760",
                    "E811", "Raise", "Xiang", "A261",
                    "S302", "F233", "F912", "F952",
                    "F928", "F870", "F600", "F103",
                    "F101", "F100", "Coral200 Sollar"
                });
            }
            else
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
            }
        }
    }
}
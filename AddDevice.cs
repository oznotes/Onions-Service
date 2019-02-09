using System;
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
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
            else
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
            }
        }
    }
}
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
            if (File.Exists("devices.dat"))
                contactFileContents = File.ReadAllText("devices.dat") + System.Environment.NewLine;
            contactFileContents += textBoxFirstName.Text + "|" +
                                   textBoxMiddleName.Text + "|" +
                                   textBoxLastName.Text + "|" +
                                   textBoxMobilePhone.Text + "|" +
                                   textBoxDeviceBrand.Text + "|" +
                                   textBoxDeviceModel.Text + "|" +
                                   textBoxWorkPhone.Text + "|" +
                                   textBoxEmail.Text;
            File.WriteAllText("devices.dat", contactFileContents);
            this.Close();

        }

        private void textBoxDeviceModel_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.textBoxDeviceBrand.Text.ToString());
            if (this.textBoxDeviceBrand.Text.ToString() == "APPLE")
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.AddRange(new string[] {
                "iPhone 4",
                "iPhone 4S",
                "iPhone 5",
                "iPhone 5S",
                "iPhone 6",
                "iPhone 6 Plus",
                "iPhone 6S",
                "iPhone 6S Plus",
                "iPhone 7",
                "iPhone 7 Plus",
                "iPhone 8",
                "iPhone 8 Plus",
                "iPhone X",
                "iPhone XS",
                "iPhone XS MAX"});
            }
            else
            {
                this.textBoxDeviceModel.AutoCompleteCustomSource.Clear();
            }
        }
    }
}
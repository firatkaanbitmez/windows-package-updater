using Squirrel;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using Timer = System.Windows.Forms.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsPackageUpdater.Forms
{
    public partial class frmMain : Form
    {
        //constants Sabitler
        #region
        private BackgroundWorker bgWorker;
        private int labelPosition;
        private bool isDragging = false;
        private Point lastLocation;
        public string versionNum;
        public int load_counter;
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private string enableStartup;
        private const string AppName = "WindowsPackageUpdater";
        private int countdownSeconds = 0;
        private int selectedHour = 1; 
        #endregion


        public frmMain()
        {

            //Install Components and First Start
            #region

            load_counter = Properties.Settings.Default.FirstMain;

            if (load_counter < 1)
            {
                load_counter++;

                Properties.Settings.Default.FirstMain = load_counter;
                Properties.Settings.Default.Save();

                frmFirstOpen frms = new frmFirstOpen();
                frms.ShowDialog();
                this.Close();

            }


            Loading();
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            lstUpdates.ColumnClick += lstUpdates_ColumnClick;

            string filePath = Application.StartupPath + "\\data.txt";
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                }
            }
           
            #endregion


        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            AddVersionNumber();
            CFU();

            //System Tray and minimize Settings
            #region
            if (string.IsNullOrEmpty(Properties.Settings.Default.windowsStart))
            {
                toggleWindowsStart.Checked = false;
             
                Properties.Settings.Default.windowsStart = "false";
            }
            else
            {
                if ("true" == Properties.Settings.Default.windowsStart.ToString())
                {
                    toggleWindowsStart.Checked = true;
                    
                }
                else
                {
                    toggleWindowsStart.Checked = false;
                   
                }
            }

            enableStartup = Properties.Settings.Default.windowsStart.ToString();

            if (enableStartup == "true")
            {
                // Program Startup ile başlatıldı
                this.WindowState = FormWindowState.Minimized; // Programı minimize olarak aç
                this.ShowInTaskbar = false; // Görev çubuğunda gösterme
                SetStartup(true);
                // Pencereyi ön plana getir
                SetForegroundWindow(this.Handle);
            }
            else
            {
                // Program masaüstünden tıklanarak açıldı
                this.WindowState = FormWindowState.Normal; // Programı normal boyutta aç
                this.ShowInTaskbar = true; // Görev çubuğunda göster
                SetStartup(false);

            }
            #endregion

            LoadData();

        }

        //SaveDATA  LoadDATA
        #region



        private void SaveData()
        {
            string appPath = Application.StartupPath;
            try
            {
                using (StreamWriter writer = new StreamWriter(appPath + "\\" + "data.txt"))
                {
                    writer.WriteLine(LastScanLabel.Text);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void LoadData()
        {

            try
            {
                using (StreamReader reader = new StreamReader("data.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        LastScanLabel.Text=line;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        #endregion

        //StartOn settings and minimize tray function
        #region

        private void SetStartup(bool enableStartup)
        {
            try
            {
                string keyPath = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Run";
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(keyPath, true);

                if (enableStartup)
                {
                    rk.SetValue(AppName, Assembly.GetExecutingAssembly().Location);
                }
                else
                {
                    rk.DeleteValue(AppName, false);
                }
            }
            catch (Exception ex)
            {
                // Notification durumunda bir Notification işleme mekanizması ekleme
                Console.WriteLine("Notification: " + ex.Message);
            }
        }



        public void BringToForeground()
        {
            if (WindowState == FormWindowState.Minimized || !Visible)
            {
                WindowState = FormWindowState.Normal;
            }

            bool top = TopMost;
            TopMost = true;
            TopMost = top;

            Show();
            Activate();
            BringToFront();
        }


        #endregion

        //LoadSettings
        #region

        private void LoadSettings()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.theme))
            {
                Properties.Settings.Default.theme = "Light";
                Properties.Settings.Default.Save();

            }
            // Seçilen saat'i saniyeye çevirin
            if (string.IsNullOrEmpty(Properties.Settings.Default.autoTime))
            {
                ComboBoxHour.SelectedIndex = 0; 
            }
            else
            {
                int cs= Convert.ToInt32(Properties.Settings.Default.autoTime.ToString());
                ComboBoxHour.SelectedIndex = cs;
            }


            // Timer'ı oluşturun
            timer = new Timer();

            // Interval değerini 1 saniye olarak ayarlayın (milisaniye cinsinden)
            timer.Interval = 1000;

            // Timer'ın zamanlayıcı olayını tanımlayın
            timer.Tick += TimerTick;
          

            LoadSavedImages();

            rjButton1.Enabled = false;
            panelinterface.Visible = false;
            panelAbouts.Visible = false;
            panelLanguage.Visible = false;
            panelSystem.Visible = false;
            panelUpdate.Visible = false;
            panelinterface.Visible = false;
            panelNotification.Visible=false;
            if ("tr-TR" == Properties.Settings.Default.language.ToString())
            {
                comboLanguages.SelectedIndex = 0;
            }
            if ("en-US" == Properties.Settings.Default.language.ToString())
            {
                comboLanguages.SelectedIndex = 1;
            }
                                  

            if ("true" == Properties.Settings.Default.autoupdate.ToString())
            {
                ToggleButtonAuto.Checked = true;

            }
            else
            {
                ToggleButtonAuto.Checked = false;
            }
           
            
            if ("false" == Properties.Settings.Default.notification.ToString())
            {
                ToggleButtonNoti.Checked = false;

            }
            else 
            {

                ToggleButtonNoti.Checked = true; 
            }

                       
            if ("false" == Properties.Settings.Default.alert.ToString())
            {
                ToggleButtonAlert.Checked = false;

            }
            else 
            { 
                ToggleButtonAlert.Checked = true; 
            }


            if (string.IsNullOrEmpty(Properties.Settings.Default.DarkBackground))
            {
                txtDarkBack.Tag = "22, 35, 50";
                txtDarkBack.Text = "22, 35, 50";
                txtDarkBack.ForeColor = Color.Transparent;
                txtDarkBack.BackColor = Color.FromArgb(22, 35, 50);
            }
            else
            {
                string rgbValues = Properties.Settings.Default.DarkBackground;
                string[] rgbArray = rgbValues.Split(',');

                int r = int.Parse(rgbArray[0]);
                int g = int.Parse(rgbArray[1]);
                int b = int.Parse(rgbArray[2]);

                txtDarkBack.Tag = $"{r},{g},{b}";
                txtDarkBack.Text = string.Format("{0}, {1}, {2}", r, g, b);
                txtDarkBack.ForeColor = Color.Transparent;
                txtDarkBack.BackColor = Color.FromArgb(r, g, b);

            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.DarkText))
            {
                txtDarkText.Tag = "240, 248, 255";
                txtDarkText.Text = "240, 248, 255";
                txtDarkText.ForeColor = Color.Transparent;
                txtDarkText.BackColor = Color.FromArgb(240, 248, 255);
            }
            else
            {
                string rgbValues = Properties.Settings.Default.DarkText;
                string[] rgbArray = rgbValues.Split(',');

                int r = int.Parse(rgbArray[0]);
                int g = int.Parse(rgbArray[1]);
                int b = int.Parse(rgbArray[2]);

                txtDarkText.Tag = $"{r},{g},{b}";
                txtDarkText.Text = string.Format("{0}, {1}, {2})", r, g, b);
                txtDarkText.ForeColor = Color.Transparent;
                txtDarkText.BackColor = Color.FromArgb(r, g, b);
            }


            if (string.IsNullOrEmpty(Properties.Settings.Default.DarkButtons))
            {
                txtDarkButton.Tag = "0, 95, 186";
                txtDarkButton.Text = "0, 95, 186";
                txtDarkButton.ForeColor = Color.Transparent;
                txtDarkButton.BackColor = Color.FromArgb(0, 95, 186);
            }
            else
            {
                string rgbValues = Properties.Settings.Default.DarkButtons;
                string[] rgbArray = rgbValues.Split(',');

                int r = int.Parse(rgbArray[0]);
                int g = int.Parse(rgbArray[1]);
                int b = int.Parse(rgbArray[2]);

                txtDarkButton.Tag = $"{r},{g},{b}";
                txtDarkButton.Text = string.Format("{0}, {1}, {2}", r, g, b);
                txtDarkButton.ForeColor = Color.Transparent;
                txtDarkButton.BackColor = Color.FromArgb(r, g, b);

            }


            if (string.IsNullOrEmpty(Properties.Settings.Default.LightBackground))
            {
                txtLightBack.Tag = "240, 248, 255";
                txtLightBack.Text = "240, 248, 255";
                txtLightBack.ForeColor = Color.Transparent;
                txtLightBack.BackColor = Color.FromArgb(240, 248, 255);
            }
            else
            {
                string rgbValues = Properties.Settings.Default.LightBackground;
                string[] rgbArray = rgbValues.Split(',');

                int r = int.Parse(rgbArray[0]);
                int g = int.Parse(rgbArray[1]);
                int b = int.Parse(rgbArray[2]);

                txtLightBack.Tag = $"{r},{g},{b}";
                txtLightBack.Text = string.Format("{0}, {1}, {2}", r, g, b);
                txtLightBack.ForeColor = Color.Transparent;
                txtLightBack.BackColor = Color.FromArgb(r, g, b);
            }


            if (string.IsNullOrEmpty(Properties.Settings.Default.LightText))
            {
                txtLightText.Tag = "22, 35, 50";
                txtLightText.Text = "22, 35, 50";
                txtLightText.ForeColor = Color.Transparent;
                txtLightText.BackColor = Color.FromArgb(22, 35, 50);
            }
            else
            {
                string rgbValues = Properties.Settings.Default.LightText;
                string[] rgbArray = rgbValues.Split(',');

                int r = int.Parse(rgbArray[0]);
                int g = int.Parse(rgbArray[1]);
                int b = int.Parse(rgbArray[2]);

                txtLightText.Tag = $"{r},{g},{b}";
                txtLightText.Text = string.Format("{0}, {1}, {2}", r, g, b);
                txtLightText.ForeColor = Color.Transparent;
                txtLightText.BackColor = Color.FromArgb(r, g, b);
            }


            if (string.IsNullOrEmpty(Properties.Settings.Default.LightButtons))
            {
                txtLightButton.Tag = "0, 95, 186";
                txtLightButton.Text = "0, 95, 186";
                txtLightButton.ForeColor = Color.Transparent;
                txtLightButton.BackColor = Color.FromArgb(0, 95, 186);
            }
            else
            {
                string rgbValues = Properties.Settings.Default.LightButtons;
                string[] rgbArray = rgbValues.Split(',');

                int r = int.Parse(rgbArray[0]);
                int g = int.Parse(rgbArray[1]);
                int b = int.Parse(rgbArray[2]);

                txtLightButton.Tag = $"{r},{g},{b}";
                txtLightButton.Text = string.Format("{0}, {1}, {2}", r, g, b);
                txtLightButton.ForeColor = Color.Transparent;
                txtLightButton.BackColor = Color.FromArgb(r, g, b);
            }


            if ("Light" == Properties.Settings.Default.theme.ToString())
            {
                SetLightTheme();
            }
            if ("Dark" == Properties.Settings.Default.theme.ToString())
            {
                SetDarkTheme();
            }



        }
        #endregion

        // Loading func
        #region
        private void Loading()
        {


            if ("tr-TR" == Properties.Settings.Default.language.ToString())
            {


                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                this.Controls.Clear();

                InitializeComponent();
               
                LoadSettings();

            }
            if ("en-US" == Properties.Settings.Default.language.ToString())
            {



                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                this.Controls.Clear();

                InitializeComponent();
                
                LoadSettings();

            }
        }
        #endregion

        //Move panel to form
        #region        
        private void panelUpper_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastLocation = e.Location;

        }

        private void panelUpper_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point diff = new Point(
                    e.Location.X - lastLocation.X,
                    e.Location.Y - lastLocation.Y);
                this.Location = new Point(
                    this.Location.X + diff.X,
                    this.Location.Y + diff.Y);
            }

        }

        private void panelUpper_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        private void comboLanguages_OnSelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void ComboBoxHour_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Focus();
        }
        #endregion

        //Exit and Minimize Buttons
        #region
        private void btnExit_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
        #endregion

        // MENÜLERRRR
        #region

        private void SystemSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelSystem.Visible = true;
            panelinterface.Visible = false;
            panelUpdate.Visible = false;
            panelAbouts.Visible = false;
            panelSystem.Dock = DockStyle.Fill;
            panelLanguage.Visible = false;
            panelNotification.Visible = false;
            btnSave.Visible = true;
            btnSave.BringToFront();
            btnBack.Visible = true;
            btnBack.BringToFront();
        }

        private void notificationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNotification.Visible = true;
            panelSystem.Visible = false;
            panelinterface.Visible = false;
            panelUpdate.Visible = false;
            panelAbouts.Visible = false;
            panelNotification.Dock = DockStyle.Fill;
            panelLanguage.Visible = false;

            btnSave.Visible = false;
         
            btnBack.Visible = true;
            btnBack.BringToFront();
        }

        private void languageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelNotification.Visible = false;
            panelinterface.Visible = false;
            panelUpdate.Visible = false;
            panelAbouts.Visible = false;
            panelSystem.Visible = false;
            panelLanguage.Visible = true;
            panelLanguage.Dock = DockStyle.Fill;
            btnSave.Visible = true;
            btnSave.BringToFront();
            btnBack.Visible = true;
            btnBack.BringToFront();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNotification.Visible = false;
            panelinterface.Visible = false;
            panelUpdate.Visible = false;
            panelAbouts.Visible = true;
            panelSystem.Visible = false;
            panelLanguage.Visible = false;
            panelAbouts.Dock = DockStyle.Fill;
            btnSave.Visible = false;
            btnOk.Visible = true;
            btnOk.BringToFront();
            btnBack.Visible = false;


        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNotification.Visible = false;
            panelinterface.Visible = false;
            panelUpdate.Visible = true;
            panelAbouts.Visible = false;
            panelSystem.Visible = false;
            panelLanguage.Visible = false;
            panelUpdate.Dock = DockStyle.Fill;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnBack.Visible = true;
            btnBack.BringToFront();
            btnUpdate.BringToFront();
        }



        private void userInterfaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panelinterface.Visible = true;
            panelUpdate.Visible = false;
            panelAbouts.Visible = false;
            panelNotification.Visible = false;
            panelLanguage.Visible = false;
            panelSystem.Visible = false;
            panelinterface.Dock = DockStyle.Fill;
            btnSave.Visible = true;
            btnSave.BringToFront();
            btnBack.Visible = true;
            btnBack.BringToFront();
            panel2.Dock = DockStyle.Top;
            kryptonButton1.PerformClick();
        }
        #endregion

        //Back Save ok Browse linklabel update 
        #region
        private void btnBack_Click(object sender, EventArgs e)
        {
            panelNotification.Visible = false;
            panelinterface.Visible = false;
            panelUpdate.Visible = false;
            panelSystem.Visible = false;
            panelLanguage.Visible = false;
            btnSave.Visible = false;
            btnBack.Visible = false;
            btnUpdate.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if ("Turkish" == comboLanguages.Texts.ToString())
            {
                Properties.Settings.Default.language = "tr-TR";
                Properties.Settings.Default.Save();

            }
            if ("English" == comboLanguages.Texts.ToString())
            {
                Properties.Settings.Default.language = "en-US";
                Properties.Settings.Default.Save();

            }
            if ("Türkçe" == comboLanguages.Texts.ToString())
            {
                Properties.Settings.Default.language = "tr-TR";
                Properties.Settings.Default.Save();

            }
            if ("İngilizce" == comboLanguages.Texts.ToString())
            {
                Properties.Settings.Default.language = "en-US";
                Properties.Settings.Default.Save();

            }
            
            if (toggleWindowsStart.Checked == true)
            {

                Properties.Settings.Default.windowsStart = "true";
            }
            if (toggleWindowsStart.Checked == false)
            {

                Properties.Settings.Default.windowsStart = "false";
            }

            Properties.Settings.Default.DarkButtons = txtDarkButton.Tag.ToString();
            Properties.Settings.Default.LightButtons = txtLightButton.Tag.ToString();

            Properties.Settings.Default.DarkBackground = txtDarkBack.Tag.ToString();
            Properties.Settings.Default.DarkText = txtDarkText.Tag.ToString();
            Properties.Settings.Default.LightBackground = txtLightBack.Tag.ToString();
            Properties.Settings.Default.LightText = txtLightText.Tag.ToString();
            Properties.Settings.Default.autoTime = ComboBoxHour.SelectedIndex.ToString();
          
            Properties.Settings.Default.Save();
            panelNotification.Visible = false;
            panelSystem.Visible = false;
            panelinterface.Visible = false;
            panelAbouts.Visible = false;
            btnSave.Visible = false;
            btnBack.Visible = false;
            panelSystem.Visible = false;
            panelLanguage.Visible = false;
            LoadSettings();
            Thread.Sleep(100);


            Application.Restart();

        }


        private void linkLabelProjectURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filePath = linkLabelProjectURL.Tag.ToString();
            var ps = new ProcessStartInfo(filePath)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            panelAbouts.Visible = false;
            panelLanguage.Visible = false;
            panelinterface.Visible = false;
            panelUpdate.Visible = false;

        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        #endregion

        //LABEL RESET COLORS 
        #region

        private void lblRESETCOLOR_MouseEnter(object sender, EventArgs e)
        {

            lblRESETCOLOR.ForeColor = Color.Green;


        }

        private void lblRESETCOLOR_MouseLeave(object sender, EventArgs e)
        {
            lblRESETCOLOR.ForeColor = Color.Red;

        }

        private void lblRESETCOLOR_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("All color Settings will be reset Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtDarkBack.Tag = "22, 35, 50";
                txtDarkBack.Text = "Background Color RGB (22, 35, 50)";
                txtDarkText.Tag = "240, 248, 255";
                txtDarkText.Text = "Text Color RGB (240, 248, 255)";
                txtLightBack.Tag = "240, 248, 255";
                txtLightBack.Text = "Background Color RGB (240, 248, 255)";
                txtLightText.Tag = "22, 35, 50";
                txtLightText.Text = "Text Color RGB (22, 35, 50)";

                txtDarkButton.Tag = "0, 95, 186";
                txtDarkButton.Text = "Text Color RGB (0, 95, 186)";

                txtLightButton.Tag = "0, 95, 186";
                txtLightButton.Text = "Text Color RGB (0, 95, 186)";

                Properties.Settings.Default.DarkBackground = txtDarkBack.Tag.ToString();
                Properties.Settings.Default.DarkText = txtDarkText.Tag.ToString();
                Properties.Settings.Default.LightBackground = txtLightBack.Tag.ToString();
                Properties.Settings.Default.LightText = txtLightText.Tag.ToString();
                Properties.Settings.Default.LightButtons = txtLightButton.Tag.ToString();
                Properties.Settings.Default.DarkButtons = txtDarkButton.Tag.ToString();

                Properties.Settings.Default.ImagePathLigt = null;

                Properties.Settings.Default.ImagePathDark = null;


                Properties.Settings.Default.Save();

                Application.Restart();

            }
            else if (result == DialogResult.No)
            {

            }
        }

        #endregion

        //GİTHUB UPDATER AND ASSEMBLY VERSİON NUMBER++ TİMER FOR Slader Notification
        #region
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelPosition -= 2;
            if (labelPosition < -labelTitle.Width)
            {
                labelPosition = panelUpper.ClientSize.Width;
            }
            labelTitle.Location = new Point(labelPosition, 10);
            panelUpper.Invalidate();
        }
        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            versionNum += $"v.{versionInfo.FileVersion}";
            labelCurrentVersion.Text = "Current Version " + versionNum.ToString();


        }
        public string releaseversion;
        public async void CheckForUpdates()
        {
            btnUpdate.Enabled = false;

            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/firatkaanbitmez/WindowsPackageUpdater"))
            {


                try
                {
                    var updateInfo = await mgr.CheckForUpdate();

                    if (updateInfo.ReleasesToApply.Any())
                    {

                        var updateResult = await mgr.UpdateApp();
                        UpdateManager.RestartApp();

                    }
                    else
                    {

                    }
                }
                catch (Exception)
                {

                }
            }


        }



        public async void CFU()//Verilen github linki üzerinden Updateleri kontrol edecek fonksiyon
        {

            using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/firatkaanbitmez/WindowsPackageUpdater"))
            {
                //this.logger.Info("Checking for updates");

                try
                {
                    var updateInfo = await mgr.CheckForUpdate();

                    if (updateInfo.ReleasesToApply.Any())
                    {




                        timer1.Interval = 50;
                        timer1.Tick += timer1_Tick;
                        timer1.Start();

                        btnUpdate.Visible = true;
                        btnUpdate.Enabled = true;

                        if ("en-US" == Properties.Settings.Default.language.ToString())
                        {
                            this.Alert("New Available version \nInstall Now!");
                            labelTitle.Text = "There Is A New Version Available. Please See Update Section";
                        }
                        if ("tr-TR" == Properties.Settings.Default.language.ToString())
                        {
                            this.Alert("Kullanılabilir Yeni Sürüm Var \nHemen Yükle!");
                            labelTitle.Text = "Kullanılabilir Yeni Sürüm Var. Lütfen Güncelleme Bölümüne Bakın";
                        }

                        var sizeInBytes = updateInfo.FutureReleaseEntry.Filesize;
                        var sizeInMegabytes = (double)sizeInBytes / 1048576;
                        string size = $"{sizeInMegabytes:N2} MB";


                        var repoUrl = "https://github.com/firatkaanbitmez/WindowsPackageUpdater/releases/latest";

                        var client = new System.Net.Http.HttpClient();
                        client.DefaultRequestHeaders.Add("User-Agent", "WindowsPackageUpdaterReleaseBot");
                        var response = await client.GetAsync(repoUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var json = JObject.Parse(responseContent);

                            var tagName = json["tag_name"].ToString();
                            var releaseNotes = json["body"].ToString();



                            if ("en-US" == Properties.Settings.Default.language.ToString())
                            {
                                labelAvailableInfo.Text = "New Available Version v." + tagName + " There is a Update Required!" + "\n\nUpdate File Size " + size + "\n\nRelease notes:\n\n" + releaseNotes;
                            }
                            if ("tr-TR" == Properties.Settings.Default.language.ToString())
                            {
                                labelAvailableInfo.Text = "Yeni Kullanılabilir Version v." + tagName + " Güncelleme Gerekiyor!" + "\n\nGüncelleme Dosya Boyutu " + size + "\n\nSürüm Notları:\n\n" + releaseNotes;
                            }

                        }
                        else
                        {
                            labelAvailableInfo.Text = "Error retrieving latest release: " + response.StatusCode + "Windows Package Updater Release Notes";
                        }

                    }
                }
                catch (Exception)
                {

                }
            }



        }


        #endregion

        //Form Closed and Closing
        #region

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopTimer();
            Thread.Sleep(100);
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer();
            Thread.Sleep(100);
            Application.Exit();

        }
        #endregion

        //Alert +Notification
        #region

        public void Alert(string msg)
        {
            bool isAlertEnabled = ToggleButtonAlert.Checked;


            if (isAlertEnabled)
            {
                frmUpdateNotify frm = new frmUpdateNotify();
                frm.showAlert(msg);
                frm.Show();
            }




            
        }


        private void Notification(string msg, Color labelColor)
        {
            bool isNotificationEnabled = ToggleButtonNoti.Checked;

            if (isNotificationEnabled)
            {
                frmNotification frmnoti = new frmNotification();
                frmnoti.showAlert(msg, labelColor);
                frmnoti.Show();
            }
        }

        #endregion

        //Themes LIGHT DARK THEMES SETTİNGS AND COLORS
        #region

        private void SetLightTheme()
        {
            string tagLightBack = txtLightBack.Tag.ToString();
            string[] lightcolorpart1 = tagLightBack.Split(',');
            int lightBackR = Int32.Parse(lightcolorpart1[0]);
            int lightBackG = Int32.Parse(lightcolorpart1[1]);
            int lightBackB = Int32.Parse(lightcolorpart1[2]);
            string tagLightText = txtLightText.Tag.ToString();
            string[] lightcolorpart2 = tagLightText.Split(',');
            int lightTextR = Int32.Parse(lightcolorpart2[0]);
            int lightTextG = Int32.Parse(lightcolorpart2[1]);
            int lightTextB = Int32.Parse(lightcolorpart2[2]);


            string tagLightButtons = txtLightButton.Tag.ToString();
            string[] lightcolorpart3 = tagLightButtons.Split(',');
            int lightButtonR = Int32.Parse(lightcolorpart3[0]);
            int lightButtonG = Int32.Parse(lightcolorpart3[1]);
            int lightButtonB = Int32.Parse(lightcolorpart3[2]);


            pictureBox1.Image = pictureBox6.Image;

            ChangeAllLabelButtonsColors(this, Color.FromArgb(lightButtonR, lightButtonG, lightButtonB));
            ChangeAllPanelBackgroundColors(this, Color.FromArgb(lightBackR, lightBackG, lightBackB));
            ChangeAllLabelForegroundColors(this, Color.FromArgb(lightTextR, lightTextG, lightTextB));
            panelUpper.BackColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);
            labelTitle.ForeColor = Color.FromArgb(lightBackR, lightBackG, lightBackB);
            menuStrip1.BackColor = Color.FromArgb(lightBackR, lightBackG, lightBackB);
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);
            }


            txtLightBack.ForeColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);
            txtLightText.ForeColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);
            txtDarkBack.ForeColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);
            txtDarkText.ForeColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);

            button1.Image = Properties.Resources.lighttheme;
            pictureBox6.BackColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);
            pictureBox5.BackColor = Color.FromArgb(lightBackR, lightBackG, lightBackB);

            btnExit.Image = Properties.Resources.light_exit;
            btnMinimize.Image = Properties.Resources.light_subtract;
            linkLabelProjectURL.LinkColor = Color.FromArgb(lightTextR, lightTextG, lightTextB);
            lblRESETCOLOR.ForeColor = Color.Red;
            UpdateStatusLabel();
        }

        private void SetDarkTheme()
        {
            string tagDarkBack = txtDarkBack.Tag.ToString();
            string[] darkBackColorParts = tagDarkBack.Split(',');
            int darkBackR = Int32.Parse(darkBackColorParts[0]);
            int darkBackG = Int32.Parse(darkBackColorParts[1]);
            int darkBackB = Int32.Parse(darkBackColorParts[2]);
            string TagDarkText = txtDarkText.Tag.ToString();
            string[] darkBackColorParts2 = TagDarkText.Split(',');
            int darkTextR = Int32.Parse(darkBackColorParts2[0]);
            int darkTextG = Int32.Parse(darkBackColorParts2[1]);
            int darkTextB = Int32.Parse(darkBackColorParts2[2]);

            string TagDarkButton = txtDarkButton.Tag.ToString();
            string[] darkBackColorParts3 = TagDarkButton.Split(',');
            int darkButtonR = Int32.Parse(darkBackColorParts3[0]);
            int darkButtonG = Int32.Parse(darkBackColorParts3[1]);
            int darkButtonB = Int32.Parse(darkBackColorParts3[2]);

            pictureBox1.Image = pictureBox5.Image;



            ChangeAllLabelButtonsColors(this, Color.FromArgb(darkButtonR, darkButtonG, darkButtonB));
            ChangeAllPanelBackgroundColors(this, Color.FromArgb(darkBackR, darkBackG, darkBackB));
            ChangeAllLabelForegroundColors(this, Color.FromArgb(darkTextR, darkTextG, darkTextB));
            panelUpper.BackColor = Color.FromArgb(darkTextR, darkTextG, darkTextB);
            labelTitle.ForeColor = Color.FromArgb(darkBackR, darkBackG, darkBackB);

            pictureBox6.BackColor = Color.FromArgb(darkBackR, darkBackG, darkBackB);
            pictureBox5.BackColor = Color.FromArgb(darkTextR, darkTextG, darkTextB);
            button1.Image = Properties.Resources.darktheme;
            btnExit.Image = Properties.Resources.dark_exit;
            btnMinimize.Image = Properties.Resources.dark_subtract;
            linkLabelProjectURL.LinkColor = Color.FromArgb(darkTextR, darkTextG, darkTextB);
            lblRESETCOLOR.ForeColor = Color.Red;


            txtLightBack.ForeColor = Color.FromArgb(darkTextR, darkTextG, darkTextB);
            txtLightText.ForeColor = Color.FromArgb(darkTextR, darkTextG, darkTextB);
            txtDarkBack.ForeColor = Color.FromArgb(darkTextR, darkTextG, darkTextB);
            txtDarkText.ForeColor = Color.FromArgb(darkTextR, darkTextG, darkTextB);
            UpdateStatusLabel();
        }
        public static void ChangeAllPanelBackgroundColors(Control control, Color color)
        {
            var panels = control.Controls.OfType<Panel>();
            foreach (var panel in panels)
            {
                panel.BackColor = color;
            }

            foreach (Control ctrl in control.Controls)
            {
                ChangeAllPanelBackgroundColors(ctrl, color);
            }
        }
        public static void ChangeAllLabelForegroundColors(Control control, Color color)
        {
            var labels = control.Controls.OfType<Label>();
            foreach (var label in labels)
            {
                label.ForeColor = color;
            }

            foreach (Control ctrl in control.Controls)
            {
                ChangeAllLabelForegroundColors(ctrl, color);
            }
        }
        public static void ChangeAllLabelButtonsColors(Control control, Color color)
        {
            var buttons = control.Controls.OfType<System.Windows.Forms.Button>();
            foreach (var button in buttons)
            {
                if (!string.IsNullOrWhiteSpace(button.Text)) // Button Text'i boşluk içermiyorsa
                {
                    button.BackColor = color;
                }
            }

            foreach (Control ctrl in control.Controls)
            {
                ChangeAllLabelButtonsColors(ctrl, color);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if ("Light" == Properties.Settings.Default.theme.ToString())
            {
                SetDarkTheme();
                Properties.Settings.Default.theme = "Dark";
                Properties.Settings.Default.Save();
            }
            else
            {
                SetLightTheme();
                Properties.Settings.Default.theme = "Light";
                Properties.Settings.Default.Save();
            }

            this.ToggleButtonAuto.Focus();
        }


        #endregion

        //Color Set Buttons Dark+Light Text,Background,Buttons
        #region

        private void btnDarkBack_Click(object sender, EventArgs e)
        {
            if (kryptonColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = kryptonColorDialog1.Color;
                txtDarkBack.Tag = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                txtDarkBack.Text = string.Format($"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}");


            }
        }

        private void btnDarkText_Click(object sender, EventArgs e)
        {
            if (kryptonColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = kryptonColorDialog1.Color;
                txtDarkText.Tag = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                txtDarkText.Text = string.Format($"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}");

            }
        }

        private void btnDarkButton_Click(object sender, EventArgs e)
        {
            if (kryptonColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = kryptonColorDialog1.Color;
                txtDarkButton.Tag = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                txtDarkButton.Text = string.Format($"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}");

            }

        }
        private void btnDarkicon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Resim Seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePathDark = openFileDialog.FileName;

                pictureBox5.Image = LoadImageFromFile(imagePathDark);

                Properties.Settings.Default.ImagePathDark = imagePathDark;
               
            }

        }

        private void btnLightBack_Click(object sender, EventArgs e)
        {
            if (kryptonColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = kryptonColorDialog1.Color;
                txtLightBack.Tag = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                txtLightBack.Text = string.Format($"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}");

            }
        }

        private void btnLightText_Click(object sender, EventArgs e)
        {
            if (kryptonColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = kryptonColorDialog1.Color;
                txtLightText.Tag = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                txtLightText.Text = string.Format($"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}");

            }
        }
        private void btnLightButton_Click(object sender, EventArgs e)
        {
            if (kryptonColorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = kryptonColorDialog1.Color;
                txtLightButton.Tag = $"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}";

                txtLightButton.Text = string.Format($"{selectedColor.R}, {selectedColor.G}, {selectedColor.B}");

            }
        }
        private void btnLighticon_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Resim Seçin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePathLight = openFileDialog.FileName;

                pictureBox6.Image = LoadImageFromFile(imagePathLight);

                Properties.Settings.Default.ImagePathLigt = imagePathLight;
               
            }
        }
        private void LoadSavedImages()
        {
            string imagePathLight = Properties.Settings.Default.ImagePathLigt;
            string imagePathDark = Properties.Settings.Default.ImagePathDark;

                       
            if (!string.IsNullOrEmpty(imagePathLight) && File.Exists(imagePathLight))
            {
                pictureBox6.Image = Image.FromFile(imagePathLight);
            }
            else
            {
                pictureBox6.Image = Properties.Resources.iconn;
            }


            if (!string.IsNullOrEmpty(imagePathDark) && File.Exists(imagePathDark))
            {
                pictureBox5.Image = Image.FromFile(imagePathDark);
            }
            else
            {
                pictureBox5.Image = Properties.Resources.iconn;
            }


        }

        private Image LoadImageFromFile(string imagePath)
        {
            try
            {
                using (FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda uygun bir işlem yapabilirsiniz
                MessageBox.Show("Resim yüklenirken bir hata oluştu: " + ex.Message);
                return null;
            }
        }

        #endregion

        //BACKGROUNWORKER dowork+completed
        #region
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                label4.Text = "Checking for Updates...";
                rjButton1.Enabled = false;
                btnCheckforUpdates.Enabled = false;
                lstUpdates.Items.Clear();
                pictureBox3.Visible = true;
                pictureBox4.Image = Properties.Resources.icons8_synchronize_48px;

                pictureBox3.Image = Properties.Resources.loading;



                // Güncellemeleri yüklemek için PowerShell betiğini çalıştırın
                string script = @"class Software {
    [string]$Name
    [string]$Id
    [string]$Version
    [string]$AvailableVersion
}

$upgradeResult = winget upgrade | Out-String

$lines = $upgradeResult -split '\r?\n' | ForEach-Object { $_.Trim() }

# Başlık bilgisini içeren satırı bulun
$fl = 0
while (-not $lines[$fl].StartsWith('Name')) {
    $fl++
}

# Başlık bilgisinin olduğu satırda, ID ve Version bulunan karakterleri tespit edin
$NameStart = $lines[$fl].IndexOf('Name')
$idStart = $lines[$fl].IndexOf('Id')
$versionStart = $lines[$fl].IndexOf('Version')
$availableStart = $lines[$fl].IndexOf('Available')
$sourceStart = $lines[$fl].IndexOf('Source')

# Gerçek paketlerde dönerek ilgili alanlara göre bölün
$upgradeList = @()
for ($i = $fl + 1; $i -lt $lines.Length; $i++) {
    $line = $lines[$i]
    if ($line.Length -gt ($sourceStart + 1) -and -not $line.StartsWith('-')) {
        $name = $line.Substring(0, $idStart).TrimEnd()
        $id = $line.Substring($idStart, $versionStart - $idStart).TrimEnd()
        $version = $line.Substring($versionStart, $availableStart - $versionStart).TrimEnd()
        $available = $line.Substring($availableStart, $sourceStart - $availableStart).TrimEnd()

        $name = $name -replace 'ÔÇ', ''
        $name = $name.Trim()

        $id = $id -replace 'Ğ', ''
        $id = $id.Trim()

        $version = $version.Trim()
        $available = $available.Trim()

        $software = [Software]::new()
        $software.Name = $name+ ','
        $software.Id = $id+ ','
        $software.Version = $version+ ','
        $software.AvailableVersion = $available

        $upgradeList += $software
    }
}

$upgradeList | Format-Table
";


                // PowerShell betiğini çalıştırarak güncellemeleri alın
                string result = RunScript(script);

                // İşlem tamamlandığında arayüzü güncellemek için bir argüman gönderin
                e.Result = result;

            }
            catch (Exception ex)
            {
                // Notification durumunda Notification mesajını döndürün
                e.Result = "Notification: " + ex.Message;

                label4.Text = "Error during update checking";
                
                btnCheckforUpdates.Enabled = true;
                lstUpdates.Items.Clear();
                pictureBox3.Visible = true;
                pictureBox4.Image = Properties.Resources.error;

               

            }
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {

                pictureBox3.Visible = false;

                pictureBox3.Image = Properties.Resources.error;
                MessageBox.Show("Güncellemeler yüklenirken bir hata oluştu: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {

                pictureBox3.Visible = false;

                MessageBox.Show("Güncelleme işlemi iptal edildi.");
            }
            else
            {

                string result = e.Result as string;


                UpdateListView(result);
                btnCheckforUpdates.Enabled = true;
                rjButton1.Enabled = true;
                pictureBox3.Visible = false;

                // Tetikleme işlemlerini burada gerçekleştirin
                DateTime currentTime = DateTime.Now;
               
                LastScanLabel.Text ="Last Scan Time : " + currentTime.ToString("HH:mm");

                pictureBox4.Image = Properties.Resources.icons8_Update_Done_48px;

                SaveData();



            }
        }
        #endregion

        //Check For Update +Select Update BUTTONS
        #region
        private void btnCheckforUpdates_Click(object sender, EventArgs e)
        {
           
            // BackgroundWorker'ı başlatın
            bgWorker.RunWorkerAsync();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            if (lstUpdates.SelectedItems.Count > 0)
            {

                ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                string programId = selectedUpdate.SubItems[1].Text;
                string programname = selectedUpdate.SubItems[0].Text;

                DialogResult dialogResult = MessageBox.Show(programname + " will be Install.Do you Confirm?", "Software Install", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    if (selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text == "Installation started")
                    {
                        this.Notification("This update has already been\nstarted.It cannot be restarted.", Color.Blue);
                        return;
                    }

                    if (selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text == "Installed")
                    {
                        this.Notification("This update has been \nsuccessfully installed.\nCannot be reinstalled", Color.Blue);
                        return;
                    }
                    if (selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text == "You're up to date.")
                    {
                        MessageBox.Show("This is a Notification Message. It cannot be updated.");
                        return;
                    }
                    if (selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 4].Text == "Microsoft.VCRedist.2015+.x6")
                    {


                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 4].Text = "Microsoft.VCRedist.2015+.x64";

                        programId = "Microsoft.VCRedist.2015+.x64";



                    }

                    

                    string inputText1 = selectedUpdate.SubItems[1].Text;
                    string inputText2 = selectedUpdate.SubItems[0].Text;

                    string[] words1 = inputText1.Split('.', (char)StringSplitOptions.RemoveEmptyEntries);
                    string[] words2 = inputText2.Split('.', (char)StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word1 in words1)
                    {
                        string exeFileName = word1 + ".exe";
                        System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                        process1.StartInfo.FileName = "taskkill";
                        process1.StartInfo.Arguments = "/IM " + exeFileName + " /F";
                        process1.StartInfo.CreateNoWindow = true;
                        process1.StartInfo.UseShellExecute = false;
                        process1.Start();
                        process1.WaitForExit();
                    }

                    foreach (string word2 in words2)
                    {
                        string exeFileName = word2 + ".exe";
                        System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                        process2.StartInfo.FileName = "taskkill";
                        process2.StartInfo.Arguments = "/IM " + exeFileName + " /F";
                        process2.StartInfo.CreateNoWindow = true;
                        process2.StartInfo.UseShellExecute = false;
                        process2.Start();
                        process2.WaitForExit();
                    }

                    if (selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text == "Yükleme tamamlanamadı")
                    {
                        _ = ReProgram(programId);
                        selectedUpdate.SubItems[4].Text = "Uninstall+Install started";
                    }
                    else
                    {
                        selectedUpdate.SubItems[4].Text = "Installation started";
                        _ = UpdateProgram(programId);
                    }

                   
                }
                else
                {
                    return;
                }


            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz bir program seçin.");
            }
        }
        #endregion

        //RunScript(POWERSHELL)+ UPDATELİSTVİEW (Bilgilerin Listview a işlenmesi)+ Install Program
        #region
        private void UpdateListView(string result)
        {
            lstUpdates.Items.Clear();

            if (result.StartsWith("Notification:"))
            {
                // Notification durumunda mesajı gösterin
                ListViewItem item = new ListViewItem(result);
                lstUpdates.Items.Add(item);
                item.SubItems.Add("You're up to date.");
                item.SubItems.Add("You're up to date.");
                item.SubItems.Add("You're up to date.");
                item.SubItems.Add("You're up to date.");
                label4.Text = "You're up to date";
                pictureBox4.Image = Properties.Resources.icons8_Update_Done_48px;
                this.Notification("Scan Completed.\nNo updates Available", Color.Red);
            }
            else
            {
                // Güncellemeleri ListView'e ekleme
                string[] lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                bool isHeaderLine = true; // İlk satır başlık satırı
                foreach (string line in lines)
                {
                    // Başlık veya ayırıcı satırları atlayın
                    if (isHeaderLine || line.StartsWith("----"))
                    {
                        isHeaderLine = false;
                        continue;
                    }

                    var arr = line.Replace(" ", "").Split(',');

                    ListViewItem lvi = new ListViewItem(Encoding.UTF8.GetString(Encoding.Default.GetBytes(arr[0])));

                    for (int i = 1; i < arr.Length; i++)
                    {
                        lvi.SubItems.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(arr[i])));
                    }

                    lvi.SubItems.Add("Available Update");
                    lstUpdates.Items.Add(lvi);
                }
                if (ToggleButtonAuto.Checked == true)
                {

                    label4.Text = "There are Updates available";
                    pictureBox4.Image = Properties.Resources.icons8_available_updates_48px_1;
                    this.Notification("The automatic scan found\nnew updates and will install them..", Color.Green);

                    foreach (ListViewItem item in lstUpdates.Items)
                    {
                        string programId = item.SubItems[1].Text;

                        if (item.SubItems[4].Text == "Installation started")
                        {
                            this.Notification("This update has already been\nstarted.It cannot be restarted.", Color.Blue);
                            return;
                        }

                        if (item.SubItems[4].Text == "Installed")
                        {
                            this.Notification("This update has been \nsuccessfully installed.\nCannot be reinstalled", Color.Blue);
                            return;
                        }
                        if (item.SubItems[4].Text == "You're up to date.")
                        {
                            MessageBox.Show("This is a Notification Message. It cannot be updated.");
                            return;
                        }
                        if (item.SubItems[4].Text == "Microsoft.VCRedist.2015+.x6")
                        {


                            item.SubItems[4].Text = "Microsoft.VCRedist.2015+.x64";

                            programId = "Microsoft.VCRedist.2015+.x64";



                        }

                        

                        string inputText1 = item.SubItems[1].Text;
                        string inputText2 = item.SubItems[0].Text;

                        string[] words1 = inputText1.Split('.', (char)StringSplitOptions.RemoveEmptyEntries);
                        string[] words2 = inputText2.Split('.', (char)StringSplitOptions.RemoveEmptyEntries);

                        foreach (string word1 in words1)
                        {
                            string exeFileName = word1 + ".exe";
                            System.Diagnostics.Process process1 = new System.Diagnostics.Process();
                            process1.StartInfo.FileName = "taskkill";
                            process1.StartInfo.Arguments = "/IM " + exeFileName + " /F";
                            process1.StartInfo.CreateNoWindow = true;
                            process1.StartInfo.UseShellExecute = false;
                            process1.Start();
                            process1.WaitForExit();
                        }

                        foreach (string word2 in words2)
                        {
                            string exeFileName = word2 + ".exe";
                            System.Diagnostics.Process process2 = new System.Diagnostics.Process();
                            process2.StartInfo.FileName = "taskkill";
                            process2.StartInfo.Arguments = "/IM " + exeFileName + " /F";
                            process2.StartInfo.CreateNoWindow = true;
                            process2.StartInfo.UseShellExecute = false;
                            process2.Start();
                            process2.WaitForExit();
                        }

                        if (item.SubItems[4].Text == "Yükleme tamamlanamadı")
                        {
                            _ = ReProgram(programId);
                            item.SubItems[4].Text = "Uninstall+Install started";
                        }
                        else
                        {
                            item.SubItems[4].Text = "Installation started";
                            _ = UpdateProgram(programId);
                        }


                    }



                }
                else
                {
                    label4.Text = "There are Updates available";
                    pictureBox4.Image = Properties.Resources.icons8_available_updates_48px_1;
                    this.Notification("Scan Completed.\nNew Updates are Available.", Color.Green);

                }





              
            }
        }





        private string RunScript(string script)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();

            pipeline.Commands.AddScript(script);
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();

            runspace.Close();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject pSObject in results)
            {
                stringBuilder.AppendLine(pSObject.ToString());
            }

            return stringBuilder.ToString();
        }
     

        private async Task UpdateProgram(string programId)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "winget";
            startInfo.Arguments = $"install --id {programId} --accept-package-agreements --accept-source-agreements --silent --force";
            startInfo.RedirectStandardOutput = true; // Standart çıktıyı yakalamak için
            startInfo.UseShellExecute = false; // Shell'i kullanmadan işlemi başlatmak için
            startInfo.CreateNoWindow = true; // Pencere oluşturmadan işlemi başlatmak için
            process.StartInfo = startInfo;

            List<string> outputLines = new List<string>(); // Çıktı satırlarını depolamak için bir liste

            process.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    outputLines.Add(e.Data); // Çıktıyı satır listesine ekleyin
               
                }
                
            };

            process.Start();
            process.BeginOutputReadLine();

            await Task.Run(() => process.WaitForExit()); // İşlem tamamlanana kadar bekleyin
          
            // İşlem tamamlandığında çıktıyı işleyin ve lstUpdates listesini güncelleyin
            foreach (string outputLine in outputLines)
            {
                // İşlem çıktısını işleyin ve lstUpdates listesini güncelleyin
                if (outputLine.Contains("Successfully installed"))
                {
                    Invoke(new Action(() =>
                    {
                        ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text = "Installed";
                    }));
                }
                else if (outputLine.Contains("No match found"))
                {
                    Invoke(new Action(() =>
                    {
                        ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text = "Hata: Program bulunamadı";
                    }));
                }
                else
                {
                    
                    Invoke(new Action(() =>
                    {
                        ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text = "Yükleme tamamlanamadı";
                      
                    }));
                }
               
            }
          
        }


        private async Task ReProgram(string programId)
        {
            Process uninstallProcess = new Process();

            // Uninstall işlemi
            ProcessStartInfo uninstallStartInfo = new ProcessStartInfo();
            uninstallStartInfo.FileName = "winget";
            uninstallStartInfo.Arguments = $"uninstall --id {programId} --silent --force";
            uninstallStartInfo.RedirectStandardOutput = true;
            uninstallStartInfo.UseShellExecute = false;
            uninstallStartInfo.CreateNoWindow = true;
            uninstallProcess.StartInfo = uninstallStartInfo;

            List<string> outputLines = new List<string>(); // Çıktı satırlarını depolamak için bir liste

            uninstallProcess.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    outputLines.Add(e.Data); // Çıktıyı satır listesine ekleyin
                }
            };

            uninstallProcess.Start();
            uninstallProcess.BeginOutputReadLine();

            await Task.Run(() =>
            {
                uninstallProcess.WaitForExit(); // Uninstall işleminin tamamlanmasını bekleyin
            });

            // İşlem tamamlandığında çıktıyı işleyin ve lstUpdates listesini güncelleyin
            foreach (string outputLine in outputLines)
            {
                // İşlem çıktısını işleyin ve lstUpdates listesini güncelleyin
                if (outputLine.Contains("No match found"))
                {
                    Invoke(new Action(() =>
                    {
                        ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text = "Hata: Program bulunamadı";
                    }));
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text = "Uninstall Failed";
                    }));

                    return; // Uninstall işlemi başarısız olduysa install işlemine devam etmeyin
                }
            }

            Process installProcess = new Process();

            // Install işlemi
            ProcessStartInfo installStartInfo = new ProcessStartInfo();
            installStartInfo.FileName = "winget";
            installStartInfo.Arguments = $"install --id {programId} --accept-package-agreements --accept-source-agreements --silent --force";
            installStartInfo.RedirectStandardOutput = true;
            installStartInfo.UseShellExecute = false;
            installStartInfo.CreateNoWindow = true;
            installProcess.StartInfo = installStartInfo;

            outputLines.Clear(); // Önceki çıktı satırlarını temizleyin

            installProcess.OutputDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    outputLines.Add(e.Data); // Çıktıyı satır listesine ekleyin
                }
            };

            installProcess.Start();
            installProcess.BeginOutputReadLine();

            await Task.Run(() =>
            {
                installProcess.WaitForExit(); // Install işleminin tamamlanmasını bekleyin
            });

            // İşlem tamamlandığında çıktıyı işleyin ve lstUpdates listesini güncelleyin
            foreach (string outputLine in outputLines)
            {
                // İşlem çıktısını işleyin ve lstUpdates listesini güncelleyin
                if (outputLine.Contains("Successfully installed"))
                {
                    Invoke(new Action(() =>
                    {
                        ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text = "Installed";
                    }));
                }
                else
                {
                    Invoke(new Action(() =>
                    {
                        ListViewItem selectedUpdate = lstUpdates.SelectedItems[0];
                        selectedUpdate.SubItems[selectedUpdate.SubItems.Count - 1].Text = "Install Failed";
                    }));
                }
            }
        }






        #endregion

        //Listview Columb Shorter 
        #region
        private void lstUpdates_ColumnClick(object sender, ColumnClickEventArgs e)
        {


            int columnIndex = e.Column;

            // Mevcut sıralama yöntemini kontrol et
            if (lstUpdates.ListViewItemSorter is ListViewItemComparer comparer)
            {
                // Aynı sütuna tekrar tıklandığında sıralama yöntemini tersine çevir
                if (comparer.GetSortOrder() == SortOrder.Ascending)
                    comparer.sortOrder = SortOrder.Descending;
                else
                    comparer.sortOrder = SortOrder.Ascending;
            }
            else
            {
                // Farklı bir sütuna tıklandığında yeni bir sıralama yöntemi oluştur
                lstUpdates.ListViewItemSorter = new ListViewItemComparer(columnIndex, SortOrder.Ascending);
            }

            // Listeyi yeniden sırala
            lstUpdates.Sort();
        }



        public class ListViewItemComparer : IComparer
        {
            private int columnIndex;
            public SortOrder sortOrder;

            public ListViewItemComparer(int columnIndex, SortOrder sortOrder)
            {
                this.columnIndex = columnIndex;
                this.sortOrder = sortOrder;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = (ListViewItem)x;
                ListViewItem itemY = (ListViewItem)y;

                string textX = itemX.SubItems[columnIndex].Text;
                string textY = itemY.SubItems[columnIndex].Text;

                // İstenen sıralama yöntemine göre karşılaştırma yap
                int result;
                if (sortOrder == SortOrder.Ascending)
                    result = string.Compare(textX, textY);
                else
                    result = string.Compare(textY, textX);

                return result;
            }

            public SortOrder GetSortOrder()
            {
                return sortOrder;
            }
        }
        #endregion

        // System Minimize TRAY ( Notify+ Move+ Toolstrip +Show+exit+Scan
        #region
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;


        }


        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCheckforUpdates.PerformClick();


        }


     

        private void comboLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        private void ComboBoxHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();

        }



        #endregion

        // ALL TOGGLE SWİTCH --  DARK LİGHT THEME BUTTON
        #region
        private void ToggleButtonAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleButtonAuto.Checked)
            {
                Properties.Settings.Default.autoupdate = "true";
                Properties.Settings.Default.Save();
               
                
                StartTimer();
            }
            else
            {
                Properties.Settings.Default.autoupdate = "false";
                Properties.Settings.Default.Save();
               
                StopTimer();
            }
        }
        private void ToggleButtonNoti_CheckedChanged(object sender, EventArgs e)
        {


            bool isNotificationEnabled = ToggleButtonNoti.Checked;

            if (isNotificationEnabled)
            {
                Properties.Settings.Default.notification = "true";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.notification = "false";
                Properties.Settings.Default.Save();
            }





        }

        private void ToggleButtonAlert_CheckedChanged(object sender, EventArgs e)
        {
            bool isAlertEnabled = ToggleButtonAlert.Checked;

            if (isAlertEnabled)
            {
                Properties.Settings.Default.alert = "true";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.alert = "false";
                Properties.Settings.Default.Save();
            }
        }
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            kryptonButton2.Enabled = true;
            panelDark.Visible = true;
            panelLight.Visible = false;
            panelDark.Width = 740;
            panelDark.Height = 270;
            panelDark.Location = new Point(3, 35);
            kryptonButton1.Enabled = false;
            panelDark.BringToFront();
            btnSave.Visible = true;
            btnSave.BringToFront();
            btnBack.Visible = true;
            btnBack.BringToFront();
            lblRESETCOLOR.BringToFront();

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            kryptonButton1.Enabled = true;
            panelLight.Visible = true;
            panelDark.Visible = false;
            kryptonButton2.Enabled = false;
            panelLight.Width = 740;
            panelLight.Height = 270;
            panelLight.Location = new Point(3, 35);
            panelLight.BringToFront();

            btnSave.Visible = true;
            btnSave.BringToFront();
            btnBack.Visible = true;
            btnBack.BringToFront();
            lblRESETCOLOR.BringToFront();
        }



        #endregion

        //otomatik tarama timer ve diğer ayaralr
        #region

        private void StartTimer()
        {
            // Seçilen saat'i saniyeye çevirin
            if (ComboBoxHour.SelectedIndex == -1)
            {
                ComboBoxHour.SelectedIndex = 0; // 1. indeksi seçin
            }

            selectedHour = int.Parse(ComboBoxHour.SelectedItem.ToString());
            countdownSeconds = selectedHour *60 *60;

            // Timer'ı başlatın
            timer.Start();
            UpdateStatusLabel();
            
        }


        private void StopTimer()
        {
            // Timer'ı durdurun
            timer.Stop();
            UpdateStatusLabel();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            countdownSeconds--;
            

            if (countdownSeconds <= 0)
            {
                btnCheckforUpdates.PerformClick();
                
                // Geri sayımı sıfırla ve tekrar başlat
                countdownSeconds = selectedHour *60 *60;
                UpdateStatusLabel();

                Timer delayTimer = new Timer();
                delayTimer.Interval = 500;
                delayTimer.Tick += (s, ev) =>
                {
                   
                    delayTimer.Stop();
                };
                delayTimer.Start();
            }
        }

        private string FormatTime(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
        }

        private void UpdateStatusLabel()
        {
            if (timer.Enabled)
            {
                StatusLabel.Text = "On";                
                btnCheckforUpdates.PerformClick();
                StatusLabel.ForeColor = Color.FromArgb(25, 156, 87);
               


            }
            else
            {
                StatusLabel.Text = "Off";                
                StatusLabel.ForeColor = Color.Red;
                

            }
        }


        #endregion

      

       
    }
}

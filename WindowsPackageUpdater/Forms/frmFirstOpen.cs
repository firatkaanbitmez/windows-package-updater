using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace WindowsPackageUpdater.Forms
{
    public partial class frmFirstOpen : Form
    {
        private int loadCounter;
        private Process cmd;
        private Mutex mutex;

        public frmFirstOpen()
        {
            InitializeComponent();
            loadCounter = 0;
            mutex = new Mutex(true, "WindowsPackageUpdater");
        }

        private void frmFirstOpen_Load(object sender, EventArgs e)
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                // Uygulama zaten çalışıyorsa çıkış yap
                MessageBox.Show("Windows Package Updater is already running.", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (loadCounter < 1)
            {
                loadCounter = 1;
                Properties.Settings.Default.First = loadCounter;
                Properties.Settings.Default.Save();

                cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.OutputDataReceived += Cmd_OutputDataReceived;
                cmd.Start();
                cmd.BeginOutputReadLine();

                // İşlemleri arka arkaya çalıştır
                RunCommand("cd %userprofile%\\downloads");
                RunCommand("curl -L https://github.com/microsoft/winget-cli/releases/latest/download/Microsoft.DesktopAppInstaller_8wekyb3d8bbwe.msixbundle -o winpackageins.msixbundle");
                RunCommand("powershell -command \"Add-AppPackage -path \"%userprofile%\\downloads\\winpackageins.msixbundle\"\"");
                RunCommand("winget search zoom --accept-source-agreements");
                RunCommand("winget source reset --force");
                RunCommand("winget source add -n winget \"https://cdn.winget.microsoft.com/cache\"");
                RunCommand("winget source update --accept-source-agreements");
                RunCommand("winget search vlc --accept-source-agreements");
                RunCommand("cd %userprofile%\\desktop");
                RunCommand("taskkill /f /im WindowsPackageUpdater.exe");
                RunCommand("WindowsPackageUpdater.lnk");
            }
            else
            {
                frmMain frms = new frmMain();
                frms.ShowDialog();
                this.Close(); // Close Application

            }
        }

        private void RunCommand(string command)
        {
            cmd.StandardInput.WriteLine(command);

            cmd.StandardInput.Flush();
        }

        private void Cmd_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            SetText(e.Data);
        }

        private delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            if (text != null)
            {
                if (richTextBox2.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    richTextBox2.AppendText(text);

                    if (text.Contains("curl"))
                    {
                        materialLabel2.Text = "The necessary packages for the ";
                        materialLabel3.Text = "Windows Installer are being Downloaded.";
                    }
                    else if (text.Contains("powershell"))
                    {
                        materialLabel2.Text = "The Package is Loading...";
                        materialLabel3.Text = "";
                    }
                    else if (text.Contains("zoom"))
                    {
                        materialLabel2.Text = "Necessary settings are being adjusted.";
                        materialLabel3.Text = "A little later, Windows Package Updater will open.";
                    }
                    else if (text.Contains("failed"))
                    {
                        materialLabel2.Text = "An unexpected error has occurred..";
                        materialLabel3.Text = "Please Restart.";

                        loadCounter = 0;
                        Properties.Settings.Default.First = loadCounter;
                        Properties.Settings.Default.Save();

                        frmMain fmsss = new frmMain();
                        fmsss.load_counter = loadCounter;
                    }
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            mutex.ReleaseMutex();
        }
    }
}

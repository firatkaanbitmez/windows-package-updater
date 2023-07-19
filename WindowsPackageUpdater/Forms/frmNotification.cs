using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsPackageUpdater.Forms
{
    public partial class frmNotification : Form
    {
        public frmNotification()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }
        private int x, y;
        private frmNotification.enmAction action;
        private void frmNotification_Load(object sender, EventArgs e)
        {
            if ("en-US" == Properties.Settings.Default.language.ToString())
            {
                NotifyRemindLater.Text = "Remind Me Later";
                button1.Text = "Install Now";
            }
            if ("tr-TR" == Properties.Settings.Default.language.ToString())
            {
                NotifyRemindLater.Text = "Daha Sonra Hatırlat";
                button1.Text = "Şimdi Yükle";
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TOOLWINDOW;
                return cp;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //timer1.Interval = 1;

            //frmMain frm = new frmMain();
            //frm.CheckForUpdates();
            //action = enmAction.close;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 3000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void NotifyRemindLater_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void NotifyRemindLater_MouseEnter(object sender, EventArgs e)
        {
            NotifyRemindLater.ForeColor = Color.Red;
        }

        private void NotifyRemindLater_MouseLeave(object sender, EventArgs e)
        {
            NotifyRemindLater.ForeColor = Color.FromArgb(0, 82, 127);

        }
        public void showAlert(string msg, Color labelColor)
        {
            NotifyLabel.ForeColor = labelColor;
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                frmNotification frm = (frmNotification)Application.OpenForms[fname];
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height + i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 1;
            this.NotifyLabel.Text = msg;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;

            timer1.Start();
        }
    }
}

using WindowsPackageUpdater.Forms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsPackageUpdater
{
    public partial class frmWelcomeOpening : Form
    {
        private bool isDragging = false;
        private Point lastLocation;

        public frmWelcomeOpening()
        {

            InitializeComponent();
            if (string.IsNullOrEmpty(Properties.Settings.Default.theme))
            {
                Properties.Settings.Default.theme = "Light";
                Properties.Settings.Default.Save();

            }
        }
       

        private void welcomeform_Load(object sender, EventArgs e)
        {


            //if (string.IsNullOrEmpty(Properties.Settings.Default.outrate))
            //{
            //    Loading();
            //}
            //else
            //{
            //    frmMain frms = new frmMain();
            //    frms.ShowDialog();
            //    this.Close();
            //}

        }




        private void Loading()
        {
            


            if ("tr-TR" == Properties.Settings.Default.language.ToString())
            {


                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
                this.Controls.Clear();

                InitializeComponent();
             
                LoadSettings();
                btnLanguage.Text = "English";
                btnLanguage.Image = Properties.Resources.english_flag;
            }
            if ("en-US" == Properties.Settings.Default.language.ToString())
            {



                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                this.Controls.Clear();

                InitializeComponent();
               
                LoadSettings();
                btnLanguage.Text = "Türkçe"; ;
                btnLanguage.Image = Properties.Resources.turkish_flag;
            }

            
        }

        private void LoadSettings()
        {
            if ("Light" == Properties.Settings.Default.theme.ToString())
            {
                SetLightTheme();
            }
            if ("Dark" == Properties.Settings.Default.theme.ToString())
            {
                SetDarkTheme();
            }

            panelWelcomeFirst.Visible = true;
            panelWelcomeFirst.Dock = DockStyle.Fill;
         
            comboExtension.SelectedIndex = 0;
            comboChannels.SelectedIndex = 1;
            comboOutRate.SelectedIndex = 3;
            comboConfimation.SelectedIndex = 1;
            comboOpenFileAfter.SelectedIndex = 1;
            textBox1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        }

        //Express , Custom and Save Buttons
        #region


        private void btnExpress_Click(object sender, EventArgs e)
        {
            if ("tr-TR" == Properties.Settings.Default.language.ToString())
            {
                DialogResult result = MessageBox.Show("Hızlı kurulumla Devam etmek istiyor musunuz?", "Hızlı Kurulum", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {


                   

                    Application.Restart();
                }
                else
                {
                    
                }
            }
            if ("en-US" == Properties.Settings.Default.language.ToString())
            {
                DialogResult result = MessageBox.Show("Do you want to Continue with Express Installation?", "Express Installation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    

                    Application.Restart();
                }
                else
                {
                    
                }
            }
            
        }


        private void btnCustom_Click(object sender, EventArgs e)
        {
            panelWelcomeFirst.Visible=false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

            if ("tr-TR" == Properties.Settings.Default.language.ToString())
            {
                DialogResult result = MessageBox.Show("Seçtiğiniz Ayarlar Kaydedilecek.Emin misiniz?", "Ayarlar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {


                 

                    Application.Restart();


                }
                else
                {

                }
            }
            if ("en-US" == Properties.Settings.Default.language.ToString())
            {
                DialogResult result = MessageBox.Show("Your selected settings will be saved. Are you sure?", "Settings", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    

                    Application.Restart();
                }
                else
                {

                }
            }


        }
        #endregion
        //Button Back Custom Menu
        #region
        private void btnBack_Click(object sender, EventArgs e)
        {
            panelWelcomeFirst.Visible = true;
            panelWelcomeFirst.Dock = DockStyle.Fill;
        }
        #endregion

        //Load Devies
        #region
    
        #endregion

        //Move panel to form
        #region
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        #endregion

        //ComboBoxes Selections
        #region
        private void comboDevies_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        private void comboExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        private void comboOutRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        private void comboChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        private void comboSaveLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        private void comboConfimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        private void comboOpenFileAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDefaultWall.Focus();
        }

        #endregion

        //Language
        #region
        private void btnLanguage_Click(object sender, EventArgs e)
        {
            if (btnLanguage.Text.ToString() == "Türkçe")
            {
                Properties.Settings.Default.language = "tr-TR";
                Properties.Settings.Default.Save();

                Application.Restart();
            }
            if (btnLanguage.Text.ToString() == "English")
            {
                Properties.Settings.Default.language = "en-US";
                Properties.Settings.Default.Save();

                Application.Restart();
            }

        }
        #endregion

        //Buton Browse
        #region
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    textBox1.Text = fbd.SelectedPath;
            }
        }
        #endregion

        //Exit and Minimize Buttons
        #region
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

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
        private void SetLightTheme()
        {

            ChangeAllPanelBackgroundColors(this, Color.FromArgb(240, 248, 255));
            ChangeAllLabelForegroundColors(this, Color.FromArgb(43, 45, 57));
            panelUpper.BackColor = Color.FromArgb(43, 45, 57);
            labelWelcomeTitle.ForeColor = Color.FromArgb(240, 248, 255);
            //menuStrip1.BackColor = Color.FromArgb(240, 248, 255);
            //foreach (ToolStripMenuItem item in menuStrip1.Items)
            //{
            //    item.ForeColor = Color.FromArgb(43, 45, 57);
            //}
            this.BackColor = Color.FromArgb(43, 45, 57);
            button1.Image = Properties.Resources.lighttheme;
            btnExit.Image = Properties.Resources.light_exit;
            btnMinimize.Image = Properties.Resources.light_subtract;
            labelwelcomeInfo4.ForeColor = Color.Red;
            pictureBox1.Image = Properties.Resources.iconn;
        }
        private void SetDarkTheme()
        {

            ChangeAllPanelBackgroundColors(this, Color.FromArgb(43, 45, 57));
            ChangeAllLabelForegroundColors(this, Color.FromArgb(240, 248, 255));
            panelUpper.BackColor = Color.FromArgb(240, 248, 255);
            labelWelcomeTitle.ForeColor = Color.FromArgb(43, 45, 57);
            //menuStrip1.BackColor = Color.FromArgb(43, 45, 57);
            //foreach (ToolStripMenuItem item in menuStrip1.Items)
            //{
            //    item.ForeColor = Color.FromArgb(240, 248, 255);
            //}
            this.BackColor = Color.FromArgb(240, 248, 255);
            button1.Image = Properties.Resources.darktheme;
            btnExit.Image = Properties.Resources.dark_exit;
            btnMinimize.Image = Properties.Resources.dark_subtract;
            labelwelcomeInfo4.ForeColor = Color.Red;
            pictureBox1.Image= Properties.Resources.iconn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.FromArgb(43, 45, 57))
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
        }
    }
}

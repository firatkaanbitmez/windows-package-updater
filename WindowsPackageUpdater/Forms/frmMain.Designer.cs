using System.Drawing;
using System.Windows.Forms;

namespace WindowsPackageUpdater.Forms
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelUpper = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelCustomize = new System.Windows.Forms.Panel();
            this.panelAbouts = new System.Windows.Forms.Panel();
            this.btnOk = new WindowsPackageUpdater.RJControls.RJButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.linkLabelProjectURL = new System.Windows.Forms.LinkLabel();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.btnUpdate = new WindowsPackageUpdater.RJControls.RJButton();
            this.labelAvailableInfo = new System.Windows.Forms.Label();
            this.labelCurrentVersion = new System.Windows.Forms.Label();
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.comboLanguages = new WindowsPackageUpdater.RJControls.RJComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.panelinterface = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.kryptonButton1 = new WindowsPackageUpdater.RJControls.RJButton();
            this.kryptonButton2 = new WindowsPackageUpdater.RJControls.RJButton();
            this.panelLight = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnLightBack = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnLightText = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnLightButton = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnLighticon = new WindowsPackageUpdater.RJControls.RJButton();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLightBack = new System.Windows.Forms.TextBox();
            this.txtLightText = new System.Windows.Forms.TextBox();
            this.txtLightButton = new System.Windows.Forms.TextBox();
            this.panelDark = new System.Windows.Forms.Panel();
            this.btnDarkBack = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnDarkText = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnDarkButton = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnDarkIcon = new WindowsPackageUpdater.RJControls.RJButton();
            this.labelColorScheme = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDarkBack = new System.Windows.Forms.TextBox();
            this.txtDarkText = new System.Windows.Forms.TextBox();
            this.txtDarkButton = new System.Windows.Forms.TextBox();
            this.lblRESETCOLOR = new System.Windows.Forms.Label();
            this.panelSystem = new System.Windows.Forms.Panel();
            this.ComboBoxHour = new WindowsPackageUpdater.RJControls.RJComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.toggleWindowsStart = new WindowsPackageUpdater.RJControls.RJToggleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelNotification = new System.Windows.Forms.Panel();
            this.ToggleButtonAlert = new WindowsPackageUpdater.RJControls.RJToggleButton();
            this.label16 = new System.Windows.Forms.Label();
            this.ToggleButtonNoti = new WindowsPackageUpdater.RJControls.RJToggleButton();
            this.label15 = new System.Windows.Forms.Label();
            this.lstUpdates = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.notificationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ınterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.languageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ToggleButtonAuto = new WindowsPackageUpdater.RJControls.RJToggleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.rjButton1 = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnCheckforUpdates = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnBack = new WindowsPackageUpdater.RJControls.RJButton();
            this.btnSave = new WindowsPackageUpdater.RJControls.RJButton();
            this.LastScanLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelDefaultWall = new System.Windows.Forms.Panel();
            this.kryptonColorDialog1 = new Krypton.Toolkit.KryptonColorDialog();
            this.kryptonContextMenuItems3 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.scanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelUpper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCustomize.SuspendLayout();
            this.panelAbouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelUpdate.SuspendLayout();
            this.panelLanguage.SuspendLayout();
            this.panelinterface.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panelDark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panelSystem.SuspendLayout();
            this.panelNotification.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelDefaultWall.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Name = "labelTitle";
            // 
            // panelUpper
            // 
            this.panelUpper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.panelUpper.Controls.Add(this.button1);
            this.panelUpper.Controls.Add(this.btnMinimize);
            this.panelUpper.Controls.Add(this.btnExit);
            this.panelUpper.Controls.Add(this.pictureBox1);
            this.panelUpper.Controls.Add(this.labelTitle);
            resources.ApplyResources(this.panelUpper, "panelUpper");
            this.panelUpper.Name = "panelUpper";
            this.panelUpper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseDown);
            this.panelUpper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseMove);
            this.panelUpper.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelUpper_MouseUp);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AliceBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::WindowsPackageUpdater.Properties.Resources.lighttheme;
            this.button1.Name = "button1";
            this.button1.TabStop = false;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AliceBlue;
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.ForeColor = System.Drawing.Color.Black;
            this.btnMinimize.Image = global::WindowsPackageUpdater.Properties.Resources.light_subtract;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.TabStop = false;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Image = global::WindowsPackageUpdater.Properties.Resources.light_exit;
            this.btnExit.Name = "btnExit";
            this.btnExit.TabStop = false;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsPackageUpdater.Properties.Resources.iconn;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelCustomize
            // 
            this.panelCustomize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.panelCustomize.Controls.Add(this.panelAbouts);
            this.panelCustomize.Controls.Add(this.panelUpdate);
            this.panelCustomize.Controls.Add(this.panelLanguage);
            this.panelCustomize.Controls.Add(this.panelinterface);
            this.panelCustomize.Controls.Add(this.panelSystem);
            this.panelCustomize.Controls.Add(this.panelNotification);
            this.panelCustomize.Controls.Add(this.lstUpdates);
            this.panelCustomize.Controls.Add(this.menuStrip1);
            this.panelCustomize.Controls.Add(this.pictureBox3);
            this.panelCustomize.Controls.Add(this.pictureBox4);
            this.panelCustomize.Controls.Add(this.label4);
            this.panelCustomize.Controls.Add(this.ToggleButtonAuto);
            this.panelCustomize.Controls.Add(this.label5);
            this.panelCustomize.Controls.Add(this.rjButton1);
            this.panelCustomize.Controls.Add(this.btnCheckforUpdates);
            this.panelCustomize.Controls.Add(this.btnBack);
            this.panelCustomize.Controls.Add(this.btnSave);
            this.panelCustomize.Controls.Add(this.LastScanLabel);
            this.panelCustomize.Controls.Add(this.StatusLabel);
            this.panelCustomize.Controls.Add(this.label3);
            resources.ApplyResources(this.panelCustomize, "panelCustomize");
            this.panelCustomize.ForeColor = System.Drawing.Color.AliceBlue;
            this.panelCustomize.Name = "panelCustomize";
            // 
            // panelAbouts
            // 
            this.panelAbouts.Controls.Add(this.btnOk);
            this.panelAbouts.Controls.Add(this.pictureBox2);
            this.panelAbouts.Controls.Add(this.linkLabelProjectURL);
            resources.ApplyResources(this.panelAbouts, "panelAbouts");
            this.panelAbouts.Name = "panelAbouts";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnOk.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnOk.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnOk.BorderRadius = 16;
            this.btnOk.BorderSize = 0;
            this.btnOk.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnOk.Name = "btnOk";
            this.btnOk.TextColor = System.Drawing.Color.AliceBlue;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WindowsPackageUpdater.Properties.Resources.middle_earth_shadow_of_mordo;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // linkLabelProjectURL
            // 
            resources.ApplyResources(this.linkLabelProjectURL, "linkLabelProjectURL");
            this.linkLabelProjectURL.LinkColor = System.Drawing.Color.AliceBlue;
            this.linkLabelProjectURL.Name = "linkLabelProjectURL";
            this.linkLabelProjectURL.TabStop = true;
            this.linkLabelProjectURL.Tag = "https://github.com/firatkaanbitmez/DriverUpdater";
            this.linkLabelProjectURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelProjectURL_LinkClicked);
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.btnUpdate);
            this.panelUpdate.Controls.Add(this.labelAvailableInfo);
            this.panelUpdate.Controls.Add(this.labelCurrentVersion);
            resources.ApplyResources(this.panelUpdate, "panelUpdate");
            this.panelUpdate.Name = "panelUpdate";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnUpdate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnUpdate.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnUpdate.BorderRadius = 16;
            this.btnUpdate.BorderSize = 0;
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.TextColor = System.Drawing.Color.AliceBlue;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // labelAvailableInfo
            // 
            resources.ApplyResources(this.labelAvailableInfo, "labelAvailableInfo");
            this.labelAvailableInfo.Name = "labelAvailableInfo";
            // 
            // labelCurrentVersion
            // 
            resources.ApplyResources(this.labelCurrentVersion, "labelCurrentVersion");
            this.labelCurrentVersion.Name = "labelCurrentVersion";
            // 
            // panelLanguage
            // 
            this.panelLanguage.Controls.Add(this.comboLanguages);
            this.panelLanguage.Controls.Add(this.labelLanguage);
            resources.ApplyResources(this.panelLanguage, "panelLanguage");
            this.panelLanguage.Name = "panelLanguage";
            // 
            // comboLanguages
            // 
            this.comboLanguages.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboLanguages.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboLanguages.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.comboLanguages.BorderSize = 1;
            this.comboLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            resources.ApplyResources(this.comboLanguages, "comboLanguages");
            this.comboLanguages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.comboLanguages.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.comboLanguages.Items.AddRange(new object[] {
            resources.GetString("comboLanguages.Items"),
            resources.GetString("comboLanguages.Items1")});
            this.comboLanguages.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.comboLanguages.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.comboLanguages.Name = "comboLanguages";
            this.comboLanguages.Texts = "";
            this.comboLanguages.OnSelectedIndexChanged += new System.EventHandler(this.comboLanguages_OnSelectedIndexChanged_1);
            // 
            // labelLanguage
            // 
            resources.ApplyResources(this.labelLanguage, "labelLanguage");
            this.labelLanguage.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelLanguage.Name = "labelLanguage";
            // 
            // panelinterface
            // 
            this.panelinterface.Controls.Add(this.panel2);
            this.panelinterface.Controls.Add(this.panelLight);
            this.panelinterface.Controls.Add(this.panelDark);
            this.panelinterface.Controls.Add(this.lblRESETCOLOR);
            resources.ApplyResources(this.panelinterface, "panelinterface");
            this.panelinterface.Name = "panelinterface";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.kryptonButton1);
            this.panel2.Controls.Add(this.kryptonButton2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.kryptonButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.kryptonButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.kryptonButton1.BorderRadius = -10;
            this.kryptonButton1.BorderSize = 0;
            this.kryptonButton1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.kryptonButton1, "kryptonButton1");
            this.kryptonButton1.ForeColor = System.Drawing.Color.AliceBlue;
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.TextColor = System.Drawing.Color.AliceBlue;
            this.kryptonButton1.UseVisualStyleBackColor = false;
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.kryptonButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.kryptonButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.kryptonButton2.BorderRadius = -10;
            this.kryptonButton2.BorderSize = 0;
            this.kryptonButton2.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.kryptonButton2, "kryptonButton2");
            this.kryptonButton2.ForeColor = System.Drawing.Color.AliceBlue;
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.TextColor = System.Drawing.Color.AliceBlue;
            this.kryptonButton2.UseVisualStyleBackColor = false;
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // panelLight
            // 
            this.panelLight.Controls.Add(this.label14);
            this.panelLight.Controls.Add(this.btnLightBack);
            this.panelLight.Controls.Add(this.btnLightText);
            this.panelLight.Controls.Add(this.btnLightButton);
            this.panelLight.Controls.Add(this.btnLighticon);
            this.panelLight.Controls.Add(this.pictureBox6);
            this.panelLight.Controls.Add(this.label1);
            this.panelLight.Controls.Add(this.label13);
            this.panelLight.Controls.Add(this.label12);
            this.panelLight.Controls.Add(this.label11);
            this.panelLight.Controls.Add(this.txtLightBack);
            this.panelLight.Controls.Add(this.txtLightText);
            this.panelLight.Controls.Add(this.txtLightButton);
            resources.ApplyResources(this.panelLight, "panelLight");
            this.panelLight.Name = "panelLight";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.ForeColor = System.Drawing.Color.AliceBlue;
            this.label14.Name = "label14";
            // 
            // btnLightBack
            // 
            this.btnLightBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLightBack.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLightBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLightBack.BorderRadius = 12;
            this.btnLightBack.BorderSize = 0;
            this.btnLightBack.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnLightBack, "btnLightBack");
            this.btnLightBack.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLightBack.Name = "btnLightBack";
            this.btnLightBack.TextColor = System.Drawing.Color.AliceBlue;
            this.btnLightBack.UseVisualStyleBackColor = false;
            this.btnLightBack.Click += new System.EventHandler(this.btnLightBack_Click);
            // 
            // btnLightText
            // 
            this.btnLightText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLightText.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLightText.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLightText.BorderRadius = 12;
            this.btnLightText.BorderSize = 0;
            this.btnLightText.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnLightText, "btnLightText");
            this.btnLightText.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLightText.Name = "btnLightText";
            this.btnLightText.TextColor = System.Drawing.Color.AliceBlue;
            this.btnLightText.UseVisualStyleBackColor = false;
            this.btnLightText.Click += new System.EventHandler(this.btnLightText_Click);
            // 
            // btnLightButton
            // 
            this.btnLightButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLightButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLightButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLightButton.BorderRadius = 12;
            this.btnLightButton.BorderSize = 0;
            this.btnLightButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnLightButton, "btnLightButton");
            this.btnLightButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLightButton.Name = "btnLightButton";
            this.btnLightButton.TextColor = System.Drawing.Color.AliceBlue;
            this.btnLightButton.UseVisualStyleBackColor = false;
            this.btnLightButton.Click += new System.EventHandler(this.btnLightButton_Click);
            // 
            // btnLighticon
            // 
            this.btnLighticon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLighticon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnLighticon.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLighticon.BorderRadius = 12;
            this.btnLighticon.BorderSize = 0;
            this.btnLighticon.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnLighticon, "btnLighticon");
            this.btnLighticon.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLighticon.Name = "btnLighticon";
            this.btnLighticon.TextColor = System.Drawing.Color.AliceBlue;
            this.btnLighticon.UseVisualStyleBackColor = false;
            this.btnLighticon.Click += new System.EventHandler(this.btnLighticon_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::WindowsPackageUpdater.Properties.Resources.iconn;
            resources.ApplyResources(this.pictureBox6, "pictureBox6");
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Name = "label1";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.AliceBlue;
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.AliceBlue;
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.AliceBlue;
            this.label11.Name = "label11";
            // 
            // txtLightBack
            // 
            this.txtLightBack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtLightBack, "txtLightBack");
            this.txtLightBack.Name = "txtLightBack";
            this.txtLightBack.ReadOnly = true;
            this.txtLightBack.TabStop = false;
            // 
            // txtLightText
            // 
            this.txtLightText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtLightText, "txtLightText");
            this.txtLightText.Name = "txtLightText";
            this.txtLightText.ReadOnly = true;
            this.txtLightText.TabStop = false;
            // 
            // txtLightButton
            // 
            this.txtLightButton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtLightButton, "txtLightButton");
            this.txtLightButton.Name = "txtLightButton";
            this.txtLightButton.ReadOnly = true;
            this.txtLightButton.TabStop = false;
            // 
            // panelDark
            // 
            this.panelDark.Controls.Add(this.btnDarkBack);
            this.panelDark.Controls.Add(this.btnDarkText);
            this.panelDark.Controls.Add(this.btnDarkButton);
            this.panelDark.Controls.Add(this.btnDarkIcon);
            this.panelDark.Controls.Add(this.labelColorScheme);
            this.panelDark.Controls.Add(this.pictureBox5);
            this.panelDark.Controls.Add(this.label8);
            this.panelDark.Controls.Add(this.label9);
            this.panelDark.Controls.Add(this.label7);
            this.panelDark.Controls.Add(this.label10);
            this.panelDark.Controls.Add(this.txtDarkBack);
            this.panelDark.Controls.Add(this.txtDarkText);
            this.panelDark.Controls.Add(this.txtDarkButton);
            resources.ApplyResources(this.panelDark, "panelDark");
            this.panelDark.Name = "panelDark";
            // 
            // btnDarkBack
            // 
            this.btnDarkBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkBack.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDarkBack.BorderRadius = 12;
            this.btnDarkBack.BorderSize = 0;
            this.btnDarkBack.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnDarkBack, "btnDarkBack");
            this.btnDarkBack.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnDarkBack.Name = "btnDarkBack";
            this.btnDarkBack.TextColor = System.Drawing.Color.AliceBlue;
            this.btnDarkBack.UseVisualStyleBackColor = false;
            this.btnDarkBack.Click += new System.EventHandler(this.btnDarkBack_Click);
            // 
            // btnDarkText
            // 
            this.btnDarkText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkText.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkText.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDarkText.BorderRadius = 12;
            this.btnDarkText.BorderSize = 0;
            this.btnDarkText.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnDarkText, "btnDarkText");
            this.btnDarkText.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnDarkText.Name = "btnDarkText";
            this.btnDarkText.TextColor = System.Drawing.Color.AliceBlue;
            this.btnDarkText.UseVisualStyleBackColor = false;
            this.btnDarkText.Click += new System.EventHandler(this.btnDarkText_Click);
            // 
            // btnDarkButton
            // 
            this.btnDarkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkButton.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkButton.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDarkButton.BorderRadius = 12;
            this.btnDarkButton.BorderSize = 0;
            this.btnDarkButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnDarkButton, "btnDarkButton");
            this.btnDarkButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnDarkButton.Name = "btnDarkButton";
            this.btnDarkButton.TextColor = System.Drawing.Color.AliceBlue;
            this.btnDarkButton.UseVisualStyleBackColor = false;
            this.btnDarkButton.Click += new System.EventHandler(this.btnDarkButton_Click);
            // 
            // btnDarkIcon
            // 
            this.btnDarkIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkIcon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnDarkIcon.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDarkIcon.BorderRadius = 12;
            this.btnDarkIcon.BorderSize = 0;
            this.btnDarkIcon.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnDarkIcon, "btnDarkIcon");
            this.btnDarkIcon.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnDarkIcon.Name = "btnDarkIcon";
            this.btnDarkIcon.TextColor = System.Drawing.Color.AliceBlue;
            this.btnDarkIcon.UseVisualStyleBackColor = false;
            this.btnDarkIcon.Click += new System.EventHandler(this.btnDarkicon_Click);
            // 
            // labelColorScheme
            // 
            resources.ApplyResources(this.labelColorScheme, "labelColorScheme");
            this.labelColorScheme.ForeColor = System.Drawing.Color.AliceBlue;
            this.labelColorScheme.Name = "labelColorScheme";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::WindowsPackageUpdater.Properties.Resources.iconn;
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.AliceBlue;
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.AliceBlue;
            this.label9.Name = "label9";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.AliceBlue;
            this.label7.Name = "label7";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.AliceBlue;
            this.label10.Name = "label10";
            // 
            // txtDarkBack
            // 
            this.txtDarkBack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtDarkBack, "txtDarkBack");
            this.txtDarkBack.Name = "txtDarkBack";
            this.txtDarkBack.ReadOnly = true;
            this.txtDarkBack.TabStop = false;
            // 
            // txtDarkText
            // 
            this.txtDarkText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtDarkText, "txtDarkText");
            this.txtDarkText.Name = "txtDarkText";
            this.txtDarkText.ReadOnly = true;
            this.txtDarkText.TabStop = false;
            // 
            // txtDarkButton
            // 
            this.txtDarkButton.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtDarkButton, "txtDarkButton");
            this.txtDarkButton.Name = "txtDarkButton";
            this.txtDarkButton.ReadOnly = true;
            this.txtDarkButton.TabStop = false;
            // 
            // lblRESETCOLOR
            // 
            this.lblRESETCOLOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.lblRESETCOLOR, "lblRESETCOLOR");
            this.lblRESETCOLOR.ForeColor = System.Drawing.Color.Red;
            this.lblRESETCOLOR.Name = "lblRESETCOLOR";
            this.lblRESETCOLOR.Click += new System.EventHandler(this.lblRESETCOLOR_Click);
            this.lblRESETCOLOR.MouseEnter += new System.EventHandler(this.lblRESETCOLOR_MouseEnter);
            this.lblRESETCOLOR.MouseLeave += new System.EventHandler(this.lblRESETCOLOR_MouseLeave);
            // 
            // panelSystem
            // 
            this.panelSystem.Controls.Add(this.ComboBoxHour);
            this.panelSystem.Controls.Add(this.label18);
            this.panelSystem.Controls.Add(this.label17);
            this.panelSystem.Controls.Add(this.toggleWindowsStart);
            this.panelSystem.Controls.Add(this.label6);
            this.panelSystem.Controls.Add(this.label2);
            resources.ApplyResources(this.panelSystem, "panelSystem");
            this.panelSystem.Name = "panelSystem";
            // 
            // ComboBoxHour
            // 
            this.ComboBoxHour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ComboBoxHour.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ComboBoxHour.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.ComboBoxHour.BorderSize = 1;
            this.ComboBoxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            resources.ApplyResources(this.ComboBoxHour, "ComboBoxHour");
            this.ComboBoxHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ComboBoxHour.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.ComboBoxHour.Items.AddRange(new object[] {
            resources.GetString("ComboBoxHour.Items"),
            resources.GetString("ComboBoxHour.Items1"),
            resources.GetString("ComboBoxHour.Items2"),
            resources.GetString("ComboBoxHour.Items3"),
            resources.GetString("ComboBoxHour.Items4"),
            resources.GetString("ComboBoxHour.Items5"),
            resources.GetString("ComboBoxHour.Items6")});
            this.ComboBoxHour.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.ComboBoxHour.ListTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ComboBoxHour.Name = "ComboBoxHour";
            this.ComboBoxHour.Texts = "";
            this.ComboBoxHour.OnSelectedIndexChanged += new System.EventHandler(this.ComboBoxHour_OnSelectedIndexChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.ForeColor = System.Drawing.Color.AliceBlue;
            this.label18.Name = "label18";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.AliceBlue;
            this.label17.Name = "label17";
            // 
            // toggleWindowsStart
            // 
            resources.ApplyResources(this.toggleWindowsStart, "toggleWindowsStart");
            this.toggleWindowsStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.toggleWindowsStart.Name = "toggleWindowsStart";
            this.toggleWindowsStart.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.toggleWindowsStart.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleWindowsStart.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(156)))), ((int)(((byte)(87)))));
            this.toggleWindowsStart.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleWindowsStart.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.AliceBlue;
            this.label6.Name = "label6";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Name = "label2";
            // 
            // panelNotification
            // 
            this.panelNotification.Controls.Add(this.ToggleButtonAlert);
            this.panelNotification.Controls.Add(this.label16);
            this.panelNotification.Controls.Add(this.ToggleButtonNoti);
            this.panelNotification.Controls.Add(this.label15);
            resources.ApplyResources(this.panelNotification, "panelNotification");
            this.panelNotification.Name = "panelNotification";
            // 
            // ToggleButtonAlert
            // 
            resources.ApplyResources(this.ToggleButtonAlert, "ToggleButtonAlert");
            this.ToggleButtonAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ToggleButtonAlert.Name = "ToggleButtonAlert";
            this.ToggleButtonAlert.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.ToggleButtonAlert.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.ToggleButtonAlert.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(156)))), ((int)(((byte)(87)))));
            this.ToggleButtonAlert.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.ToggleButtonAlert.UseVisualStyleBackColor = false;
            this.ToggleButtonAlert.CheckedChanged += new System.EventHandler(this.ToggleButtonAlert_CheckedChanged);
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.AliceBlue;
            this.label16.Name = "label16";
            // 
            // ToggleButtonNoti
            // 
            resources.ApplyResources(this.ToggleButtonNoti, "ToggleButtonNoti");
            this.ToggleButtonNoti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ToggleButtonNoti.Name = "ToggleButtonNoti";
            this.ToggleButtonNoti.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.ToggleButtonNoti.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.ToggleButtonNoti.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(156)))), ((int)(((byte)(87)))));
            this.ToggleButtonNoti.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.ToggleButtonNoti.UseVisualStyleBackColor = false;
            this.ToggleButtonNoti.CheckedChanged += new System.EventHandler(this.ToggleButtonNoti_CheckedChanged);
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.AliceBlue;
            this.label15.Name = "label15";
            // 
            // lstUpdates
            // 
            this.lstUpdates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUpdates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            resources.ApplyResources(this.lstUpdates, "lstUpdates");
            this.lstUpdates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(41)))));
            this.lstUpdates.FullRowSelect = true;
            this.lstUpdates.HideSelection = false;
            this.lstUpdates.Name = "lstUpdates";
            this.lstUpdates.UseCompatibleStateImageBehavior = false;
            this.lstUpdates.View = System.Windows.Forms.View.Details;
            this.lstUpdates.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstUpdates_ColumnClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowMerge = false;
            this.menuStrip1.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.ınterfaceToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SystemSettingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.notificationSettingsToolStripMenuItem});
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // SystemSettingsToolStripMenuItem
            // 
            resources.ApplyResources(this.SystemSettingsToolStripMenuItem, "SystemSettingsToolStripMenuItem");
            this.SystemSettingsToolStripMenuItem.Name = "SystemSettingsToolStripMenuItem";
            this.SystemSettingsToolStripMenuItem.Click += new System.EventHandler(this.SystemSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // notificationSettingsToolStripMenuItem
            // 
            resources.ApplyResources(this.notificationSettingsToolStripMenuItem, "notificationSettingsToolStripMenuItem");
            this.notificationSettingsToolStripMenuItem.Name = "notificationSettingsToolStripMenuItem";
            this.notificationSettingsToolStripMenuItem.Click += new System.EventHandler(this.notificationSettingsToolStripMenuItem_Click);
            // 
            // ınterfaceToolStripMenuItem
            // 
            this.ınterfaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userInterfaceToolStripMenuItem,
            this.toolStripSeparator3,
            this.languageToolStripMenuItem1});
            resources.ApplyResources(this.ınterfaceToolStripMenuItem, "ınterfaceToolStripMenuItem");
            this.ınterfaceToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.ınterfaceToolStripMenuItem.Name = "ınterfaceToolStripMenuItem";
            // 
            // userInterfaceToolStripMenuItem
            // 
            resources.ApplyResources(this.userInterfaceToolStripMenuItem, "userInterfaceToolStripMenuItem");
            this.userInterfaceToolStripMenuItem.Name = "userInterfaceToolStripMenuItem";
            this.userInterfaceToolStripMenuItem.Click += new System.EventHandler(this.userInterfaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // languageToolStripMenuItem1
            // 
            resources.ApplyResources(this.languageToolStripMenuItem1, "languageToolStripMenuItem1");
            this.languageToolStripMenuItem1.Name = "languageToolStripMenuItem1";
            this.languageToolStripMenuItem1.Click += new System.EventHandler(this.languageToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatesToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // updatesToolStripMenuItem
            // 
            resources.ApplyResources(this.updatesToolStripMenuItem, "updatesToolStripMenuItem");
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Click += new System.EventHandler(this.updatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::WindowsPackageUpdater.Properties.Resources.icons8_synchronize_48px;
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.AliceBlue;
            this.label4.Name = "label4";
            // 
            // ToggleButtonAuto
            // 
            resources.ApplyResources(this.ToggleButtonAuto, "ToggleButtonAuto");
            this.ToggleButtonAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ToggleButtonAuto.Name = "ToggleButtonAuto";
            this.ToggleButtonAuto.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(63)))), ((int)(((byte)(76)))));
            this.ToggleButtonAuto.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.ToggleButtonAuto.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(156)))), ((int)(((byte)(87)))));
            this.ToggleButtonAuto.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.ToggleButtonAuto.UseVisualStyleBackColor = false;
            this.ToggleButtonAuto.CheckedChanged += new System.EventHandler(this.ToggleButtonAuto_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.AliceBlue;
            this.label5.Name = "label5";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.rjButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 16;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.rjButton1, "rjButton1");
            this.rjButton1.ForeColor = System.Drawing.Color.AliceBlue;
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.TextColor = System.Drawing.Color.AliceBlue;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton1_Click);
            // 
            // btnCheckforUpdates
            // 
            this.btnCheckforUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnCheckforUpdates.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnCheckforUpdates.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCheckforUpdates.BorderRadius = 16;
            this.btnCheckforUpdates.BorderSize = 0;
            this.btnCheckforUpdates.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnCheckforUpdates, "btnCheckforUpdates");
            this.btnCheckforUpdates.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnCheckforUpdates.Name = "btnCheckforUpdates";
            this.btnCheckforUpdates.TextColor = System.Drawing.Color.AliceBlue;
            this.btnCheckforUpdates.UseVisualStyleBackColor = false;
            this.btnCheckforUpdates.Click += new System.EventHandler(this.btnCheckforUpdates_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnBack.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnBack.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnBack.BorderRadius = 16;
            this.btnBack.BorderSize = 0;
            this.btnBack.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnBack.Name = "btnBack";
            this.btnBack.TextColor = System.Drawing.Color.AliceBlue;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(186)))));
            this.btnSave.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnSave.BorderRadius = 16;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.TextColor = System.Drawing.Color.AliceBlue;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // LastScanLabel
            // 
            resources.ApplyResources(this.LastScanLabel, "LastScanLabel");
            this.LastScanLabel.Name = "LastScanLabel";
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusLabel.Name = "StatusLabel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // panelDefaultWall
            // 
            this.panelDefaultWall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.panelDefaultWall.Controls.Add(this.panelCustomize);
            resources.ApplyResources(this.panelDefaultWall, "panelDefaultWall");
            this.panelDefaultWall.Name = "panelDefaultWall";
            // 
            // kryptonColorDialog1
            // 
            this.kryptonColorDialog1.AnyColor = true;
            this.kryptonColorDialog1.FullOpen = true;
            this.kryptonColorDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("kryptonColorDialog1.Icon")));
            this.kryptonColorDialog1.ShowIcon = true;
            this.kryptonColorDialog1.Title = null;
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanToolStripMenuItem,
            this.toolStripSeparator5,
            this.showToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // scanToolStripMenuItem
            // 
            resources.ApplyResources(this.scanToolStripMenuItem, "scanToolStripMenuItem");
            this.scanToolStripMenuItem.Name = "scanToolStripMenuItem";
            this.scanToolStripMenuItem.Click += new System.EventHandler(this.scanToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // showToolStripMenuItem
            // 
            resources.ApplyResources(this.showToolStripMenuItem, "showToolStripMenuItem");
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDefaultWall);
            this.Controls.Add(this.panelUpper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelUpper.ResumeLayout(false);
            this.panelUpper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCustomize.ResumeLayout(false);
            this.panelCustomize.PerformLayout();
            this.panelAbouts.ResumeLayout(false);
            this.panelAbouts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            this.panelLanguage.ResumeLayout(false);
            this.panelLanguage.PerformLayout();
            this.panelinterface.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelLight.ResumeLayout(false);
            this.panelLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panelDark.ResumeLayout(false);
            this.panelDark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panelSystem.ResumeLayout(false);
            this.panelSystem.PerformLayout();
            this.panelNotification.ResumeLayout(false);
            this.panelNotification.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelDefaultWall.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelUpper;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelCustomize;
        private System.Windows.Forms.Panel panelinterface;
        private System.Windows.Forms.Label lblRESETCOLOR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelColorScheme;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.Label labelAvailableInfo;
        private System.Windows.Forms.Label labelCurrentVersion;
        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SystemSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ınterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panelDefaultWall;
        private Krypton.Toolkit.KryptonColorDialog kryptonColorDialog1;
        private System.Windows.Forms.Panel panelAbouts;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.LinkLabel linkLabelProjectURL;
        private TextBox txtDarkButton;
        private TextBox txtDarkText;
        private TextBox txtDarkBack;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox txtLightButton;
        private TextBox txtLightText;
        private TextBox txtLightBack;
        private Label label11;
        private Label label12;
        private Label label13;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private ListView lstUpdates;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Panel panelSystem;
        private Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems3;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem exitToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem scanToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private Label label2;
        private Label label4;
        private RJControls.RJToggleButton ToggleButtonAuto;
        private Label label5;
        private RJControls.RJButton btnCheckforUpdates;
        private RJControls.RJButton rjButton1;
        private RJControls.RJButton btnBack;
        private RJControls.RJButton btnSave;
        private RJControls.RJButton btnUpdate;
        private RJControls.RJButton btnOk;
        private ToolStripMenuItem notificationSettingsToolStripMenuItem;
        private Panel panelNotification;
        private Panel panel2;
        private Panel panelLight;
        private Panel panelDark;
        private RJControls.RJButton kryptonButton2;
        private RJControls.RJButton kryptonButton1;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private Label label7;
        private RJControls.RJButton btnDarkIcon;
        private RJControls.RJButton btnDarkBack;
        private RJControls.RJButton btnDarkText;
        private RJControls.RJButton btnDarkButton;
        private RJControls.RJButton btnLightBack;
        private RJControls.RJButton btnLightText;
        private RJControls.RJButton btnLightButton;
        private RJControls.RJButton btnLighticon;
        private Label label14;
        private RJControls.RJToggleButton ToggleButtonNoti;
        private Label label15;
        private RJControls.RJToggleButton ToggleButtonAlert;
        private Label label16;
        private Label LastScanLabel;
        private Label StatusLabel;
        private Timer timer;
        private Label label6;
        private Label label3;
        private RJControls.RJToggleButton toggleWindowsStart;
        private Label label18;
        private Label label17;
        private RJControls.RJComboBox comboLanguages;
        private RJControls.RJComboBox ComboBoxHour;
    }
}
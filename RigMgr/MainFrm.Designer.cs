namespace MiningManager
{
    partial class MinerManagerMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinerManagerMain));
            this.showLogsGB = new System.Windows.Forms.GroupBox();
            this.cbTips = new System.Windows.Forms.CheckBox();
            this.debugLogCB = new System.Windows.Forms.CheckBox();
            this.showGoodWattLogCB = new System.Windows.Forms.CheckBox();
            this.showGeneralLogCb = new System.Windows.Forms.CheckBox();
            this.showFixProfilLogCB = new System.Windows.Forms.CheckBox();
            this.settingsSaveBtn = new System.Windows.Forms.Button();
            this.resetSettingsBtn = new System.Windows.Forms.Button();
            this.startupWinGB = new System.Windows.Forms.GroupBox();
            this.autoWattFixCB = new System.Windows.Forms.CheckBox();
            this.startupMiningSoftCB = new System.Windows.Forms.CheckBox();
            this.startupRMrgCheckCB = new System.Windows.Forms.CheckBox();
            this.LogTabCtrl = new System.Windows.Forms.TabControl();
            this.LogTabPage = new System.Windows.Forms.TabPage();
            this.logsRTB = new System.Windows.Forms.RichTextBox();
            this.DebugTabPage = new System.Windows.Forms.TabPage();
            this.debugRTB = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.wattFixGB = new System.Windows.Forms.GroupBox();
            this.lblMinW8 = new System.Windows.Forms.Label();
            this.lblMinCheckWatt = new System.Windows.Forms.Label();
            this.pauseLbl = new System.Windows.Forms.Label();
            this.pauseNum = new System.Windows.Forms.NumericUpDown();
            this.watLimitlbl = new System.Windows.Forms.Label();
            this.wattLimitNum = new System.Windows.Forms.NumericUpDown();
            this.timerTickLbl = new System.Windows.Forms.Label();
            this.timerTickNum = new System.Windows.Forms.NumericUpDown();
            this.startstopBtn = new System.Windows.Forms.Button();
            this.gpuzBtn = new System.Windows.Forms.Button();
            this.gpuzSoftTb = new System.Windows.Forms.TextBox();
            this.gpuZSoftPathlbl = new System.Windows.Forms.Label();
            this.afterburnerBtn = new System.Windows.Forms.Button();
            this.afterburnerTb = new System.Windows.Forms.TextBox();
            this.afterburnerPathlbl = new System.Windows.Forms.Label();
            this.miningSoft = new System.Windows.Forms.GroupBox();
            this.cbMiners = new System.Windows.Forms.ComboBox();
            this.btnMinersList = new System.Windows.Forms.Button();
            this.ManualStartMinerBtn = new System.Windows.Forms.Button();
            this.miningSoftLbl = new System.Windows.Forms.Label();
            this.gbDonation = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBTC = new System.Windows.Forms.Button();
            this.tbETH = new System.Windows.Forms.TextBox();
            this.tbBTC = new System.Windows.Forms.TextBox();
            this.lblETH = new System.Windows.Forms.Label();
            this.lblBTC = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnTwitter = new System.Windows.Forms.Button();
            this.btnWWW = new System.Windows.Forms.Button();
            this.btngitHub = new System.Windows.Forms.Button();
            this.btnYoutube = new System.Windows.Forms.Button();
            this.btnFacebook = new System.Windows.Forms.Button();
            this.gpuzPathClearBtn = new System.Windows.Forms.Button();
            this.afterburnetPathClearBtn = new System.Windows.Forms.Button();
            this.showLogsGB.SuspendLayout();
            this.startupWinGB.SuspendLayout();
            this.LogTabCtrl.SuspendLayout();
            this.LogTabPage.SuspendLayout();
            this.DebugTabPage.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.wattFixGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pauseNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wattLimitNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerTickNum)).BeginInit();
            this.miningSoft.SuspendLayout();
            this.gbDonation.SuspendLayout();
            this.SuspendLayout();
            // 
            // showLogsGB
            // 
            this.showLogsGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showLogsGB.Controls.Add(this.cbTips);
            this.showLogsGB.Controls.Add(this.debugLogCB);
            this.showLogsGB.Controls.Add(this.showGoodWattLogCB);
            this.showLogsGB.Controls.Add(this.showGeneralLogCb);
            this.showLogsGB.Controls.Add(this.showFixProfilLogCB);
            this.showLogsGB.Location = new System.Drawing.Point(12, 379);
            this.showLogsGB.Name = "showLogsGB";
            this.showLogsGB.Size = new System.Drawing.Size(533, 42);
            this.showLogsGB.TabIndex = 16;
            this.showLogsGB.TabStop = false;
            this.showLogsGB.Text = "Show Infos";
            // 
            // cbTips
            // 
            this.cbTips.AutoSize = true;
            this.cbTips.Checked = true;
            this.cbTips.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTips.Location = new System.Drawing.Point(342, 19);
            this.cbTips.Name = "cbTips";
            this.cbTips.Size = new System.Drawing.Size(46, 17);
            this.cbTips.TabIndex = 20;
            this.cbTips.Text = "Tips";
            this.toolTip.SetToolTip(this.cbTips, "Show help tips.");
            this.cbTips.UseVisualStyleBackColor = true;
            this.cbTips.CheckedChanged += new System.EventHandler(this.cbTips_CheckedChanged);
            // 
            // debugLogCB
            // 
            this.debugLogCB.AutoSize = true;
            this.debugLogCB.Location = new System.Drawing.Point(439, 19);
            this.debugLogCB.Name = "debugLogCB";
            this.debugLogCB.Size = new System.Drawing.Size(58, 17);
            this.debugLogCB.TabIndex = 19;
            this.debugLogCB.Text = "Debug";
            this.toolTip.SetToolTip(this.debugLogCB, "Show the debugging logs in the tab \"Debug\".");
            this.debugLogCB.UseVisualStyleBackColor = true;
            // 
            // showGoodWattLogCB
            // 
            this.showGoodWattLogCB.AutoSize = true;
            this.showGoodWattLogCB.Location = new System.Drawing.Point(230, 19);
            this.showGoodWattLogCB.Name = "showGoodWattLogCB";
            this.showGoodWattLogCB.Size = new System.Drawing.Size(67, 17);
            this.showGoodWattLogCB.TabIndex = 18;
            this.showGoodWattLogCB.Text = "Watt OK";
            this.toolTip.SetToolTip(this.showGoodWattLogCB, "Show the logs when the power consumption \r\nof the graphics cards is correct.");
            this.showGoodWattLogCB.UseVisualStyleBackColor = true;
            this.showGoodWattLogCB.CheckedChanged += new System.EventHandler(this.showGoodWattLogCB_CheckedChanged);
            // 
            // showGeneralLogCb
            // 
            this.showGeneralLogCb.AutoSize = true;
            this.showGeneralLogCb.Checked = true;
            this.showGeneralLogCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGeneralLogCb.Location = new System.Drawing.Point(6, 19);
            this.showGeneralLogCb.Name = "showGeneralLogCb";
            this.showGeneralLogCb.Size = new System.Drawing.Size(63, 17);
            this.showGeneralLogCb.TabIndex = 17;
            this.showGeneralLogCb.Text = "General";
            this.toolTip.SetToolTip(this.showGeneralLogCb, "Show the general logs.");
            this.showGeneralLogCb.UseVisualStyleBackColor = true;
            this.showGeneralLogCb.CheckedChanged += new System.EventHandler(this.showGeneralLogCb_CheckedChanged);
            // 
            // showFixProfilLogCB
            // 
            this.showFixProfilLogCB.AutoSize = true;
            this.showFixProfilLogCB.Checked = true;
            this.showFixProfilLogCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFixProfilLogCB.Location = new System.Drawing.Point(118, 19);
            this.showFixProfilLogCB.Name = "showFixProfilLogCB";
            this.showFixProfilLogCB.Size = new System.Drawing.Size(62, 17);
            this.showFixProfilLogCB.TabIndex = 16;
            this.showFixProfilLogCB.Text = "Watt fix";
            this.toolTip.SetToolTip(this.showFixProfilLogCB, "Show the logs of the profile changing in MSI Afterburner when the \r\nMining Manage" +
        "r detects abnormal power consumption of graphics cards.");
            this.showFixProfilLogCB.UseVisualStyleBackColor = true;
            this.showFixProfilLogCB.CheckedChanged += new System.EventHandler(this.showFixProfilLogCB_CheckedChanged);
            // 
            // settingsSaveBtn
            // 
            this.settingsSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsSaveBtn.Location = new System.Drawing.Point(448, 19);
            this.settingsSaveBtn.Name = "settingsSaveBtn";
            this.settingsSaveBtn.Size = new System.Drawing.Size(85, 23);
            this.settingsSaveBtn.TabIndex = 17;
            this.settingsSaveBtn.Text = "Save Settings";
            this.settingsSaveBtn.UseVisualStyleBackColor = true;
            this.settingsSaveBtn.Visible = false;
            this.settingsSaveBtn.Click += new System.EventHandler(this.settingsSaveBtn_Click);
            // 
            // resetSettingsBtn
            // 
            this.resetSettingsBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetSettingsBtn.Location = new System.Drawing.Point(448, 0);
            this.resetSettingsBtn.Name = "resetSettingsBtn";
            this.resetSettingsBtn.Size = new System.Drawing.Size(85, 23);
            this.resetSettingsBtn.TabIndex = 18;
            this.resetSettingsBtn.Text = "Reset Settings";
            this.resetSettingsBtn.UseVisualStyleBackColor = true;
            this.resetSettingsBtn.Visible = false;
            this.resetSettingsBtn.Click += new System.EventHandler(this.resetSettingsBtn_Click);
            // 
            // startupWinGB
            // 
            this.startupWinGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startupWinGB.Controls.Add(this.settingsSaveBtn);
            this.startupWinGB.Controls.Add(this.resetSettingsBtn);
            this.startupWinGB.Controls.Add(this.autoWattFixCB);
            this.startupWinGB.Controls.Add(this.startupMiningSoftCB);
            this.startupWinGB.Controls.Add(this.startupRMrgCheckCB);
            this.startupWinGB.Location = new System.Drawing.Point(12, 10);
            this.startupWinGB.Name = "startupWinGB";
            this.startupWinGB.Size = new System.Drawing.Size(533, 42);
            this.startupWinGB.TabIndex = 28;
            this.startupWinGB.TabStop = false;
            this.startupWinGB.Text = "Start automatically";
            // 
            // autoWattFixCB
            // 
            this.autoWattFixCB.AutoSize = true;
            this.autoWattFixCB.Location = new System.Drawing.Point(342, 19);
            this.autoWattFixCB.Name = "autoWattFixCB";
            this.autoWattFixCB.Size = new System.Drawing.Size(62, 17);
            this.autoWattFixCB.TabIndex = 30;
            this.autoWattFixCB.Text = "Watt fix";
            this.toolTip.SetToolTip(this.autoWattFixCB, resources.GetString("autoWattFixCB.ToolTip"));
            this.autoWattFixCB.UseVisualStyleBackColor = true;
            this.autoWattFixCB.CheckedChanged += new System.EventHandler(this.autoWattFixCB_CheckedChanged);
            // 
            // startupMiningSoftCB
            // 
            this.startupMiningSoftCB.AutoSize = true;
            this.startupMiningSoftCB.Location = new System.Drawing.Point(230, 19);
            this.startupMiningSoftCB.Name = "startupMiningSoftCB";
            this.startupMiningSoftCB.Size = new System.Drawing.Size(100, 17);
            this.startupMiningSoftCB.TabIndex = 29;
            this.startupMiningSoftCB.Text = "Mining software";
            this.toolTip.SetToolTip(this.startupMiningSoftCB, resources.GetString("startupMiningSoftCB.ToolTip"));
            this.startupMiningSoftCB.UseVisualStyleBackColor = true;
            this.startupMiningSoftCB.CheckedChanged += new System.EventHandler(this.startupMiningSoftCB_CheckedChanged);
            // 
            // startupRMrgCheckCB
            // 
            this.startupRMrgCheckCB.AutoSize = true;
            this.startupRMrgCheckCB.Location = new System.Drawing.Point(6, 19);
            this.startupRMrgCheckCB.Name = "startupRMrgCheckCB";
            this.startupRMrgCheckCB.Size = new System.Drawing.Size(188, 17);
            this.startupRMrgCheckCB.TabIndex = 28;
            this.startupRMrgCheckCB.Text = "Mining Manager on Windows boot";
            this.toolTip.SetToolTip(this.startupRMrgCheckCB, "If this option is checked, the Mining Manager will start at the same time as Wind" +
        "ows.");
            this.startupRMrgCheckCB.UseVisualStyleBackColor = true;
            this.startupRMrgCheckCB.CheckedChanged += new System.EventHandler(this.startupCheckCB_CheckedChanged);
            // 
            // LogTabCtrl
            // 
            this.LogTabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTabCtrl.Controls.Add(this.LogTabPage);
            this.LogTabCtrl.Controls.Add(this.DebugTabPage);
            this.LogTabCtrl.Location = new System.Drawing.Point(12, 427);
            this.LogTabCtrl.Name = "LogTabCtrl";
            this.LogTabCtrl.SelectedIndex = 0;
            this.LogTabCtrl.Size = new System.Drawing.Size(501, 157);
            this.LogTabCtrl.TabIndex = 33;
            // 
            // LogTabPage
            // 
            this.LogTabPage.Controls.Add(this.logsRTB);
            this.LogTabPage.Location = new System.Drawing.Point(4, 22);
            this.LogTabPage.Name = "LogTabPage";
            this.LogTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LogTabPage.Size = new System.Drawing.Size(493, 131);
            this.LogTabPage.TabIndex = 0;
            this.LogTabPage.Text = "Infos";
            this.LogTabPage.UseVisualStyleBackColor = true;
            // 
            // logsRTB
            // 
            this.logsRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsRTB.Location = new System.Drawing.Point(3, 3);
            this.logsRTB.Name = "logsRTB";
            this.logsRTB.ReadOnly = true;
            this.logsRTB.Size = new System.Drawing.Size(487, 125);
            this.logsRTB.TabIndex = 2;
            this.logsRTB.Text = "";
            // 
            // DebugTabPage
            // 
            this.DebugTabPage.Controls.Add(this.debugRTB);
            this.DebugTabPage.Location = new System.Drawing.Point(4, 22);
            this.DebugTabPage.Name = "DebugTabPage";
            this.DebugTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DebugTabPage.Size = new System.Drawing.Size(493, 131);
            this.DebugTabPage.TabIndex = 1;
            this.DebugTabPage.Text = "Debug";
            this.DebugTabPage.UseVisualStyleBackColor = true;
            // 
            // debugRTB
            // 
            this.debugRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugRTB.Location = new System.Drawing.Point(3, 3);
            this.debugRTB.Name = "debugRTB";
            this.debugRTB.ReadOnly = true;
            this.debugRTB.Size = new System.Drawing.Size(487, 125);
            this.debugRTB.TabIndex = 3;
            this.debugRTB.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 584);
            this.splitter1.TabIndex = 34;
            this.splitter1.TabStop = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Text = "Mining Manager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTSMI,
            this.toolStripSeparator1,
            this.closeTSMI});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 54);
            // 
            // showTSMI
            // 
            this.showTSMI.Name = "showTSMI";
            this.showTSMI.Size = new System.Drawing.Size(132, 22);
            this.showTSMI.Text = "Show form";
            this.showTSMI.Click += new System.EventHandler(this.showTSMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // closeTSMI
            // 
            this.closeTSMI.Name = "closeTSMI";
            this.closeTSMI.Size = new System.Drawing.Size(132, 22);
            this.closeTSMI.Text = "Exit";
            this.closeTSMI.Click += new System.EventHandler(this.closeTSMI_Click);
            // 
            // wattFixGB
            // 
            this.wattFixGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wattFixGB.Controls.Add(this.lblMinW8);
            this.wattFixGB.Controls.Add(this.lblMinCheckWatt);
            this.wattFixGB.Controls.Add(this.pauseLbl);
            this.wattFixGB.Controls.Add(this.pauseNum);
            this.wattFixGB.Controls.Add(this.watLimitlbl);
            this.wattFixGB.Controls.Add(this.wattLimitNum);
            this.wattFixGB.Controls.Add(this.timerTickLbl);
            this.wattFixGB.Controls.Add(this.timerTickNum);
            this.wattFixGB.Controls.Add(this.startstopBtn);
            this.wattFixGB.Controls.Add(this.gpuzPathClearBtn);
            this.wattFixGB.Controls.Add(this.gpuzBtn);
            this.wattFixGB.Controls.Add(this.gpuzSoftTb);
            this.wattFixGB.Controls.Add(this.gpuZSoftPathlbl);
            this.wattFixGB.Controls.Add(this.afterburnetPathClearBtn);
            this.wattFixGB.Controls.Add(this.afterburnerBtn);
            this.wattFixGB.Controls.Add(this.afterburnerTb);
            this.wattFixGB.Controls.Add(this.afterburnerPathlbl);
            this.wattFixGB.Location = new System.Drawing.Point(12, 223);
            this.wattFixGB.Name = "wattFixGB";
            this.wattFixGB.Size = new System.Drawing.Size(533, 150);
            this.wattFixGB.TabIndex = 36;
            this.wattFixGB.TabStop = false;
            this.wattFixGB.Text = "Watt fix";
            // 
            // lblMinW8
            // 
            this.lblMinW8.AutoSize = true;
            this.lblMinW8.Location = new System.Drawing.Point(244, 126);
            this.lblMinW8.Name = "lblMinW8";
            this.lblMinW8.Size = new System.Drawing.Size(68, 13);
            this.lblMinW8.TabIndex = 53;
            this.lblMinW8.Text = "minimum 500";
            // 
            // lblMinCheckWatt
            // 
            this.lblMinCheckWatt.AutoSize = true;
            this.lblMinCheckWatt.Location = new System.Drawing.Point(244, 74);
            this.lblMinCheckWatt.Name = "lblMinCheckWatt";
            this.lblMinCheckWatt.Size = new System.Drawing.Size(68, 13);
            this.lblMinCheckWatt.TabIndex = 52;
            this.lblMinCheckWatt.Text = "minimum 250";
            // 
            // pauseLbl
            // 
            this.pauseLbl.AutoSize = true;
            this.pauseLbl.Location = new System.Drawing.Point(11, 126);
            this.pauseLbl.Name = "pauseLbl";
            this.pauseLbl.Size = new System.Drawing.Size(146, 13);
            this.pauseLbl.TabIndex = 51;
            this.pauseLbl.Text = "Pause after reset profiel (ms) :";
            // 
            // pauseNum
            // 
            this.pauseNum.Location = new System.Drawing.Point(163, 124);
            this.pauseNum.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.pauseNum.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.pauseNum.Name = "pauseNum";
            this.pauseNum.Size = new System.Drawing.Size(75, 20);
            this.pauseNum.TabIndex = 50;
            this.toolTip.SetToolTip(this.pauseNum, resources.GetString("pauseNum.ToolTip"));
            this.pauseNum.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pauseNum.ValueChanged += new System.EventHandler(this.pauseNum_ValueChanged);
            // 
            // watLimitlbl
            // 
            this.watLimitlbl.AutoSize = true;
            this.watLimitlbl.Location = new System.Drawing.Point(11, 100);
            this.watLimitlbl.Name = "watLimitlbl";
            this.watLimitlbl.Size = new System.Drawing.Size(76, 13);
            this.watLimitlbl.TabIndex = 49;
            this.watLimitlbl.Text = "Watt limit (W) :";
            // 
            // wattLimitNum
            // 
            this.wattLimitNum.Location = new System.Drawing.Point(163, 98);
            this.wattLimitNum.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.wattLimitNum.Name = "wattLimitNum";
            this.wattLimitNum.Size = new System.Drawing.Size(75, 20);
            this.wattLimitNum.TabIndex = 48;
            this.toolTip.SetToolTip(this.wattLimitNum, "The power to not exceed for the power consumption of graphics cards.\r\n\r\nif your n" +
        "ormal consumption is 90W, put a little more in this box, \r\nexemple 100.\r\n\r\nDefau" +
        "lt value : 100.");
            this.wattLimitNum.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.wattLimitNum.ValueChanged += new System.EventHandler(this.wattLimitNum_ValueChanged);
            // 
            // timerTickLbl
            // 
            this.timerTickLbl.AutoSize = true;
            this.timerTickLbl.Location = new System.Drawing.Point(11, 74);
            this.timerTickLbl.Name = "timerTickLbl";
            this.timerTickLbl.Size = new System.Drawing.Size(121, 13);
            this.timerTickLbl.TabIndex = 47;
            this.timerTickLbl.Text = "Check Watt every (ms) :";
            // 
            // timerTickNum
            // 
            this.timerTickNum.Location = new System.Drawing.Point(163, 72);
            this.timerTickNum.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.timerTickNum.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.timerTickNum.Name = "timerTickNum";
            this.timerTickNum.Size = new System.Drawing.Size(75, 20);
            this.timerTickNum.TabIndex = 46;
            this.toolTip.SetToolTip(this.timerTickNum, "Interval between two checks of the electrical consumption of your cards.\r\n\r\nDefau" +
        "lt value :  500 (twice a second).");
            this.timerTickNum.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.timerTickNum.ValueChanged += new System.EventHandler(this.timerTickNum_ValueChanged);
            // 
            // startstopBtn
            // 
            this.startstopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startstopBtn.Location = new System.Drawing.Point(439, 121);
            this.startstopBtn.Name = "startstopBtn";
            this.startstopBtn.Size = new System.Drawing.Size(85, 23);
            this.startstopBtn.TabIndex = 45;
            this.startstopBtn.Text = "Start Watt fix";
            this.toolTip.SetToolTip(this.startstopBtn, "Starts the process of checking and correcting the\r\npower consumption of the graph" +
        "ics cards.");
            this.startstopBtn.UseVisualStyleBackColor = true;
            this.startstopBtn.Click += new System.EventHandler(this.StartWattFix_Click);
            // 
            // gpuzBtn
            // 
            this.gpuzBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpuzBtn.Location = new System.Drawing.Point(468, 44);
            this.gpuzBtn.Name = "gpuzBtn";
            this.gpuzBtn.Size = new System.Drawing.Size(25, 23);
            this.gpuzBtn.TabIndex = 43;
            this.gpuzBtn.Text = "...";
            this.toolTip.SetToolTip(this.gpuzBtn, "Initialize the path of GPU-Z.");
            this.gpuzBtn.UseVisualStyleBackColor = true;
            this.gpuzBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // gpuzSoftTb
            // 
            this.gpuzSoftTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpuzSoftTb.Location = new System.Drawing.Point(128, 46);
            this.gpuzSoftTb.Name = "gpuzSoftTb";
            this.gpuzSoftTb.ReadOnly = true;
            this.gpuzSoftTb.Size = new System.Drawing.Size(334, 20);
            this.gpuzSoftTb.TabIndex = 42;
            this.toolTip.SetToolTip(this.gpuzSoftTb, "The path of GPU-Z.\r\n\r\nIt is thanks to the shared memory of GPU-Z that the Mining " +
        "Manager \r\nknow the electrical consumption of the cards.");
            this.gpuzSoftTb.TextChanged += new System.EventHandler(this.gpuzSoftTb_TextChanged);
            // 
            // gpuZSoftPathlbl
            // 
            this.gpuZSoftPathlbl.AutoSize = true;
            this.gpuZSoftPathlbl.Location = new System.Drawing.Point(11, 49);
            this.gpuZSoftPathlbl.Name = "gpuZSoftPathlbl";
            this.gpuZSoftPathlbl.Size = new System.Drawing.Size(70, 13);
            this.gpuZSoftPathlbl.TabIndex = 41;
            this.gpuZSoftPathlbl.Text = "GPU-Z path :";
            // 
            // afterburnerBtn
            // 
            this.afterburnerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.afterburnerBtn.Location = new System.Drawing.Point(468, 16);
            this.afterburnerBtn.Name = "afterburnerBtn";
            this.afterburnerBtn.Size = new System.Drawing.Size(25, 23);
            this.afterburnerBtn.TabIndex = 35;
            this.afterburnerBtn.Text = "...";
            this.toolTip.SetToolTip(this.afterburnerBtn, "Initialize the path of MSI AfterBurner.");
            this.afterburnerBtn.UseVisualStyleBackColor = true;
            this.afterburnerBtn.Click += new System.EventHandler(this.afterburnerBtn_Click);
            // 
            // afterburnerTb
            // 
            this.afterburnerTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.afterburnerTb.Location = new System.Drawing.Point(128, 19);
            this.afterburnerTb.Name = "afterburnerTb";
            this.afterburnerTb.ReadOnly = true;
            this.afterburnerTb.Size = new System.Drawing.Size(334, 20);
            this.afterburnerTb.TabIndex = 34;
            this.toolTip.SetToolTip(this.afterburnerTb, "The path of MSI Afterburner.\r\n\r\nIt is thanks to the profiles of MSI Afterburner t" +
        "hat the Mining Manager \r\nmanages to correct the electrical consumption of your c" +
        "ards.");
            this.afterburnerTb.TextChanged += new System.EventHandler(this.afterburnerTb_TextChanged);
            // 
            // afterburnerPathlbl
            // 
            this.afterburnerPathlbl.AutoSize = true;
            this.afterburnerPathlbl.Location = new System.Drawing.Point(11, 22);
            this.afterburnerPathlbl.Name = "afterburnerPathlbl";
            this.afterburnerPathlbl.Size = new System.Drawing.Size(111, 13);
            this.afterburnerPathlbl.TabIndex = 33;
            this.afterburnerPathlbl.Text = "MSI Afterburner path :";
            // 
            // miningSoft
            // 
            this.miningSoft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.miningSoft.Controls.Add(this.cbMiners);
            this.miningSoft.Controls.Add(this.btnMinersList);
            this.miningSoft.Controls.Add(this.ManualStartMinerBtn);
            this.miningSoft.Controls.Add(this.miningSoftLbl);
            this.miningSoft.Location = new System.Drawing.Point(12, 58);
            this.miningSoft.Name = "miningSoft";
            this.miningSoft.Size = new System.Drawing.Size(533, 75);
            this.miningSoft.TabIndex = 37;
            this.miningSoft.TabStop = false;
            this.miningSoft.Text = "Mining software";
            // 
            // cbMiners
            // 
            this.cbMiners.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMiners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMiners.FormattingEnabled = true;
            this.cbMiners.Location = new System.Drawing.Point(128, 18);
            this.cbMiners.Name = "cbMiners";
            this.cbMiners.Size = new System.Drawing.Size(365, 21);
            this.cbMiners.TabIndex = 47;
            this.toolTip.SetToolTip(this.cbMiners, "Your selected mining software.");
            this.cbMiners.SelectedIndexChanged += new System.EventHandler(this.cbMiners_SelectedIndexChanged);
            // 
            // btnMinersList
            // 
            this.btnMinersList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinersList.Location = new System.Drawing.Point(499, 17);
            this.btnMinersList.Name = "btnMinersList";
            this.btnMinersList.Size = new System.Drawing.Size(25, 23);
            this.btnMinersList.TabIndex = 46;
            this.btnMinersList.Text = "...";
            this.toolTip.SetToolTip(this.btnMinersList, "Management of your mining softwares.");
            this.btnMinersList.UseVisualStyleBackColor = true;
            this.btnMinersList.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ManualStartMinerBtn
            // 
            this.ManualStartMinerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ManualStartMinerBtn.Location = new System.Drawing.Point(435, 46);
            this.ManualStartMinerBtn.Name = "ManualStartMinerBtn";
            this.ManualStartMinerBtn.Size = new System.Drawing.Size(89, 23);
            this.ManualStartMinerBtn.TabIndex = 45;
            this.ManualStartMinerBtn.Text = "Start miner soft.";
            this.toolTip.SetToolTip(this.ManualStartMinerBtn, "Manually start your mining software.");
            this.ManualStartMinerBtn.UseVisualStyleBackColor = true;
            this.ManualStartMinerBtn.Click += new System.EventHandler(this.ManualStartMinerBtn_Click);
            // 
            // miningSoftLbl
            // 
            this.miningSoftLbl.AutoSize = true;
            this.miningSoftLbl.Location = new System.Drawing.Point(11, 22);
            this.miningSoftLbl.Name = "miningSoftLbl";
            this.miningSoftLbl.Size = new System.Drawing.Size(111, 13);
            this.miningSoftLbl.TabIndex = 41;
            this.miningSoftLbl.Text = "Mining software path :";
            // 
            // gbDonation
            // 
            this.gbDonation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDonation.Controls.Add(this.button1);
            this.gbDonation.Controls.Add(this.btnBTC);
            this.gbDonation.Controls.Add(this.tbETH);
            this.gbDonation.Controls.Add(this.tbBTC);
            this.gbDonation.Controls.Add(this.lblETH);
            this.gbDonation.Controls.Add(this.lblBTC);
            this.gbDonation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.gbDonation.Location = new System.Drawing.Point(12, 139);
            this.gbDonation.Name = "gbDonation";
            this.gbDonation.Size = new System.Drawing.Size(533, 78);
            this.gbDonation.TabIndex = 38;
            this.gbDonation.TabStop = false;
            this.gbDonation.Text = "Donations";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(441, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Copy ETH";
            this.toolTip.SetToolTip(this.button1, "Copy the ETH address to the clipboard");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnBTC
            // 
            this.btnBTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBTC.Location = new System.Drawing.Point(441, 21);
            this.btnBTC.Name = "btnBTC";
            this.btnBTC.Size = new System.Drawing.Size(83, 23);
            this.btnBTC.TabIndex = 4;
            this.btnBTC.Text = "Copy BTC";
            this.toolTip.SetToolTip(this.btnBTC, "Copy the BTC address to the clipboard.");
            this.btnBTC.UseVisualStyleBackColor = true;
            this.btnBTC.Click += new System.EventHandler(this.btnBTC_Click);
            // 
            // tbETH
            // 
            this.tbETH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbETH.Location = new System.Drawing.Point(51, 51);
            this.tbETH.Name = "tbETH";
            this.tbETH.ReadOnly = true;
            this.tbETH.Size = new System.Drawing.Size(380, 20);
            this.tbETH.TabIndex = 3;
            this.tbETH.Text = "0x49fC48aD2a321eeAc512933307daA1e804fB43A3";
            this.tbETH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbETH, "Support me, make a donation :)");
            // 
            // tbBTC
            // 
            this.tbBTC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBTC.Location = new System.Drawing.Point(51, 23);
            this.tbBTC.Name = "tbBTC";
            this.tbBTC.ReadOnly = true;
            this.tbBTC.Size = new System.Drawing.Size(380, 20);
            this.tbBTC.TabIndex = 2;
            this.tbBTC.Text = "3HJNqLzPuF1fRXzxjZ7zKyBU6otFUKn87q";
            this.tbBTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.tbBTC, "Support me, make a donation :)");
            // 
            // lblETH
            // 
            this.lblETH.AutoSize = true;
            this.lblETH.Location = new System.Drawing.Point(11, 54);
            this.lblETH.Name = "lblETH";
            this.lblETH.Size = new System.Drawing.Size(38, 13);
            this.lblETH.TabIndex = 1;
            this.lblETH.Text = "ETH : ";
            // 
            // lblBTC
            // 
            this.lblBTC.AutoSize = true;
            this.lblBTC.Location = new System.Drawing.Point(11, 26);
            this.lblBTC.Name = "lblBTC";
            this.lblBTC.Size = new System.Drawing.Size(34, 13);
            this.lblBTC.TabIndex = 0;
            this.lblBTC.Text = "BTC :";
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // btnTwitter
            // 
            this.btnTwitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTwitter.BackgroundImage = global::MiningManager.Properties.Resources.twitterlogo;
            this.btnTwitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTwitter.Location = new System.Drawing.Point(519, 522);
            this.btnTwitter.Name = "btnTwitter";
            this.btnTwitter.Size = new System.Drawing.Size(26, 26);
            this.btnTwitter.TabIndex = 43;
            this.toolTip.SetToolTip(this.btnTwitter, "Go to my Twitter.");
            this.btnTwitter.UseVisualStyleBackColor = true;
            this.btnTwitter.Click += new System.EventHandler(this.btnTwitter_Click);
            // 
            // btnWWW
            // 
            this.btnWWW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWWW.BackgroundImage = global::MiningManager.Properties.Resources.internet;
            this.btnWWW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWWW.Location = new System.Drawing.Point(519, 426);
            this.btnWWW.Name = "btnWWW";
            this.btnWWW.Size = new System.Drawing.Size(26, 26);
            this.btnWWW.TabIndex = 42;
            this.toolTip.SetToolTip(this.btnWWW, "Go to my website.\r\nwww.mforge.org");
            this.btnWWW.UseVisualStyleBackColor = true;
            this.btnWWW.Click += new System.EventHandler(this.btnWWW_Click);
            // 
            // btngitHub
            // 
            this.btngitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btngitHub.BackgroundImage = global::MiningManager.Properties.Resources.github22x22;
            this.btngitHub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btngitHub.Location = new System.Drawing.Point(519, 554);
            this.btngitHub.Name = "btngitHub";
            this.btngitHub.Size = new System.Drawing.Size(26, 26);
            this.btngitHub.TabIndex = 41;
            this.toolTip.SetToolTip(this.btngitHub, "Visit my GitHUB repository.");
            this.btngitHub.UseVisualStyleBackColor = true;
            this.btngitHub.Click += new System.EventHandler(this.btngitHub_Click);
            // 
            // btnYoutube
            // 
            this.btnYoutube.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYoutube.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYoutube.BackgroundImage")));
            this.btnYoutube.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnYoutube.Location = new System.Drawing.Point(519, 458);
            this.btnYoutube.Name = "btnYoutube";
            this.btnYoutube.Size = new System.Drawing.Size(26, 26);
            this.btnYoutube.TabIndex = 40;
            this.toolTip.SetToolTip(this.btnYoutube, "Visit my YouTube channel.");
            this.btnYoutube.UseVisualStyleBackColor = true;
            this.btnYoutube.Click += new System.EventHandler(this.btnYoutube_Click);
            // 
            // btnFacebook
            // 
            this.btnFacebook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacebook.BackgroundImage = global::MiningManager.Properties.Resources.Facebook22x22;
            this.btnFacebook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFacebook.Location = new System.Drawing.Point(519, 490);
            this.btnFacebook.Name = "btnFacebook";
            this.btnFacebook.Size = new System.Drawing.Size(26, 26);
            this.btnFacebook.TabIndex = 39;
            this.toolTip.SetToolTip(this.btnFacebook, "Visit my Facebook page.");
            this.btnFacebook.UseVisualStyleBackColor = true;
            this.btnFacebook.Click += new System.EventHandler(this.btnFacebook_Click);
            // 
            // gpuzPathClearBtn
            // 
            this.gpuzPathClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpuzPathClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("gpuzPathClearBtn.Image")));
            this.gpuzPathClearBtn.Location = new System.Drawing.Point(499, 44);
            this.gpuzPathClearBtn.Name = "gpuzPathClearBtn";
            this.gpuzPathClearBtn.Size = new System.Drawing.Size(25, 23);
            this.gpuzPathClearBtn.TabIndex = 44;
            this.toolTip.SetToolTip(this.gpuzPathClearBtn, "Clear the path of GPU-Z.");
            this.gpuzPathClearBtn.UseVisualStyleBackColor = true;
            this.gpuzPathClearBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // afterburnetPathClearBtn
            // 
            this.afterburnetPathClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.afterburnetPathClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("afterburnetPathClearBtn.Image")));
            this.afterburnetPathClearBtn.Location = new System.Drawing.Point(499, 17);
            this.afterburnetPathClearBtn.Name = "afterburnetPathClearBtn";
            this.afterburnetPathClearBtn.Size = new System.Drawing.Size(25, 23);
            this.afterburnetPathClearBtn.TabIndex = 39;
            this.toolTip.SetToolTip(this.afterburnetPathClearBtn, "Clear the path of MSI AfterBurner.");
            this.afterburnetPathClearBtn.UseVisualStyleBackColor = true;
            this.afterburnetPathClearBtn.Click += new System.EventHandler(this.afterburnetPathEraseBtn_Click);
            // 
            // MinerManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 584);
            this.Controls.Add(this.btnTwitter);
            this.Controls.Add(this.btnWWW);
            this.Controls.Add(this.btngitHub);
            this.Controls.Add(this.btnYoutube);
            this.Controls.Add(this.btnFacebook);
            this.Controls.Add(this.gbDonation);
            this.Controls.Add(this.showLogsGB);
            this.Controls.Add(this.miningSoft);
            this.Controls.Add(this.wattFixGB);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.LogTabCtrl);
            this.Controls.Add(this.startupWinGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(568, 623);
            this.Name = "MinerManagerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mining Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MinerManagerMain_FormClosed);
            this.Resize += new System.EventHandler(this.MinerManagerMain_Resize);
            this.showLogsGB.ResumeLayout(false);
            this.showLogsGB.PerformLayout();
            this.startupWinGB.ResumeLayout(false);
            this.startupWinGB.PerformLayout();
            this.LogTabCtrl.ResumeLayout(false);
            this.LogTabPage.ResumeLayout(false);
            this.DebugTabPage.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.wattFixGB.ResumeLayout(false);
            this.wattFixGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pauseNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wattLimitNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerTickNum)).EndInit();
            this.miningSoft.ResumeLayout(false);
            this.miningSoft.PerformLayout();
            this.gbDonation.ResumeLayout(false);
            this.gbDonation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox showLogsGB;
        private System.Windows.Forms.CheckBox showGoodWattLogCB;
        private System.Windows.Forms.CheckBox showGeneralLogCb;
        private System.Windows.Forms.CheckBox showFixProfilLogCB;
        private System.Windows.Forms.Button settingsSaveBtn;
        private System.Windows.Forms.Button resetSettingsBtn;
        private System.Windows.Forms.GroupBox startupWinGB;
        private System.Windows.Forms.CheckBox startupRMrgCheckCB;
        private System.Windows.Forms.CheckBox startupMiningSoftCB;
        private System.Windows.Forms.CheckBox debugLogCB;
        private System.Windows.Forms.TabControl LogTabCtrl;
        private System.Windows.Forms.TabPage LogTabPage;
        private System.Windows.Forms.RichTextBox logsRTB;
        private System.Windows.Forms.TabPage DebugTabPage;
        private System.Windows.Forms.RichTextBox debugRTB;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeTSMI;
        private System.Windows.Forms.CheckBox autoWattFixCB;
        private System.Windows.Forms.GroupBox wattFixGB;
        private System.Windows.Forms.Label pauseLbl;
        private System.Windows.Forms.NumericUpDown pauseNum;
        private System.Windows.Forms.Label watLimitlbl;
        private System.Windows.Forms.NumericUpDown wattLimitNum;
        private System.Windows.Forms.Label timerTickLbl;
        private System.Windows.Forms.NumericUpDown timerTickNum;
        private System.Windows.Forms.Button startstopBtn;
        private System.Windows.Forms.Button gpuzPathClearBtn;
        private System.Windows.Forms.Button gpuzBtn;
        private System.Windows.Forms.TextBox gpuzSoftTb;
        private System.Windows.Forms.Label gpuZSoftPathlbl;
        private System.Windows.Forms.Button afterburnetPathClearBtn;
        private System.Windows.Forms.Button afterburnerBtn;
        private System.Windows.Forms.TextBox afterburnerTb;
        private System.Windows.Forms.Label afterburnerPathlbl;
        private System.Windows.Forms.GroupBox miningSoft;
        private System.Windows.Forms.Button ManualStartMinerBtn;
        private System.Windows.Forms.Label miningSoftLbl;
        private System.Windows.Forms.Button btnMinersList;
        private System.Windows.Forms.ComboBox cbMiners;
        private System.Windows.Forms.GroupBox gbDonation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBTC;
        private System.Windows.Forms.TextBox tbETH;
        private System.Windows.Forms.TextBox tbBTC;
        private System.Windows.Forms.Label lblETH;
        private System.Windows.Forms.Label lblBTC;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox cbTips;
        private System.Windows.Forms.Button btnFacebook;
        private System.Windows.Forms.Button btnYoutube;
        private System.Windows.Forms.Button btngitHub;
        private System.Windows.Forms.Button btnWWW;
        private System.Windows.Forms.Button btnTwitter;
        private System.Windows.Forms.Label lblMinCheckWatt;
        private System.Windows.Forms.Label lblMinW8;
    }
}


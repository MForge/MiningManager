using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using MiningManager.Properties;

namespace MiningManager
{
    public partial class MinerManagerMain : Form
    {
        
        // pour le process focus
        [DllImport("user32.dll")]
        private static extern
        bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern
            bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern
            bool IsIconic(IntPtr hWnd);

        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;

        private int tickCount;
        private GPUZ_SHMEM SHMEM;
        private SettingsMgr m_SettingsMgr;
        private Boolean isLoadingSettings = false;
        private Boolean WattMrgRun = false;
        private Boolean MinerStartedManualy = false;

        private BackgroundWorker bgwGlobalWattFixMandatoryApps;
        private BackgroundWorker bgwAfterburner;
        private BackgroundWorker bgwGPUZ;
        private BackgroundWorker bgwWattFix;
        private BackgroundWorker bgwMiningSoft;

        private Icon MainIcon = Resources.GaugeGreen;

        private enum LogType { generalLog, fixProfile, goodWatt, debug, error };

        public MinerManagerMain()
        {
            InitializeComponent();

            notifyIcon.Icon = MainIcon;
            notifyIcon.BalloonTipText = "Application Minimized.";
            notifyIcon.BalloonTipTitle = "Mining Manager";
 
            // change version : Properties / AssemblyInfo.cs
            string version = (FileVersionInfo.GetVersionInfo((Assembly.GetExecutingAssembly()).Location)).FileVersion; // or fvi.ProductVersion
            this.Text = this.Text + " v." + version.Remove(version.Length - 4);

            tickCount = 0;
            SHMEM = new GPUZ_SHMEM();
            loadSettings();
            loadMiners();

            if (autoWattFixCB.Checked)
            {
                WattFixThreadStart();
            }

            if (startupMiningSoftCB.Checked)
            {
                MinerThreadStart();
            }
        }

        /*
         * Démmare le soft de minage dans une autre thread
         */
        private void MinerThreadStart()
        {
            bgwMiningSoft = new BackgroundWorker();
            bgwMiningSoft.WorkerReportsProgress = true;
            bgwMiningSoft.WorkerSupportsCancellation = true;
            bgwMiningSoft.DoWork += new DoWorkEventHandler(bgwMiningSoft_DoWork);
            bgwMiningSoft.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwMiningSoft_RunWorkerCompleted);
            bgwMiningSoft.RunWorkerAsync();
        }

        /*
         * Cette fonction démmare la chaine de vérification des prérequis pour le Watt Fix.
         */
        private void WattFixThreadStart()
        {
            bgwGlobalWattFixMandatoryApps = new BackgroundWorker();
            bgwGlobalWattFixMandatoryApps.WorkerReportsProgress = true;
            bgwGlobalWattFixMandatoryApps.WorkerSupportsCancellation = true;
            bgwGlobalWattFixMandatoryApps.DoWork += new DoWorkEventHandler(bgwGlobalWattFixMandatoryApps_DoWork);
            bgwGlobalWattFixMandatoryApps.RunWorkerAsync();
        }

        #region BackgroundWorkers
        /*
         * Thread qui s'assure que toutes les applications prérequis (MSI Afterburner, GPU-z,...) pour le watt fix tournent et startle watt fix dans une autre thread. 
         */
        private void bgwGlobalWattFixMandatoryApps_DoWork(object sender, DoWorkEventArgs e)
        {
            WattMrgRun = true;

            logsRTB.BeginInvoke(new MethodInvoker(delegate
            {
                logsRTB.Clear();
            }));

           /* errorsRTB.BeginInvoke(new MethodInvoker(delegate
            {
                errorsRTB.Clear();
            }));*/

            debugRTB.BeginInvoke(new MethodInvoker(delegate
            {
                debugRTB.Clear();
            }));

            startstopBtn.BeginInvoke(new MethodInvoker(delegate
            {
                startstopBtn.Text = "Stop Watt fix";
            }));

            disableUiComponents();

            if (autoWattFixCB.Checked)
            {
                int sleeptimeA = 2500;
                showLog("Start Watt fix management threads in " + Convert.ToSingle(sleeptimeA/1000) + " sec", LogType.generalLog);
                Thread.Sleep(sleeptimeA);
            }

            // Start and Wait for MSI Afterburner
            bgwAfterburner = new BackgroundWorker();
            bgwAfterburner.WorkerReportsProgress = true;
            bgwAfterburner.WorkerSupportsCancellation = true;
            bgwAfterburner.DoWork += new DoWorkEventHandler(bgwAfterburner_DoWork);
            bgwAfterburner.RunWorkerAsync();

            Boolean AfterburnerIsRunning = false;
            int sleeptimeB = 2000;
            string afterburnerName = Path.GetFileNameWithoutExtension(afterburnerTb.Text);

            while (!AfterburnerIsRunning && !this.bgwGlobalWattFixMandatoryApps.CancellationPending)
            {
                showLog("Waiting for MSI Afterburner....", LogType.generalLog);

                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Contains(afterburnerName))
                    {
                        AfterburnerIsRunning = true;
                        break;
                    }

                    if (this.bgwGlobalWattFixMandatoryApps.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }
                }

                if (!AfterburnerIsRunning && !this.bgwGlobalWattFixMandatoryApps.CancellationPending)
                {
                    Thread.Sleep(sleeptimeB);
                }
            }

            if(!this.bgwGlobalWattFixMandatoryApps.CancellationPending)
            {
                // Start and Wait for GPU-Z
                bgwGPUZ = new BackgroundWorker();
                bgwGPUZ.WorkerReportsProgress = true;
                bgwGPUZ.WorkerSupportsCancellation = true;
                bgwGPUZ.DoWork += new DoWorkEventHandler(bgwGPUZ_DoWork);
                bgwGPUZ.RunWorkerAsync();

                Boolean GPUZIsRunning = false;
                string GPUZName = Path.GetFileNameWithoutExtension(gpuzSoftTb.Text);

                while (!GPUZIsRunning && !this.bgwGlobalWattFixMandatoryApps.CancellationPending)
                {
                    showLog("Waiting for GPU-Z...", LogType.generalLog);

                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Contains(GPUZName))
                        {
                            GPUZIsRunning = true;
                            break;
                        }
                        if (this.bgwGlobalWattFixMandatoryApps.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }
                    }
                    if (!GPUZIsRunning && !this.bgwGlobalWattFixMandatoryApps.CancellationPending)
                    {
                        Thread.Sleep(sleeptimeB);
                    }
                }

                // Start WattFix thread :
                if (!this.bgwGlobalWattFixMandatoryApps.CancellationPending)
                {
                    bgwWattFix = new BackgroundWorker();
                    bgwWattFix.WorkerReportsProgress = true;
                    bgwWattFix.WorkerSupportsCancellation = true;
                    bgwWattFix.DoWork += new DoWorkEventHandler(bgwWattFix_DoWork);
                    bgwWattFix.RunWorkerAsync();
                }
            }
        }

        private void bgwMiningSoft_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (!MinerStartedManualy)
                {
                    Thread.Sleep(2000);
                    int sleepTime = 120000; // 300000 = 5min
                    showLog("Start Mining soft in : " + Convert.ToSingle(sleepTime / 60000) + " min", LogType.generalLog);

                    Thread.Sleep(sleepTime);
                }
                else
                {
                    cbMiners.BeginInvoke(new MethodInvoker(delegate
                    {
                        showLog("Start Mining soft : " + m_SettingsMgr.MinerList.getMiner(cbMiners.SelectedIndex).Name, LogType.generalLog);

                    }));
                    MinerStartedManualy = false;
                }

                startMiningSoftware();
            }
            catch (Exception ex)
            {
                showLog("Error Start Mining soft : " + ex.Message, LogType.error);
            }
        }

        private void bgwMiningSoft_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void ManualStartMinerBtn_Click(object sender, EventArgs e)
        {
            MinerStartedManualy = true;
            if (MinerAlreadyRun())
            {
                DialogResult result;
                result = MessageBox.Show("The mining software seems already running, do you still want to start your mining software ?", "Mining Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //startMiningSoftware();
                    MinerThreadStart();
                }
            }
            else
            {
                //startMiningSoftware();
                MinerThreadStart();
            }
        }

        /*
         * Vérifie si le soft de mining ne tourne pas déjà. 
         */
        private Boolean MinerAlreadyRun()
        {
            Boolean toReturn = false;
            if (cbMiners.SelectedIndex != -1)
            {
                string MinerName = Path.GetFileNameWithoutExtension((m_SettingsMgr.MinerList.getMiner(cbMiners.SelectedIndex)).Path);

                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Contains(MinerName))
                    {
                        toReturn = true;
                        break;
                    }
                }
            }
            else
            {
                toReturn = false;
            }
            return toReturn;
        }

        private void startMiningSoftware()
        {

            cbMiners.BeginInvoke(new MethodInvoker(delegate
            {
                if (cbMiners.SelectedIndex != -1)
                {
                    string minerPath = (m_SettingsMgr.MinerList.getMiner(cbMiners.SelectedIndex)).Path;
                    /*
                    using (Process exeProcess = Process.Start(minerPath, ""))
                    {
                        showLog("Start Mining soft : " + minerPath, LogType.generalLog);
                    }*/

                    Process proc = new Process();
                    proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(minerPath);
                    proc.StartInfo.FileName = minerPath;
                    proc.StartInfo.CreateNoWindow = false; //true;

                    proc.StartInfo.UseShellExecute = true;//false;
                    //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                   /* proc.StartInfo.RedirectStandardOutput = true;
                    proc.OutputDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
                    proc.StartInfo.RedirectStandardError = true;
                    proc.ErrorDataReceived += new DataReceivedEventHandler(ProcessOutputHandler);
                    */
                    proc.Start();

                    //proc.BeginOutputReadLine();

                    /*proc.WaitForExit();
                    int ExitCode = proc.ExitCode;
                    proc.Close();*/

                    showLog("Mining soft started.", LogType.generalLog);
                }
                else
                {
                    showLog("Please first initialize a miner.", LogType.generalLog);
                }
            }));
        }

        /*private void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                showLog(outLine.Data , LogType.generalLog);
            }
        }*/

        /*
         * Loop qui fixle profile dans MSI afterburner pour réduire la conssommation de courant 
         */
        private void bgwWattFix_DoWork(object sender, DoWorkEventArgs e)
        {
            showLog("Start Watt fix", LogType.generalLog);
            try
            {
                double myMawWatt = Convert.ToDouble(wattLimitNum.Value);
                while ((WattMrgRun) && (!this.bgwWattFix.CancellationPending))
                {
                    try
                    {
                        if (this.bgwWattFix.CancellationPending)
                        {
                            showLog("Watt Fix Thread : Cancel thread", LogType.debug);
                            e.Cancel = true;
                            break;
                        }

                        showLog("Watt Fix Thread : Sleep " + Convert.ToString(timerTickNum.Value) + " ms", LogType.debug);
                        Thread.Sleep(Convert.ToInt32(timerTickNum.Value));

                        showLog("Watt Fix Thread : GPUZ read shared memory", LogType.debug);
                        SHMEM.ReadSharedMemory();
                        showLog("Watt Fix Thread : GPUZ get sensor Power(Watt) sensor value", LogType.debug);
                        GPUZ_SHMEM.GPUZ_SENSOR_RECORD aSensor = SHMEM.GetSensorByIndex(7);

                        double sensorValue = Math.Round(aSensor.value, 2);

                        showLog("Watt Fix Thread : Begin Watts compare", LogType.debug);
                        if (sensorValue > myMawWatt)
                        {
                            try
                            {
                                showLog("Watt Fix Thread : Sensor value > Max Watt", LogType.debug);
                                int modulo = tickCount % 2;
                                if (modulo == 0)
                                {
                                    showLog("Watt Fix Thread : Start Afterburner profil 1", LogType.debug);
                                    StartProcess(afterburnerTb.Text, "-Profile1");
                                }
                                else
                                {
                                    showLog("Watt Fix Thread : Start Afterburner profil 2", LogType.debug);
                                    StartProcess(afterburnerTb.Text, "-Profile2");
                                }

                                showLog("Set Profile " + Convert.ToString(modulo + 1) + "; " +
                                        aSensor.name + " : " + sensorValue + "W > " + myMawWatt + "W", LogType.fixProfile);

                                tickCount++;

                                if (tickCount == 11)
                                {
                                    tickCount = 0;
                                }

                                showLog("Watt Fix Thread : Sleep " + Convert.ToString(pauseNum.Value) + " ms", LogType.debug);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                            Thread.Sleep(Convert.ToInt32(pauseNum.Value));
                        }
                        else
                        {
                            showLog("Watt Fix Thread : Sensor value <= max Watt ==> Watt OK (" + sensorValue + "W <= " + myMawWatt + "W)", LogType.debug);
                            showLog("Consumption (Watt) OK - " + aSensor.name + " : " + sensorValue + "W <= " + myMawWatt + "W", LogType.goodWatt);
                        }
                    }
                    catch (Exception ex)
                    {
                        showLog("Watt Fix Thread Error : " + ex.Message, LogType.error);
                    }
                }
            }
            catch (Exception ex)
            {
                showLog("Watt Fix Thread Error : " + ex.Message, LogType.error);
            }
        }


        /*
         * Vérifie si MSI Afterburner tourne, si pas, elle va le démarrer au bout de "tickStartMsi" et s'assure qu'il à bien démmarer.
         *  Si oui, elle ...
         *  Si non elle log l'erreur et ne vas pas plus loin.
         */
        private void bgwAfterburner_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean AfterburnerIsRunning = false;
            int maxloop = 12;
            int tickStartMsi = maxloop / 2;
            int sleeptime = 2000;
            string afterburnerName = Path.GetFileNameWithoutExtension(afterburnerTb.Text);

            while ( (!AfterburnerIsRunning) && (maxloop > 0) && (!this.bgwAfterburner.CancellationPending))
            {
               // showLog("Waiting for MSI Afterburner...", LogType.generalLog);

                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Contains(afterburnerName))
                    {
                        AfterburnerIsRunning = true;
                        break;
                    }

                    if (this.bgwAfterburner.CancellationPending)
                    {
                        break;
                    }
                }

                if ((maxloop == tickStartMsi) && (!this.bgwAfterburner.CancellationPending))
                {
                    StartProcess(afterburnerTb.Text, "-Profile1");
                }

                maxloop--;
                if((!AfterburnerIsRunning) && (!this.bgwAfterburner.CancellationPending))
                {
                    Thread.Sleep(sleeptime);
                }
            }

            if ((!this.bgwAfterburner.CancellationPending))
            {
                if (!AfterburnerIsRunning)
                {
                    showLog("Impossible to start MSI Afterburner !", LogType.generalLog);
                }
                else
                {
                    showLog("MSI Afterburner is running.", LogType.generalLog);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        /*
         * Vérifie siGPU-Z tourne, si pas, elle va le démarrer au bout de "tickStart" et s'assure qu'il à bien démmarer.
         *  Si oui, elle ...
         *  Si non elle log l'erreur et ne vas pas plus loin.
         */
        private void bgwGPUZ_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean GPUZIsRunning = false;
            int maxloop = 12;
            int tickStart = maxloop / 2;
            int sleeptime = 2000;
            string GPUZName = Path.GetFileNameWithoutExtension(gpuzSoftTb.Text);

            while ((!GPUZIsRunning) && (maxloop > 0) && (!this.bgwGPUZ.CancellationPending))
            {
                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Contains(GPUZName))
                    {
                        GPUZIsRunning = true;
                        break;
                    }
                    if (this.bgwGPUZ.CancellationPending)
                    {
                        break;
                    }
                }

                if ((maxloop == tickStart) && (!this.bgwGPUZ.CancellationPending))
                {
                    StartProcess(gpuzSoftTb.Text);
                }

                maxloop--;
                if ((!GPUZIsRunning) && (!this.bgwGPUZ.CancellationPending))
                { Thread.Sleep(sleeptime); }
            }

            if(!this.bgwGPUZ.CancellationPending)
            {
                if (!GPUZIsRunning)
                {
                    showLog("Impossible to start GPU-Z !", LogType.generalLog);
                }
                else
                {
                    showLog("GPU-Z is running.", LogType.generalLog);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion BackgroundWorkers

        private void StartProcess(string exePath, string aPrams="")
        {
            try
            {
                showLog("Process.Start " + exePath + ", Params : " + aPrams, LogType.debug);
                Process.Start(exePath, aPrams);
            }
            catch (Exception ex)
            {
                showLog("Error StartProcess : " + ex.Message + " ( path : " + exePath + ")", LogType.error);
            }
        }

        /*
         * Démmare la Watt fix thread si elle ne tourne pas déjà, sinon annule toutes les autres threads pour stopper le watt fixing. 
         */
        private void StartWattFix_Click(object sender, EventArgs e)
        {
            try
            {
                if (!WattMrgRun && checkMandatoryPathsWattFix())
                {
                    WattFixThreadStart();
                }
                else
                {
                    WattMrgRun = false;

                    if ((bgwWattFix != null) && (bgwWattFix.IsBusy))
                    {
                        bgwWattFix.CancelAsync();
                        bgwWattFix.Dispose();
                        //showLog("bgwWattFix.CancelAsync", LogType.generalLog);
                    }

                    if ((bgwGPUZ != null) && (bgwGPUZ.IsBusy))
                    {
                        bgwGPUZ.CancelAsync();
                        bgwGPUZ.Dispose();
                        //showLog("bgwGPUZ.CancelAsync", LogType.generalLog);
                    } 

                    if ((bgwAfterburner != null) && (bgwAfterburner.IsBusy))
                    {
                        bgwAfterburner.CancelAsync();
                        bgwAfterburner.Dispose();
                        //showLog("bgwAfterburner.CancelAsync", LogType.generalLog);
                    }

                    if ((bgwGlobalWattFixMandatoryApps != null) && (bgwGlobalWattFixMandatoryApps.IsBusy))
                    {
                        bgwGlobalWattFixMandatoryApps.CancelAsync();
                        bgwGlobalWattFixMandatoryApps.Dispose();
                        //showLog("bgwGlobalWattFixMandatoryApps.CancelAsync", LogType.generalLog);
                    } 

                    enableUiComponents();
                    startstopBtn.Text = "Start Watt fix";
                }
            }
            catch (Exception ex)
            {
                showLog("Error Start Watt fix Btn click : " + ex.Message, LogType.error);
            }
        }
        /*
         * Vérifie si toutes les données obligatoires au bon fonctionnement de l'application sont initialisées.
         * Retourne True si tout est initialisé, false sinon.
         */
        private Boolean checkMandatoryPathsWattFix()
        {
            string message = "Please check the following things : ";
            Boolean allOK = true;

            if (afterburnerTb.Text == "")
            {
                message += Environment.NewLine + "- The path of MSI Afterburner is missing";
                allOK = false;
            }
            else
            {
                if ((!File.Exists(afterburnerTb.Text)) || (Path.GetFileName(afterburnerTb.Text) != "MSIAfterburner.exe"))
                {
                    message += Environment.NewLine + "- MSI Afterburner path incorrect (" + afterburnerTb.Text + ")";
                    allOK = false;
                }
            }

            if (gpuzSoftTb.Text == "")
            {
                message += Environment.NewLine + "- The path of GPU-Z is missing";
                allOK = false;
            }
            else
            {
                if ((!File.Exists(gpuzSoftTb.Text)) || (Path.GetFileName(gpuzSoftTb.Text) != "GPU-Z.exe"))
                {
                    message += Environment.NewLine + "- GPU-Z path incorrect (" + gpuzSoftTb.Text + ")";
                    allOK = false;
                }
            }

            if(!allOK)
            {
                MessageBox.Show(message, "Miner Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                return true;
            }  
        }

        private void disableUiComponents()
        {
            timerTickNum.BeginInvoke(new MethodInvoker(delegate
            {
                timerTickNum.ReadOnly = true;
            }));

            wattLimitNum.BeginInvoke(new MethodInvoker(delegate
            {
                wattLimitNum.ReadOnly = true;
            }));

            pauseNum.BeginInvoke(new MethodInvoker(delegate
            {
                 pauseNum.ReadOnly = true;
            }));

            settingsSaveBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 settingsSaveBtn.Enabled = false;
            }));

            resetSettingsBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 resetSettingsBtn.Enabled = false;
            }));

            afterburnerBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 afterburnerBtn.Enabled = false;
            }));

            afterburnetPathClearBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 afterburnetPathClearBtn.Enabled = false;
            }));

            btnMinersList.BeginInvoke(new MethodInvoker(delegate
            {
                btnMinersList.Enabled = false;
            }));

            cbMiners.BeginInvoke(new MethodInvoker(delegate
            {
                cbMiners.Enabled = false;
            }));

            startupRMrgCheckCB.BeginInvoke(new MethodInvoker(delegate
            {
                 startupRMrgCheckCB.Enabled = false;
            }));

            startupMiningSoftCB.BeginInvoke(new MethodInvoker(delegate
            {
                 startupMiningSoftCB.Enabled = false;
            }));

            autoWattFixCB.BeginInvoke(new MethodInvoker(delegate
            {
                autoWattFixCB.Enabled = false;
            }));

            gpuzBtn.BeginInvoke(new MethodInvoker(delegate
            {
                gpuzBtn.Enabled = false;
            }));

            gpuzPathClearBtn.BeginInvoke(new MethodInvoker(delegate
            {
                gpuzPathClearBtn.Enabled = false;
            }));
            
        }

        private void enableUiComponents()
        {
            timerTickNum.BeginInvoke(new MethodInvoker(delegate
            {
                timerTickNum.ReadOnly = false;
            }));

            wattLimitNum.BeginInvoke(new MethodInvoker(delegate
            {
                 wattLimitNum.ReadOnly = false;
            }));

            pauseNum.BeginInvoke(new MethodInvoker(delegate
            {
                 pauseNum.ReadOnly = false;
            }));

            settingsSaveBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 settingsSaveBtn.Enabled = true;
            }));

            resetSettingsBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 resetSettingsBtn.Enabled = true;
            }));

            afterburnerBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 afterburnerBtn.Enabled = true;
            }));

            afterburnetPathClearBtn.BeginInvoke(new MethodInvoker(delegate
            {
                 afterburnetPathClearBtn.Enabled = true;
            }));

            btnMinersList.BeginInvoke(new MethodInvoker(delegate
            {
                btnMinersList.Enabled = true;
            }));

            cbMiners.BeginInvoke(new MethodInvoker(delegate
            {
                cbMiners.Enabled = true;
            }));

            startupRMrgCheckCB.BeginInvoke(new MethodInvoker(delegate
            {
                 startupRMrgCheckCB.Enabled = true;
            }));

            startupMiningSoftCB.BeginInvoke(new MethodInvoker(delegate
            {
                 startupMiningSoftCB.Enabled = true;
            }));

            autoWattFixCB.BeginInvoke(new MethodInvoker(delegate
            {
                autoWattFixCB.Enabled = true;
            }));

            gpuzBtn.BeginInvoke(new MethodInvoker(delegate
            {
                gpuzBtn.Enabled = true;
            }));

            gpuzPathClearBtn.BeginInvoke(new MethodInvoker(delegate
            {
                gpuzPathClearBtn.Enabled = true;
            }));
        }

        public void loadSettings()
        {
            m_SettingsMgr = new SettingsMgr();

            if (File.Exists(SettingsMgr.fileName))
            {
                isLoadingSettings = true;

                m_SettingsMgr.loadFromXml();
                timerTickNum.Value = m_SettingsMgr.TimerTick;
                wattLimitNum.Value = m_SettingsMgr.WattLimit;
                pauseNum.Value = m_SettingsMgr.PauseAfetSetProfil;
                showGeneralLogCb.Checked = m_SettingsMgr.LogGeneral;
                showFixProfilLogCB.Checked = m_SettingsMgr.LogFixProfil;
                showGoodWattLogCB.Checked = m_SettingsMgr.LogWattOk;
                debugLogCB.Checked = m_SettingsMgr.LogDebug;
                cbTips.Checked = m_SettingsMgr.Tips;
                afterburnerTb.Text = m_SettingsMgr.AfterburnerPath;
                gpuzSoftTb.Text = m_SettingsMgr.GpuzPath;
                startupRMrgCheckCB.Checked = m_SettingsMgr.StartOnBootRigMgr;
                startupMiningSoftCB.Checked = m_SettingsMgr.StartOnBootMiningSoft;
                autoWattFixCB.Checked = m_SettingsMgr.StartOnBootWattFix;

                isLoadingSettings = false;
                
            }
            else
            {
                m_SettingsMgr.TimerTick = Convert.ToInt32(timerTickNum.Value);
                m_SettingsMgr.WattLimit = Convert.ToInt32(wattLimitNum.Value);
                m_SettingsMgr.PauseAfetSetProfil = Convert.ToInt32(pauseNum.Value);
                m_SettingsMgr.LogGeneral = showGeneralLogCb.Checked;
                m_SettingsMgr.LogFixProfil = showFixProfilLogCB.Checked;
                m_SettingsMgr.LogWattOk = showGoodWattLogCB.Checked;
                m_SettingsMgr.LogDebug = debugLogCB.Checked;
                m_SettingsMgr.Tips = cbTips.Checked;
                m_SettingsMgr.AfterburnerPath = checkAfterburnerPath();
                afterburnerTb.Text = m_SettingsMgr.AfterburnerPath;
                m_SettingsMgr.GpuzPath = checkGpuzPath();
                gpuzSoftTb.Text = m_SettingsMgr.GpuzPath;
                m_SettingsMgr.StartOnBootRigMgr = startupRMrgCheckCB.Checked;
                m_SettingsMgr.StartOnBootMiningSoft = startupMiningSoftCB.Checked;
                m_SettingsMgr.StartOnBootWattFix = autoWattFixCB.Checked;
            }
        }

        private void updateSettings()
        {
            if ((m_SettingsMgr != null) && (!isLoadingSettings))
            {
                m_SettingsMgr.TimerTick = Convert.ToInt32(timerTickNum.Value);
                m_SettingsMgr.WattLimit = Convert.ToInt32(wattLimitNum.Value);
                m_SettingsMgr.PauseAfetSetProfil = Convert.ToInt32(pauseNum.Value);
                m_SettingsMgr.LogGeneral = showGeneralLogCb.Checked;
                m_SettingsMgr.LogFixProfil = showFixProfilLogCB.Checked;
                m_SettingsMgr.LogWattOk = showGoodWattLogCB.Checked;
                m_SettingsMgr.LogDebug = debugLogCB.Checked;
                m_SettingsMgr.Tips = cbTips.Checked;
                m_SettingsMgr.AfterburnerPath = afterburnerTb.Text;
                m_SettingsMgr.GpuzPath = gpuzSoftTb.Text;
                m_SettingsMgr.StartOnBootRigMgr = startupRMrgCheckCB.Checked;
                m_SettingsMgr.StartOnBootMiningSoft = startupMiningSoftCB.Checked;
                m_SettingsMgr.StartOnBootWattFix = autoWattFixCB.Checked;
                saveSettings();
            }
        }

        private void resetSettingsBtn_Click(object sender, EventArgs e)
        {

            string message = "Are you sure that you want reset the settings ?";
            string caption = "Miner Manager";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                timerTickNum.Value = 500;
                wattLimitNum.Value = 90;
                pauseNum.Value = 1000;
                showGeneralLogCb.Checked = true;
                showFixProfilLogCB.Checked = true;
                showGoodWattLogCB.Checked = true;
                debugLogCB.Checked = false;
                cbTips.Checked = true;
                startupMiningSoftCB.Checked = false;
                autoWattFixCB.Checked = false;
                startupRMrgCheckCB.Checked = false;

                showLog("Settings resetted", LogType.generalLog);
            }
        }

        private void showLog (string aLog, LogType alogType)
        {
            Boolean showLog = false;

            switch (alogType)
            {
                case LogType.generalLog:
                    showLog = showGeneralLogCb.Checked;
                    break;
                case LogType.fixProfile:
                    showLog = showFixProfilLogCB.Checked;
                    break;
                case LogType.goodWatt:
                    showLog = showGoodWattLogCB.Checked;
                    break;
                case LogType.error:
                    logsRTB.BeginInvoke(new MethodInvoker(delegate
                    {
                        logsRTB.AppendText(DateTime.Now.ToString("dd/MM/yy HH:mm:ss") + @" : /!\ ERROR : " + aLog + Environment.NewLine);
                        logsRTB.SelectionStart = logsRTB.Text.Length;
                        logsRTB.ScrollToCaret();
                    }));
                    break;
                case LogType.debug:
                    if (debugLogCB.Checked)
                    {
                        debugRTB.BeginInvoke(new MethodInvoker(delegate
                        {
                            debugRTB.AppendText(DateTime.Now.ToString("dd/MM/yy HH:mm:ss") + " : " + aLog + Environment.NewLine);
                        }));
                    } 
                    break;
            }

            if (showLog)
            {
                logsRTB.BeginInvoke(new MethodInvoker(delegate
                {
                    logsRTB.AppendText(DateTime.Now.ToString("dd/MM/yy HH:mm:ss") + " : " + aLog + Environment.NewLine);
                    logsRTB.SelectionStart = logsRTB.Text.Length;
                    logsRTB.ScrollToCaret();
                }));
            }
        }

        public void saveSettings()
        {
            m_SettingsMgr.saveToXml();
        }

        private string checkAfterburnerPath()
        {
            string ProgrammFilePath, toReturn = "";
            if (8 == IntPtr.Size || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                ProgrammFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }
            else
            {
                ProgrammFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }

            if (File.Exists(ProgrammFilePath + @"\MSI Afterburner\MSIAfterburner.exe"))
            {
                toReturn = ProgrammFilePath + @"\MSI Afterburner\MSIAfterburner.exe";
            }
            return toReturn;
        }

        private string checkGpuzPath()
        {
            string ProgrammFilePath, toReturn = "";
            if (8 == IntPtr.Size || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                ProgrammFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }
            else
            {
                ProgrammFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }

            if (File.Exists(ProgrammFilePath + @"\GPU-Z\GPU-Z.exe"))
            {
                toReturn = ProgrammFilePath + @"\GPU-Z\GPU-Z.exe";
            }
            return toReturn;
        }

        private void settingsSaveBtn_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void timerTickNum_ValueChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void wattLimitNum_ValueChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void pauseNum_ValueChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void showGeneralLogCb_CheckedChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void showFixProfilLogCB_CheckedChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void showGoodWattLogCB_CheckedChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void startupMiningSoftCB_CheckedChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void afterburnerBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            myOpenFileDialog.Filter = @"(MSIAfterburner.exe)|MSIAfterburner.exe";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.Multiselect = false;

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                afterburnerTb.Text = myOpenFileDialog.InitialDirectory + myOpenFileDialog.FileName;
                updateSettings();
            }

        }

        private void afterburnetPathEraseBtn_Click(object sender, EventArgs e)
        {
            afterburnerTb.Text = "";
            updateSettings();
        }

        private void addStartupLnk()
        {
            try
            {
                string shortcutLocation = Windows.GetStartupPath() + Path.DirectorySeparatorChar + "MiningManager.bat"; // Path.Combine(shortcutPath, shortcutName + ".lnk");

                Boolean fileexist = File.Exists(shortcutLocation);
                if (fileexist)
                {
                    File.Delete(shortcutLocation);
                }

                FileStream fs1 = new FileStream(shortcutLocation, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.Write("timeout 120");
                writer.WriteLine();
                writer.Write(@"start /d """ + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @""" MiningManager.exe");
                writer.WriteLine();
                writer.Write("pause");
                writer.Close();

                // add shortkut to startup directory
                /*string shortcutLocation = Windows.GetStartupPath() + Path.DirectorySeparatorChar + "MiningManager.lnk"; // Path.Combine(shortcutPath, shortcutName + ".lnk");
                if (!System.IO.File.Exists(shortcutLocation))
                {
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                    shortcut.Description = "Shortcut to Mining Manager";   // The description of the shortcut
                    shortcut.WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    //shortcut.IconLocation = @"c:\myicon.ico";           // The icon of the shortcut
                    shortcut.TargetPath = Assembly.GetExecutingAssembly().Location;  // The path of the file that will launch when the shortcut is run
                    shortcut.Save();
                }*/
            }
            catch (Exception ex)
            {
                startupRMrgCheckCB.Checked = false;
                showLog("Error Add Startup link : " + ex.Message, LogType.error);
            }
        }

        private void deleteStartupLnk()
        {
            string linkPath = Windows.GetStartupPath() + Path.DirectorySeparatorChar + "MiningManager.bat";
            if (File.Exists(linkPath))
            {
                File.Delete(linkPath);
                showLog("Startup bat deleted from : " + linkPath, LogType.generalLog);
            }
        }

        private void startupCheckCB_CheckedChanged(object sender, EventArgs e)
        {
            if (startupRMrgCheckCB.Checked)
            {
                addStartupLnk();
            }
            else{
                deleteStartupLnk();
            }
            updateSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gpuzSoftTb.Text = "";
            updateSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();

            myOpenFileDialog.Filter = @"(GPU-Z.exe)|GPU-Z.exe";
            myOpenFileDialog.FilterIndex = 1;
            myOpenFileDialog.Multiselect = false;

            if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                gpuzSoftTb.Text = myOpenFileDialog.InitialDirectory + myOpenFileDialog.FileName;
                updateSettings();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;

        }

        private void closeTSMI_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MinerManagerMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainIcon.Dispose();
        }

        private void showTSMI_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = true;
            notifyIcon.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void MinerManagerMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                ShowInTaskbar = false;
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void autoWattFixCB_CheckedChanged(object sender, EventArgs e)
        {
            updateSettings();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MinerListFrm frmMiner = new MinerListFrm(m_SettingsMgr.MySettings, false);
            frmMiner.ShowDialog();
            saveSettings();
            loadMiners();
        }

        private void loadMiners()
        {
            cbMiners.Items.Clear();
            int selectedMinerIndex = -1;
            int index = 0;
            foreach (Miner m in m_SettingsMgr.MySettings.MinerList)
            {
                cbMiners.Items.Add(m.Name);
                if (m.IsSelected)
                {
                    selectedMinerIndex = index;
                }
                index++;
            }

            if (cbMiners.Items.Count > 0)
            {
                if (selectedMinerIndex == -1)
                {
                    cbMiners.SelectedIndex = 0;
                }
                else
                {
                    cbMiners.SelectedIndex = selectedMinerIndex;
                }
            }
            checkMandatoryApp();
        }

        private void checkMandatoryApp()
        {
            ManualStartMinerBtn.Enabled = !(cbMiners.Items.Count <= 0);
            cbMiners.Enabled = ManualStartMinerBtn.Enabled;

            startstopBtn.Enabled = ((afterburnerTb.Text != "") && (afterburnerTb.Text != "gpuzSoftTb"));
        }

        private void cbMiners_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            foreach (Miner m in m_SettingsMgr.MySettings.MinerList)
            {
                if (index == cbMiners.SelectedIndex)
                {
                    m.IsSelected = true;
                }
                else
                {
                    m.IsSelected = false;
                }
                index++;
            }
            updateSettings();
        }

        private void afterburnerTb_TextChanged(object sender, EventArgs e)
        {
            checkMandatoryApp();
        }

        private void gpuzSoftTb_TextChanged(object sender, EventArgs e)
        {
            checkMandatoryApp();
        }

        private void btnBTC_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbBTC.Text);
            showLog("=> BTC address copied to the clipboard <=", LogType.generalLog);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Clipboard.SetText(tbETH.Text);
            showLog("=> ETH address copied to the clipboard <=", LogType.generalLog);
        }

        private void cbTips_CheckedChanged(object sender, EventArgs e)
        {
            updateSettings();
            toolTip.Active = cbTips.Checked;
        }

        private void btnWWW_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.mforge.org");
        }

        private void btnYoutube_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCJxJRCVHtH8ou97JK_CXn_g");
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/MForge-397373667285919");
        }

        private void btngitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MForge");
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/MForgeM");
        }
    }
}

/*
 
AutoIt :

    AutoItX3 automation = new AutoItX3();

    automation.WinActivate("TechPowerUp GPU-Z 2.5.0");

    //automation.MouseMove(92, 498, 10);

    automation.MouseClick("LEFT", 92, 498, 2, 10);
    //automation.ControlClick("TechPowerUp GPU-Z 2.5.0", "", "[CLASS:ComboBox; INSTANCE:1]", "left", 1, 94, 11); 
     
     
System information : 

    private void button1_Click(object sender, EventArgs e)
        {
            GPUZ_SHMEM shMem = new GPUZ_SHMEM();
            if (!shMem.GPUZ_Running)
            {
                // handle it however you want
            }
            else shMem.ReadSharedMemory();
            
            //GPUZ_SHMEM SHMEM = new GPUZ_SHMEM();

            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.Contains("GPU-Z"))
                {
                    richTextBox1.Clear();
                    foreach (KeyValuePair<string, string> listOfRecord in SHMEM.GetListOfRecords())
                    {

                        richTextBox1.AppendText(listOfRecord.Key + " : " + listOfRecord.Value + Environment.NewLine);

                    }

                    richTextBox1.AppendText("-----------------------------------------------------" + Environment.NewLine);
                    richTextBox1.AppendText("SENSORS :" + Environment.NewLine);
                    richTextBox1.AppendText("-----------------------------------------------------" + Environment.NewLine);

                    foreach (GPUZ_SHMEM.GPUZ_SENSOR_RECORD Sensor in SHMEM.GetListOfSensors())
                    {
                        richTextBox1.AppendText("Name :" + Sensor.name + "; Unit : " + Sensor.unit + "; Value : " + Sensor.value + "; Digits : " + Sensor.digits + Environment.NewLine);
                    }
                }
            }
        }

        showLog("Click Start btn Nicehash : ", LogType.generalLog);

        AutoItX3 automation = new AutoItX3();
        // TODO : rechercher automatiquement le nom de la fenêtre sur base su string "NiceHash Miner Legacy" seulement
        automation.WinActivate("NiceHash Miner Legacy v1.8.2.0-Pre2");
        //automation.MouseMove(92, 498, 10);
        //automation.MouseClick("LEFT", 92, 498, 2, 10);
        //automation.ControlFocus("NiceHash Miner Legacy v1.8.2.0-Pre2", "", "");
        automation.ControlClick("NiceHash Miner Legacy v1.8.2.0-Pre2", "", "[CLASS:WindowsForms10.BUTTON.app.0.1408c35_r6_ad1; INSTANCE:6]", "left", 1, 42, 11);
            
    if (richTextBox1.InvokeRequired) { richTextBox1.BeginInvoke(new DataReceivedEventHandler(SortOutputHandler), new[] { sendingProcess, outLine }); }
    else {
        sortOutput.Append(Environment.NewLine + "[" + numOutputLines.ToString() + "] - " + outLine.Data);
        richTextBox1.AppendText(sortOutput.ToString());
    }
*/

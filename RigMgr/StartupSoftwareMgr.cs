using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace MiningManager
{
    class StartupSoftwareMgr
    {
        private string m_ExeName;
        private string m_path;
        private string m_parameters;
        private Boolean m_isRunning;
        private System.Timers.Timer m_timer;
        private const int timerRefreckTick = 5000;
        private const int maxTicBeforeAutoStart = 6;
        private int tickCount;
        private Process m_Process;


        public StartupSoftwareMgr(string aExeName, string aPath)
        {
            try
            {
                this.ExeName = aExeName;
                this.Path = aPath;
                this.m_isRunning = false;
                tickCount = 0;
                m_timer = new System.Timers.Timer(timerRefreckTick);
                m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);
                m_timer.AutoReset = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error StartupSoftwareMgr.StartupSoftwareMgr : " + ex.Message);
            }
        }

        public void startTimer()
        {
            try
            {
                m_timer.Start();
            }
            catch (Exception ex)
            {
                throw new Exception("Error StartupSoftwareMgr.m_timer_Elapsed : " + ex.Message);
            }
        }

        private void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (tickCount > maxTicBeforeAutoStart)
                {
                    m_timer.Stop();
                    tickCount = 0;
                    // autoStart Soft
                    StartSoftware();   
                }
                else
                {
                    if(IsRunning())
                    {
                        m_isRunning = true;
                        stopTimer();
                    }
                }
                tickCount++;
            }
            catch(Exception ex)
            {
                throw new Exception("Error StartupSoftwareMgr.m_timer_Elapsed : " + ex.Message);
            }
        }

        private void stopTimer()
        {
            try
            {
                if (m_timer != null)
                {
                    m_timer.Stop();
                    m_timer.Close();
                    m_timer.Elapsed -= new System.Timers.ElapsedEventHandler(m_timer_Elapsed);
                    m_timer = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error StartupSoftwareMgr.clearTimer : " + ex.Message);
            }
        }

        public void StartSoftware()
        {
            if(m_ExeName == "")
            {
                throw new Exception("Error StartupSoftwareMgr.StartSoftware : no exe name");
            }

            if (m_path == "")
            {
                throw new Exception("Error StartupSoftwareMgr.StartSoftware : no exe path");
            }

            try
            {
                using (Process exeProcess = Process.Start(m_path, m_parameters))
                {
                    Thread.Sleep(1500);

                    foreach (Process process in Process.GetProcesses())
                    {
                        if (process.ProcessName.Contains(m_ExeName))
                        {
                            m_isRunning = true;
                        }
                    }

                    if(!m_isRunning)
                    {
                        throw new Exception("Unable to start : " + m_ExeName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error StartupSoftwareMgr.StartSoftware : " + ex.Message);
            }
        }

        public Boolean IsRunning()
        {
            try
            {
                Boolean toReturn = false;

                foreach (Process process in Process.GetProcesses())
                {
                    if (process.ProcessName.Contains(m_ExeName))
                    {
                        toReturn = true;
                    }
                }
                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("Error StartupSoftwareMgr.IsRunninf() : " + ex.Message);
            }
        }

        public string ExeName
        {
            get
            {
                return m_ExeName;
            }

            set
            {
                m_ExeName = value;
            }
        }

        public string Path
        {
            get
            {
                return m_path;
            }

            set
            {
                m_path = value;
            }
        }

        public bool isRunning
        {
            get
            {
                return m_isRunning;
            }

            set
            {
                m_isRunning = value;
            }
        }

        public Process Process
        {
            get
            {
                return m_Process;
            }

            set
            {
                m_Process = value;
            }
        }

        public string Parameters
        {
            get
            {
                return m_parameters;
            }

            set
            {
                m_parameters = value;
            }
        }
    }
}

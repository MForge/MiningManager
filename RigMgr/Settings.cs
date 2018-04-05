using System;

namespace MiningManager
{
    public class Settings
    {

        private int m_TimerTick;
        private int m_WattLimit;
        private int m_PauseAfetSetProfil;

        private Boolean m_LogGeneral;
        private Boolean m_LogFixProfil;
        private Boolean m_LogWattOk;
        private Boolean m_LogDebug;
        private Boolean m_Tips;
        private Boolean m_StartOnBootRigMgr;
        private Boolean m_StartOnBootWattFix;
        private Boolean m_StartOnBootMiningSoft;

        private string m_AfterburnerPath;
        //private string m_MinerPath;
        private string m_GpuzPath;

        private MinerList m_MinerList;

        public Settings()
        {
            m_MinerList = new MinerList();
        }

        public int TimerTick
        {
            get
            {
                return m_TimerTick;
            }

            set
            {
                m_TimerTick = value;
            }
        }

        public int WattLimit
        {
            get
            {
                return m_WattLimit;
            }

            set
            {
                m_WattLimit = value;
            }
        }

        public int PauseAfetSetProfil
        {
            get
            {
                return m_PauseAfetSetProfil;
            }

            set
            {
                m_PauseAfetSetProfil = value;
            }
        }

        public bool LogGeneral
        {
            get
            {
                return m_LogGeneral;
            }

            set
            {
                m_LogGeneral = value;
            }
        }

        public bool LogFixProfil
        {
            get
            {
                return m_LogFixProfil;
            }

            set
            {
                m_LogFixProfil = value;
            }
        }

        public bool LogWattOk
        {
            get
            {
                return m_LogWattOk;
            }

            set
            {
                m_LogWattOk = value;
            }
        }

        public string AfterburnerPath
        {
            get
            {
                return m_AfterburnerPath;
            }

            set
            {
                m_AfterburnerPath = value;
            }
        }

        public bool StartOnBootRigMgr
        {
            get
            {
                return m_StartOnBootRigMgr;
            }

            set
            {
                m_StartOnBootRigMgr = value;
            }
        }

        public string GpuzPath
        {
            get
            {
                return m_GpuzPath;
            }

            set
            {
                m_GpuzPath = value;
            }
        }

        public bool StartOnBootMiningSoft
        {
            get
            {
                return m_StartOnBootMiningSoft;
            }

            set
            {
                m_StartOnBootMiningSoft = value;
            }
        }

        public bool LogDebug
        {
            get
            {
                return m_LogDebug;
            }

            set
            {
                m_LogDebug = value;
            }
        }

        public bool StartOnBootWattFix
        {
            get
            {
                return m_StartOnBootWattFix;
            }

            set
            {
                m_StartOnBootWattFix = value;
            }
        }

        public MinerList MinerList
        {
            get
            {
                return m_MinerList;
            }

            set
            {
                m_MinerList = value;
            }
        }

        public bool Tips
        {
            get
            {
                return m_Tips;
            }

            set
            {
                m_Tips = value;
            }
        }
    }
}

using System;
using System.IO;
using System.Xml.Linq;
//using Newtonsoft.Json;

namespace MiningManager
{
    class SettingsMgr
    {
        private Settings m_Settings;
        //public const string SavefileName = @"Settings.json";
        public const string fileName = @"Settings.xml";

        public SettingsMgr()
        {
            m_Settings = new Settings();

        }
        public int TimerTick
        {
            get
            {
                return m_Settings.TimerTick;
            }

            set
            {
                m_Settings.TimerTick = value;
            }
        }

        public int WattLimit
        {
            get
            {
                return m_Settings.WattLimit;
            }

            set
            {
                m_Settings.WattLimit = value;
            }
        }

        public int PauseAfetSetProfil
        {
            get
            {
                return m_Settings.PauseAfetSetProfil;
            }

            set
            {
                m_Settings.PauseAfetSetProfil = value;
            }
        }

        public Boolean LogGeneral
        {
            get
            {
                return m_Settings.LogGeneral;
            }

            set
            {
                m_Settings.LogGeneral = value;
            }
        }

        public Boolean LogFixProfil
        {
            get
            {
                return m_Settings.LogFixProfil;
            }

            set
            {
                m_Settings.LogFixProfil = value;
            }
        }

        public Boolean LogWattOk
        {
            get
            {
                return m_Settings.LogWattOk;
            }

            set
            {
                m_Settings.LogWattOk = value;
            }
        }

        public Boolean LogDebug
        {
            get
            {
                return m_Settings.LogDebug;
            }

            set
            {
                m_Settings.LogDebug = value;
            }
        }

        public Boolean Tips
        {
            get
            {
                return m_Settings.Tips;
            }

            set
            {
                m_Settings.Tips = value;
            }
        }

        public string AfterburnerPath
        {
            get
            {
                return m_Settings.AfterburnerPath;
            }

            set
            {
                m_Settings.AfterburnerPath = value;
            }
        }

        public string GpuzPath
        {
            get
            {
                return m_Settings.GpuzPath;
            }

            set
            {
                m_Settings.GpuzPath = value;
            }
        }

        public MinerList MinerList
        {
            get
            {
                return m_Settings.MinerList;
            }

            set
            {
                m_Settings.MinerList = value;
            }
        }

        public Boolean StartOnBootRigMgr
        {
            get
            {
                return m_Settings.StartOnBootRigMgr;
            }

            set
            {
                m_Settings.StartOnBootRigMgr = value;
            }
        }

        public Boolean StartOnBootMiningSoft
        {
            get
            {
                return m_Settings.StartOnBootMiningSoft;
            }

            set
            {
                m_Settings.StartOnBootMiningSoft = value;
            }
        }

        public Boolean StartOnBootWattFix
        {
            get
            {
                return m_Settings.StartOnBootWattFix;
            }

            set
            {
                m_Settings.StartOnBootWattFix = value;
            }
        }

        public Settings MySettings
        {
            get
            {
                return m_Settings;
            }

            set
            {
                m_Settings = value;
            }
        }

       /* public void saveSettings()
        {
            using (StreamWriter file = File.CreateText(SettingsMgr.SavefileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, this.m_Settings);
            }
        }

        public void loadSettings()
        {
            using (StreamReader file = File.OpenText(SettingsMgr.SavefileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                m_Settings = (Settings)serializer.Deserialize(file, typeof(Settings));
            }
        }*/

        public void loadFromXml()
        {
            try
            {
                if (File.Exists(fileName))
                {
                    XElement root = XElement.Load(fileName);

                    foreach (XElement el in root.Descendants("Settings").Nodes())
                    {

                        switch (el.Name.LocalName)
                        {
                            case "TimerTick":
                                TimerTick = Convert.ToInt32(el.Value);
                                break;
                            case "WattLimit":
                                WattLimit = Convert.ToInt32(el.Value);
                                break;
                            case "PauseAfetSetProfil":
                                PauseAfetSetProfil = Convert.ToInt32(el.Value);
                                break;
                            case "LogGeneral":
                                LogGeneral = Convert.ToBoolean(el.Value);
                                break;
                            case "LogFixProfil":
                                LogFixProfil = Convert.ToBoolean(el.Value);
                                break;
                            case "LogWattOk":
                                LogWattOk = Convert.ToBoolean(el.Value);
                                break;
                            case "LogDebug":
                                LogDebug = Convert.ToBoolean(el.Value);
                                break;
                            case "Tips":
                                Tips = Convert.ToBoolean(el.Value);
                                break;
                            case "StartOnBootRigMgr":
                                StartOnBootRigMgr = Convert.ToBoolean(el.Value);
                                break;
                            case "StartOnBootWattFix":
                                StartOnBootWattFix = Convert.ToBoolean(el.Value);
                                break;
                            case "StartOnBootMiningSoft":
                                StartOnBootMiningSoft = Convert.ToBoolean(el.Value);
                                break;
                            case "AfterburnerPath":
                                AfterburnerPath = Convert.ToString(el.Value);
                                break;
                            case "GpuzPath":
                                GpuzPath = Convert.ToString(el.Value);
                                break;
                            /*case "SelectedMiner":
                                MinerList.SelectedMinerIndex = Convert.ToInt32(el.Value);
                                break;*/
                            default:
                                break;
                        }
                    }

                    foreach (XElement el in root.Descendants("Miners").Nodes())
                    {
                        Miner aMiner = new Miner(el.Element("Name").Value, el.Element("Path").Value, Convert.ToInt32(el.Element("Order").Value), Convert.ToBoolean(el.Element("IsSelected").Value)) ;
                        MinerList.add(aMiner);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void saveToXml()
        {
            try
            {
                XElement rootNode = new XElement("Root");

                XElement settingsNode = new XElement("Settings");

                XElement configNode = new XElement("TimerTick", TimerTick);
                settingsNode.Add(configNode);

                configNode = new XElement("WattLimit", WattLimit);
                settingsNode.Add(configNode);

                configNode = new XElement("PauseAfetSetProfil", PauseAfetSetProfil);
                settingsNode.Add(configNode);

                configNode = new XElement("LogGeneral", LogGeneral);
                settingsNode.Add(configNode);

                configNode = new XElement("LogFixProfil", LogFixProfil);
                settingsNode.Add(configNode);

                configNode = new XElement("LogWattOk", LogWattOk);
                settingsNode.Add(configNode);

                configNode = new XElement("LogDebug", LogDebug);
                settingsNode.Add(configNode);

                configNode = new XElement("Tips", Tips);
                settingsNode.Add(configNode);

                configNode = new XElement("StartOnBootRigMgr", StartOnBootRigMgr);
                settingsNode.Add(configNode);

                configNode = new XElement("StartOnBootWattFix", StartOnBootWattFix);
                settingsNode.Add(configNode);

                configNode = new XElement("StartOnBootMiningSoft", StartOnBootMiningSoft);
                settingsNode.Add(configNode);

                configNode = new XElement("AfterburnerPath", AfterburnerPath);
                settingsNode.Add(configNode);

                configNode = new XElement("GpuzPath", GpuzPath);
                settingsNode.Add(configNode);

                /*configNode = new XElement("SelectedMiner", MinerList.SelectedMinerIndex);
                settingsNode.Add(configNode);*/

                rootNode.Add(settingsNode);

                configNode = new XElement("Miners");
                foreach (Miner miner in MinerList)
                {
                    XElement MinerNode = new XElement("Miner");

                    XElement MinerDateNode = new XElement("Name", miner.Name);
                    MinerNode.Add(MinerDateNode);

                    MinerDateNode = new XElement("Path", miner.Path);
                    MinerNode.Add(MinerDateNode);

                    MinerDateNode = new XElement("Order", miner.Order);
                    MinerNode.Add(MinerDateNode);

                    MinerDateNode = new XElement("IsSelected", Convert.ToString(miner.IsSelected));
                    MinerNode.Add(MinerDateNode);

                    configNode.Add(MinerNode);
                }
                rootNode.Add(configNode);

                rootNode.Save(fileName);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}

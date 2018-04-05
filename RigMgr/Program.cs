using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MiningManager
{
    static class Program
    {
        public static int appCount = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "MiningManager")
                {
                    appCount++;
                }
            }

            if (appCount <= 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new MinerManagerMain());

                /*using (NotifyIcon icon = new NotifyIcon())
                {
                    icon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
                    icon.ContextMenu = new ContextMenu(new MenuItem[] {
                        new MenuItem("Show form", (s, e) => {new MinerManagerMain().Show();}),
                        new MenuItem("Exit", (s, e) => { Application.Exit(); }),
                    });
                    icon.Visible = true;

                    Application.Run();
                    icon.Visible = false;
                }*/
            }
            else
            {
                MessageBox.Show("Miner Manager is already running", "Miner Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

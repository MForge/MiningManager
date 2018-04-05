using System;
using System.Runtime.InteropServices;
using System.Text;

namespace MiningManager
{
    class Windows
    {
        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner,
           [Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_STARTUP = 0x7;  

        public static string GetStartupPath()
        {
            StringBuilder path = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, path, CSIDL_STARTUP, false);
            return path.ToString();
        }
    }
}

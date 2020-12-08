using System;

namespace DemoApoXmlApp
{
    public static class Utils
    {
        // The installation folder of the application, includes trailing slash.
        public static string AppFolder { get { return AppDomain.CurrentDomain.BaseDirectory; } }

        // AppFolder but with forward slashes, to be used in file:///{AppFolderUrl}...
        public static string AppFolderUrl { get { return AppFolder.Replace('\\', '/'); } }

        // Timestamp to make filenames unique.
        public static string Timestamp { get { return DateTime.Now.ToString("MMddHHmmss"); } } 

    }
}

using System;
using System.IO;
using System.Windows.Forms;

namespace scalecloud_scale_agent.Settings
{
    public static class SettingsPaths
    {
        public static string SettingsFile
        {
            get
            {
                return Path.Combine(Application.StartupPath,"settings.json");
            }
        }
    }
}
using scalecloud_scale_agent.Managers;
using scalecloud_scale_agent.Settings;
using scalecloud_scale_agent.Tray;
using System;
using System.Windows.Forms;

namespace scalecloud_scale_agent
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            var settingsRepository = new JsonSettingsRepository();

            var scaleManager =new ScaleManager(settingsRepository);

            Application.Run(new TrayApplicationContext(scaleManager));
        }
    }
}
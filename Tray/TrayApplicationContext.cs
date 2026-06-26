using scalecloud_scale_agent.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace scalecloud_scale_agent.Tray
{
    public class TrayApplicationContext : ApplicationContext
    {
        private NotifyIcon _notifyIcon;
        private WebSocketHost _server;

        public TrayApplicationContext()
        {
            _server = new WebSocketHost();
            _server.Start();

            var menu = new ContextMenuStrip();

            menu.Items.Add(
                "Exit",
                null,
                (s, e) =>
                {
                    _server.Stop();
                    _notifyIcon.Visible = false;
                    Application.Exit();
                });

            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true,
                Text = "Scale Agent",
                ContextMenuStrip = menu
            };
        }
    }
}

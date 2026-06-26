using scalecloud_scale_agent.Managers;
using scalecloud_scale_agent.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace scalecloud_scale_agent.Tray
{
    public class TrayApplicationContext : ApplicationContext
    {
        private readonly NotifyIcon _notifyIcon;

        private readonly WebSocketHost _server;

        private readonly IScaleManager _scaleManager;

        public TrayApplicationContext(
            IScaleManager scaleManager)
        {
            _scaleManager = scaleManager;

            _server = new WebSocketHost();

            try
            {
                _scaleManager.LoadSettings();

                _scaleManager.Start();

                _server.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Scale Agent",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            var menu = new ContextMenuStrip();

            menu.Items.Add(
                "Exit",
                null,
                OnExit);

            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true,
                Text = "Scale Agent",
                ContextMenuStrip = menu
            };
        }

        private void OnExit(
            object sender,
            EventArgs e)
        {
            try
            {
                _server.Stop();

                _scaleManager.Stop();

                _scaleManager.Dispose();
            }
            catch
            {
            }

            _notifyIcon.Visible = false;

            Application.Exit();
        }
    }
}
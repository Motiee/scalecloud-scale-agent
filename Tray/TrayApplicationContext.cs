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

        private SettingsForm _settingsForm;

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
                Icon =Properties.Resources.RS323_32x32,
                Visible = true,
                Text = "Scale Agent",
                ContextMenuStrip = menu
            };

            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

        }

        private void OnExit(object sender,EventArgs e)
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

        private void NotifyIcon_DoubleClick(object sender,EventArgs e)
        {
            if (_settingsForm == null ||
                _settingsForm.IsDisposed)
            {
                _settingsForm =
                    new SettingsForm(_scaleManager);
            }

            _settingsForm.Show();
            _settingsForm.BringToFront();
            _settingsForm.Activate();
        }
    }
}
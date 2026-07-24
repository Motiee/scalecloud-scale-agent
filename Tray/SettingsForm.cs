using scalecloud_scale_agent.Managers;
using scalecloud_scale_agent.Model;
using scalecloud_scale_agent.Protocols;
using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace scalecloud_scale_agent.Tray
{
    public partial class SettingsForm : Form
    {
        private readonly IScaleManager _scaleManager;

        public SettingsForm(IScaleManager scaleManager)
        {
            _scaleManager = scaleManager;

            InitializeComponent();
        }

        private void SettingsForm_Load(object sender,EventArgs e)
        {
            LoadPorts();

            LoadProtocols();

            LoadSettings();
        }

        private void LoadPorts()
        {
            string[] ports =
                SerialPort.GetPortNames()
                    .OrderBy(p => p)
                    .ToArray();

            cmbPort1.Items.Clear();
            cmbPort2.Items.Clear();

            cmbPort1.Items.AddRange(ports);
            cmbPort2.Items.AddRange(ports);
        }

        private void LoadBaudRates()
        {
            object[] baudRates =
            {
        1200,
        2400,
        4800,
        9600,
        19200,
        38400,
        57600,
        115200
    };

            cmbBaudRate1.Items.Clear();
            cmbBaudRate2.Items.Clear();

            cmbBaudRate1.Items.AddRange(baudRates);
            cmbBaudRate2.Items.AddRange(baudRates);
        }

        private void LoadProtocols()
        {
            var protocols =
                ScaleProtocolRegistry.GetAll()
                    .ToList();

            cmbProtocol1.DataSource =
                protocols.ToList();

            cmbProtocol2.DataSource =
                protocols.ToList();

            cmbProtocol1.DisplayMember =
                "DisplayName";

            cmbProtocol1.ValueMember =
                "Id";

            cmbProtocol2.DisplayMember =
                "DisplayName";

            cmbProtocol2.ValueMember =
                "Id";
        }

        private void LoadSettings()
        {
            LoadChannel(
                ScaleChannelId.Bascule1,
                chkEnabled1,
                cmbPort1,
                cmbBaudRate1,
                cmbProtocol1);

            LoadChannel(
                ScaleChannelId.Bascule2,
                chkEnabled2,
                cmbPort2,
                cmbBaudRate2,
                cmbProtocol2);
        }

        private void LoadChannel(
    ScaleChannelId channelId,
    CheckBox chkEnabled,
    ComboBox cmbPort,
    ComboBox cmbBaudRate,
    ComboBox cmbProtocol)
        {
            var channel =
                _scaleManager.GetChannel(channelId);

            var settings =
                channel.Settings;

            chkEnabled.Checked =
                settings.Enabled;

            cmbPort.Text =
                settings.SerialPort.PortName;

            cmbBaudRate.Text =
                settings.SerialPort.BaudRate
                    .ToString();

            cmbProtocol.SelectedValue =
                settings.Protocol.ProtocolId;
        }
    }


}
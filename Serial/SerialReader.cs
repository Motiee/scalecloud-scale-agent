using scalecloud_scale_agent.Model;
using System;
using System.IO.Ports;

namespace scalecloud_scale_agent.Serial
{
    public class SerialReader : ISerialReader
    {
        private SerialPort _serialPort;

        public bool IsRunning
        {
            get
            {
                return _serialPort != null &&
                       _serialPort.IsOpen;
            }
        }

        public event Action<byte> ByteReceived;

        public event Action<Exception> Error;

        public void Start(SerialPortSettings settings)
        {
            Stop();

            try
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = settings.PortName;

                _serialPort.BaudRate = settings.BaudRate;

                _serialPort.Parity = settings.Parity;

                _serialPort.DataBits = settings.DataBits;

                _serialPort.StopBits = settings.StopBits;

                _serialPort.DtrEnable = settings.DtrEnable;

                _serialPort.RtsEnable = settings.RtsEnable;

                _serialPort.ReadTimeout = settings.ReadTimeout;

                _serialPort.DataReceived += OnDataReceived;
                
                _serialPort.Open();

            }
            catch (Exception ex)
            {
                Stop();

                Error?.Invoke(ex);
            }
        }

        public void Stop()
        {
            try
            {
                if (_serialPort != null)
                {
                    _serialPort.DataReceived -= OnDataReceived;

                    if (_serialPort.IsOpen)
                    {
                        _serialPort.Close();
                    }

                    _serialPort.Dispose();

                    _serialPort = null;
                }
            }
            catch
            {
            }
        }

        public void Dispose()
        {
            Stop();
        }

        private void OnDataReceived(object sender,SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort port = _serialPort;
                if (port == null) return;
                while (port != null &&
                       port.IsOpen &&
                       port.BytesToRead > 0)
                {
                    int value = port.ReadByte();

                    if (value >= 0)
                    {
                        ByteReceived?.Invoke((byte)value);
                    }
                }
            }
            catch (Exception ex)
            {
                Error?.Invoke(ex);
            }
        }
    }
}
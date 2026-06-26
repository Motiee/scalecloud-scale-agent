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

        public void Start(
         string portName,
         int baudRate,
         Parity parity,
         int dataBits,
         StopBits stopBits)
        {
            Stop();

            try
            {
                _serialPort = new SerialPort();

                _serialPort.PortName = portName;
                _serialPort.BaudRate = baudRate;
                _serialPort.Parity = parity;
                _serialPort.DataBits = dataBits;
                _serialPort.StopBits = stopBits;

                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;

                _serialPort.Open();
                _serialPort.DataReceived += OnDataReceived;
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
                _serialPort.DataReceived -= OnDataReceived;

                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
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

        private void OnDataReceived(
    object sender,
    SerialDataReceivedEventArgs e)
        {
            try
            {
                while (_serialPort != null &&
                       _serialPort.IsOpen &&
                       _serialPort.BytesToRead > 0)
                {
                    int value = _serialPort.ReadByte();

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
using Newtonsoft.Json.Linq;
using scalecloud_scale_agent.Protocols.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Protocols.FrameDetectors
{
    public class FrameDetector : IFrameDetector
    {
        private readonly List<byte> _buffer = new List<byte>();
        private byte[] _delimiter = { 13 };
        public FrameDetector(byte[] delimiter)
        {
            _delimiter = delimiter;
        }


        public bool Push(byte value, out byte[] frame)
        {
            frame = null;
            
            if (isDelimeter(value))
            {
                if (_buffer.Count == 0)
                {
                    frame = null;
                    return false;
                }

                frame = _buffer.ToArray();

                _buffer.Clear();

                return true;
            }

            _buffer.Add(value);

            return false;
        }

        public void Reset()
        {
            _buffer.Clear();
        }

        private bool isDelimeter(byte value)
        {
            for (int i = 0; i <= _delimiter.Length -1; i++)
            {
                if (value == _delimiter[i]) return true;
            }
            return false;
        }
   

    }
}

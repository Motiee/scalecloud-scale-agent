using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scalecloud_scale_agent.Model
{
    public  class ScaleData
    {
        public  decimal? Weight { get; set; }

        public  bool Stable { get; set; }

        public  DateTime Time { get; set; }

        public  string RawFrame { get; set; }     // برای Debug

        public string Unit { get; set; }     

        public  byte[] RawBytes { get; set; }     // برای ذخیره لاگ

        public  bool IsValid { get; set; }        // نتیجه Parse

        public  string Error { get; set; }        // علت خطا
    }
}

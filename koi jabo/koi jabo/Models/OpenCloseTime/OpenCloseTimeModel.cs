using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Models.OpenCloseTime
{
    public class OpenCloseTimeModel
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DayOfWeek Day { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }    
}

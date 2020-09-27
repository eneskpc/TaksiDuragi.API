using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaksiDuragi.API.Dtos
{
    public class CallerInfo
    {
        public int CallId { get; set; }
        public string DeviceSerialNumber { get; set; }
        public string LineNumber { get; set; }
        public string CallerNumber { get; set; }
        public string CallerNameSurname { get; set; }
        public string CallerAddress { get; set; }
        public DateTime CallDateTime { get; set; }
    }
}

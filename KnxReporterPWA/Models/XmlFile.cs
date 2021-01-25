using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnxReporterPWA.Models
{

    public partial class XmlFile
    {
        public string FileName { get; set; }
        public string Xmldata { get; set; }
        public int? IsProcessed { get; set; }
        public int? ProcessingPercentage { get; set; }
        public int? TelegramsCount { get; set; }
        public int? CancellationToken { get; set; }
    }

}

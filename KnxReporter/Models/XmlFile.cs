using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnxReporter.Models
{
    public class XmlFile
    {
        public partial class Xmlfile
        {
            public int Fid { get; set; }
            public string FileName { get; set; }
            public string Xmldata { get; set; }
            public int? IsProcessed { get; set; }
            public int? ProcessingPercentage { get; set; }
            public int? TelegramsCount { get; set; }
            public int? CancellationToken { get; set; }
        }
    }
}

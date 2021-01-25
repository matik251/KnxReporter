using System;

namespace KnxReporterPWA.Models
{
    public class Telegram
    {
        public long TID { get; set; }

        public string TimestampS { get; set; }
        public DateTime Timestamp { get; set; }

        public string Service { get; set; }
        public string FrameFormat { get; set; }

        public string RawData { get; set; }
        public int RawDataLength { get; set; }
    }

    public enum KnxServices
    {
        L_Busmon_ind
    }

    public class KnxDecoderWorkers
    {
        public int Id { get; set; }
        public int IsBusy { get; set; }
    }
}


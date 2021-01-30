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

    public class Xmlfile
    {
        public int Fid { get; set; }
        public string FileName { get; set; }
        public string Xmldata { get; set; }
        public int? IsProcessed { get; set; }
        public int? ProcessingPercentage { get; set; }
        public int? TelegramsCount { get; set; }
        public int? CancellationToken { get; set; }
    }

    public class KnxProcess
    {
        public long Pid { get; set; }
        public string ProcessName { get; set; }
        public string ProcessIp { get; set; }
        public string ProcessType { get; set; }
        public string ProcessedFile { get; set; }
        public int? ActualTelegramNr { get; set; }
        public int? TotalTelegramNr { get; set; }
    }

    public class DecodedTelegram
    {
        public long Tid { get; set; }
        public string TimestampS { get; set; }
        public DateTime Timestamp { get; set; }
        public string Service { get; set; }
        public string FrameFormat { get; set; }
        public string SourceAddress { get; set; }
        public string GroupAddress { get; set; }
        public string DeviceName { get; set; }
        public string Data { get; set; }
        public double? DataFloat { get; set; }
        public string SerializedData { get; set; }
    }
}


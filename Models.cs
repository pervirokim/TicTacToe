using System;

namespace tic_tac_toe
{
    public class InfoModel
    {
        public string Version { get; set; }
        public string CreatedBy { get; set; }
        public string LastUpdated { get; set; }
        public string ContactInfo { get; set; }
    }
    public class ProgressModel
    {
        public int Loses { get; set; }
        public int Wins { get; set; }
    }
}

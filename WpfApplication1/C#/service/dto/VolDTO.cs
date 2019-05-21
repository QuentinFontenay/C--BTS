using System;

namespace WpfApplication1.service.dto
{
    public class VolDTO
    {
        public int IdVol { get; set; }
        
        public DateTime DateA { get; set; }
        
        public DateTime DateD { get; set; }
        
        public string   AeroportA_Reel { get; set; }

        public string AeroportD_Reel { get; set; }

        public string AeroportA_Theo { get; set; }

        public bool Status { get; set; }
        
        public DateTime DateATheo { get; set; }

        public DateTime DateDTheo { get; set; }

        public int IdAvion { get; set; }
        
        public int IdTrajet { get; set; }
    }
}
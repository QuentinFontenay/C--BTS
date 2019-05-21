using System;
using System.Collections.Generic;

namespace WpfApplication1.repository.dao
{
    public class TrajetDAO
    {
        public int IdTrajet { get; set; }
        
        public string Duree { get; set; }
        
        public int IdVoyage { get; set; }
        
        public string AeroportDepart { get; set; }
        public int Kilometre { get; set; }
        
        public string AeroportArrive { get; set; }
    }
}
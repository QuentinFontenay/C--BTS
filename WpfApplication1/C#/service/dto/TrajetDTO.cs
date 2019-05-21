using System;

namespace WpfApplication1.service.dto
{
  public class TrajetDTO
  {
    public int IdTrajet { get; set; }
        
    public string Duree { get; set; }
        
    public int IdVoyage { get; set; }
        
    public string AeroportDepart { get; set; }
    public int Kilometre { get; set; }
        
    public string AeroportArrive { get; set; }
  }
}
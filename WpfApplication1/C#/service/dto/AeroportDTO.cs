using System.Collections.Generic;

namespace WpfApplication1.service.dto
{
    public class AeroportDTO
    {
        public string IdAeroport { get; set;}

        public string Ville { get; set;}

        public string Pays { get; set;}

        public List<AvionDTO> AvionDTOs;
    }
}
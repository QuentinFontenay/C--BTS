using System.Collections.Generic;
using WpfApplication1.service;
using WpfApplication1.service.dto;

namespace WpfApplication1.controller
{
    public class AeroportController
    {
        //if the list is empty you make select all
        
        public List<AeroportDTO> GetAeroportDTOs(List<int> ids)
        {
            AeroportService aeroportService = new AeroportService();

            return aeroportService.GetAeroportDTOs();
        }
        public List<AeroportDTO> GetAeroportDTOs()
        {
            AeroportService aeroportService = new AeroportService();
            return aeroportService.GetAeroportDTOs();
        }

        public void RemoveAeroport(List<AeroportDTO> aeroportDTO)
        {
            AeroportService aeroportService = new AeroportService();
            aeroportService.RemoveAeroport(aeroportDTO);
        }

        public void AddAeroport(List<AeroportDTO> aeroportDTOs)
        {
            AeroportService aeroportService = new AeroportService();
            aeroportService.AddAeroport(aeroportDTOs);
        }

        public List<AeroportDTO> UpdateAeroport(string id, string column, int value)
        {
            AeroportService aeroportService = new AeroportService();
            return aeroportService.UpdateAeroport(id, column, value);
        }
    }
}
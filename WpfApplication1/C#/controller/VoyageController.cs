using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.C_.service;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.controller
{
   public class VoyageController
    {
        private VoyageService voyageService = new VoyageService();
        public List<VoyageDTO> GetVoyageDTOs()
        {
            return voyageService.GetVoyageDTOs();
        }

        public void RemoveVoyage(List<VoyageDTO> voyageDTOs)
        {
            voyageService.RemoveVoyage(voyageDTOs);
        }

        public void AddVoyage(List<VoyageDTO> voyageDTOs)
        {
            voyageService.AddVoyage(voyageDTOs);
        }

        public List<VoyageDTO> UpdateVoyage(int id, string column, string value)
        {
            return voyageService.UpdateVoyage(id, column, value);
        }
    }
}

using System.Collections.Generic;
using WpfApplication1.service;
using WpfApplication1.service.dto;

namespace WpfApplication1.controller
{
    public class TrajetController
    {
        private TrajetService trajetService = new TrajetService();

      //  public List<TrajetDTO> GetTrajetDTOs(List<int> ids)
        //{
          //  return trajetService.GetTrajetDTOs(ids);
       // }
        public List<TrajetDTO> GetTrajetDTOs()
        {
            return trajetService.GetTrajetDTOs();
        }

        public void RemoveTrajet(List<TrajetDTO> trajetDTOs)
        {
            trajetService.RemoveTrajet(trajetDTOs);
        }

        public void AddTrajet(List<TrajetDTO> trajetDTOs)
        {
            trajetService.AddTrajet(trajetDTOs);
        }

        public List<TrajetDTO> UpdateTrajet(int id, string column, dynamic value)
        {
            return trajetService.UpdateTrajet(id, column, value);
        }
    }
}
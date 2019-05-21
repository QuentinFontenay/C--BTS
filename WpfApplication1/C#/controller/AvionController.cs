using System;
using System.Collections.Generic;
using System.Windows.Documents;
using WpfApplication1.service;
using WpfApplication1.service.dto;

namespace WpfApplication1.controller
{
    public class AvionController
    {
        private AvionService avionService = new AvionService();
        
        //if the list is empty you make select all
        
        public List<AvionDTO> GetAvionDTOs(List<int> ids)
        {
            return avionService.GetAvionDTOs();
        }
        
        public List<AvionDTO> GetAvionDTOs()
        {
            return avionService.GetAvionDTOs();
        }

        public void RemoveAvion(List<AvionDTO> avionDTO)
        {
            avionService.RemoveAvion(avionDTO);
        }

        public void AddAvion(List<AvionDTO> avionDTOs)
        {
            avionService.AddAvion(avionDTOs);
        }

        public List<AvionDTO> UpdateAvion(int id, string column, int value)
        {
            return avionService.UpdateAvion(id, column, value);
        }
    }
}
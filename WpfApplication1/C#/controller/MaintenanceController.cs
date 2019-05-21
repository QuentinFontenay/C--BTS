using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.service;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.controller
{
    public class MaintenanceController
    {
        private MaintenanceService maintenanceService = new MaintenanceService();

        //if the list is empty you make select all
        public List<MaintenanceDTO> GetMaintenanceDTOs()
        {
            return maintenanceService.GetMaintenanceDTOs();
        }

        public void RemoveMaintenance(List<MaintenanceDTO> maintenanceDTO)
        {
            maintenanceService.RemoveMaintenance(maintenanceDTO);
        }

        public void AddMaintenance(List<MaintenanceDTO> maintenanceDTOs)
        {
            maintenanceService.AddMaintenance(maintenanceDTOs);
        }

        public List<MaintenanceDTO> UpdateMaintenance(int id, string column, dynamic value)
        {
            return maintenanceService.UpdateMaintenance(id, column, value);
        }
    }
}

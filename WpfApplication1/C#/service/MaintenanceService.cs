using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.MaintenanceRepository;
using WpfApplication1.C_.service.converter;
using WpfApplication1.C_.service.dto;
using WpfApplication1.repository;

namespace WpfApplication1.C_.service
{
   public class MaintenanceService
    {
        private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();

        private Abstract_MaintenanceRepository _maintenanceRepository;

        public MaintenanceService()
        {
            Console.Write(adapter);

            switch (adapter)
            {
                case "MySQL":
                    this._maintenanceRepository = new MySQL_MaintenanceRepository();
                    break;
                case "Oracle":
                    this._maintenanceRepository = new Oracle_MaintenanceRepository();
                    break;
                case "SQLserver":
                    this._maintenanceRepository = new SQLserver_MaintenanceRepository();
                    break;
            }
        }

        //overcharge GetAvionDTO with and without id, without you select all in bdd

        public List<MaintenanceDTO> GetMaintenanceDTOs()
        {
            MaintenanceConverter maintenanceConverter = new MaintenanceConverter();
            return maintenanceConverter.GetMaintenanceDTOs(this._maintenanceRepository.GetMaintenanceDAOsInternal());
        }

        public List<MaintenanceDTO> GetMaintenanceDTOs(List<int> ids)
        {
            MaintenanceConverter maintenanceConverter = new MaintenanceConverter();
            return maintenanceConverter.GetMaintenanceDTOs(this._maintenanceRepository.GetMaintenanceDAOs(ids));
        }

        public void RemoveMaintenance(List<MaintenanceDTO> maintenanceDTOs)
        {
            MaintenanceConverter maintenanceConverter = new MaintenanceConverter();
            this._maintenanceRepository.RemoveMaintenance(maintenanceConverter.RemoveMaintenance(maintenanceDTOs));
        }

        public void RemoveTotalMaintenance()
        {
            this._maintenanceRepository.RemoveMaintenanceInternal();
        }

        public void AddMaintenance(List<MaintenanceDTO> maintenanceDTOs)
        {
            MaintenanceConverter maintenanceConverter = new MaintenanceConverter();
            this._maintenanceRepository.AddMaintenance(maintenanceConverter.AddMaintenance(maintenanceDTOs));
        }

        public List<MaintenanceDTO> UpdateMaintenance(int id, string column, dynamic value)
        {
            MaintenanceConverter maintenanceConverter = new MaintenanceConverter();

            return maintenanceConverter.GetMaintenanceDTOs(this._maintenanceRepository.UpdateMaintenance(id, column, value));
        }
    }
}

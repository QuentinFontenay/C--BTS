using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.service.converter
{
    public class MaintenanceConverter
    {
        public List<MaintenanceDTO> GetMaintenanceDTOs(List<MaintenanceDAO> MaintenanceDAOs)
        {
            List<MaintenanceDTO> MaintenanceDTOs = new List<MaintenanceDTO>();

            foreach (var maintenanceDAO in MaintenanceDAOs)
            {
                MaintenanceDTO maintenanceDTO = new MaintenanceDTO();

                maintenanceDTO.IdAvion = maintenanceDAO.IdAvion;
                maintenanceDTO.IdMaintenance = maintenanceDAO.IdMaintenance;
                maintenanceDTO.SuiviAppareil = maintenanceDAO.SuiviAppareil;
                maintenanceDTO.DateDebut = maintenanceDAO.DateDebut;
                maintenanceDTO.DateFin = maintenanceDAO.DateFin;

                MaintenanceDTOs.Add(maintenanceDTO);
            }

            return MaintenanceDTOs;
        }

        public List<int> RemoveMaintenance(List<MaintenanceDTO> maintenanceDTOs)
        {
            List<int> ids = new List<int>();

            foreach (var maintenanceDTO in maintenanceDTOs)
            {
                ids.Add(maintenanceDTO.IdMaintenance);
            }

            return ids;
        }

        public List<MaintenanceDAO> AddMaintenance(List<MaintenanceDTO> maintenanceDTOs)
        {
            List<MaintenanceDAO> maintenanceDAOs = new List<MaintenanceDAO>();

            foreach (var maintenanceDTO in maintenanceDTOs)
            {
                MaintenanceDAO maintenanceDAO = new MaintenanceDAO();

                maintenanceDAO.IdAvion = maintenanceDTO.IdAvion;
                maintenanceDAO.IdMaintenance = maintenanceDTO.IdMaintenance;
                maintenanceDAO.SuiviAppareil = maintenanceDTO.SuiviAppareil;
                maintenanceDAO.DateDebut = maintenanceDTO.DateDebut;
                maintenanceDAO.DateFin = maintenanceDTO.DateFin;

                maintenanceDAOs.Add(maintenanceDAO);
            }

            return maintenanceDAOs;
        }
    }
}

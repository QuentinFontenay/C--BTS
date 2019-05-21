using System;
using System.Collections.Generic;
using WpfApplication1.repository;
using WpfApplication1.repository.dao;
using WpfApplication1.service.converter;
using WpfApplication1.service.dto;
using static System.Configuration.ConfigurationManager;

namespace WpfApplication1.service
{
    public class AvionService
    {
        private string adapter = AppSettings["dbtype"];

        private Abstract_AvionRepository _avionRepository;
        
        public AvionService()
        {
            Console.Write(adapter);
            
            switch (adapter)
            {
                case "MySQL":
                    this._avionRepository = new MySQL_AvionRepository();
                    break;
                case "Oracle":
                    this._avionRepository = new Oracle_AvionRepository();
                    break;
                case "SQLserver":
                    this._avionRepository = new SQLserver_AvionRepository();
                    break;
            }   
        }
        
        //overcharge GetAvionDTO with and without id, without you select all in bdd
        
        public List<AvionDTO> GetAvionDTOs()
        {
            AvionConverter avionConverter = new AvionConverter();
            return avionConverter.GetAvionDTOs(this._avionRepository.GetAvionDAOsInternal());
        }
        
        public List<AvionDTO> GetAvionDTOs(List<int> ids)
        {
            AvionConverter avionConverter = new AvionConverter();
            return avionConverter.GetAvionDTOs(this._avionRepository.GetAvionDAOs(ids));
        }

        public void RemoveAvion(List<AvionDTO> avionDTOs)
        {
            AvionConverter avionConverter = new AvionConverter();
            this._avionRepository.RemoveAvion(avionConverter.RemoveAvion(avionDTOs));
        }

        public void RemoveTotalAvion()
        {
            this._avionRepository.RemoveAvionInternal();
        }

        public void AddAvion(List<AvionDTO> avionDTOs)
        {
            AvionConverter avionConverter = new AvionConverter();
            this._avionRepository.AddAvion(avionConverter.AddAvion(avionDTOs));
        }

        public List<AvionDTO> UpdateAvion(int id, string column, int value)
        {
            AvionConverter avionConverter = new AvionConverter();
            
            return avionConverter.GetAvionDTOs(this._avionRepository.UpdateAvion(id, column, value));
        }
    }
}
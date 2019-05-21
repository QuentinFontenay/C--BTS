using System.Collections.Generic;
using System.Configuration;
using WpfApplication1.repository;
using WpfApplication1.repository.AeroportRepository;
using WpfApplication1.repository.dao;
using WpfApplication1.service.converter;
using WpfApplication1.service.dto;

namespace WpfApplication1.service
{
    public class AeroportService
    {
        private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();

        private Abstract_AeroportRepository _aeroportRepository;

        public AeroportService()
        {
            switch (adapter)
            {
                case "MySQL":
                    this._aeroportRepository = new MySQL_AeroportRepository();
                    break;
                case "Oracle":
                    this._aeroportRepository = new Oracle_AeroportRepository();
                    break;
                case "SQLserver":
                    this._aeroportRepository = new SQLserver_AeroportRepository();
                    break;
            }
        }

        //overcharge GetAvionDTO with and without id, without you select all in bdd

        public List<AeroportDTO> GetAeroportDTOs()
        {
            AeroportConverter aeroportConverter = new AeroportConverter();
            return aeroportConverter.GetAeroportDTOs(this._aeroportRepository.GetAeroportDAOsInternal());
        }

        public List<AeroportDTO> GetAeroportDTOs(List<string> ids)
        {
            AeroportConverter aeroportConverter = new AeroportConverter();
            return aeroportConverter.GetAeroportDTOs(this._aeroportRepository.GetAeroportDAOs(ids));
        }

        public void RemoveAeroport(List<AeroportDTO> aeroportDTOs)
        {
            AeroportConverter aeroportConverter = new AeroportConverter();
            this._aeroportRepository.RemoveAeroport(aeroportConverter.RemoveAeroport(aeroportDTOs));
        }

        public void RemoveTotalAeroport()
        {
            this._aeroportRepository.RemoveAeroportInternal();
        }

        public void AddAeroport(List<AeroportDTO> aeroportDTOs)
        {
            AeroportConverter aeroportConverter = new AeroportConverter();
            this._aeroportRepository.AddAeroport(aeroportConverter.AddAeroport(aeroportDTOs));
        }

        public List<AeroportDTO> UpdateAeroport(string id, string column, int value)
        {
            AeroportConverter avionConverter = new AeroportConverter();

            return avionConverter.GetAeroportDTOs(this._aeroportRepository.UpdateAeroport(id, column, value));
        }

    }
}
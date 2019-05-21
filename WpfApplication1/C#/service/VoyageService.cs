using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.VoyageRepository;
using WpfApplication1.C_.service.converter;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.service
{
    public class VoyageService
    {
        private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();

        private VoyageConverter voyageConverter = new VoyageConverter();

        private Abstract_VoyageRepository _voyageRepository;

        public VoyageService()
        {
            switch (adapter)
            {
                case "MySQL":
                    this._voyageRepository = new MySQL_VoyageRepository();
                    break;
                case "Oracle":
                    this._voyageRepository = new Oracle_VoyageRepository();
                    break;
                case "SQLserver":
                    this._voyageRepository = new SQLserver_VoyageRepostiory();
                    break;
            }
        }

        //overcharge GetAvionDTO with and without id, without you select all in bdd

        public List<VoyageDTO> GetVoyageDTOs()
        {
            return voyageConverter.GetVoyageDTOs(this._voyageRepository.GetVoyageDAOsInternal());
        }

        // public List<TrajetDTO> GetTrajetDTOs(List<int> ids)
        //{
        //return trajetConverter.GetTrajetDTOs(this._trajetRepository.GetTrajetDAOs(ids));
        //}

        public void RemoveVoyage(List<VoyageDTO> voyageDTOs)
        {
            this._voyageRepository.RemoveVoyage(voyageConverter.RemoveVoyage(voyageDTOs));
        }

        public void RemoveTotalVoyage()
        {
            this._voyageRepository.RemoveVoyageInternal();
        }

        public void AddVoyage(List<VoyageDTO> voyageDTOs)
        {
            this._voyageRepository.AddVoyage(voyageConverter.AddVoyage(voyageDTOs));
        }

        public List<VoyageDTO> UpdateVoyage(int id, string column, string value)
        {
            return voyageConverter.GetVoyageDTOs(this._voyageRepository.UpdateVoyage(id, column, value));
        }
    }
}

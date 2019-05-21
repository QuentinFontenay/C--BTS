using System.Collections.Generic;
using System.Configuration;
using WpfApplication1.repository.TrajetRepository;
using WpfApplication1.service.converter;
using WpfApplication1.service.dto;

namespace WpfApplication1.service
{
    public class TrajetService
    {
         private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();
        
        private TrajetConverter trajetConverter = new TrajetConverter();

        private Abstract_TrajetRepository _trajetRepository;
        
        public TrajetService()
        {
            switch (adapter)
            {
                case "MySQL":
                    this._trajetRepository = new MySQL_TrajetRepository();
                    break;
                case "Oracle":
                    this._trajetRepository = new Oracle_TrajetRepository();
                    break;
                case "SQLserver":
                    this._trajetRepository = new SQLserver_TrajetRepository();
                    break;
            }
        }
        
        //overcharge GetAvionDTO with and without id, without you select all in bdd
        
        public List<TrajetDTO> GetTrajetDTOs()
        {
            return trajetConverter.GetTrajetDTOs(this._trajetRepository.GetTrajetDAOsInternal());
        }
        
       // public List<TrajetDTO> GetTrajetDTOs(List<int> ids)
        //{
         //return trajetConverter.GetTrajetDTOs(this._trajetRepository.GetTrajetDAOs(ids));
        //}

        public void RemoveTrajet(List<TrajetDTO> trajetDTOs)
        {
           this._trajetRepository.RemoveTrajet(trajetConverter.RemoveTrajet(trajetDTOs));
        }

        public void RemoveTotalTrajet()
        {
            this._trajetRepository.RemoveTrajetInternal();
        }

        public void AddTrajet(List<TrajetDTO> trajetDTOs)
        {
         this._trajetRepository.AddTrajet(trajetConverter.AddTrajet(trajetDTOs));
        }

        public List<TrajetDTO> UpdateTrajet(int id, string column, dynamic value)
        {   
            return trajetConverter.GetTrajetDTOs(this._trajetRepository.UpdateTrajet(id, column, value));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.ModeleRepository;
using WpfApplication1.C_.service.converter;
using WpfApplication1.C_.service.dto;
using WpfApplication1.repository;

namespace WpfApplication1.C_.service
{
    class ModeleService
    {
        private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();

        private readonly Abstract_ModeleRepository _modeleRepository;

        public ModeleService()
        {
            switch (adapter)
            {
                case "MySQL":
                    this._modeleRepository = new MySQL_ModeleRepository();
                    break;
                case "Oracle":
                    this._modeleRepository = new Oracle_ModeleRepository();
                    break;
                case "SQLserver":
                    this._modeleRepository = new SQLserver_ModeleRepository();
                    break;
            }
        }
        public List<ModeleDTO> GetModeleDTOs()
        {
            ModeleConverter modeleConverter = new ModeleConverter();
            return modeleConverter.GetModeleDTOs(this._modeleRepository.GetModeleDAOsInternal());
        }
        public IEnumerable<string> GetNomModele()
        {
            ModeleConverter modeleConverter = new ModeleConverter();

            return this._modeleRepository.GetNomModele();
        }

        public List<ModeleDTO> GetModeleDTOs(List<int> ids)
        {
            ModeleConverter modeleConverter = new ModeleConverter();
            return modeleConverter.GetModeleDTOs(this._modeleRepository.GetModeleDAOs(ids));
        }

        public void RemoveModele(List<ModeleDTO> modeleDTOs)
        {
            ModeleConverter modeleConverter = new ModeleConverter();
            this._modeleRepository.RemoveModele(modeleConverter.RemoveModele(modeleDTOs));
        }

        public void RemoveTotalModele()
        {
            this._modeleRepository.RemoveModeleInternal();
        }

        public void AddModele(List<ModeleDTO> modeleDTOs)
        {
            ModeleConverter modeleConverter = new ModeleConverter();
            this._modeleRepository.AddModele(modeleConverter.AddModele(modeleDTOs));
        }

        public List<ModeleDTO> UpdateModele(int id, string column, int value)
        {
            ModeleConverter modeleConverter = new ModeleConverter();

            return modeleConverter.GetModeleDTOs(this._modeleRepository.UpdateModele(id, column, value));
        }

    }
}


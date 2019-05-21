using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.MotorisationRepository;
using WpfApplication1.C_.service.converter;
using WpfApplication1.C_.service.dto;
using WpfApplication1.repository;

namespace WpfApplication1.C_.service
{
    class MotorisationService
    {
        private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();

        private readonly Abstract_MotorisationRepository _motorisationRepository;

        public MotorisationService()
        {
            switch (adapter)
            {
                case "MySQL":
                    this._motorisationRepository = new MySQL_MotorisationRepository();
                    break;
                case "Oracle":
                    this._motorisationRepository = new Oracle_MotorisationRepository();
                    break;
                case "SQLserver":
                    this._motorisationRepository = new SQLserver_MotorisationRepository();
                    break;
            }
        }
        public List<MotorisationDTO> GetMotorisationDTOs()
        {
            MotorisationConverter motorisationConverter = new MotorisationConverter();
            return motorisationConverter.GetMotorisationDTOs(this._motorisationRepository.GetMotorisationDAOsInternal());
        }

        public List<MotorisationDTO> GetMotorisationDTOs(List<int> ids)
        {
            MotorisationConverter motorisationConverter = new MotorisationConverter();
            return motorisationConverter.GetMotorisationDTOs(this._motorisationRepository.GetMotorisationDAOs(ids));
        }

        public void RemoveMotorisation(List<MotorisationDTO> motorisationDTOs)
        {
            MotorisationConverter motorisationConverter = new MotorisationConverter();
            this._motorisationRepository.RemoveMotorisation(motorisationConverter.RemoveMotorisation(motorisationDTOs));
        }

        public void RemoveTotalMotorisation()
        {
            this._motorisationRepository.RemoveMotorisationInternal();
        }

        public void AddMotorisation(List<MotorisationDTO> motorisationDTOs)
        {
            MotorisationConverter motorisationConverter = new MotorisationConverter();
            this._motorisationRepository.AddMotorisation(motorisationConverter.AddMotorisation(motorisationDTOs));
        }

        public List<MotorisationDTO> UpdateMotorisation(int id, string column, int value)

        {
            MotorisationConverter motorisationConverter = new MotorisationConverter();

            return motorisationConverter.GetMotorisationDTOs(this._motorisationRepository.UpdateMotorisation(id, column, value));
        }
    }
}

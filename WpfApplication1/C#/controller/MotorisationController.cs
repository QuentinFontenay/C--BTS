using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.service;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.controller
{
    class MotorisationController
    {
        public List<MotorisationDTO> getMotorisationDTOs()
        {
            MotorisationService motorisationservice = new MotorisationService();

            return motorisationservice.GetMotorisationDTOs();
        }

        public void RemoveMotorisation(List<MotorisationDTO> motorisationDTO)
        {
            MotorisationService motorisationService = new MotorisationService();
            motorisationService.RemoveMotorisation(motorisationDTO);
        }
        public void AddMotorisation(List<MotorisationDTO> motorisationDTOs)
        {
            MotorisationService motorisationService = new MotorisationService();
            motorisationService.AddMotorisation(motorisationDTOs);
        }

        public List<MotorisationDTO> UpdateMotorisation(int id, string column, int value)
        {
            MotorisationService motorisationService = new MotorisationService();
            return motorisationService.UpdateMotorisation(id, column, value);
        }
    }
}

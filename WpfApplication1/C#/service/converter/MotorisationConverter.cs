using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.service.converter
{
    class MotorisationConverter
    {
        public List<MotorisationDTO> GetMotorisationDTOs(List<MotorisationDAO> MotorisationDAOs)
        {
            List<MotorisationDTO> MotorisationDTOs = new List<MotorisationDTO>();

            foreach (var MotorisationDAO in MotorisationDTOs)
            {
                MotorisationDTO MotorisationDTO = new MotorisationDTO();

                MotorisationDTO.Id_moteur = MotorisationDAO.Id_moteur;
                MotorisationDTO.Nom = MotorisationDAO.Nom;

                MotorisationDTOs.Add(MotorisationDTO);
            }

            return MotorisationDTOs;
        }

        public List<int> RemoveMotorisation(List<MotorisationDTO> motorisationDTOs)
        {
            List<int> ids = new List<int>();

            foreach (var motorisationDTO in motorisationDTOs)
            {
                ids.Add(motorisationDTO.Id_moteur);
            }

            return ids;
        }
        public List<MotorisationDAO> AddMotorisation(List<MotorisationDTO> motorisationDTOs)
        {
            List<MotorisationDAO> motorisationDAOs = new List<MotorisationDAO>();

            foreach (var motorisationDTO in motorisationDTOs)
            {
                MotorisationDAO motorisationDAO = new MotorisationDAO();

                motorisationDAO.Id_moteur = motorisationDTO.Id_moteur;
                motorisationDAO.Nom = motorisationDTO.Nom;
                
                

                motorisationDAOs.Add(motorisationDAO);
            }

            return motorisationDAOs;
        }
    }
}

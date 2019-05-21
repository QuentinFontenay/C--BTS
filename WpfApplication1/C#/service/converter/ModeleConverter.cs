using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.C_.repository.dao;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.C_.service.converter
{
    class ModeleConverter
    {
        public List<ModeleDTO> GetModeleDTOs(List<ModeleDAO> ModeleDAOs)
        {
            List<ModeleDTO> ModeleDTOs = new List<ModeleDTO>();

            foreach (var ModeleDAO in ModeleDAOs)
            {
                ModeleDTO ModeleDTO = new ModeleDTO();

                ModeleDTO.Id_modele = ModeleDAO.Id_modele;
                ModeleDTO.Nom = ModeleDAO.Nom;
                ModeleDTO.Type = ModeleDAO.Type;
                ModeleDTO.Capacite = ModeleDAO.Capacite;

                ModeleDTOs.Add(ModeleDTO);
            }

            return ModeleDTOs;
        }

        public List<int> RemoveModele(List<ModeleDTO> modeleDTOs)
        {
            List<int> ids = new List<int>();

            foreach (var modeleDTO in modeleDTOs)
            {
                ids.Add(modeleDTO.Id_modele);
            }

            return ids;
        }
        public List<ModeleDAO> AddModele(List<ModeleDTO> modeleDTOs)
        {
            List<ModeleDAO> modeleDAOs = new List<ModeleDAO>();

            foreach (var modeleDTO in modeleDTOs)
            {
                ModeleDAO modeleDAO = new ModeleDAO();

                modeleDAO.Id_modele = modeleDTO.Id_modele;
                modeleDAO.Type = modeleDTO.Type;
                modeleDAO.Capacite = modeleDTO.Capacite;
                modeleDAO.Nom = modeleDTO.Nom;

                modeleDAOs.Add(modeleDAO);
            }

            return modeleDAOs;
        }
    }
}

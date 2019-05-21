using System;
using System.Collections.Generic;
using System.Configuration;
using MaterialDesignThemes.Wpf.Converters;
using Microsoft.Win32;
using WpfApplication1.C_.repository.VolReposotory;
using WpfApplication1.service.converter;
using WpfApplication1.service.dto;

namespace WpfApplication1.service
{
    public class VolService
    {
        private string adapter = ConfigurationManager.AppSettings["dbtype"].ToString();

        private VolConverter volConverter = new VolConverter();

        private Abstract_VolRepository _volRepository;

        public VolService()
        {
            switch (adapter)
            {
                case "MySQL":
                    this._volRepository = new MySQL_VolRepository();
                    break;
                case "Oracle":
                    this._volRepository = new Oracle_VolRepository();
                    break;
                case "SQLserver":
                    this._volRepository = new SQLserver_VolRepository();
                    break;
            }
        }

        //overcharge GetAvionDTO with and without id, without you select all in bdd

        public List<VolDTO> GetVolDTOs()
        {
            return volConverter.GetVolDTOs(this._volRepository.GetVolDAOsInternal());
        }

      //  public List<VolDTO> GetVolDTOs(List<int> ids)
        //{
         //   return volConverter.GetVolDTOs(this._volRepository.GetVolDAOs(ids));
        //}

        public void RemoveVol(List<VolDTO> volDTOs)
        {
            this._volRepository.RemoveVol(volConverter.RemoveVol(volDTOs));
        }
        public IEnumerable<DateTime> GetDateVol()
        {
            return this._volRepository.GetDateVol();
        }

        public IEnumerable<int> GetMaxIdVol()
        {
            return this._volRepository.GetMaxIdVol();
        }

        public void RemoveTotalVol()
        {
            this._volRepository.RemoveVolInternal();
        }
        public void AddVol(List<VolDTO> volDTOs)
        {
           this._volRepository.AddVol(volConverter.AddVol(volDTOs));
        }

        public List<VolDTO> UpdateVol(int id, string column, dynamic value)
        {
            return volConverter.GetVolDTOs(this._volRepository.UpdateVol(id, column, value));
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication1.controller;
using WpfApplication1.C_.controller;
using WpfApplication1.Infrastructure;
using WpfApplication1.C_.controller;
using WpfApplication1.controller;
using WpfApplication1.repository.dao;
using WpfApplication1.service.dto;
using System;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1.ViewModel
{
    public class Enregistrement_ViewModel
    {   
        public Enregistrement_ViewModel()
        {
           AvionController avionController = new AvionController();
           VolController volController = new VolController();
            AeroportController aeroportController = new AeroportController();
            ModeleController modeleController = new ModeleController();

            AvionDTOs = new ObservableCollection<AvionDTO>(avionController.GetAvionDTOs());
           VolDTOs = new ObservableCollection<VolDTO>(volController.GetVolDTOs());
            NomModele = new ObservableCollection<string>(modeleController.GetNomModele());
            AeroportDTOs = new ObservableCollection<AeroportDTO>(aeroportController.GetAeroportDTOs());
           MaxIdAvion = new ObservableCollection<int>(volController.GetMaxIdVol());
            DateVol = new ObservableCollection<DateTime>(volController.GetDateVol());
            ModeleDTOs = new ObservableCollection<ModeleDTO>(modeleController.GetModeleDTOs());
            //this.SearchCommand = new RelayCommand(Search);
        }
        
        public ObservableCollection<AvionDTO> AvionDTOs { get; set; }
        public ObservableCollection<VolDTO> VolDTOs { get; set; }
        public ObservableCollection<AeroportDTO> AeroportDTOs { get; set; }
        public ObservableCollection<ModeleDTO> ModeleDTOs { get; set; }
        public ObservableCollection<int> MaxIdAvion { get; set; }
        public ObservableCollection<DateTime> DateVol { get; set; }
        public ObservableCollection<string> NomModele { get; set; }

        // public ObservableCollection<VolDTO> VolDTOse { get; set; }

        //        public ICommand SearchCommand { get; set; }
        //
        //        private void Search()
        //        {
        //            
        //        }
        //public ObservableCollection<VolDTO> VolDTOs { get; set; } 
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.controller;
using WpfApplication1.service.dto;

namespace WpfApplication1.ViewModel
{
    class Maintenance_ViewModel
    {
        public Maintenance_ViewModel()
        {
            AvionController avionController = new AvionController();

            AvionDTOs = new ObservableCollection<AvionDTO>(avionController.GetAvionDTOs());
            //this.SearchCommand = new RelayCommand(Search);
        }

        public ObservableCollection<AvionDTO> AvionDTOs { get; set; }
    }
}

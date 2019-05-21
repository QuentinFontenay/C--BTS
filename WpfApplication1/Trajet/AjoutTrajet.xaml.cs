using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.C_.controller;
using WpfApplication1.C_.service.dto;
using WpfApplication1.controller;
using WpfApplication1.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour AjoutTrajet.xaml
    /// </summary>
    public partial class AjoutTrajet : Window
    {
        TrajetController trajetController = new TrajetController();
        VoyageController voyageController = new VoyageController();
        AeroportController aeroportController = new AeroportController();
        public ObservableCollection<VoyageDTO> VoyageDTOs { get; set; }
        public ObservableCollection<AeroportDTO> AeroportDTOs { get; set; }

        public AjoutTrajet()
        {
            InitializeComponent();
            VoyageDTOs = new ObservableCollection<VoyageDTO>(voyageController.GetVoyageDTOs());
            AeroportDTOs = new ObservableCollection<AeroportDTO>(aeroportController.GetAeroportDTOs());

            for (int i = 0; i < VoyageDTOs.Count(); i++)
            {
                id_voyage.ItemsSource = VoyageDTOs;
            }
                aeroportA.ItemsSource = AeroportDTOs;
                aeroportD.ItemsSource = AeroportDTOs;
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<VoyageDTO> recup_id = new List<VoyageDTO>();
            List<AeroportDTO> recup_aeroportA = new List<AeroportDTO>();
            List<AeroportDTO> recup_aeroportD = new List<AeroportDTO>();
            List<TrajetDTO> add = new List<TrajetDTO>();

            recup_id.Add(id_voyage.SelectedItem as VoyageDTO);
            recup_aeroportA.Add(aeroportA.SelectedItem as AeroportDTO);
            recup_aeroportD.Add(aeroportD.SelectedItem as AeroportDTO);
            TrajetDTO add_m = new TrajetDTO()
            {
                Duree = duree.Text,
                IdVoyage = recup_id[0].IdVoyage,
                AeroportArrive = recup_aeroportA[0].IdAeroport,
                AeroportDepart = recup_aeroportD[0].IdAeroport,
                Kilometre = Convert.ToInt32(kilometre.Text)
            };
            add.Add(add_m);
            trajetController.AddTrajet(add);
            this.Close();
        }
    }
}

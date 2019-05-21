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
    /// Logique d'interaction pour EditTrajet.xaml
    /// </summary>
    public partial class EditTrajet : Window
    {
        TrajetController trajetController = new TrajetController();
        TrajetController trajetController2 = new TrajetController();
        TrajetController trajetController3 = new TrajetController();
        TrajetController trajetController4 = new TrajetController();
        TrajetController trajetController5 = new TrajetController();
        VoyageController voyageController = new VoyageController();
        AeroportController aeroportController = new AeroportController();
        public ObservableCollection<VoyageDTO> VoyageDTOs { get; set; }
        public ObservableCollection<AeroportDTO> AeroportDTOs { get; set; }
        public TrajetDTO recup_info { get; set; }
        public EditTrajet(TrajetDTO lol)
        {
            VoyageDTOs = new ObservableCollection<VoyageDTO>(voyageController.GetVoyageDTOs());
            AeroportDTOs = new ObservableCollection<AeroportDTO>(aeroportController.GetAeroportDTOs());


            InitializeComponent();
            recup_info = lol;
            duree.Text = recup_info.Duree;
            kilometre.Text = Convert.ToString(recup_info.Kilometre);
            aeroportA.Text = recup_info.AeroportArrive;
            aeroportD.Text = recup_info.AeroportDepart;
            for (int i = 0; i < VoyageDTOs.Count(); i++)
            {
                if (VoyageDTOs[i].IdVoyage == recup_info.IdVoyage)
                {
                    id_voyage.Text = VoyageDTOs[i].Nom;
                }
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

            recup_id.Add(id_voyage.SelectedItem as VoyageDTO);
            recup_aeroportA.Add(aeroportA.SelectedItem as AeroportDTO);
            recup_aeroportD.Add(aeroportD.SelectedItem as AeroportDTO);

            trajetController.UpdateTrajet(recup_info.IdTrajet, "duree", duree.Text);
            trajetController2.UpdateTrajet(recup_info.IdTrajet, "kilometre", kilometre.Text);
            trajetController3.UpdateTrajet(recup_info.IdTrajet, "id_voyage", recup_id[0].IdVoyage);
            trajetController4.UpdateTrajet(recup_info.IdTrajet, "aeroportA", recup_aeroportA[0].IdAeroport);
            trajetController5.UpdateTrajet(recup_info.IdTrajet, "aeroportD", recup_aeroportD[0].IdAeroport);
            this.Close();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfApplication1.C_.controller;
using WpfApplication1.C_.service.dto;
using WpfApplication1.controller;
using WpfApplication1.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour AjoutVol.xaml
    /// </summary>
    public partial class AjoutVol : Window
    {
        TrajetController trajetController = new TrajetController();
        VoyageController voyageController = new VoyageController();
        AeroportController aeroportController = new AeroportController();
        VolController volController = new VolController();
        ModeleController modeleController = new ModeleController();
        AvionController avionController = new AvionController();
        public ObservableCollection<VoyageDTO> VoyageDTOs { get; set; }
        public ObservableCollection<AeroportDTO> AeroportDTOs { get; set; }
        public ObservableCollection<ModeleDTO> ModeleDTOs { get; set; }
        public ObservableCollection<AvionDTO> AvionDTOs { get; set; }
        public ObservableCollection<TrajetDTO> TrajetDTOs { get; set; }
        public int recup { get; set; }
        public int recup_trajet { get; set; }
        public AjoutVol()
        {
            InitializeComponent();
            VoyageDTOs = new ObservableCollection<VoyageDTO>(voyageController.GetVoyageDTOs());
            AeroportDTOs = new ObservableCollection<AeroportDTO>(aeroportController.GetAeroportDTOs());
            ModeleDTOs = new ObservableCollection<ModeleDTO>(modeleController.GetModeleDTOs());
            AvionDTOs = new ObservableCollection<AvionDTO>(avionController.GetAvionDTOs());
            TrajetDTOs = new ObservableCollection<TrajetDTO>(trajetController.GetTrajetDTOs());


            id_voyage.ItemsSource = VoyageDTOs;
            Avion.ItemsSource = ModeleDTOs;
            aeroportA.ItemsSource = AeroportDTOs;
            aeroportD.ItemsSource = AeroportDTOs;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<VoyageDTO> recup_id = new List<VoyageDTO>();
            List<AeroportDTO> recup_aeroportA = new List<AeroportDTO>();
            List<ModeleDTO> recup_modele = new List<ModeleDTO>();
            List<AeroportDTO> recup_aeroportD = new List<AeroportDTO>();
            List<VolDTO> add = new List<VolDTO>();

            recup_id.Add(id_voyage.SelectedItem as VoyageDTO);
            for (int i = 0; i < TrajetDTOs.Count(); i++)
            {
                if (Convert.ToString(recup_id[0].IdVoyage) == Convert.ToString(TrajetDTOs[i].IdVoyage))
                {
                    recup_trajet = TrajetDTOs[i].IdTrajet;
                }
            }

            recup_modele.Add(Avion.SelectedItem as ModeleDTO);
            for (int i = 0; i < AvionDTOs.Count(); i++)
            {
                if (Convert.ToString(recup_modele[0].Id_modele) == Convert.ToString(AvionDTOs[i].IdModele) && AvionDTOs[i].Status == true)
                {
                    recup = AvionDTOs[i].IdAvion;
                }
            }
            recup_aeroportA.Add(aeroportA.SelectedItem as AeroportDTO);
            recup_aeroportD.Add(aeroportD.SelectedItem as AeroportDTO);
            string arriver = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date_arriver.Text + " " + temps_arriver.Text + ":00");
            string depart = String.Format("{0:yyyy-MM-dd HH:mm:ss}", date_depart.Text + " " + temps_depart.Text + ":00");
            VolDTO add_m = new VolDTO()
            {
                IdTrajet = recup_trajet,
                IdAvion = recup,
                AeroportD_Reel = recup_aeroportD[0].IdAeroport,
                AeroportA_Reel = recup_aeroportA[0].IdAeroport,
                AeroportA_Theo = recup_aeroportA[0].IdAeroport,
                DateA = Convert.ToDateTime(arriver),
                DateD = Convert.ToDateTime(depart),
                DateATheo = Convert.ToDateTime(arriver),
                DateDTheo = Convert.ToDateTime(depart),
                Status = true
            };
            add.Add(add_m);
            volController.AddVol(add);
            this.Close();
        }
    }
}

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
    /// Logique d'interaction pour EditVol.xaml
    /// </summary>
    public partial class EditVol : Window
    {
        TrajetController trajetController = new TrajetController();
        VoyageController voyageController = new VoyageController();
        AeroportController aeroportController = new AeroportController();

        VolController volController = new VolController();
        VolController volController2 = new VolController();
        VolController volController3 = new VolController();
        VolController volController4 = new VolController();
        VolController volController5 = new VolController();
        VolController volController6 = new VolController();
        VolController volController7 = new VolController();
        VolController volController8 = new VolController();
        VolController volController9 = new VolController();

        ModeleController modeleController = new ModeleController();
        AvionController avionController = new AvionController();
        public ObservableCollection<VoyageDTO> VoyageDTOs { get; set; }
        public ObservableCollection<AeroportDTO> AeroportDTOs { get; set; }
        public ObservableCollection<ModeleDTO> ModeleDTOs { get; set; }
        public ObservableCollection<AvionDTO> AvionDTOs { get; set; }
        public ObservableCollection<TrajetDTO> TrajetDTOs { get; set; }
        public int recup { get; set; }
        public int recup_trajet { get; set; }
        public VolDTO recup_info { get; set; }
        public EditVol(VolDTO lol)
        {
            VoyageDTOs = new ObservableCollection<VoyageDTO>(voyageController.GetVoyageDTOs());
            AeroportDTOs = new ObservableCollection<AeroportDTO>(aeroportController.GetAeroportDTOs());
            ModeleDTOs = new ObservableCollection<ModeleDTO>(modeleController.GetModeleDTOs());
            AvionDTOs = new ObservableCollection<AvionDTO>(avionController.GetAvionDTOs());
            TrajetDTOs = new ObservableCollection<TrajetDTO>(trajetController.GetTrajetDTOs());

            InitializeComponent();
            recup_info = lol;
            string datedepart = String.Format("{0:yyyy/MM/d}", Convert.ToString(recup_info.DateD));
            string timedepart = String.Format("{0:HH:mm}", Convert.ToString(recup_info.DateD));
            string datearriver = String.Format("{0:yyyy/MM/d}", Convert.ToString(recup_info.DateA));
            string timearriver = String.Format("{0:HH:mm}", Convert.ToString(recup_info.DateA));
            date_depart.Text = datedepart;
            temps_depart.Text = timedepart;
            date_arriver.Text = datearriver;
            temps_arriver.Text = timearriver;
           // aeroportA.Text = recup_info.AeroportA_Reel;
            //aeroportD.Text = recup_info.AeroportD_Reel;
            //id_voyage.Text = recup_info.


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
            string a = date_arriver.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
            string d = date_depart.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "-");
            string arriver = a + " " + temps_arriver.Text + ":00";
            string depart = d + " " + temps_depart.Text + ":00";

            volController.UpdateVol(recup_info.IdVol, "dateD", depart);
            volController2.UpdateVol(recup_info.IdVol, "dateA", arriver);
            volController3.UpdateVol(recup_info.IdVol, "dateATheo", arriver);
            volController4.UpdateVol(recup_info.IdVol, "dateDTheo", depart);
            volController5.UpdateVol(recup_info.IdVol, "id_trajet", recup_trajet);
            volController6.UpdateVol(recup_info.IdVol, "id_avions", recup);
            volController7.UpdateVol(recup_info.IdVol, "id_aeroportD_Reel", recup_aeroportD[0].IdAeroport);
            volController8.UpdateVol(recup_info.IdVol, "aeroportA_Reel", recup_aeroportA[0].IdAeroport);
            volController9.UpdateVol(recup_info.IdVol, "aeroportA_Theo", recup_aeroportA[0].IdAeroport);
            this.Close();
        }
    }
}

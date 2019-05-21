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

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour GestionVoyage.xaml
    /// </summary>
    public partial class GestionVoyage : Window
    {
        VoyageController voyageController = new VoyageController();

        public ObservableCollection<VoyageDTO> VoyageDTOs { get; set; }
        public List<VoyageDTO> remove_voyage { get; set; }

        public GestionVoyage()
        {
            InitializeComponent();
            VoyageDTOs = new ObservableCollection<VoyageDTO>(voyageController.GetVoyageDTOs());

            for (int i = 0; i < VoyageDTOs.Count(); i++)
            {
                //if (VolDTOs[i].Status == true)
                //{
                list_voyage.ItemsSource = VoyageDTOs;
                //}
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage NewWindow4 = new MainPage();
            NewWindow4.Show();
            this.Close();
           // this.NavigationService.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            VoyageDTO myitem = (VoyageDTO)list_voyage.SelectedItems[0];
            EditVoyage NewWindow6 = new EditVoyage(myitem);
            NewWindow6.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            remove_voyage = new List<VoyageDTO>();
            remove_voyage.Add(list_voyage.SelectedItems[0] as VoyageDTO);
            voyageController.RemoveVoyage(remove_voyage);
            GestionVoyage NewWindow4 = new GestionVoyage();
            NewWindow4.Show();
            this.Close();

        }

        private void Ajout_Voyage_Click(object sender, RoutedEventArgs e)
        {
            AjoutVoyage NewWindow7 = new AjoutVoyage();
            NewWindow7.Show();
        }
    }
}

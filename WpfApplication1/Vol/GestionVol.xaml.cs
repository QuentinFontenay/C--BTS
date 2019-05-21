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
using WpfApplication1.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour GestionVol.xaml
    /// </summary>
    public partial class GestionVol : Window
    {
        VolController volController = new VolController();

        public ObservableCollection<VolDTO> VolDTOs { get; set; }
        public List<VolDTO> remove_vol { get; set; }
        public GestionVol()
        {
            InitializeComponent();
            VolDTOs = new ObservableCollection<VolDTO>(volController.GetVolDTOs());

            for (int i = 0; i < VolDTOs.Count(); i++)
            {
                //if (VolDTOs[i].Status == true)
                //{
                list_vol.ItemsSource = VolDTOs;
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

        private void Trajet_Click(object sender, RoutedEventArgs e)
        {
             GestionTrajet NewWindow6 = new GestionTrajet();
            NewWindow6.Show();
            this.Close();
            //this.NavigationService.Navigate(typeof(GestionTrajet));
        }

        private void Voyage_Click(object sender, RoutedEventArgs e)
        {
            GestionVoyage NewWindow5 = new GestionVoyage();
            NewWindow5.Show();
            this.Close();
           // this.NavigationService.Navigate(typeof(GestionVoyage));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            VolDTO myitem = (VolDTO)list_vol.SelectedItems[0];
            EditVol NewWindow7 = new EditVol(myitem);
            NewWindow7.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            remove_vol = new List<VolDTO>();
            remove_vol.Add(list_vol.SelectedItems[0] as VolDTO);
            volController.RemoveVol(remove_vol);
            GestionVol NewWindow4 = new GestionVol();
            NewWindow4.Show();
            this.Close();
        }

        private void Voyage_Click_1(object sender, RoutedEventArgs e)
        {
            AjoutVol NewWindow7 = new AjoutVol();
            NewWindow7.Show();
        }
    }
}

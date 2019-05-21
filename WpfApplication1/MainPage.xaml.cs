using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //Enregistrement NewWindow = new Enregistrement();
            Stock NewWindow = new Stock();
             NewWindow.Show();
            this.Close();
            // this.NavigationService.Navigate(typeof(Enregistrement));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Maintenance NewWindow2 = new Maintenance();
            NewWindow2.Show();
            this.Close();
            // this.NavigationService.Navigate(typeof(Maintenance));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            GestionVol NewWindow3 = new GestionVol();
            NewWindow3.Show();
            this.Close();
            //this.NavigationService.Navigate(typeof(GestionVol));


        }
    }
}

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
using System.Windows.Shapes;
using WpfApplication1.C_.controller;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour AjoutVoyage.xaml
    /// </summary>
    public partial class AjoutVoyage : Window
    {
        VoyageController voyageController = new VoyageController();
        public AjoutVoyage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<VoyageDTO> add = new List<VoyageDTO>();

            VoyageDTO add_m = new VoyageDTO()
            {
                Nom = nom_voyage.Text
            };
            add.Add(add_m);
            voyageController.AddVoyage(add);
            this.Close();
        }
    }
}

using System.Xml.Serialization.Configuration;
using System.Windows;
using WpfApplication1.ViewModel;
using WpfApplication1.repository.dao;
using System.Windows.Controls;
using WpfApplication1.service.dto;
using System;
using WpfApplication1.C_.controller;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;
using WpfApplication1.controller;
using System.Linq;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using WpfApplication1.C_.service.dto;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Enregistrement : Window
    {
        VolController volController = new VolController();
        AeroportController aeroportController = new AeroportController();
        AvionController avionController = new AvionController();
        ModeleController modeleController = new ModeleController();
        public ObservableCollection<VolDTO> VolDTOs { get; set; }
        public List<string> VolDTOe { get; set; }
        public ObservableCollection<AeroportDTO> AeroportDTOs { get; set; }
        public int i { get; set; }
        public ObservableCollection<AvionDTO> AvionDTOs { get; set; }
        public ObservableCollection<ModeleDTO> ModeleDTOs { get; set; }

        public ObservableCollection<int> MaxIdAvion { get; set; }
        public ObservableCollection<DateTime> DateVol { get; set; }
        public ObservableCollection<string> NomModele { get; set; }
        public List<VolDTO> add_vol { get; set; }

        public Enregistrement()
        {
            InitializeComponent();
            add_vol = new List<VolDTO>();
            List<dynamic> s = new List<dynamic>();
           // VolDTOe = volController.AddVol());
            VolDTOs = new ObservableCollection<VolDTO>(volController.GetVolDTOs());
            AeroportDTOs = new ObservableCollection<AeroportDTO>(aeroportController.GetAeroportDTOs());
            DateVol = new ObservableCollection<DateTime>(volController.GetDateVol());
            NomModele = new ObservableCollection<string>(modeleController.GetNomModele());
            AvionDTOs = new ObservableCollection<AvionDTO>(avionController.GetAvionDTOs());
            ModeleDTOs = new ObservableCollection<ModeleDTO>(modeleController.GetModeleDTOs());
            MaxIdAvion = new ObservableCollection<int>(volController.GetMaxIdVol());

            this.DataContext = new Enregistrement_ViewModel();
        }
        public void Afficher_avion(object sender, RoutedEventArgs e)
        { 
             for (i = 0; i < AvionDTOs.Count(); i++)
            {
         
            if (Convert.ToString(AvionDTOs[i].Status) == "True")
                {
                    avion_dispo.Orientation = Orientation.Horizontal;
                    Image img = new Image();
                    BitmapImage bi3 = new BitmapImage();
                    TextBlock nom_avion = new TextBlock();

                    bi3.BeginInit();
                    bi3.UriSource = new Uri("C:/Users/quent/Documents/B2/C#/c_sharpedo_aa/WpfApplication1/image/plane_dispo.png", UriKind.Relative);
                    bi3.CacheOption = BitmapCacheOption.OnLoad;
                    bi3.EndInit();
                    img.Source = bi3;
                    img.Width = 30;
                    img.Margin = new Thickness(5, 0, 0, 0);
              //  int test = Convert.ToInt16(AvionDTOs[i].IdModele);
                    img.ToolTip = NomModele[0];
                    img.PreviewMouseDown += new MouseButtonEventHandler(img2_MouseLeftButtonDown);
                    nom_avion.Text = Convert.ToString(AvionDTOs[i].IdAvion);
                    nom_avion.Margin = new Thickness(0, 70, 0, 0);
                    avion_dispo.Children.Add(img);
                    avion_dispo.Children.Add(nom_avion);
                   }
            else if (Convert.ToString(AvionDTOs[i].Status) == "False")
                {
                    avion_secours.Orientation = Orientation.Horizontal;
                    Image img2 = new Image();
                    BitmapImage bi4 = new BitmapImage();
                    TextBlock nom_avion2 = new TextBlock();

                    bi4.BeginInit();
                    bi4.UriSource = new Uri("C:/Users/quent/Documents/B2/C#/c_sharpedo_aa/WpfApplication1/image/plane_secours.png", UriKind.Relative);
                    bi4.CacheOption = BitmapCacheOption.OnLoad;
                    bi4.EndInit();
                    img2.Source = bi4;
                    img2.Width = 30;
                    img2.Margin = new Thickness(5, 0, 0, 0);
                    img2.ToolTip = NomModele[0];
                    img2.PreviewMouseDown += new MouseButtonEventHandler(img2_MouseLeftButtonDown);
                    nom_avion2.Text = Convert.ToString(AvionDTOs[i].IdAvion);
                    nom_avion2.Margin = new Thickness(0, 70, 0, 0);
                    avion_secours.Children.Add(img2);
                    avion_secours.Children.Add(nom_avion2);
                }
            }
        }

        private void img2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // DataObject[] Data = new DataObject[2];
            //Image image = e.Source as Image;
            //Data = new DataObject(typeof(ImageSource), image.Source);
            //Data[1] = new DataObject(typeof(ToolTip), image.ToolTip);
            //DragDrop.DoDragDrop(image, Data, DragDropEffects.All);
            DragDrop.DoDragDrop((DependencyObject)sender, ((Image)sender).Source, DragDropEffects.Copy);
        }
        private void Image_Drop(object sender, DragEventArgs e)
        {
            
            foreach (var format in e.Data.GetFormats())
            {
                ImageSource imageSource = e.Data.GetData(format) as ImageSource;
              //  ToolTip tool = e.Data.GetData(format) as ToolTip;
                //ToolTip ff = e.Data.GetData(format) as ToolTip;

                if (imageSource != null)
                {
                    Image img = new Image();
                    //TextBlock texte = new TextBlock();
                    img.Width = 50;
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    img.VerticalAlignment = VerticalAlignment.Center;
                    img.Source = imageSource;
                 //   img.ToolTip = tool;
                    ((Canvas)sender).Children.Add(img);
                    //((Canvas)sender).Children.Add(texte);
                }
            }
            //Image imageControl = (Image)sender;
            //if ((e.Data.GetData(typeof(ImageSource)) != null))
            //{
            //  ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
            //imageControl = new Image() { Width = 30, Height = 30, Source = image };
            //img1 = imageControl;
            // img1.Source = (ImageSource)e.Data.GetData(typeof(ImageSource));     
            // }
        }

        void rechercher_Click(object sender, RoutedEventArgs e)
        {
            date_arriver.Text = Convert.ToString(DateVol[0]);
            date_depart.Text = Convert.ToString(AvionDTOs[0].Status);
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {

        }
      
    }
}
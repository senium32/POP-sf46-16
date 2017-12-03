using POP_sf46_16_GUI.model;
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

namespace POP_sf46_16_GUI.GUI
{
    /// <summary>
    /// Interaction logic for Main_Korisnik_Window.xaml
    /// </summary>
    public partial class Main_Korisnik_Window : Window
    {
        private Korisnik ulogovani_korisnik;

        public Main_Korisnik_Window(Korisnik korisnik)
        {
            ulogovani_korisnik = korisnik;
            InitializeComponent();
            lblDobrodosli.Content = $"Dobrodosli {ulogovani_korisnik.Ime}";
        }


        private void btnPregledNamestaja_Click(object sender, RoutedEventArgs e)
        {
            var prozor = new Korisnik_Prikaz_Namestaja();
            prozor.ShowDialog();
        }

        private void btnNaAkciji_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}

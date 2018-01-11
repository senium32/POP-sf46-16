using POP_sf46_16_GUI.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Korisnik_Prikaz_Namestaja.xaml
    /// </summary>
    public partial class Korisnik_Prikaz_Namestaja : Window
    {
        private ICollectionView view;

        public Namestaj IzabraniNamestaj { get; set; }

        public Korisnik_Prikaz_Namestaja()
        {
            InitializeComponent();
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view.Filter = PrikazNeobrisanogNamestaja;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.AutoGeneratingColumn += prikaz1;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        private bool PrikazNeobrisanogNamestaja(object obj)
        {
            return ((Namestaj)obj).NaStanju == true;
        }
        private void prikaz1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "AkcijskaCenaId" || e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;

            }
        }



        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DaVidimo()
        {
            var rowStyle = new Style { };
        }
    }
    
}

using POP_sf46_16_GUI.Databases;
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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        private ProdajaNamestaja izabrani;
        private Namestaj namestaj;
        private ICollectionView view;
        public ProdajaWindow(ProdajaNamestaja objekat)
        {
            InitializeComponent();
            izabrani = objekat;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view.Filter = PrikazNamestaja;
            cbProizvod.ItemsSource = view;
            tbKolicina.DataContext = izabrani;
            tbKupac.DataContext = izabrani;
        }
        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool PrikazNamestaja(object obj)
        {
            return ((Namestaj)obj).NaStanju == false;
        }
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = RadSaPodacima.Instance.ProdajaNamestaja;
            namestaj = (Namestaj)cbProizvod.SelectedItem;
            var msg_greska = false;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";
            string greska = "Pogresno ste uneli polje: ";
            int parsedTest;

            if (tbKolicina.Text == "")
            {
                msg_prazno = true;
                poruka += " Kolicina ";
            }
            if (!int.TryParse(tbKolicina.Text, out parsedTest))
            {
                msg_greska = true;
                greska += " Kolicina ";

            
            }
            else
            {
                if (namestaj.Kolicina < int.Parse(tbKolicina.Text))
                {
                    msg_greska = true;
                    greska += " Kolicina ";

                }
            }
            if (tbKupac.Text == "")
            {
                msg_prazno = true;
                poruka += " Kupac ";

            }
            if (cbProizvod.SelectedItem == null)
            {
                msg_prazno = true;
                poruka += " Proizvod ";

            }
            if (msg_prazno == true || msg_greska == true)
            {
                MessageBox.Show(poruka, greska);
            }
            
            else if (msg_greska == false && msg_prazno == false)
            {
                izabrani.Broj_Racuna = lista.Count + 1;
                izabrani.Datum_Prodaje = DateTime.Now;
                izabrani.NamestajId = namestaj.Id;
                izabrani.Obrisan = false;
                
                ProdajaNamestajaDatabase.ProdajaDodaj(izabrani);
                NamestajDatabase.NamestajIzmeni(namestaj);
                RadSaPodacima.Instance.ProdajaNamestaja.Add(izabrani);
                this.Close();

                
            }
        }
    }
}

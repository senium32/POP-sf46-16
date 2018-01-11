using POP_sf46_16_GUI.Databases;
using POP_sf46_16_GUI.model;
using POP_sf46_16_GUI.Utils;
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
    /// Interaction logic for Dodaj_Namestaj_Window.xaml
    /// </summary>
    public partial class Dodaj_Namestaj_Window : Window
    {
        private ICollectionView view;
        private Namestaj odabrani;
        int pbroj = 0;
        
        public Dodaj_Namestaj_Window(int broj, Namestaj izabrani)
        {   
            InitializeComponent();
            this.odabrani = izabrani;
           
            
            pbroj = broj;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.TipoviNamestaja);
            view.Filter = PrikazNeobrisanogTipaNamestaja;
            cbTip.ItemsSource = view;
            cbTip.DataContext = odabrani;
            cbPopust.ItemsSource = RadSaPodacima.Instance.Akcije;
            cbPopust.DataContext = odabrani;
            if (pbroj == 2)
            {
                foreach (TipNamestaja item in cbTip.Items)
                {
                    if (item.ToString().Equals(odabrani.TipNamestaja.Naziv))
                    {
                        cbTip.SelectedItem = item;
                        break;
                    }
                }
                
            }
            tbKolicina.DataContext = odabrani;
            tbCena.DataContext = odabrani;
            tbNaziv.DataContext = odabrani;


        }
        private bool PrikazNeobrisanogTipaNamestaja(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }



        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            
            var izabrani_tip_namestaja = (TipNamestaja)cbTip.SelectedItem;
            var lista = RadSaPodacima.Instance.Namestaj;
            var msg_greska = false;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";
            string greska = "Pogresno ste uneli polje: ";
            int parsedTest;

            if (tbCena.Text == "")
            {
                msg_prazno = true;
                poruka += " Cena ";
            }
            if (!int.TryParse(tbCena.Text, out parsedTest))
            {
                msg_greska = true;
                greska += " Cena ";

                
            }
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
            if (tbNaziv.Text == "")
            {
                msg_prazno = true;
                poruka += " Naziv ";

            }
            if (cbTip.SelectedItem == null)
            {
                msg_prazno = true;
                poruka += " Tip ";

            }
            if (msg_prazno == true || msg_greska == true)
            {
                MessageBox.Show(poruka, greska);
            }
            else if (msg_greska == false && msg_prazno == false)
            {
                if (pbroj == 1)
                {
                    odabrani.Id = lista.Count + 1;

                    NamestajDatabase.NamestajDodaj(odabrani);
                    RadSaPodacima.Instance.Namestaj.Add(odabrani);
                    this.Close();

                }
                else if (pbroj == 2)
                {
                    foreach (Namestaj n in lista)
                    {
                        if (n.Id == odabrani.Id)
                        {
                            n.Kolicina = odabrani.Kolicina;
                            n.Naziv = odabrani.Naziv;
                            n.TipNamestaja = odabrani.TipNamestaja;
                            n.NaPopustu = odabrani.NaPopustu;
                            n.Cena = odabrani.Cena;



                        }
                    }
                    NamestajDatabase.NamestajIzmeni(odabrani);
                    this.Close();

                }

            }
           
        }
    }
}

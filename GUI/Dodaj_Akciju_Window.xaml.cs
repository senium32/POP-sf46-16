using POP_sf46_16_GUI.Databases;
using POP_sf46_16_GUI.model;
using POP_sf46_16_GUI.Utils;
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
    /// Interaction logic for Dodaj_Akciju_Window.xaml
    /// </summary>
    public partial class Dodaj_Akciju_Window : Window
    {
        int pbroj = 0;
        private Akcija odabrana;
        public Dodaj_Akciju_Window(int broj, Akcija izabrana)
        {
            InitializeComponent();
            dpPocetak.DisplayDate = DateTime.Now;
            dpKraj.DisplayDate = DateTime.Now;
            pbroj = broj;
            this.odabrana = izabrana;
            tbNaziv.DataContext = odabrana;
            dpPocetak.DataContext = odabrana;
            dpKraj.DataContext = odabrana;
            tbPopust.DataContext = odabrana;

        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = RadSaPodacima.Instance.Akcije;
            var msg_greska = false;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";
            string greska = "Pogresno ste uneli polje: ";
            int parsedTest;


            if (tbNaziv.Text == "")
            {
                msg_prazno = true;
                poruka += " Naziv ";
            }
            if (tbPopust.Text == "")
            {
                msg_prazno = true;
                poruka += " Popust ";
            }
            if (!int.TryParse(tbPopust.Text, out parsedTest))
            {
                msg_greska = true;
                greska += " Popust ";


            }
            if (dpPocetak.Text == "")
            {
                msg_prazno = true;
                poruka += " Datum Pocetka ";
            }
            if (dpKraj.Text == "")
            {
                msg_prazno = true;
                poruka += " Datum Zavrsetka ";
            }
            if (odabrana.Datum_Pocetka > odabrana.Datum_Zavrsetka)
            {
                msg_greska = true;
                greska += " Datum Zavrsetka ";
            }
            if (msg_prazno == true || msg_greska == true)
            {
                MessageBox.Show(poruka, greska);
            }
            else if (msg_greska == false && msg_prazno == false)
            {
                if (pbroj == 1)
                {
                    odabrana.Id = lista.Count + 1;

                    AkcijaDatabase.AkcijaDodaj(odabrana);
                    RadSaPodacima.Instance.Akcije.Add(odabrana);
                    this.Close();

                }
                else if (pbroj == 2)
                {
                    foreach (Akcija n in lista)
                    {
                        if (n.Id == odabrana.Id)
                        {
                            n.Datum_Pocetka = odabrana.Datum_Pocetka;
                            n.Datum_Zavrsetka = odabrana.Datum_Zavrsetka;
                            n.Popust = odabrana.Popust;
                            n.Naziv = odabrana.Naziv;
                        }
                    }
                    AkcijaDatabase.AkcijaIzmeni(odabrana);
                    this.Close();

                }
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

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
    /// Interaction logic for DodajDodatakWindow.xaml
    /// </summary>
    public partial class DodajDodatakWindow : Window
    {
        int kbroj = 0;
        private DodatnaUsluga izabrani;
        public DodajDodatakWindow(int broj, DodatnaUsluga objekat)
        {
            InitializeComponent();
            izabrani = objekat;
            kbroj = broj;
            tbCena.DataContext = izabrani;
            tbNaziv.DataContext = izabrani;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = RadSaPodacima.Instance.DodatnaUsluga;
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
            if (tbNaziv.Text == "")
            {
                msg_prazno = true;
                poruka += " Naziv ";

            }
            if (msg_prazno == true || msg_greska == true)
            {
                MessageBox.Show(poruka, greska);
            }
            else if (msg_greska == false && msg_prazno == false)
            {
                if (kbroj == 1)
                {
                    izabrani.Id = lista.Count + 1;
                    izabrani.Obrisan = false;

                    DodatnaUslugaDatabase.DodatnaUslugaDodaj(izabrani);
                    RadSaPodacima.Instance.DodatnaUsluga.Add(izabrani);
                    this.Close();

                }
                else if (kbroj == 2)
                {
                    foreach (DodatnaUsluga n in lista)
                    {
                        if (n.Id == izabrani.Id)
                        {
                            n.Cena = izabrani.Cena;
                            n.Naziv = izabrani.Naziv;



                        }
                    }
                    DodatnaUslugaDatabase.DodatnaUslugaIzmeni(izabrani);
                    this.Close();

                }
            }
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

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
    /// Interaction logic for Dodaj_TipNamestaja_Window.xaml
    /// </summary>
    public partial class Dodaj_TipNamestaja_Window : Window
    {
        int kbroj = 0;
        private TipNamestaja izabrani;
        public Dodaj_TipNamestaja_Window(int broj, TipNamestaja objekat)
        {
            InitializeComponent();
            izabrani = objekat;
            kbroj = broj;
            tbNaziv.DataContext = izabrani;
        }


        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista = RadSaPodacima.Instance.TipoviNamestaja;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";

            if (tbNaziv.Text == "")
            {
                msg_prazno = true;
                poruka += " Naziv ";
            }

            if (msg_prazno == true)
            {
                MessageBox.Show(poruka);
            }
            else if (msg_prazno == false)
            {
                if (kbroj == 1)
                {
                    izabrani.Id = lista.Count + 1;
                    lista.Add(izabrani);
                    GenericSerialize.Serialize("tipovi_namestaja.xml", lista);
                    this.Close();

                }
                else if (kbroj == 2)
                {
                    foreach (TipNamestaja n in lista)
                    {
                        if (n.Id == izabrani.Id)
                        {
                            n.Naziv = izabrani.Naziv;
                            



                        }
                    }
                    GenericSerialize.Serialize("tipovi_namestaja.xml", lista);
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

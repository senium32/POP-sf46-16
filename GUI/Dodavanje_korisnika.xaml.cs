using POP_sf46_16_GUI.Databases;
using POP_sf46_16_GUI.model;
using POP_sf46_16_GUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Dodavanje_korisnika.xaml
    /// </summary>
    public partial class Dodavanje_korisnika : Window
    {
        int kbroj = 0;
        string opcija;
        private Korisnik izabrani;
        public Dodavanje_korisnika(int broj, Korisnik objekat, string pravljenje)
        {
            InitializeComponent();
            izabrani = objekat;
            kbroj = broj;
            opcija = pravljenje;
            TipoviKorisnika();
            tbIme.DataContext = izabrani;
            tbPrezime.DataContext = izabrani;
            tbUsername.DataContext = izabrani;
            if (kbroj == 2)
            {
                tbUsername.IsReadOnly = true;
            }
            tbPassword.DataContext = izabrani;
            cbTip.DataContext = izabrani;
            if (opcija.Equals("Registracija"))
            {
                cbTip.IsEnabled = false;
            }
            else if (opcija.Equals("Novi"))
            {
                cbTip.IsEnabled = true;
            }
        }
        private void TipoviKorisnika()
        {
            cbTip.Items.Add("korisnik");
            cbTip.Items.Add("admin");
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            var izabrani_tip_korisnika = ""+cbTip.SelectedItem;
            var lista = RadSaPodacima.Instance.Korisnici;
            var msg_greska = false;
            var msg_prazno = false;
            string poruka = " Niste uneli polje: ";
            string greska = "Username koji ste izabrali je zauzet: ";
            

            if (tbIme.Text == "")
            {
                msg_prazno = true;
                poruka += " Ime ";
            }
            
            if (tbPrezime.Text == "")
            {
                msg_prazno = true;
                poruka += " Prezime ";

            }
            
            if (tbUsername.Text == "")
            {
                msg_prazno = true;
                poruka += " Username ";

            }
            if (kbroj == 1)
            {
                foreach (Korisnik k in lista)
                {
                    if (k.Username.Equals(tbUsername.Text))
                    {
                        msg_greska = true;
                    }
                }

            }
            
            if (tbPassword.Text == "")
            {
                msg_prazno = true;
                poruka += " Password ";

            }
            if (opcija.Equals("Novi"))
            {
                if (cbTip.SelectedItem == null)
                {
                    msg_prazno = true;
                    poruka += " Tip ";

                }
            }
            if (msg_prazno == true || msg_greska == true)
            {
                MessageBox.Show(poruka, greska);
            }
            else if (msg_greska == false && msg_prazno == false)
            {
                if (kbroj == 1)
                {
                    izabrani.Password = tbPassword.Text;
                    if (opcija.Equals("Registracija"))
                    {
                        izabrani.Tip_Korisnika = "korisnik";
                    }
                    KorisnikDatabase.KorisnikDodaj(izabrani);
                    RadSaPodacima.Instance.Korisnici.Add(izabrani);
                    this.Close();

                }
                else if (kbroj == 2)
                {
                    foreach (Korisnik n in lista)
                    {
                        if (n.Username == izabrani.Username)
                        {
                            n.Ime = izabrani.Ime;
                            n.Prezime = izabrani.Prezime;
                            n.Username = izabrani.Username;
                            n.Password = tbPassword.Text;
                            n.Tip_Korisnika = izabrani.Tip_Korisnika;



                        }
                    }
                    KorisnikDatabase.KorisnikIzmeni(izabrani);
                    this.Close();

                }

            }

        }
        private string Hash(string passw)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(passw));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

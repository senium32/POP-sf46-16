using POP_sf46_16_GUI.model;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private Korisnik korisnik;
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = pswBox.Password.ToString();
            int br = 0;
            foreach (Korisnik k in RadSaPodacima.Instance.Korisnici)
            {
                if (k.Username.Equals(username) && k.Password.Equals(Hash(password)) && k.Obrisan == false)
                {
                    br += 1;
                    korisnik = k;
                
                }

            }
            if (br > 0)
            {
                this.Hide();
                if (korisnik.Tip_Korisnika.Equals("korisnik"))
                {
                    var window = new Main_Korisnik_Window(korisnik);
                    window.ShowDialog();
                }
                else
                {
                    var window = new MainWindow(korisnik);
                    window.ShowDialog();
                }
                
            }
            if (br == 0)
            {
                var greska = new LoginGreska();
                greska.ShowDialog();
            }
            this.Show();
            

        }
        private string Hash(string passw)
        {
            var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(passw));
            return string.Join("", hash.Select(b => b.ToString("x2")).ToArray());
        }

        private void lblOvde_Click(object sender, RoutedEventArgs e)
        {
            var zaDodati = new Korisnik
            {
                Ime = ""
            };
            var window = new Dodavanje_korisnika(1, zaDodati);
            window.ShowDialog();
        }
    }
}

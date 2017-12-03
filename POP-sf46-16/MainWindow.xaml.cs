using POP_sf46_16_GUI.GUI;
using POP_sf46_16_GUI.model;
using POP_sf46_16_GUI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_sf46_16_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private Korisnik ulogovani_korisnik;
        private ICollectionView view;

        public Korisnik IzabraniKorisnik { get; set; }

        public Korisnik Korisnik { get; set; }

        public Namestaj IzabraniNamestaj { get; set; }

        public Namestaj Namestaj { get; set; }

        public TipNamestaja IzabraniTipNamestaja { get; set; }

        public TipNamestaja TipNamestaja { get; set; }

        public Akcija IzabranaAkcija { get; set; }
        public Akcija Akcija { get; set; }

        public Object Objekat { get; set; }

        public string operacija = "";
        public MainWindow(Korisnik korisnik)
        {
            ulogovani_korisnik = korisnik;
            InitializeComponent();
            lblSalon.Content = $"Dobrodosli {ulogovani_korisnik.Ime}";
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void btnNamestaji_Click(object sender, RoutedEventArgs e)
        {
            operacija = "namestaj";
            Objekat = null;
            Objekat = IzabraniNamestaj;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view.Filter = PrikazNeobrisanogNamestaja;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.AutoGeneratingColumn += prikaz1;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

        }

        private void prikaz1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "AkcijskaCenaId")
            {
                e.Cancel = true;

            }
        }


        private bool PrikazNeobrisanogNamestaja(object obj)
        {
            return ((Namestaj) obj).NaStanju == true;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            operacija = "korisnik";
            Objekat = null;
            Objekat = IzabraniKorisnik;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Korisnici);
            dgPrikaz.ItemsSource = view;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnTipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            operacija = "tipNamestaja";
            Objekat = null;
            Objekat = IzabraniTipNamestaja;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.TipoviNamestaja);
            dgPrikaz.ItemsSource = view;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnAkcije_Click(object sender, RoutedEventArgs e)
        {
            operacija = "akcija";
            Objekat = null;
            Objekat = IzabranaAkcija;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Akcije);
            dgPrikaz.ItemsSource = null;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
       
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (operacija.Equals(""))
            {
                MessageBox.Show("Niste izabrali pregled ni jednog tipa!");
            }
            else
            {
                if (operacija.Equals("korisnik"))
                {
                    var zaDodati = new Korisnik
                    {
                        Ime = ""
                    };
                    var window = new Dodavanje_korisnika(1, zaDodati);
                    window.ShowDialog();
                }
                else if (operacija.Equals("namestaj"))
                {
                    var zaDodati = new Namestaj()
                    {
                        Naziv = ""
                       
                    };
                    var window = new Dodaj_Namestaj_Window(1, zaDodati);
                    window.ShowDialog();
                }
                else if (operacija.Equals("tipNamestaja"))
                {
                    var zaDodati = new TipNamestaja()
                    {
                        Naziv = ""
                    };
                    var window = new Dodaj_TipNamestaja_Window(1, zaDodati);
                    window.ShowDialog();
                }
                else if (operacija.Equals("akcija"))
                {
                    var zaDodati = new Akcija()
                    {
                        Popust = 0,
                        Datum_Pocetka = DateTime.Now,
                        Datum_Zavrsetka = DateTime.Now
                    };
                    var window = new Dodaj_Akciju_Window(1, zaDodati);
                    window.ShowDialog();
                }

            }
            view.Refresh();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (operacija.Equals(""))
            {
                MessageBox.Show("Niste izabrali pregled ni jednog tipa!");
            }
            if (operacija.Equals("korisnik"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    Korisnik = (Korisnik)Objekat;
                    var zaIzmenu = (Korisnik)Korisnik.Clone();
                    var window = new Dodavanje_korisnika(2, zaIzmenu);
                    window.ShowDialog();

                }
                else
                {
                    MessageBox.Show(" Morate izabrati korisnika za izmenu!! ");
                }
            }
            else if (operacija.Equals("namestaj"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    Namestaj = (Namestaj)Objekat;
                    var prosledjenNamestaj = (Namestaj)Namestaj.Clone();
                    var window = new Dodaj_Namestaj_Window(2, prosledjenNamestaj);
                    window.ShowDialog();

                }
                else
                {
                    MessageBox.Show(" Morate izabrati objekat za izmenu!! ");
                }
            }
            else if (operacija.Equals("tipNamestaja"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    TipNamestaja prosledjenTip = (TipNamestaja)Objekat;
                    var window = new Dodaj_TipNamestaja_Window(2, prosledjenTip);
                    window.ShowDialog();

                }
                else
                {
                    MessageBox.Show(" Morate izabrati objekat za izmenu!! ");
                }
            }
            else if (operacija.Equals("akcija"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    Akcija = (Akcija)Objekat;
                    var prosledjenaAkcija = (Akcija)Akcija.Clone();
                    var window = new Dodaj_Akciju_Window(2, prosledjenaAkcija);
                    window.ShowDialog();

                }
                else
                {
                    MessageBox.Show(" Morate izabrati objekat za izmenu!! ");
                }
            }
            view.Refresh();

        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (operacija.Equals(""))
            {
                MessageBox.Show("Niste izabrali pregled ni jednog tipa!");
            }
            else
            {
                if (operacija.Equals("korisnik"))
                {
                    var lista_korisnika = RadSaPodacima.Instance.Korisnici;
                    var Korisnik = (Korisnik)Objekat;
                    var ob = (Korisnik)Korisnik.Clone();
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati korisnika za brisanje!! ");
                    }
                    if (ob != null)
                    {
                        foreach (Korisnik n in lista_korisnika)
                        {
                            if (n.Username == ob.Username)
                            {
                                if (n.Obrisan == false)
                                {
                                    n.Obrisan = true;
                                    GenericSerialize.Serialize("Korisnici.xml", lista_korisnika);

                                    break;
                                }
                                else if (n.Obrisan == true)
                                {
                                    n.Obrisan = false;
                                    GenericSerialize.Serialize("Korisnici.xml", lista_korisnika);

                                    break;
                                }
                            }
                        }




                    }
                }
                else if (operacija.Equals("namestaj"))
                {
                    var lista_namestaja = RadSaPodacima.Instance.Namestaj;
                    Namestaj = (Namestaj)Objekat;
                    var ob = (Namestaj)Namestaj.Clone();

                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {
                        foreach (Namestaj n in lista_namestaja)
                        {
                            if (n.Id == ob.Id)
                            {
                                if (n.NaStanju == false)
                                {
                                    n.NaStanju = true;
                                    GenericSerialize.Serialize("listaNam.xml", lista_namestaja);

                                    break;
                                }
                                else if (n.NaStanju == true)
                                {
                                    n.NaStanju = false;
                                    GenericSerialize.Serialize("listaNam.xml", lista_namestaja);
                                    view.Refresh();
                                    break;
                                }
                            }
                        }




                    }
                }
                else if (operacija.Equals("akcija"))
                {
                    var lista_akcija = RadSaPodacima.Instance.Akcije;
                    var ob = (Akcija)Objekat;
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {
                        foreach (Akcija n in lista_akcija)
                        {
                            if (n.Id == ob.Id)
                            {
                                if (n.Datum_Zavrsetka  < System.DateTime.Now)
                                {
                                    lista_akcija.Remove(n);
                                    GenericSerialize.Serialize("Akcije.xml", lista_akcija);

                                    break;
                                }
                                
                            }
                        }




                    }
                }
                else if (operacija.Equals("tipNamestaja"))
                {
                    var lista_tipova = RadSaPodacima.Instance.TipoviNamestaja;
                    TipNamestaja = (TipNamestaja)Objekat;
                    var ob = (TipNamestaja)TipNamestaja.Clone();
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {
                        foreach (TipNamestaja n in lista_tipova)
                        {
                            if (n.Id == ob.Id)
                            {
                                if (n.Obrisan == false)
                                {
                                    n.Obrisan = true;
                                    GenericSerialize.Serialize("tipovi_namestaja.xml", lista_tipova);

                                    break;
                                }
                                else if (n.Obrisan == true)
                                {
                                    n.Obrisan = false;
                                    GenericSerialize.Serialize("tipovi_namestaja.xml", lista_tipova);

                                    break;
                                }

                            }
                        }




                    }
                }

            }
            view.Refresh();
        }

    }
}

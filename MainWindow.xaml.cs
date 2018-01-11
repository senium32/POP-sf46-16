using POP_sf46_16_GUI.Databases;
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

        public DodatnaUsluga IzabranaUsluga { get; set; }

        public DodatnaUsluga DodatnaUsluga { get; set; }

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
            btnDodajAkciju.Visibility = Visibility.Hidden;
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
        private void Akcije_Istekle()
        {
            var lista_akcija = RadSaPodacima.Instance.Akcije;
            var lista = new List<Akcija>();
            var lista1 = new List<Akcija>();
            var lista_namestaja = RadSaPodacima.Instance.Namestaj;
            foreach (Akcija a in lista_akcija)
            {
                if (DateTime.Now > a.Datum_Zavrsetka)
                {
                    lista.Add(a);
                    foreach (Namestaj n in lista_namestaja)
                    {
                        if (n.NaPopustu == a)
                        {
                            n.NaPopustu = null;
                        }
                    }
                }

                
            }
            foreach (Akcija l in lista_akcija)
            {
                if (DateTime.Now < l.Datum_Zavrsetka)
                {
                    lista1.Add(l);
                }
                }
            GenericSerialize.Serialize("listaNam.xml", lista_namestaja);
            GenericSerialize.Serialize("Akcije.xml", lista_akcija);
        }
        private void btnDodajNaAkciju_Click(object sender, RoutedEventArgs e)
        {
            var dodaj_akciju_prozor = new DodajNaAkciju();
            dodaj_akciju_prozor.ShowDialog();

        }

        private void prikaz1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "AkcijskaCenaId" || e.Column.Header.ToString() == "Id" || e.Column.Header.ToString() == "Password" || e.Column.Header.ToString() == "Obrisan")
            {
                e.Cancel = true;

            }
        }


        private bool PrikazNeobrisanogNamestaja(object obj)
        {
            return ((Namestaj) obj).NaStanju == false;
        }
        private bool PrikazNeobrisanogTipaNamestaja(object obj)
        {
            return ((TipNamestaja)obj).Obrisan == false;
        }
        private bool PrikazNeobrisanogKorisnika(object obj)
        {
            return ((Korisnik)obj).Obrisan == false;
        }
        private bool PrikazNeobrisaneUsluge(object obj)
        {
            return ((DodatnaUsluga)obj).Obrisan == false;
        }
        private bool PrikazNeobrisaneAkcije(object obj)
        {
            return ((Akcija)obj).Obrisan == false;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnKorisnici_Click(object sender, RoutedEventArgs e)
        {
            operacija = "korisnik";
            btnDodajAkciju.Visibility = Visibility.Hidden;
            Objekat = null;
            Objekat = IzabraniKorisnik;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Korisnici);
            view.Filter = PrikazNeobrisanogKorisnika;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.AutoGeneratingColumn += prikaz1;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnTipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            operacija = "tipNamestaja";
            btnDodajAkciju.Visibility = Visibility.Hidden;
            Objekat = null;
            Objekat = IzabraniTipNamestaja;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.TipoviNamestaja);
            view.Filter = PrikazNeobrisanogTipaNamestaja;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.AutoGeneratingColumn += prikaz1;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        private void btnDodatnaUsluga_Click(object sender, RoutedEventArgs e)
        {
            operacija = "dodatna";
            btnDodajAkciju.Visibility = Visibility.Hidden;
            Objekat = null;
            Objekat = IzabranaUsluga;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.DodatnaUsluga);
            view.Filter = PrikazNeobrisaneUsluge;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.AutoGeneratingColumn += prikaz1;
            dgPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnAkcije_Click(object sender, RoutedEventArgs e)
        {
            operacija = "akcija";
            btnDodajAkciju.Visibility = Visibility.Visible;
            Objekat = null;
            Objekat = IzabranaAkcija;
            dgPrikaz.DataContext = this;
            view = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Akcije);
            view.Filter = PrikazNeobrisaneAkcije;
            dgPrikaz.ItemsSource = null;
            dgPrikaz.ItemsSource = view;
            dgPrikaz.IsSynchronizedWithCurrentItem = true;
            dgPrikaz.AutoGeneratingColumn += prikaz1;
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
                    var window = new Dodavanje_korisnika(1, zaDodati, "Novi");
                    window.ShowDialog();
                    RadSaPodacima.Instance.Korisnici.Clear();
                    Databases.KorisnikDatabase.popunjavanjeKorisnika();
                    view.Refresh();
                }
                else if (operacija.Equals("namestaj"))
                {
                    var zaDodati = new Namestaj()
                    {
                        Naziv = ""
                       
                    };
                    var window = new Dodaj_Namestaj_Window(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.Namestaj.Clear();
                    Databases.NamestajDatabase.popunjavanjeNamestaja();
                    view.Refresh();
                }
                else if (operacija.Equals("dodatna"))
                {
                    var zaDodati = new DodatnaUsluga()
                    {
                        Naziv = ""

                    };
                    var window = new DodajDodatakWindow(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.DodatnaUsluga.Clear();
                    Databases.DodatnaUslugaDatabase.popunjavanjeDodatneUsluge();
                    view.Refresh();
                }
                else if (operacija.Equals("tipNamestaja"))
                {
                    var zaDodati = new TipNamestaja()
                    {
                        Naziv = ""
                    };
                    var window = new Dodaj_TipNamestaja_Window(1, zaDodati);
                    window.ShowDialog();
                    RadSaPodacima.Instance.TipoviNamestaja.Clear();
                    Databases.TipNamestajaDatabase.popunjavanjeTipaNamestaja();
                    view.Refresh();
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
                    RadSaPodacima.Instance.Akcije.Clear();
                    Databases.AkcijaDatabase.popunjavanjeAkcija();
                    view.Refresh();
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
                    var window = new Dodavanje_korisnika(2, zaIzmenu, "Novi");
                    window.ShowDialog();
                    RadSaPodacima.Instance.Korisnici.Clear();
                    Databases.KorisnikDatabase.popunjavanjeKorisnika();
                    view.Refresh();

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
                    RadSaPodacima.Instance.Namestaj.Clear();
                    Databases.NamestajDatabase.popunjavanjeNamestaja();
                    view.Refresh();

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
                    RadSaPodacima.Instance.TipoviNamestaja.Clear();
                    Databases.TipNamestajaDatabase.popunjavanjeTipaNamestaja();
                    view.Refresh();

                }
                else
                {
                    MessageBox.Show(" Morate izabrati objekat za izmenu!! ");
                }
            }
            else if (operacija.Equals("dodatna"))
            {
                if (dgPrikaz.SelectedItem != null)
                {
                    DodatnaUsluga = (DodatnaUsluga)Objekat;
                    var prosledjenaUsluga = (DodatnaUsluga)DodatnaUsluga.Clone();
                    var window = new DodajDodatakWindow(2, prosledjenaUsluga);
                    window.ShowDialog();
                    RadSaPodacima.Instance.DodatnaUsluga.Clear();
                    Databases.DodatnaUslugaDatabase.popunjavanjeDodatneUsluge();
                    view.Refresh();

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
                    RadSaPodacima.Instance.Akcije.Clear();
                    Databases.AkcijaDatabase.popunjavanjeAkcija();
                    view.Refresh();

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
                    var Korisnik = (Korisnik)Objekat;
                    var ob = (Korisnik)Korisnik.Clone();
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati korisnika za brisanje!! ");
                    }
                    if (ob != null)
                    {
                        KorisnikDatabase.KorisnikIzbrisi(ob);
                        RadSaPodacima.Instance.Korisnici.Remove(ob);
                        RadSaPodacima.Instance.Korisnici.Clear();
                        Databases.KorisnikDatabase.popunjavanjeKorisnika();
                        view.Refresh();
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
                        NamestajDatabase.NamestajIzbrisi(ob);
                        RadSaPodacima.Instance.Namestaj.Remove(ob);
                        RadSaPodacima.Instance.Namestaj.Clear();
                        Databases.NamestajDatabase.popunjavanjeNamestaja();
                        view.Refresh();
                    }
                }
                else if (operacija.Equals("dodatna"))
                {
                    var lista_usluga = RadSaPodacima.Instance.DodatnaUsluga;
                    DodatnaUsluga = (DodatnaUsluga)Objekat;
                    var ob = (DodatnaUsluga)DodatnaUsluga.Clone();

                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {
                        DodatnaUslugaDatabase.DodatnaUslugaIzbrisi(ob);
                        RadSaPodacima.Instance.DodatnaUsluga.Remove(ob);
                        RadSaPodacima.Instance.DodatnaUsluga.Clear();
                        Databases.DodatnaUslugaDatabase.popunjavanjeDodatneUsluge();
                        view.Refresh();
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
                        AkcijaDatabase.AkcijaIzbrisi(ob);
                        RadSaPodacima.Instance.Akcije.Remove(ob);
                        RadSaPodacima.Instance.Akcije.Clear();
                        Databases.AkcijaDatabase.popunjavanjeAkcija();
                        view.Refresh();
                    }
                }
                else if (operacija.Equals("tipNamestaja"))
                {
                    var lista_tipova = RadSaPodacima.Instance.TipoviNamestaja;
                    var lista_namestaja = RadSaPodacima.Instance.Namestaj;
                    TipNamestaja = (TipNamestaja)Objekat;
                    var ob = (TipNamestaja)TipNamestaja.Clone();
                    if (ob == null)
                    {
                        MessageBox.Show(" Morate izabrati objekat za brisanje!! ");
                    }
                    else if (ob != null)
                    {
                        TipNamestajaDatabase.TipNamestajaIzbrisi(ob);
                        RadSaPodacima.Instance.TipoviNamestaja.Remove(ob);
                        NamestajDatabase.NamestajIzbrisiByTip(ob);
                        RadSaPodacima.Instance.TipoviNamestaja.Clear();
                        Databases.TipNamestajaDatabase.popunjavanjeTipaNamestaja();
                        RadSaPodacima.Instance.Namestaj.Clear();
                        Databases.NamestajDatabase.popunjavanjeNamestaja();
                        view.Refresh();
                    }
                }

            }
            view.Refresh();
        }

    }
}

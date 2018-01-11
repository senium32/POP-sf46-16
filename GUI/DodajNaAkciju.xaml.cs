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
    /// Interaction logic for DodajNaAkciju.xaml
    /// </summary>
    public partial class DodajNaAkciju : Window
    {
        private ICollectionView view1;
        private ICollectionView view2;
        private ICollectionView view3;
        private string operacija = "dodaj";

        public DodajNaAkciju()
        {
            InitializeComponent();
            view1 = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view1.Filter = PrikazNamestaja;
            cbNamestaji.ItemsSource = view1;
            view3 = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Akcije);
            cbAkcije.ItemsSource = view3;
        }
        private bool PrikazNamestaja(object obj)
        {
            return ((Namestaj)obj).NaStanju == false && ((Namestaj)obj).NaPopustu == null;
        }
        private bool PrikazNamestajaBez(object obj)
        {
            return ((Namestaj)obj).NaStanju == false && ((Namestaj)obj).NaPopustu != null;
        }
        private bool PrikazAkcija(object obj)
        {
            return DateTime.Now <= ((Akcija)obj).Datum_Zavrsetka;
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            var lista_namestaja = RadSaPodacima.Instance.Namestaj;
            Akcija dodata = (Akcija)cbAkcije.SelectedItem;
            Namestaj menjan = (Namestaj)cbNamestaji.SelectedItem;
            Namestaj uklonjen = (Namestaj)cbNamestajiBez.SelectedItem;
            if (operacija.Equals("dodaj"))
            {
                var msg_prazno = false;
                string poruka = " Niste uneli polje: ";
                if (cbNamestaji.SelectedItem == null)
                {
                    msg_prazno = true;
                    poruka += " Namestaji ";

                }
                if (cbAkcije.SelectedItem == null)
                {
                    msg_prazno = true;
                    poruka += " Akcije ";

                }
                if (msg_prazno == true)
                {
                    MessageBox.Show(poruka);
                }
                else if (msg_prazno == false)
                {
                    foreach (Namestaj n in lista_namestaja)
                    {
                        if (n.Id == menjan.Id)
                        {
                            n.NaPopustu = dodata;
                            NamestajDatabase.NamestajIzmeni(n);
                            break;
                        }
                        this.Close();
                    }
                }
            }
            else if (operacija.Equals("ukloni"))
            {
                var msg_prazno = false;
                string poruka = " Niste uneli polje: ";
                if (cbNamestajiBez.SelectedItem == null)
                {
                    msg_prazno = true;
                    poruka += " Namestaji ";

                }
                if (msg_prazno == true)
                {
                    MessageBox.Show(poruka);
                }
                else if (msg_prazno == false)
                {
                    foreach (Namestaj n in lista_namestaja)
                    {
                        if (n.Id == uklonjen.Id)
                        {
                            n.NaPopustu = null;
                            NamestajDatabase.NamestajIzmeni(n);
                            break;
                            this.Close();
                        }
                    }
                    this.Close(); 
                }
            }
        }

        private void btnDodajNa_Click(object sender, RoutedEventArgs e)
        {
            operacija = "dodaj";
            cbAkcije.IsEnabled = true;
            cbNamestaji.IsEnabled = true;
            cbNamestajiBez.IsEnabled = false;
            btnDodajNa.Background = new SolidColorBrush(Colors.DarkGreen);
            btnUkloniSa.Background = new SolidColorBrush(Colors.LightGreen);
            view1 = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view1.Filter = PrikazNamestaja;
            cbNamestaji.ItemsSource = view1;
            view3 = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Akcije);
            cbAkcije.ItemsSource = view3;
        }

        private void btnUkloniSa_Click(object sender, RoutedEventArgs e)
        {
            operacija = "ukloni";
            cbAkcije.IsEnabled = false;
            cbNamestaji.IsEnabled = false;
            cbNamestajiBez.IsEnabled = true;
            btnDodajNa.Background = new SolidColorBrush(Colors.LightGreen);
            btnUkloniSa.Background = new SolidColorBrush(Colors.DarkGreen);
            view2 = CollectionViewSource.GetDefaultView(RadSaPodacima.Instance.Namestaj);
            view2.Filter = PrikazNamestajaBez;
            cbNamestajiBez.ItemsSource = view2;
        }
    }
}

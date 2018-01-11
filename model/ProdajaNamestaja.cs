using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16_GUI.model
{
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int broj_racuna;
        private int broj_komada_namestaja;
        private DateTime datum_prodaje;
        private string kupac;
        private int namestajId;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public int NamestajId
        {
            get { return namestajId; }
            set { namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }



        public int Broj_Racuna
        {
            get { return broj_racuna; }
            set { broj_racuna = value;
                OnPropertyChanged("Broj_Racuna");
            }
        }
        public int Broj_Komada_Namestaja
        {
            get { return broj_komada_namestaja; }
            set { broj_komada_namestaja = value;
                OnPropertyChanged("Broj_Komada_Namestaja");
            }
        }
        public DateTime Datum_Prodaje
        {
            get { return datum_prodaje; }
            set { datum_prodaje = value;
                OnPropertyChanged("Datum_Prodaje");
            }
        }
        public string Kupac
        {
            get { return kupac; }
            set { kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                Broj_Racuna = broj_racuna,
                Broj_Komada_Namestaja = broj_komada_namestaja,
                Datum_Prodaje = datum_prodaje,
                Kupac = kupac,
                NamestajId = namestajId,
                Obrisan = obrisan
                
            };
        }
        public override string ToString()
        {
            return $"Broj Racuna: {Broj_Racuna}, Kupac: {Kupac}, kolicina: {Broj_Komada_Namestaja}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16_GUI.model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private string naziv;
        private DateTime datum_pocetka;
        private int popust;
        private DateTime datum_zavrsetka;
        private bool obrisan;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Naziv
        {
            get { return naziv; }
            set {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public DateTime Datum_Pocetka
        {
            get { return datum_pocetka; }
            set
            {
                datum_pocetka = value;
                OnPropertyChanged("Datum_Pocetka");
            }
        }
        public DateTime Datum_Zavrsetka
        {
            get { return datum_zavrsetka; }
            set { datum_zavrsetka = value; }
        }


        public int Popust
        {
            get { return popust; }
            set { popust = value;
                OnPropertyChanged("Popust");
            }
        }
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public static Akcija GetById(int? Id)
        {
            foreach (var popust in RadSaPodacima.Instance.Akcije)
            {
                if (popust.Id == Id)
                {
                    return popust;
                }
            }
            return null;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public override string ToString()
        {
            return $"Popust: {Popust}%";
        }

        public object Clone()
        {
            return new Akcija
            {
                Id = id,
                Naziv = naziv,
                Datum_Pocetka = datum_pocetka,
                Datum_Zavrsetka = datum_zavrsetka,
                Popust = popust,
                Obrisan = obrisan
            };
        }
    }

}

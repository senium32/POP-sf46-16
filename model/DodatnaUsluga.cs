using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16_GUI.model
{
   public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private int cena;
        private bool obrisan;


        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public int Cena
        {
            get { return cena; }
            set { cena = value;
                OnPropertyChanged("Cena");
            }
        }
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value;
                OnPropertyChanged("Obrisan");
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
        public override string ToString()
        {
            return $"{Naziv}";
        }

        public object Clone()
        {
            return new DodatnaUsluga
            {
                Naziv = naziv,
                Cena = cena,
                Obrisan = obrisan,
                Id = id
            };
        }
    }
}

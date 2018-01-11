using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16_GUI.model
{
    public class TipNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
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
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }

        

        
        public static TipNamestaja GetById(int? Id)
        {
            foreach (var tip in RadSaPodacima.Instance.TipoviNamestaja)
            {
                if (tip.Id == Id)
                {
                    return tip;
                }
            }
            return null;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return new TipNamestaja
            {
                Id = id,
                Naziv=naziv,
                Obrisan = obrisan
            };
        }

        public override string ToString()
        {
            return Naziv;
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

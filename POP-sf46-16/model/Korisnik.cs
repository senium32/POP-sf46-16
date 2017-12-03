using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16_GUI.model
{

    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private string ime;
        private string prezime;
        private string username;
        private string password;
        private string tip_korisnika;
        private bool obrisan;
        
        
        public string Username
        {
            get { return username; }
            set { username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value;
                OnPropertyChanged("Ime");
            }
        }

        

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        public string Tip_Korisnika
        {
            get { return tip_korisnika; }
            set
            {
                tip_korisnika = value;
                OnPropertyChanged("Tip_Korisnika");
            }
        }
        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }







        public event PropertyChangedEventHandler PropertyChanged;

        public object Clone()
        {
            return new Korisnik()
            {

                Ime = ime,
                Prezime = prezime,
                Username = username,
                Password = password,
                Tip_Korisnika = tip_korisnika,
                Obrisan = obrisan
            };
        }

        public override string ToString()
        {
            return $"Ime: {Ime}, Prezime: {Prezime}, Username: {Username}, Tip: {Tip_Korisnika} ";
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

using POP_sf46_16_GUI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16_GUI.model
{
    class RadSaPodacima
    {
        public static RadSaPodacima Instance { get; private set; } = new RadSaPodacima();

       
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<Akcija> Akcije { get; set; }

        public string ConnectionStr = @"Server=localhost\SQLEXPRESS;Initial Catalog=SeniumSalon;Trusted_Connection=True;";
        private RadSaPodacima()
        {
            TipoviNamestaja = new ObservableCollection<TipNamestaja>();
            Namestaj = new ObservableCollection<Namestaj>();
            Korisnici = new ObservableCollection<Korisnik>();
            Akcije = new ObservableCollection<Akcija>();
            DodatnaUsluga = new ObservableCollection<DodatnaUsluga>();
            ProdajaNamestaja = new ObservableCollection<ProdajaNamestaja>();
        }
    }
}
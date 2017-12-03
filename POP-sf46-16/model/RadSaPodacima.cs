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
        
        public ObservableCollection<Akcija> Akcije { get; set; }
        private RadSaPodacima()
        {
            TipoviNamestaja = GenericSerialize.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            Namestaj = GenericSerialize.Deserialize<Namestaj>("listaNam.xml");
            Korisnici = GenericSerialize.Deserialize<Korisnik>("Korisnici.xml");
            Akcije = GenericSerialize.Deserialize<Akcija>("Akcije.xml");
        }
    }
}
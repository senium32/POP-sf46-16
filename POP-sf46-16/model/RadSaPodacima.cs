using POP_sf46_16.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16.model
{
    class RadSaPodacima
    {
        public static RadSaPodacima Instance { get; private set; } = new RadSaPodacima();
        private List<TipNamestaja> tipovi_namestaja;
        private List<Namestaj> namestaj;
        private List<Korisnik> korisnik;
        private List<Akcija> akcija;

        public List<TipNamestaja> tipovi_Namestaja
        {
            get
            {
                tipovi_namestaja = GenericSerialize.Deserialize<TipNamestaja>("tipovi_namestaja.xml");

                return tipovi_namestaja;
            }
            set
            {
                tipovi_namestaja = value;
                GenericSerialize.Serialize<TipNamestaja>("tipovi_namestaja.xml", tipovi_namestaja);
            }
        }

        public List<Namestaj> namestaji
        {
            get
            {
                namestaj = GenericSerialize.Deserialize<Namestaj>("listaNam.xml");
                return namestaj;
            }
            set
            {
                namestaj = value;
                GenericSerialize.Serialize<Namestaj>("listaNam.xml", namestaj);
            }
        }

        public List<Korisnik> korisnici
        {
            get
            {
                korisnik = GenericSerialize.Deserialize<Korisnik>("Korisnici.xml");
                return korisnik;
            }
            set
            {
                korisnik = value;
                GenericSerialize.Serialize<Korisnik>("Korisnici.xml", korisnik);
            }
        }
        public List<Akcija> akcije
        {
            get
            {
                akcija = GenericSerialize.Deserialize<Akcija>("Akcije.xml");
                return akcija;
            }

            set
            {
                akcija = value;
                GenericSerialize.Serialize<Akcija>("Akcije.xml", akcija);
                
            }
        }
    }
}

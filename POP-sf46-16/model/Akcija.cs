using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_sf46_16.model
{
    public class Akcija
    {
        public int Id { get; set; }
        public DateTime Datum_Pocetka { get; set; }
        public decimal Popust { get; set; }
        public DateTime Datum_Zavrsetka { get; set; }
    }
}

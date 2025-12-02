using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepKomputerowy.Model
{
    public class Computer
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string ObrazekSrc { get; set; }
        public double Cena { get; set; }
        public string Kategoria { get; set; }
        public int DostepnaIlosc { get; set; }
    }
}

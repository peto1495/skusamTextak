using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzivatel
{
    public class Atributy
    {
        public string nazov { get; set; }
        public string description { get; set; }
        public int dlzka { get; set; }
        public string typ { get; set; }

        public Atributy(int aDlzka, string aNazov, string aDesc, string aTyp)
        {
            nazov = aNazov;
            description = aDesc;
            dlzka = aDlzka;
            typ = aTyp;
        }
    }
}

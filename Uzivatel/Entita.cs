using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzivatel
{
    public class Entita
    {
        public List<Atributy> poleAtributov { get; set; }
        public int ID { get; set; }
        public string nazov { get; set; }

        public Entita(int aID, string aNazov) 
        {
            poleAtributov = new List<Atributy>();
            ID = aID;
            nazov = aNazov;
        }

        public void pridajPrvok(Atributy aPrvok) 
        {
            poleAtributov.Add(aPrvok);
        }
    }
}

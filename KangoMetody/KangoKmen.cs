using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KangoMetody.ServiceKango;
using Uzivatel;

namespace KangoMetody
{
    public class KangoKmen
    {
        private KmenWSClient KmenKonektor;
        public bool prihlaseny { get; private set; }
        public bool pracovnyProjekt { get; private set; }
        private string[] projekty;
        private static WSEntityInfo[] WSEntity;

        public KangoKmen()
        {
            KmenKonektor = new KmenWSClient();
            prihlaseny = false;
            pracovnyProjekt = false;
        }

        public bool prihlas(string aMeno, string aHeslo)
        {
            if (KmenKonektor != null)
                prihlaseny = KmenKonektor.login(aMeno, aHeslo);
            return prihlaseny;
        }

        public void odhlas()
        {
            if (prihlaseny && KmenKonektor != null)
            {
                KmenKonektor.logout();
                prihlaseny = false;
                pracovnyProjekt = false;
            }
        }

        public string[] dajProjekty()
        {

            int i = 0;
            if (prihlaseny)
            {
                projekty = new string[KmenKonektor.getProjekty().Length];
                foreach (WSProjekt pr in KmenKonektor.getProjekty())
                {
                    projekty[i] = pr.nazov;
                    i++;
                }
                return projekty;
            }
            else
            {
                projekty = new string[0];
                return projekty;
            }


        }

        public bool nastavProjekt(string aProjekt)
        {
            if (prihlaseny)
            {
                foreach (WSProjekt pr in KmenKonektor.getProjekty())
                {
                    if (pr.nazov == aProjekt)
                    {
                        pracovnyProjekt = KmenKonektor.selectProjekt(pr);
                        break;
                    }
                }
            }
            return pracovnyProjekt;
        }

        public List<Entita> getEntityInfo()
        {
            List<Entita> pole = null;
            

            if(prihlaseny && pracovnyProjekt)
            {
                WSEntity = KmenKonektor.getEntityInfo();
                if (WSEntity != null)
                {
                    pole = new List<Entita>();
                    for (int i = 0; i < WSEntity.Length; i++) 
                    {
                        Entita en = new Entita(WSEntity[i].iD, WSEntity[i].name);

                        if (WSEntity[i].property != null)
                        {
                            
                            for (int j = 0; j < WSEntity[i].property.Length; j++)
                            {
                                Atributy atr = new Atributy(WSEntity[i].property[j].length, WSEntity[i].property[j].name, WSEntity[i].property[j].description, WSEntity[i].property[j].type);
                                en.pridajPrvok(atr);
                            }
                        }
                        pole.Add(en);
                        
                    }
                }
            }
            return pole;
        }
    }
}

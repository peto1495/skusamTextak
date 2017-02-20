using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Novacode;

namespace Uzivatel
{
    public class Projekt
    {
        // len tak skuska gitu
        //rtdfyguhijol
        public string vybranyProjekt { get; set; }
        public List<Entita> poleEntit { get; set; }
        public List<Entita> subor1 {get;set;}
        public List<Entita> subor2 { get; set; }

        public Projekt()
        {
            poleEntit = new List<Entita>();
        }

        public void pridajPrvok(Entita aPrvok) 
        {
            poleEntit.Add(aPrvok);
        }

        public void pridajPrvokSubor1(Entita aPrvok)
        {
            subor1.Add(aPrvok);
        }

        public void pridajPrvokSubor2(Entita aPrvok)
        {
            subor2.Add(aPrvok);
        }

        public string[] naplnSubor1(string aSubor)
        {
            string[] navratovePole = { "true", "OK" };
            subor1 = new List<Entita>();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(aSubor);
                string s;
                string[] rozdeleno;
                // čte řádek po řádku
                while ((s = sr.ReadLine()) != null)
                {

                    // rozdělí string řádku podle středníků
                    rozdeleno = s.Split(';');
                    if (rozdeleno[0] != "")
                    {
                        Entita ent = new Entita(int.Parse(rozdeleno[0]), rozdeleno[1]);

                        s = sr.ReadLine();
                        rozdeleno = s.Split(';');
                        int pocet = int.Parse(rozdeleno[0]);
                        for (int i = 0; i < pocet; i++)
                        {
                            s = sr.ReadLine();
                            rozdeleno = s.Split(';');
                            Atributy atr = new Atributy(int.Parse(rozdeleno[2]), rozdeleno[0], rozdeleno[3], rozdeleno[1]);
                            ent.pridajPrvok(atr);
                        }
                        pridajPrvokSubor1(ent);
                    }
                }
                sr.Close();

                return navratovePole;
            }
            catch (Exception e)
            {
                navratovePole[0] = "false";
                navratovePole[1] = e.Message.ToString();
                return navratovePole;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public string[] naplnSubor2(string aSubor)
        {
            string[] navratovePole = { "true", "OK" };
            subor2 = new List<Entita>();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(aSubor);


                string s;
                string[] rozdeleno;
                // čte řádek po řádku
                while ((s = sr.ReadLine()) != null)
                {

                    // rozdělí string řádku podle středníků
                    rozdeleno = s.Split(';');
                    if (rozdeleno[0] != "")
                    {
                        Entita ent = new Entita(int.Parse(rozdeleno[0]), rozdeleno[1]);

                        s = sr.ReadLine();
                        rozdeleno = s.Split(';');
                        int pocet = int.Parse(rozdeleno[0]);
                        for (int i = 0; i < pocet; i++)
                        {
                            s = sr.ReadLine();
                            rozdeleno = s.Split(';');
                            Atributy atr = new Atributy(int.Parse(rozdeleno[2]), rozdeleno[0], rozdeleno[3], rozdeleno[1]);
                            ent.pridajPrvok(atr);
                        }
                        pridajPrvokSubor2(ent);
                    }
                }
                sr.Close();

                return navratovePole;
            }
            catch (Exception e)
            {
                navratovePole[0] = "false";
                navratovePole[1] = e.Message.ToString();
                
                return navratovePole;
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public void ulozData() 
        {

            
            StreamWriter sw = null;

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".CSV"; // Default file extension
            dlg.Filter = "Format CSV (.csv)|*.csv"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                

                try
                {
                    sw = new StreamWriter(filename);

                    // projetí uživatelů
                    foreach (Entita u in poleEntit)
                    {
                      
                        string radek = String.Join(";", u.ID, u.nazov);
                        // zápis řádku
                        sw.WriteLine(radek);

                        int b = u.poleAtributov.Count;

                        radek = String.Join(";", b);

                        sw.WriteLine(radek);
                        foreach (Atributy atr in u.poleAtributov)
                        {
                            radek = String.Join(";", atr.nazov, atr.typ, atr.dlzka, atr.description);
                            sw.WriteLine(radek);
                        }
                        //}

                    }
                    // vyprázdnění bufferu
                    

                }
                catch
                {
                }
                finally
                {
                    if(sw != null)
                    {
                        sw.Flush();
                    }
                    
                }

            }
        }

        public string generujeWord()
        {
            //subor1
            int w = 0;
            int i = 0;
            Novacode.Table tabulka;

            BorderSize velk = BorderSize.six;
            BorderStyle styl = BorderStyle.Tcbs_single;
            int medzera = 0;

            Novacode.Border ram = new Novacode.Border();
            ram.Size = velk;
            ram.Space = medzera;
            ram.Tcbs = styl;
            ram.Color = System.Drawing.Color.Red;

            DocX dokument = DocX.Create("../../../bla.docx", Novacode.DocumentTypes.Document);

            foreach (Entita ent in subor1) 
            {
                dokument.InsertParagraph(ent.ID.ToString());
                dokument.InsertParagraph(ent.nazov);
                dokument.InsertParagraph("\n");

                dokument.InsertTable(ent.poleAtributov.Count, 4);
                i =0;
                foreach (Atributy atr in ent.poleAtributov)
                {
                    tabulka = dokument.Tables[w];
                    tabulka.SetBorder(TableBorderType.Bottom, ram);
                    tabulka.SetBorder(TableBorderType.Right, ram);
                    tabulka.SetBorder(TableBorderType.Left, ram);
                    tabulka.SetBorder(TableBorderType.Top, ram);
                    tabulka.SetBorder(TableBorderType.InsideV, ram);
                    tabulka.SetBorder(TableBorderType.InsideH, ram);

                    
                        tabulka.Rows[i].Cells[0].Paragraphs[0].InsertText(atr.nazov);
                        tabulka.Rows[i].Cells[1].Paragraphs[0].InsertText(atr.typ);
                        tabulka.Rows[i].Cells[2].Paragraphs[0].InsertText(atr.dlzka.ToString());
                        tabulka.Rows[i].Cells[3].Paragraphs[0].InsertText(atr.description);

                        i++;
                }
                w++;
            }
            try
            {
                dokument.Save();
                return "OK";
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }

        }

    }
}

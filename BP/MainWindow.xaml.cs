using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uzivatel;
using KangoMetody;

namespace BP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PrihlUdaje prihlUdaje;
        private KangoKmen kangoKmen;
        private Projekt dataSoServera;
        

        public MainWindow()
        {
            InitializeComponent();
            prihlUdaje = new PrihlUdaje();
            kangoKmen = new KangoKmen();
            dataSoServera = new Projekt();
        }

        private void OdhlasitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            kangoKmen.odhlas();
        }

        private void PrihlasitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            PrihlasovacieOkno prihlOkno = new PrihlasovacieOkno(prihlUdaje, kangoKmen);
            prihlOkno.ShowDialog();
        }

        private void ZobrazProjektyMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Projekty zobrProjekty = new Projekty(kangoKmen, dataSoServera);
            zobrProjekty.ShowDialog();
        }

        private void StiahniEntityMenuItem_Click(object sender, RoutedEventArgs e)
        {
            dataSoServera.poleEntit = kangoKmen.getEntityInfo();
            ZOBR.IsEnabled = true;
        }

        private void ZobrazEntoty_Click(object sender, RoutedEventArgs e)
        {
            Thickness marginEnt = new Thickness(0, 0, 0, 0);
            Thickness marginAtr = new Thickness(20, 0, 0, 0);
            CheckBox chb;
            foreach (Entita pp in dataSoServera.poleEntit)
            {
                chb = new CheckBox();
                chb.IsEnabled = true;
                chb.Content = pp.ID + " " + pp.nazov;
                chb.Margin = marginEnt;
                chb.IsChecked = true;
                ListBox.Items.Add(chb);
                foreach (Atributy atr in pp.poleAtributov)
                {
                    chb = new CheckBox();
                    chb.IsEnabled = true;
                    chb.Content = atr.nazov + " " + atr.typ;
                    chb.Margin = marginAtr;
                    ListBox.Items.Add(chb);
                    //ListBox.Items.Insert();
                }
            }
        }

        private void KontoOpen(object sender, RoutedEventArgs e)
        {
            if (kangoKmen.prihlaseny)
            {
                PrihlasitMenuItem.IsEnabled = false;
                OdhlasitMenuItem.IsEnabled = true;
            }
            else
            {
                PrihlasitMenuItem.IsEnabled = true;
                OdhlasitMenuItem.IsEnabled = false;
            }
        }

        private void ServerOpen(object sender, RoutedEventArgs e)
        {
            if (kangoKmen.prihlaseny)
            {
                ZobrazProjektyMenuItem.IsEnabled = true;
            }
            else
            {
                ZobrazProjektyMenuItem.IsEnabled = false;
            }

            if (kangoKmen.prihlaseny && kangoKmen.pracovnyProjekt)
            {

                StiahniEntityMenuItem.IsEnabled = true;
            }
            else
            {
                StiahniEntityMenuItem.IsEnabled = false;
            }
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            dataSoServera.ulozData();
        }

        private void NacitajSuboru_Click(object sender, RoutedEventArgs e)
        {
            PorovnanieSuborov ps = new PorovnanieSuborov(dataSoServera);
            ps.ShowDialog();
            dataSoServera.subor1 = null;
            dataSoServera.subor2 = null;
        }

        private void SuborOpen(object sender, RoutedEventArgs e)
        {
            if (dataSoServera.poleEntit.Count == 0)
            {
                SaveMenuItem.IsEnabled = false;
            }
            else 
            {
                SaveMenuItem.IsEnabled = true;
            }
            
        }
    }
}

/*
 if (kangoKmen.prihlaseny)
            {
                PrihlasitMenuItem.IsEnabled = false;
                OdhlasitMenuItem.IsEnabled = true;
            }
            else
            {
                PrihlasitMenuItem.IsEnabled = true;
                OdhlasitMenuItem.IsEnabled = false;
            }
 */
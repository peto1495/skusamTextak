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
using System.Windows.Shapes;
using KangoMetody;
using Uzivatel;

namespace BP
{
    /// <summary>
    /// Interaction logic for Projekty.xaml
    /// </summary>
    public partial class Projekty : Window
    {
        KangoKmen kangoKmen;
        Projekt dataSoServera;
        string[] projekt;
        

        public Projekty(KangoKmen aKmen, Projekt aData)
        {
            InitializeComponent();
            kangoKmen = aKmen;
            dataSoServera = aData;
            projekt = kangoKmen.dajProjekty();
            zobrazProjekty();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (sender as RadioButton);
            text.Text = rb.Content.ToString();
            dataSoServera.vybranyProjekt = rb.Content.ToString();
        }

        private void zobrazProjekty() 
        {
            foreach (string pr in projekt)
            {
                System.Windows.Thickness margin = new Thickness(10, 0, 0, 0);
                RadioButton rb = new RadioButton();
                rb.IsEnabled = true;
                rb.GroupName = "Os";
                rb.Margin = margin;
                rb.Checked += new RoutedEventHandler(RadioButton_Checked);
                rb.Content = pr;
                ListBox.Items.Add(rb);
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if(kangoKmen.nastavProjekt(dataSoServera.vybranyProjekt))
            {
                this.Close();
            }
            else 
            { 
                text.Text = "chyba";
            }
        }

        private void ZrusButton_Click(object sender, RoutedEventArgs e)
        {
            dataSoServera.vybranyProjekt = null;
            this.Close();
        }
    }
}

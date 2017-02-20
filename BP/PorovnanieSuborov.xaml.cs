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
using Uzivatel;
using System.Drawing;

namespace BP
{
    /// <summary>
    /// Interaction logic for PorovnanieSuborov.xaml
    /// </summary>
    public partial class PorovnanieSuborov : Window
    {
        private Projekt dataSoServera;
        

        public PorovnanieSuborov(Projekt aProj)
        {
            InitializeComponent();
            dataSoServera = aProj;
        }

        private void DajNazov_Click(object sender, RoutedEventArgs e)
        {
            
            Button bt = (sender as Button);

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".CSV"; // Default file extension
            dlg.Filter = "Format CSV (.csv)|*.csv"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;

                if (bt.Name == "Sub1")
                {
                    Sub1TextBox.Text = filename;
                }
                else 
                {
                    Sub2TextBox.Text = filename;
                }
            }

            if (Sub1TextBox.Text != "" && Sub2TextBox.Text != "")
            {
                NacitajSubory.IsEnabled = true;
            }
            else
            {
                NacitajSubory.IsEnabled = false;
            }
        }

        private void NacitajSubory_Click(object sender, RoutedEventArgs e)
        {

            string[] navrat1 = dataSoServera.naplnSubor1(Sub1TextBox.Text);
            string[] navrat2 = dataSoServera.naplnSubor2(Sub2TextBox.Text);

            if (bool.Parse(navrat1[0]) && bool.Parse(navrat2[0]))
            {
                GenerujDocXButton.IsEnabled = true;
            }
            else
            {
                string messageBoxText = (bool.Parse(navrat1[0]) != true ? navrat1[1] : "") + "\n" + (bool.Parse(navrat2[0]) != true ? navrat2[1] : "");
                string caption = "Chyba";

                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                GenerujDocXButton.IsEnabled = false;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            
            
        }

        private void nastavButton(object sender, MouseEventArgs e)
        {
            

            if (Sub1TextBox.Text != "" && Sub2TextBox.Text != "")
            {
                NacitajSubory.IsEnabled = true;
            }
            else
            {
                NacitajSubory.IsEnabled = false;
            }
        }

        private void GenerujDocXButton_Click(object sender, RoutedEventArgs e)
        {
            string chyba = dataSoServera.generujeWord();
            if (chyba != "OK")
            {
                string messageBoxText = chyba;
                string caption = "Chyba";

                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;

                GenerujDocXButton.IsEnabled = false;

                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }


    }
}

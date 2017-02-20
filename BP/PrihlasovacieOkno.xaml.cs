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
using KangoMetody;

namespace BP
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PrihlasovacieOkno : Window
    {
        PrihlUdaje udaje;
        KangoKmen kangoKmen;

        public PrihlasovacieOkno(PrihlUdaje aUdaje, KangoKmen aKmen)
        {
            InitializeComponent();
            udaje = aUdaje;
            kangoKmen = aKmen;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            udaje.meno = UzivatelTextBox.Text;
            udaje.heslo = HesloTextBox.Password;

            kangoKmen.prihlas(udaje.meno, udaje.heslo);

            this.Close();
        }
    }
}

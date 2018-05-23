using E4LISA.BDD;
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

namespace E4LISA.windows
{
    /// <summary>
    /// Logique d'interaction pour Zones.xaml
    /// </summary>
    public partial class Zones : Window
    {
        public Zones(ZONE ZoneAmodifier = null)
        {
            InitializeComponent();
            
            if (ZoneAmodifier == null)
            {
                this.DataContext = new ZONE();


            }
            else
            {

                this.DataContext = ZoneAmodifier;

            }
        }

        private void creer_Click(object sender, RoutedEventArgs e)
        {
            if (!verif())
            {
                MessageBox.Show("Coordonnée X + widht doit etre inferieur a 1080 et Coordonée Y et Height doit etre inferieur a 930");
            }
            else
            {
                this.DialogResult = true;
                this.Close();
            }
            
        }

        private void Anuller_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        public Boolean verif()
        {
            if (Int32.Parse(CooX.Text) + Int32.Parse(Widht.Text) > 1080 || Int32.Parse(CooY.Text) + Int32.Parse(Height.Text) > 930)
            {
             return false;
            }
            else
            {
             return true;
            }
        }
    }
}

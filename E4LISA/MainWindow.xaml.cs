using E4LISA.BDD;
using E4LISA.windows;
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

namespace E4LISA
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void connexion_Click(object sender, RoutedEventArgs e)
        {
            BDD.LISA_DIGITALEntities db = new BDD.LISA_DIGITALEntities();

            if ((db.UTILISATEUR.FirstOrDefault(x => x.Identifier == identifiant.Text) != null) && (db.UTILISATEUR.FirstOrDefault(x => x.Password == MotDePass.Password) != null))
            {
                Acceuil accueil = new Acceuil();
                accueil.Show();
                this.Close();
            }
            else if((db.ENTITE.FirstOrDefault(x => x.Identifier == identifiant.Text) != null) && (db.ENTITE.FirstOrDefault(x => x.Password == MotDePass.Password) != null))
            {
                List<ENTITE> Ent = db.ENTITE.Where(x => x.Identifier == identifiant.Text).Where(x => x.Password == MotDePass.Password).ToList();
                long a = 0;
                foreach (ENTITE Ents in Ent)
                {
                    a = Ents.Id;
                }
                Acceuil accueil = new Acceuil(a);
                accueil.Show();
                this.Close();
            }
        }
    }
}

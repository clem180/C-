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

namespace E4LISA.controle
{
    /// <summary>
    /// Logique d'interaction pour ListMagasin.xaml
    /// </summary>
    public partial class ListMagasin : UserControl
    {
        public long user = 0;
        public ListMagasin(long a)
        {
            InitializeComponent();
            user = a;
            RefreshDatas();
        }
        public void RefreshDatas()
        {
            if (user == 0)
            {
                this.DataContext = ((App)App.Current).entity.MAGASIN.ToList();
            }
            else
            {
                this.DataContext = ((App)App.Current).entity.MAGASIN.Where(x => x.ENT_Id == user).ToList();
            }
        }
        public void Ajouter()
        {
            Magasin window = new Magasin(null,user);
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde
                MAGASIN MAGASINToAdd = (MAGASIN)window.DataContext;
                if (user != 0)
                {
                    MAGASINToAdd.ENT_Id = user;
                }

                ((App)App.Current).entity.MAGASIN.Add(MAGASINToAdd);

                ((App)App.Current).entity.SaveChanges();
            }
            else
            {
                //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                ((App)App.Current).entity = new LISA_DIGITALEntities();
            }

            RefreshDatas();
        }

        public void Modifier()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                //Civilite civiliteAModifier = dataGridElements.SelectedItem as Civilite;
                MAGASIN MAGASINAModifier = (MAGASIN)dataGridElements.SelectedItem;

                Magasin window = new Magasin(MAGASINAModifier);
                window.ShowDialog();

                if (window.DialogResult.HasValue && window.DialogResult == true)
                {
                    //Sauvegarde
                    ((App)App.Current).entity.SaveChanges();
                }
                else
                {
                    //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                    ((App)App.Current).entity = new LISA_DIGITALEntities();
                }
            }
            else
            {
                MessageBox.Show("Merci de sélectionner un et un élément maximum");
            }
            RefreshDatas();
        }

        public void Supprimer()
        {
            if (dataGridElements.SelectedItems.Count == 1)
            {
                //Faire la modif
                MAGASIN civiliteASupprimer = (MAGASIN)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.MAGASIN.Remove(civiliteASupprimer);

                    //Sauvegarde
                    ((App)App.Current).entity.SaveChanges();
                }
                else
                {
                    //On rafraichit l'entity pour éviter les erreurs de données "fantomes" mal déliées
                    ((App)App.Current).entity = new LISA_DIGITALEntities();
                }
            }
            else
            {
                MessageBox.Show("Merci de sélectionner un et un élément maximum");
            }
            RefreshDatas();
        }
    }
}


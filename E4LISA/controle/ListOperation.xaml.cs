using E4LISA.BDD;
using E4LISA.windows;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour ListOperation.xaml
    /// </summary>
    public partial class ListOperation : UserControl
    {
        public long user;
        public ListOperation(long a = 0)
        {
            InitializeComponent();
            user = a;
            RefreshDatas();
        }
        public void RefreshDatas()
        {
            if (user != 0)
            {
                this.DataContext = ((App)App.Current).entity.OPERATION.SqlQuery("SELECT * FROM OPERATION INNER JOIN CATALOGUE ON CATALOGUE.OPE_Id = OPERATION.Id INNER JOIN CATALOGUE_ENTITE on CATALOGUE_ENTITE.CAT_Id = CATALOGUE.Id where CATALOGUE_ENTITE.ENT_Id = @id", new SqlParameter("@id", this.user)).ToList();

            }
            else
            {
                this.DataContext = ((App)App.Current).entity.OPERATION.ToList();
            }
        }
          
        public void Ajouter()
        {
            Operation window = new Operation();
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde
                OPERATION OPERATIONToAdd = (OPERATION)window.DataContext;


                ((App)App.Current).entity.OPERATION.Add(OPERATIONToAdd);

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
                OPERATION OPERATIONAModifier = (OPERATION)dataGridElements.SelectedItem;

                Operation window = new Operation(OPERATIONAModifier);
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
                OPERATION OPERATIONASupprimer = (OPERATION)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.OPERATION.Remove(OPERATIONASupprimer);

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


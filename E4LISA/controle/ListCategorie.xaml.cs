﻿using E4LISA.BDD;
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
    /// Logique d'interaction pour ListCategorie.xaml
    /// </summary>
    public partial class ListCategorie : UserControl
    {
        public long user;
        public ListCategorie(long a = 0)
        {
            InitializeComponent();
            user = a;
            RefreshDatas();

        }
        public void RefreshDatas()
        {
            if (user != 0)
            {
                this.DataContext = ((App)App.Current).entity.CATEGORIE.SqlQuery("SELECT CATEGORIE.Code,CATEGORIE.Label,CATEGORIE.ID FROM CATEGORIE INNER JOIN PRODUIT ON PRODUIT.CAT_Id = CATEGORIE.Id INNER JOIN ZONE ON ZONE.PRO_Id = PRODUIT.Id INNER JOIN PAGE ON PAGE.Id = ZONE.PAG_Id INNER JOIN CATALOGUE ON CATALOGUE.Id = PAGE.CAT_Id INNER JOIN CATALOGUE_ENTITE on CATALOGUE_ENTITE.CAT_Id = CATALOGUE.Id where CATALOGUE_ENTITE.ENT_Id = @id group by  CATEGORIE.Code,CATEGORIE.Label,CATEGORIE.ID", new SqlParameter("@id", this.user)).ToList();

            }
            else
            {
                this.DataContext = ((App)App.Current).entity.CATEGORIE.ToList();
            }


           
        }
        public void Ajouter()
        {
            Categorie window = new Categorie();
            window.ShowDialog();


            if (window.DialogResult.HasValue && window.DialogResult == true)
            {
                //Sauvegarde
                CATEGORIE CATEGORIEToAdd = (CATEGORIE)window.DataContext;


                ((App)App.Current).entity.CATEGORIE.Add(CATEGORIEToAdd);

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
                CATEGORIE CATEGORIEAModifier = (CATEGORIE)dataGridElements.SelectedItem;

                Categorie window = new Categorie(CATEGORIEAModifier);
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
                CATEGORIE civiliteASupprimer = (CATEGORIE)dataGridElements.SelectedItem;

                if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet élément ?",
                                    "Suppression",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((App)App.Current).entity.CATEGORIE.Remove(civiliteASupprimer);

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

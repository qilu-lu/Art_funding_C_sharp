using Art_fundingV0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art_fundingV0.Models
{
    interface IDalArtiste:IDisposable
    {
    
    
        int AjouterUserArtiste(string mailUA, string mot_de_passeUA, CreerArtisteViewModel artiste);
       
      
        utilisateurartiste AuthentifierArtiste(string mailUA, string mot_de_passeUA);

        void ModifierArtiste(int idartiste,string nom, string prenom, DateTime date_de_naissance, string adresse, string code_postale, string ville,
        string pays, string mail, string numero, int projet_id, string description, long ecole_choisie_id, Nullable<int> formation_choisie_id, string mot_de_passe, Nullable<System.DateTime> Disponibilite, int categorie_id);
  

        List<artiste> ObtientTousLesArtistes();
        artiste ObtientTousLesArtistes(int id);
        utilisateurartiste ObtientTousLesArtistes(string idStr);
        utilisateurartiste getUtilisateurArtisteParEmail(string mail);


        List<artiste> RechercheArtistes(string SearchString);
        List<artiste> ObtientArtistesContacte(int idEntreprise);


        byte[] ObtientContratEcole(int id);



    }
}

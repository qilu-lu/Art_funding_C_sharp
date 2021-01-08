using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
namespace Art_fundingV0.ViewModels
{
    public class DossierFinancementViewModel
    {
        public document_artiste documentArtiste { get; set; }
        public artiste artiste { get; set; }
        [Display(Name = "Etape de pré-financement: l'artiste choisi a bien adressé ses docuements. Le dossier est en cours de validation par nos services. Il sera ensuite adressé au centre de formation.")]
        public string messageDossierPreFinancement { get; set; }
        [Display(Name = "Le dossier est non-conforme et gardé sans suite. Vous pouvez contacter votre conseiller Art_Funding au 01 54 80 96 33 ou au artf.contact@artfunding.com.")]
        public string messageDossierNonConforme { get; set; }
        [Display(Name = "Nous arrivons à la dernière étape: veuillez vous rendre sur cette page afin de valider le financement. Une fois le contrat valider, il vous suffira d'imprimer le contrat et de le renvoyer à votre conseiller Art_Funding.")]
        public string messageFinancementAValider { get; set; }
        public List<artiste> TousLesArtistesFinancement { get; set; }
    }
}
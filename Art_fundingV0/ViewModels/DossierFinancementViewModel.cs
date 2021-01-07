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
        [Display(Name = "en attendant les dossiers d'artistes")]
        public string messageavecdoc { get; set; }
        [Display(Name = "dossier recu")]
        public string messagesansdoc { get; set; }
        [Display(Name = "contrat fini,vous pouvez télécharger ici")]
        public string messagesaveccontrat{ get; set; }
        public List<artiste> TousLesArtistesFinancement { get; set; }
        
    }
}
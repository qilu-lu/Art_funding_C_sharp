//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Art_fundingV0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class utilisateurentreprise
    {
        public int idUtilisateurEntreprise { get; set; }
        public string adresse_mailUE { get; set; }
        public string mot_de_passeUE { get; set; }
        public Nullable<int> identreprise { get; set; }
    
        public virtual entreprise entreprise { get; set; }
    }
}

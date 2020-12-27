using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.Models
{
    interface IDalEcole:IDisposable
    {
        ecole GetEcoleParId(int id);
        List<ecole> ObtientTousLesEcoles();
        List<categorie> ObtientTousLesCategories();

        
    }
}
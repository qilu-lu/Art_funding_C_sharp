using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art_fundingV0.Models
{
    public class DalEcole:IDalEcole
    {
        private art_fundingEntities context;

        public DalEcole()
        {
            context = new art_fundingEntities();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public ecole GetEcoleParId(int id)
        {
            throw new NotImplementedException();
        }

        public List<categorie> ObtientTousLesCategories()
        {
            return context.categories.ToList();
        }
        
        public List<ecole> ObtientTousLesEcoles()
        {
            return context.ecoles.ToList();
        }

    }
}
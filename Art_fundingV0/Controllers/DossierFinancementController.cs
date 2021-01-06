using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class DossierFinancementController : Controller
    {
        private DalArtiste dalArtiste;
     
        public DossierFinancementController(DalArtiste dalArtiste)
        {
            this.dalArtiste = dalArtiste;
        }

        // GET: DossierFinancement
       public ActionResult EtapeDossiersFinancement()
        {
            if (dalArtiste.VerificationDocEmis())
            {
                // etape dossier pré_finnancement
          

                if (dalArtiste.VerificationContrat())
                {
                    //Veuiller accepter le financement , une fois arriver il regirige vers une chekbox > elle regirige vers une page avec un pdg avec le contrat à charger
                    return View();
                }
                return View();
        }
            return View();
        }
    }
}
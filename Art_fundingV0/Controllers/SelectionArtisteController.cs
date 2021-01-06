using Art_fundingV0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Art_fundingV0.Controllers
{
    public class SelectionArtisteController : Controller
    {
        
            private IDalArtiste dalArtiste;
            public SelectionArtisteController() : this(new DalArtiste())
            {
            }
            private SelectionArtisteController(IDalArtiste dalIoc)
            {
                dalArtiste = dalIoc;
            }
            // GET: SelectionArtiste
            public ActionResult SelectionArtiste()
            {
                List<artiste> listArtiste = new List<artiste>();
                listArtiste = dalArtiste.ObtientTousLesArtistes();

                return View(listArtiste);
            }

            public ActionResult RechercheArtiste()
            {
                List<artiste> listArtiste = new List<artiste>();
                listArtiste = dalArtiste.ObtientTousLesArtistes();

                return View(listArtiste);
            }

        [HttpPost]
        public ActionResult RechercheArtiste(string searchString)
        {
            List<artiste> listArtiste = new List<artiste>();
            listArtiste = dalArtiste.RechercheArtistes(searchString);

            return View(listArtiste);
        }

    }
}

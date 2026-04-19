using SOLUCAO_TCC.Models.Viewmodels;
using SOLUCAO_TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOLUCAO_TCC.Controllers
{
    public class TelaPrincipalController : Controller
    {
        // GET: TelaPrincipal
        public ActionResult TelaPrincipalAdm()
        {
            return View();
        }

        public ActionResult TelaPrincipalUser()
        {
            List<Obra> obras = Model1.GetObraList();
            

            SelectViewModel obra = new SelectViewModel
            {
                Obra = obras,
            };

            return View(obra);
        }
    }
}
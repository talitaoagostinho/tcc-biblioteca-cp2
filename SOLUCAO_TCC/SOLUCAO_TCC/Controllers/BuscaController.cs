using SOLUCAO_TCC.Models;
using SOLUCAO_TCC.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOLUCAO_TCC.Controllers
{
    public class BuscaController : Controller
    {
        // GET: Busca
        public ActionResult Busca(string search, int tipo)
        {
            List<Obra> obras = new List<Obra>();

            if (tipo == 1) 
            {
               obras = Model1.BuscarObraNome(search); 
            }
            else if(tipo == 2)
            {
               obras = Model1.BuscarObraAutor(search);
            }
            else if (tipo == 3)
            {
                obras = Model1.BuscarObraGenero(search);
            }
            else if (tipo == 4)
            {
                obras = Model1.BuscarObraTipo(search);
            }

            SelectViewModel select = new SelectViewModel
            {
                Obra = obras
            };

            return PartialView(select);
        }
    }
}
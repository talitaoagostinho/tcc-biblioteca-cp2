using SOLUCAO_TCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace SOLUCAO_TCC.Controllers
{
    public class HomeController : UserController
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            base.OnActionExecuting(filterContext);


            Pessoa pessoa = Model1.GetPessoa(UserID);
            if (pessoa != null && pessoa.Status == 1)
            {
                filterContext.HttpContext.Response.Redirect("/TelaPrincipal/TelaPrincipalUser");
            }   
            else if (pessoa != null && pessoa.Status == 0)
            { 
                filterContext.HttpContext.Response.Redirect("/Admin/TelaEspera");   
            }
            else if (pessoa != null && pessoa.Status == 2)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/TelaRecusado");
            }
            else if (pessoa == null && Admin == true)
            {
                filterContext.HttpContext.Response.Redirect("/TelaPrincipal/TelaPrincipalAdm");
            }
            //status 2 = recusado
            //status 1 = aprovado
            //status 0 = pendente
        }

        public ActionResult TelaInicial()
        {
            return View();
        }


        public ActionResult Pesquisar(string Tipo, string Genero, bool Pdf, string Nome, string Autor)
        {
            List<Obra> obras = Model1.GetObraByFiltro(Tipo, Genero, Pdf, Nome, Autor);

            return View(obras);
        }
    }
}
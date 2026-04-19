using SOLUCAO_TCC.Models;
using SOLUCAO_TCC.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOLUCAO_TCC.Controllers
{
    public class EmprestimoController : UserController
    {
        // GET: Emprestimo
        public ActionResult UserEmprestimos()
        {
            List<Emprestimos> emprestimos = Model1.GetEmprestimosByUserId(UserID);

            List<Obra> obras = new List<Obra>();

            foreach (var item in emprestimos)
            {
                obras.Add(Model1.GetObra(item.Cod_Obra));
            }

            SelectViewModel view = new SelectViewModel
            {
                Emprestimos = emprestimos,
                Obra = obras
            };

            return View(view); 
        }

    }
}
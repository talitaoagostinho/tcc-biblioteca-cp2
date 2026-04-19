using Microsoft.AspNet.Identity;
using SOLUCAO_TCC.Models;
using SOLUCAO_TCC.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOLUCAO_TCC.Controllers
{
    public class ObraController : UserController
    {
        // GET: Obra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaginaObra(int Cod_Obra)
        {
            Obra obra = Model1.GetObra(Cod_Obra);

            List<Emprestimos> emprestimos = Model1.GetEmprestimosByObra(Cod_Obra);

            List<Pessoa> pessoas = new List<Pessoa>();

            foreach(var item in emprestimos)
            {
                pessoas.Add(Model1.GetPessoa(item.Id));
            }

            ObraEmprestimoUsuarioViewmodel viewmodel = new ObraEmprestimoUsuarioViewmodel()
            {
                Obra = obra,
                Emprestimos = emprestimos,
                Pessoas = pessoas
            };

            return View(viewmodel);
        }

        public ActionResult ObraDetalhe(int Id)
        {
            Obra obra = Model1.GetObra(Id);

            return PartialView(obra);

        }

        public ActionResult CadastrarEmprestimo(int Id)
        {
                Obra obra = Model1.GetObra(Id);
                return PartialView(obra);    
        }


        [HttpPost]
        public ActionResult Emprestimos(int Cod_Obra)
        {
            var inicio = DateTime.Today;
            var fim = inicio.AddDays(15);

            Model1.CadastrarEmprestimos(inicio, fim, Cod_Obra, UserID);

            Obra obra = Model1.GetObra(Cod_Obra);

            obra.Quantidade = obra.Quantidade - 1;

            Model1.UpdateObra(obra);

            return RedirectToAction("TelaPrincipalUser", "TelaPrincipal");
        }



    }
}
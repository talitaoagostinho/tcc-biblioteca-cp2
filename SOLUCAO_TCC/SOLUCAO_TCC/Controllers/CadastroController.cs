using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;
using SOLUCAO_TCC.Models;
using SOLUCAO_TCC.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SOLUCAO_TCC.Controllers
{
    public class CadastroController : UserController
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarPessoa()
        {
            return View();
        }

        public ActionResult CadastrarAluno()
        {
            List<Turmas> turmas = Model1.GetTurmas();

            CadastroViewModel cadastro = new CadastroViewModel
            {
                Turmas = turmas
            };

            return View(cadastro);

        }

        [HttpPost]

        public ActionResult CadastrarAluno(CadastroViewModel cadastro)
        {
            Model1.CadastrarPessoa(User.Identity.GetUserId(), cadastro.Pessoa.Nome, cadastro.Pessoa.Sobrenome, cadastro.Pessoa.Nascimento, cadastro.Pessoa.Sexo, cadastro.Pessoa.Celular, Model1.GetEmail(User.Identity.GetUserId()));
            Model1.CadastrarAluno(User.Identity.GetUserId(), cadastro.Aluno.Matricula, cadastro.Aluno.Turma);

            return RedirectToAction("TelaEspera", "Admin");
        }

        public ActionResult CadastrarFuncionario()
        {
            return View();
        }

        [HttpPost]

        public ActionResult CadastrarFuncionario(CadastroViewModel cadastro)
        {
            Model1.CadastrarPessoa(User.Identity.GetUserId(), cadastro.Pessoa.Nome, cadastro.Pessoa.Sobrenome, cadastro.Pessoa.Nascimento, cadastro.Pessoa.Sexo, cadastro.Pessoa.Celular, Model1.GetEmail(User.Identity.GetUserId()));
            Model1.CadastrarFuncionario(User.Identity.GetUserId(), cadastro.Funcionario.Matricula, cadastro.Funcionario.Funcao);

            return RedirectToAction("TelaEspera", "Admin");
        }
    }
}
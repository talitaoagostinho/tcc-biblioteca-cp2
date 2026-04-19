using Microsoft.AspNet.Identity;
using SOLUCAO_TCC.Models;
using SOLUCAO_TCC.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SOLUCAO_TCC.Controllers
{
    public class AdminController : UserController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TelaEspera()
        {
            return View();
        }

        public ActionResult TelaRecusado()
        {
            return View();
        }


        public ActionResult CadastrarObras()
        {
            return View();
        }


        public ActionResult EditObra(int Id)
        {
            Obra obra = Model1.GetObra(Id);
   
            return PartialView(obra);

        }

        [HttpPost]

        public ActionResult EditObra([Bind(Include = "Cod_Obra,Nome, Autor, Genero, Quantidade, Localizacao, Pdf, Tipo, Detalhes ")] Obra obra, HttpPostedFileBase img, HttpPostedFileBase link)
        {
            
            string rPath = "";
            string lPath = "";
            Obra obraAntiga = Model1.GetObra(obra.Cod_Obra);

            if(img != null)
            { 
                if (img.ContentLength > 0)
                {
                    string tempo = DateTime.Now.Ticks.ToString();
                    string _FileName = Path.GetFileName(img.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/imgdd"), tempo + _FileName);
                    rPath = Path.Combine("../../Content/imgdd", tempo + _FileName);
                    img.SaveAs(_path);

                    if (obraAntiga.Imagem != null)
                    {
                        string[] abc = obraAntiga.Imagem.Split('\\');
                        string OldPath = Path.Combine(Server.MapPath("/Content/imgdd"), abc[1]);
                        System.IO.File.Delete(OldPath);
                        obra.Imagem = rPath;
                    }
                    
                }
                else if (img.ContentLength == 0)
                {
                    obra.Imagem = obraAntiga.Imagem;
                }
            }
            else if(img == null)
            {
                obra.Imagem = obraAntiga.Imagem;
            }

            if (link != null)
            {
                if (link.ContentLength > 0)
                {
                    string tempo = DateTime.Now.Ticks.ToString();
                    string _FileName = Path.GetFileName(link.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/livros"), tempo + _FileName);
                    lPath = Path.Combine("../../Content/livros", tempo + _FileName);
                    link.SaveAs(_path);

                    if (obraAntiga.Pdf_Link != null)
                    {
                        string[] abc = obraAntiga.Pdf_Link.Split('\\');
                        string OldPath = Path.Combine(Server.MapPath("/Content/livros"), abc[1]);
                        System.IO.File.Delete(OldPath);
                        
                    }
                    obra.Pdf_Link = lPath;
                }
                else if (link.ContentLength == 0)
                {
                    obra.Pdf_Link = obraAntiga.Pdf_Link;
                }
            }
            else if (link == null)
            {
                obra.Pdf_Link = obraAntiga.Pdf_Link;
            }

            Model1.UpdateObra(obra);
                return RedirectToAction("GerenciarObra");
           
        }

        public ActionResult DeleteObra(int Id)
        {
            Obra obra = Model1.GetObra(Id);
            return PartialView(obra);
        }

        [HttpPost]
        public ActionResult Delete(int Cod_Obra)
        {
            Model1.DeleteObra(Cod_Obra);
            return RedirectToAction("GerenciarObra");
        }





        [HttpPost]
        public ActionResult CadastrarObras(CadastroViewModel cadastro, HttpPostedFileBase img, HttpPostedFileBase link)
        {
            string rPath = "";
            string lPath = "";
            if (img != null)
            {
                if (img.ContentLength > 0)
                {
                    string tempo = DateTime.Now.Ticks.ToString();
                    string _FileName = Path.GetFileName(img.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/imgdd"), tempo + _FileName);
                    rPath = Path.Combine("../../Content/imgdd", tempo + _FileName);
                    img.SaveAs(_path);
                }
            }
            if (link != null)
            {
                if (link.ContentLength > 0)
                {
                    string tempo = DateTime.Now.Ticks.ToString();
                    string _FileName = Path.GetFileName(link.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/livros"), tempo + _FileName);
                    lPath = Path.Combine("../../Content/livros", tempo + _FileName);
                    link.SaveAs(_path);
                }
            }

            Model1.CadastrarObra(cadastro.Obra.Cod_Obra, cadastro.Obra.Nome, cadastro.Obra.Autor, cadastro.Obra.Genero, cadastro.Obra.Quantidade,
            cadastro.Obra.Localizacao, cadastro.Obra.Pdf, cadastro.Obra.Tipo, cadastro.Obra.Detalhes, rPath,lPath) ;

            return RedirectToAction("GerenciarObra", "Admin");
        }


        public ActionResult AprovarUsers()
        {
            List<Aluno> alunos = Model1.GetAlunoList0();
            List<Pessoa> pessoas = Model1.GetPessoaList0();
            List<Funcionario> funcionarios = Model1.GetFuncionarioList0();

            SelectViewModel users = new SelectViewModel
            {
                Aluno = alunos,
                Pessoa = pessoas,
                Funcionario = funcionarios
            };

            return View(users);
        }

        [HttpPost]
        public ActionResult AprovarUser0(string Cod_Pessoa, int Operacao)
        {
            Pessoa pessoa = Model1.GetPessoa(Cod_Pessoa);
            Aluno aluno = Model1.GetAluno(Cod_Pessoa);
            Funcionario funcionario = Model1.GetFuncionario(Cod_Pessoa);

            if (pessoa != null && aluno != null && funcionario == null)
            {
                if (Operacao == 1)
                {
                    pessoa.Status = 1;
                    aluno.Status = 1;

                }
                else if (Operacao == 2)
                {
                    pessoa.Status = 2;
                    aluno.Status = 2;

                }
                Model1.UpdateAluno(aluno);
            }
            else if (pessoa != null && aluno == null && funcionario != null)
            {
                if (Operacao == 1)
                {
                    pessoa.Status = 1;
                    funcionario.Status = 1;

                }
                else if (Operacao == 2)
                {
                    pessoa.Status = 2;
                    funcionario.Status = 2;

                }
                Model1.UpdateFuncionario(funcionario);
            }

            Model1.UpdatePessoa(pessoa);
            
            

            return RedirectToAction("AprovarUsers", "Admin");

        }


        public ActionResult GerenciarAluno()
        {
            List<Aluno> alunos = Model1.GetAlunoList();
            List<Pessoa> pessoas = Model1.GetPessoaList();
            List<Funcionario> funcionarios = Model1.GetFuncionarioList();

            SelectViewModel users = new SelectViewModel
            {
                Aluno = alunos,
                Pessoa = pessoas,
                Funcionario = funcionarios
            };

            return View(users);
        }

        public ActionResult EditPessoa(string Cod_Pessoa)
        {
            Aluno aluno = Model1.GetAluno(Cod_Pessoa);
            Pessoa pessoa = Model1.GetPessoa(Cod_Pessoa);
            Funcionario funcionario = Model1.GetFuncionario(Cod_Pessoa);
            List<Turmas> turmas = Model1.GetTurmas();

            CadastroViewModel users = new CadastroViewModel
            {
                Aluno = aluno,
                Pessoa = pessoa,
                Funcionario = funcionario,
                Turmas = turmas
            };

            return PartialView(users);

        }

        [HttpPost]

        public ActionResult EditPessoa(CadastroViewModel cadastroViewModel)
        {
           
                if (cadastroViewModel.Aluno.Cod_Aluno != null)
                {
                    Model1.UpdateAluno(cadastroViewModel.Aluno);
                }
                else if (cadastroViewModel.Funcionario.Cod_Funcionario != null)
            {
                    Model1.UpdateFuncionario(cadastroViewModel.Funcionario);
                }
                Model1.UpdatePessoa(cadastroViewModel.Pessoa);

                return RedirectToAction("GerenciarAluno");
            
        }



        public ActionResult GerenciarObra()
        {
            List<Obra> obras = Model1.GetObraList();

            SelectViewModel obra = new SelectViewModel
            {
                Obra = obras,
            };

            return View(obra);
        }

        public ActionResult GerenciarEmprestimo()
        {

            List<Emprestimos> emprestimos = Model1.GetEmprestimos1();

            List<Obra> obras = new List<Obra>();
            List<Pessoa> pessoas = new List<Pessoa>();
            List<Funcionario> funcionarios = new List<Funcionario>();
            List<Aluno> alunos = new List<Aluno>();

            foreach (var item in emprestimos)
            {
                Funcionario func = Model1.GetFuncionario(item.Id);
                Aluno aluno = Model1.GetAluno(item.Id);

                obras.Add(Model1.GetObra(item.Cod_Obra));
                pessoas.Add(Model1.GetPessoa(item.Id));
                if (func != null)
                {
                       funcionarios.Add(func);
                }
                if (aluno != null)
                { 
                        alunos.Add(aluno);                  
                }

            }

            SelectViewModel view = new SelectViewModel
            {
                Emprestimos = emprestimos,
                Obra = obras,
                Pessoa = pessoas,
                Funcionario = funcionarios,
                Aluno = alunos
            };

            return View(view);
        }
        public ActionResult AprovarEmprestimos()
        {
            List<Emprestimos> emprestimos = Model1.GetEmprestimos0();

            List<Obra> obras = new List<Obra>();
            List<Pessoa> pessoas = new List<Pessoa>();
            List<Funcionario> funcionarios = new List<Funcionario>();
            List<Aluno> alunos = new List<Aluno>();

            foreach (var item in emprestimos)
            {
                Funcionario func = Model1.GetFuncionario(item.Id);
                Aluno aluno = Model1.GetAluno(item.Id);

                obras.Add(Model1.GetObra(item.Cod_Obra));
                pessoas.Add(Model1.GetPessoa(item.Id));
                if (func != null)
                {
                    funcionarios.Add(func);
                }
                if (aluno != null)
                {
                    alunos.Add(aluno);
                }
            

            }

            SelectViewModel view = new SelectViewModel
            {
                Emprestimos = emprestimos,
                Obra = obras,
                Pessoa = pessoas,
                Funcionario = funcionarios,
                Aluno = alunos
            };

            return View(view);
        }

        [HttpPost]
        public ActionResult AprovarEmprestimos(int Cod_Emprestimo, int Operacao)
        {
            Emprestimos emprestimos = Model1.GetEmprestimos(Cod_Emprestimo);

                if (Operacao == 1)
                {
                    emprestimos.Status = 1;   
                }
                else if (Operacao == 2)
                {
                    emprestimos.Status = 2;
                }
                
            Model1.UpdateEmprestimo(emprestimos);

            return RedirectToAction("AprovarEmprestimos", "Admin");

        }

        public ActionResult DevolverObra(int Id)
        {
            Emprestimos emprestimos = Model1.GetEmprestimos(Id);

            return PartialView(emprestimos);
        }


        [HttpPost]
        public ActionResult Devolver(int Cod_Emprestimo)
        {
            Emprestimos emprestimos = Model1.GetEmprestimos(Cod_Emprestimo);
            emprestimos.Status = 3;

            Obra obra = Model1.GetObra(emprestimos.Cod_Obra);
            obra.Quantidade = obra.Quantidade + 1;

            Model1.UpdateObra(obra);
            Model1.UpdateEmprestimo(emprestimos);


            return RedirectToAction("GerenciarEmprestimo", "Admin");
        }

        public ActionResult UserPendente()
        {
            List<Pessoa> pessoas = Model1.GetPessoaPendente();

            List<Aluno> alunos = new List<Aluno>();

            List<Funcionario> funcionarios = new List<Funcionario>();

            foreach(var item in pessoas)
            {
                alunos.Add(Model1.GetAluno(item.Cod_Pessoa));
                funcionarios.Add(Model1.GetFuncionario(item.Cod_Pessoa));
            }


            AprovarViewmodel viewmodel = new AprovarViewmodel()
            {
                Pessoas = pessoas,
                Alunos = alunos,
                Funcionarios = funcionarios
            };

            return View(viewmodel);
        }

        
    }
}
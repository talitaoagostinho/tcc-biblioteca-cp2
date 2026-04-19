using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web.DynamicData;
using System.Web.Services.Description;

namespace SOLUCAO_TCC.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=lab")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Emprestimos> Emprestimos { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Obra> Obra { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Emprestimos)
                .WithRequired(e => e.AspNetUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Obra>()
                .HasMany(e => e.Emprestimos)
                .WithRequired(e => e.Obra)
                .WillCascadeOnDelete(false);
        }

     

        public static List<Aluno> GetAlunoList()
        {
            using (var context = new Model1())
            {
                var query = from Aluno in context.Aluno
                            where Aluno.Status == 1
                            select Aluno;

                var aluno = query.ToList();
                return aluno;
            }
        }

        public static List<Aluno> GetAlunoList0()
        {
            using (var context = new Model1())
            {
                var query = from Aluno in context.Aluno
                            where Aluno.Status == 0
                            select Aluno;

                var aluno = query.ToList();
                return aluno;
            }

        }



        public static Aluno GetAluno(string Cod_Aluno)
        {
            using (var context = new Model1())
            {
                var query = from Aluno in context.Aluno
                            where Aluno.Cod_Aluno == Cod_Aluno
                            select Aluno;

                var aluno = query.SingleOrDefault();
                return aluno;
            }

        }


        public static void CadastrarAluno(string Cod_Aluno, string Matricula, string Turma)
        {
            
                using (var context = new Model1())
                {
                    Aluno Aluno = new Aluno
                    {
                        Cod_Aluno = Cod_Aluno,
                        Matricula = Matricula,
                        Turma = Turma,
                        Status = 0
                    };

                    context.Aluno.Add(Aluno);
                    context.SaveChanges();
                }        
        }

        

       

        public static List<Funcionario> GetFuncionarioList()
        {
            using (var context = new Model1())
            {
                var query = from Funcionario in context.Funcionario
                            where Funcionario.Status == 1
                            select Funcionario;

                var funcionario = query.ToList();
                return funcionario;
            }

        }

        public static List<Funcionario> GetFuncionarioList0()
        {
            using (var context = new Model1())
            {
                var query = from Funcionario in context.Funcionario
                            where Funcionario.Status == 0
                            select Funcionario;

                var funcionario = query.ToList();
                return funcionario;
            }

        }

        public static Funcionario GetFuncionario(string Cod_Funcionario)
        {
            using (var context = new Model1())
            {
                var query = from Funcionario in context.Funcionario
                            where Funcionario.Cod_Funcionario == Cod_Funcionario
                            select Funcionario;

                var funcionario = query.SingleOrDefault();
                return funcionario;
            }

        }

        public static void CadastrarFuncionario(string Cod_Funcionario, string Matricula, string Funcao)
        {
            using (var context = new Model1())
            {
                Funcionario Funcionario = new Funcionario
                {
                    Cod_Funcionario = Cod_Funcionario,
                    Matricula = Matricula,
                    Funcao = Funcao,
                    Status = 0
                };
                context.Funcionario.Add(Funcionario);
                context.SaveChanges();
            }
        }

        public static List<Pessoa> GetPessoaList()
        {
            using (var context = new Model1())
            {
                var query = from Pessoa in context.Pessoa
                            where Pessoa.Status == 1
                            select Pessoa;

                var pessoa = query.ToList();
                return pessoa;
            }

        }
        public static List<Pessoa> GetPessoaList0()
        {
            using (var context = new Model1())
            {
                var query = from Pessoa in context.Pessoa
                            where Pessoa.Status == 0
                            select Pessoa;

                var pessoa = query.ToList();
                return pessoa;
            }

        }

        public static List<Obra> GetObraList()
        {
            using (var context = new Model1())
            {
                var query = from Obra in context.Obra
                            select Obra;

                var obra = query.ToList();
                return obra;
            }

        }

        public static Pessoa GetPessoa(string Cod_Pessoa)
        {
            using (var context = new Model1())
            {
                var query = from Pessoa in context.Pessoa
                            where Pessoa.Cod_Pessoa == Cod_Pessoa
                            select Pessoa;

                var pessoa = query.SingleOrDefault();
                return pessoa;
            }

        }

        



        public static List<Pessoa> GetPessoaPendente()
        {
            using (var context = new Model1())
            {
                var query = from Pessoa in context.Pessoa
                            where Pessoa.Status == 0
                            select Pessoa;

                var pessoa = query.ToList();
                return pessoa;
            }

        }

        public static void CadastrarPessoa(string Cod_Pessoa, string Nome, string Sobrenome, DateTime Nascimento, string Sexo, string Celular, string Email)
        {
            using (var context = new Model1())
            {        
                    Pessoa Pessoa = new Pessoa
                    {
                        Cod_Pessoa = Cod_Pessoa,
                        Nome = Nome,
                        Sobrenome = Sobrenome,
                        Nascimento = Nascimento,
                        Sexo = Sexo,
                        Celular = Celular,
                        Status = 0,
                        Email = Email
                    };
                    context.Pessoa.Add(Pessoa);
                    context.SaveChanges();         
            }
        }

        public static AspNetUsers GetUser(string Id)
        {
            using (var context = new Model1())
            {
                var query = from AspNetUsers in context.AspNetUsers
                            where AspNetUsers.Id == Id
                            select AspNetUsers;

                var aspnetuser = query.SingleOrDefault();
                return aspnetuser;
            }
        }

        public static Emprestimos GetEmprestimos(int Cod_Emprestimo)
        {
            using (var context = new Model1())
            {
                var query = from Emprestimos in context.Emprestimos
                            where Emprestimos.Cod_Emprestimo == Cod_Emprestimo
                            select Emprestimos;

                var emprestimos = query.SingleOrDefault();
                return emprestimos;
            }

        }

        public static List<Emprestimos> GetEmprestimos0()
        {
            using (var context = new Model1())
            {
                var query = from Emprestimos in context.Emprestimos
                            where Emprestimos.Status == 0
                            select Emprestimos;

                var emprestimos = query.ToList();
                return emprestimos;
            }

        }

        public static List<Emprestimos> GetEmprestimos1()
        {
            using (var context = new Model1())
            {
                var query = from Emprestimos in context.Emprestimos
                            where Emprestimos.Status == 1
                            select Emprestimos;

                var emprestimos = query.ToList();
                return emprestimos;
            }

        }

        public static List<Emprestimos> GetEmprestimosByObra(int Cod_Obra)
        {
            using (var context = new Model1())
            {
                var query = from Emprestimos in context.Emprestimos
                            where Emprestimos.Cod_Obra == Cod_Obra
                            select Emprestimos;

                var emprestimos = query.ToList();
                return emprestimos;
            }

        }
        public static void CadastrarEmprestimos(DateTime DataInicio, DateTime DataFim, int fk_Cod_Obra, string fk_Id)
        {
            using (var context = new Model1())
            {
                Emprestimos Emprestimos = new Emprestimos
                {
                    DataInicio = DataInicio,
                    DataFim = DataFim,
                    Status = 0,
                    Cod_Obra = fk_Cod_Obra,
                    Id = fk_Id
                };
                context.Emprestimos.Add(Emprestimos);
                context.SaveChanges();
            }
        }

        public static Obra GetObra(int Cod_Obra)
        {
            using (var context = new Model1())
            {
                var query = from Obra in context.Obra
                            where Obra.Cod_Obra == Cod_Obra
                            select Obra;

                var obra = query.SingleOrDefault();
                return obra;
            }

        }

        public static void UpdateAluno(Aluno item)
        {
            using (var context = new Model1())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void UpdatePessoa(Pessoa item)
        {
            using (var context = new Model1())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public static void UpdateFuncionario(Funcionario item)
        {
            using (var context = new Model1())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public static void UpdateObra(Obra item)
        {
            using (var context = new Model1())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void UpdateEmprestimo(Emprestimos item)
        {
            using (var context = new Model1())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public static Admin GetAdmin(string Id)
        {
            using (var context = new Model1())
            {
                var query = from Admin in context.Admin
                            where Admin.Id == Id
                            select Admin;

                var admin = query.SingleOrDefault();
                return admin;
            }

        }



        public static List<Obra> GetObraByFiltro(string Tipo, string Genero, bool Pdf, string Nome, string Autor)
        {
            using (var context = new Model1())
            {
                var query = from Obra in context.Obra  
                            select Obra;

                var obra = query.ToList();

                if(Tipo != null && Tipo != "")
                {
                    obra.RemoveAll(x => x.Tipo != Tipo);
                }
                if (Genero != null && Genero != "")
                {
                    obra.RemoveAll(x => x.Genero != Genero);
                }
                if (Pdf != false)
                {
                    obra.RemoveAll(x => x.Pdf != Pdf);
                }
                if (Nome != null && Nome != "")
                {
                    obra.RemoveAll(x => x.Nome != Nome);
                }
                if (Autor != null && Autor != "")
                {
                    obra.RemoveAll(x => x.Autor != Autor);
                }
                return obra;
            }

        }

        public static void CadastrarObra(int Cod_Obra, string Nome, string Autor, string Genero, int Quantidade, string Localizacao, bool Pdf, string Tipo, string Detalhes, string Imagem, string Pdf_Link)
        {
            using (var context = new Model1())
            {
                Obra Obra = new Obra
                {
                    Cod_Obra = Cod_Obra,
                    Nome = Nome,
                    Autor = Autor,
                    Genero = Genero,
                    Quantidade = Quantidade,
                    Localizacao = Localizacao,
                    Pdf = Pdf,
                    Tipo = Tipo,
                    Detalhes = Detalhes,
                    Imagem = Imagem,
                    Pdf_Link = Pdf_Link
                };
                context.Obra.Add(Obra);
                context.SaveChanges();
            }
        }



        public static List<Turmas> GetTurmas()
        {
            using (var context = new Model1())
            {
                var query = from Turmas in context.Turmas
                            select Turmas;

                var listaTurmas = query.ToList();
        
                return listaTurmas;
            }
        }

        public static string GetEmail(string uID)
        {
            using (var context = new ApplicationDbContext())
            {
                var query = from AspNetUsers in context.Users
                            where AspNetUsers.Id == uID
                            select AspNetUsers.Email;
                string Email = query.SingleOrDefault();

                return Email;
            }
        }

        public static void DeleteObra(int Cod_Obra)
        {
            using (var context = new Model1())
            {
                Obra obra = context.Obra.Find(Cod_Obra);
                context.Obra.Remove(obra);
                context.SaveChanges();
            }
        }

        public static void DeletePessoa(string Cod_Pessoa)
        {
            using (var context = new Model1())
            {
                Pessoa pessoa = context.Pessoa.Find(Cod_Pessoa);
                context.Pessoa.Remove(pessoa);
                context.SaveChanges();
            }
        }

        public static void DeleteAluno(string Cod_Aluno)
        {
            using (var context = new Model1())
            {
                Aluno aluno = context.Aluno.Find(Cod_Aluno);
                context.Aluno.Remove(aluno);
                context.SaveChanges();
            }
        }

        public static void DeleteFuncionario(string Cod_Funcionario)
        {
            using (var context = new Model1())
            {
                Funcionario funcionario = context.Funcionario.Find(Cod_Funcionario);
                context.Funcionario.Remove(funcionario);
                context.SaveChanges();
            }
        }

        public static List<Obra> BuscarObraNome(string texto)
        {
            using (var context = new Model1())
            {
                var query = from Obra in context.Obra
                            where Obra.Nome.Contains(texto) || 
                            Obra.Detalhes.Contains(texto)
                            select Obra;

                var resultado = query.ToList();
                    return resultado;
            }
        }

        public static List<Obra> BuscarObraAutor(string texto)
        {
            using (var context = new Model1())
            {
                var query = from Obra in context.Obra
                            where Obra.Autor.Contains(texto) 
                            select Obra;

                var resultado = query.ToList();
                return resultado;
            }
        }
        public static List<Obra> BuscarObraGenero(string texto)
        {
            using (var context = new Model1())
            {
                var query = from Obra in context.Obra
                            where Obra.Genero.Contains(texto)
                            select Obra;

                var resultado = query.ToList();
                return resultado;
            }
        }

        public static List<Obra> BuscarObraTipo(string texto)
        {
            using (var context = new Model1())
            {
                var query = from Obra in context.Obra
                            where Obra.Tipo.Contains(texto)
                            select Obra;

                var resultado = query.ToList();
                return resultado;
            }
        }

        public static List<Emprestimos> GetEmprestimosByUserId(string UserId)
        {
            using (var context = new Model1())
            {
                var query = from Emprestimos in context.Emprestimos
                            where Emprestimos.Id == UserId
                            select Emprestimos;

                var x = query.ToList();
                return x;
            }
        }

    }
}

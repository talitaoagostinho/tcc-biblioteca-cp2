using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLUCAO_TCC.Models.Viewmodels
{
    public class CadastroViewModel
    { 
        public Aluno Aluno { get; set; }
        public Funcionario Funcionario { get; set; }
        public Pessoa Pessoa { get; set; }
        public AspNetUsers AspNetUsers { get; set; }
        public List<Turmas> Turmas { get; set; }
        public string Sexo { get; set; }
        public Obra Obra { get; set; }
        public Emprestimos Emprestimos { get; set; }
    }
}
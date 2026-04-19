using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLUCAO_TCC.Models.Viewmodels
{
    public class SelectViewModel
    {
        public List<Aluno> Aluno { get; set; }
        public List<Funcionario> Funcionario { get; set; }
        public List<Pessoa> Pessoa { get; set; }
        public List<Obra> Obra { get; set; }
        public List<Emprestimos> Emprestimos { get; set; }
        public List<AspNetUsers> AspNetUsers { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOLUCAO_TCC.Models.Viewmodels
{
    public class AprovarViewmodel
    {
        public List<Pessoa> Pessoas { get; set; }
        public List<Aluno> Alunos { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
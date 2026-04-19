namespace SOLUCAO_TCC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aluno")]
    public partial class Aluno
    {
        [Key]
        public string Cod_Aluno { get; set; }

        [Required]
        [StringLength(7)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(50)]
        public string Turma { get; set; }

        public int Status { get; set; }

    }
 
}

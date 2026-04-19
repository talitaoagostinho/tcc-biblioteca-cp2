namespace SOLUCAO_TCC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Funcionario")]
    public partial class Funcionario
    {
        [Key]
        public string Cod_Funcionario { get; set; }

        [Required]
        [StringLength(7)]
        public string Matricula { get; set; }

        [Required]
        [StringLength(50)]
        public string Funcao { get; set; }

        public int Status { get; set; }
    }
}

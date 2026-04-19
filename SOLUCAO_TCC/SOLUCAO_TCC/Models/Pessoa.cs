namespace SOLUCAO_TCC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pessoa")]
    public partial class Pessoa
    {
        [Key]
        public string Cod_Pessoa { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Column(TypeName = "date")]
        public DateTime Nascimento { get; set; }

        [Required]
        [StringLength(50)]
        public string Sexo { get; set; }

        [Required]
        [StringLength(11)]
        public string Celular { get; set; }

        public int Status { get; set; }

        [StringLength(256)]
        public string Email { get; set; }
    }
}

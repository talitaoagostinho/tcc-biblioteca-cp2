namespace SOLUCAO_TCC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Emprestimos
    {
        [Key]
        public int Cod_Emprestimo { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int Status { get; set; }

        [Required]

        public int Cod_Obra { get; set; }

        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Obra Obra { get; set; }
    }
}

namespace SOLUCAO_TCC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Turmas")]
    public partial class Turmas
    {
        [Key]
        public int Id { get; set; }

        [StringLength(5)]
        public string Nome { get; set; }

    }
}

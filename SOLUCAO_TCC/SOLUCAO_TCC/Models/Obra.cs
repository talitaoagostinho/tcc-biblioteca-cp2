namespace SOLUCAO_TCC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Obra")]
    public partial class Obra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Obra()
        {
            Emprestimos = new HashSet<Emprestimos>();
        }

        [Key]
        public int Cod_Obra { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        [StringLength(50)]
        public string Genero { get; set; }

        public int Quantidade { get; set; }

        [Required]
        public string Localizacao { get; set; }

        public bool Pdf { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        public string Detalhes { get; set; }
        public string Imagem { get; set; }

        public string Pdf_Link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Emprestimos> Emprestimos { get; set; }
    }
}

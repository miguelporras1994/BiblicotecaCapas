namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class libros
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        ////public libros()
        ////{
        ////    Historial = new HashSet<Historial>();
        ////}

        [Key]
        public int Id_Libro { get; set; }

        [Required]
        [StringLength(60)]
        public string Titulo { get; set; }

        public int? Id_Genero { get; set; }

        [Required]
        [StringLength(60)]
        public string Genero { get; set; }

        public int? Id_Marca { get; set; }

        [Required]
        [StringLength(60)]
        public string Marca { get; set; }

        public int? Id_Estado { get; set; }

        [StringLength(60)]
        public string Nom_Estado { get; set; }

        public string Autor { get; set; }

        //public virtual Estados Estados { get; set; }

        //public virtual Generos Generos { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Historial> Historial { get; set; }

        //public virtual Marcas Marcas { get; set; }
    }
}

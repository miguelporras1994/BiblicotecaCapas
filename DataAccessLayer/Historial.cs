namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historial")]
    public partial class Historial
    {
        [Key]
        public int Id_Historial { get; set; }

        [StringLength(20)]
        public string Id_Tercero { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre_Ter { get; set; }

        public int? Id_Libro { get; set; }

        [Required]
        [StringLength(60)]
        public string Titulo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Pres { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Devo { get; set; }

        public int? Id_Estado { get; set; }

        [Required]
        [StringLength(60)]
        public string Nom_Estado { get; set; }

        //public virtual Estados Estados { get; set; }

        //public virtual libros libros { get; set; }

        //public virtual Tercero Tercero { get; set; }
    }
}

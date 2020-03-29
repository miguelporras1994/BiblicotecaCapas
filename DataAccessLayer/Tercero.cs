namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tercero")]
    public partial class Tercero
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tercero()
        {
            Historial = new HashSet<Historial>();
        }

        [Key]
        [StringLength(20)]
        public string Id_Tercero { get; set; }

        [Required]
        [StringLength(60)]
        public string Nombre_Ter { get; set; }

        [Required]
        [StringLength(60)]
        public string Apellido_Ter { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Correo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Nacimi { get; set; }

        [Required]
        [StringLength(80)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(60)]
        public string Localidad { get; set; }

        [Required]
        [StringLength(60)]
        public string Cuidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historial> Historial { get; set; }
    }
}

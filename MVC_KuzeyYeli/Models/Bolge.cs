namespace MVC_KuzeyYeli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bolge")]
    public partial class Bolge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bolge()
        {
            Bolgelers = new HashSet<Bolgeler>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BolgeID { get; set; }

        [Required]
        [StringLength(50)]
        public string BolgeTanimi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bolgeler> Bolgelers { get; set; }
    }
}

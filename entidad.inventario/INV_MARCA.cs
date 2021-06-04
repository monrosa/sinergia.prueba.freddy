namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_MARCA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_MARCA()
        {
            INV_PRODUCTO = new HashSet<INV_PRODUCTO>();
        }

        [Key]
        public int INV_MARCA_ID { get; set; }

        [Required]
        public string INV_DETALLE_MARCA { get; set; }

        [Required]
        [StringLength(1)]
        public string INV_ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PRODUCTO> INV_PRODUCTO { get; set; }
    }
}

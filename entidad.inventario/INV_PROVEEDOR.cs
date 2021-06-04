namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_PROVEEDOR()
        {
            INV_PRODUCTO = new HashSet<INV_PRODUCTO>();
        }

        [Key]
        public int INV_PROVEEDOR_ID { get; set; }

        [Required]
        [StringLength(13)]
        public string INV_RUC { get; set; }

        public string INV_DETALLE_PROVEEDOR { get; set; }

        [Required]
        [StringLength(1)]
        public string INV_ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PRODUCTO> INV_PRODUCTO { get; set; }
    }
}

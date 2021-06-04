namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INV_CATEGORIA()
        {
            INV_PRODUCTO = new HashSet<INV_PRODUCTO>();
        }

        [Key]
        public int INV_CATEGORIA_ID { get; set; }

        public string INV_DESCRIPCION_CATEGORIA { get; set; }

        [StringLength(1)]
        public string INV_ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INV_PRODUCTO> INV_PRODUCTO { get; set; }
    }
}

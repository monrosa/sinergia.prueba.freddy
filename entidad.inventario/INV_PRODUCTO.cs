namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_PRODUCTO
    {
        [Key]
        public int INV_PRODUCTO_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string INV_PRODUCTO_CODIGO { get; set; }

        public int INV_CATEGORIA_ID { get; set; }

        public int INV_PROVEEDOR_ID { get; set; }

        public int INV_MARCA_ID { get; set; }

        public int INV_MEDIDA_ID { get; set; }

        [Required]
        public string INV_DESCRIPCION { get; set; }

        public int INV_CANTIDAD { get; set; }

        [DataType(DataType.Currency)]
        public decimal INV_PRECIO_UNITARIO { get; set; }

        public virtual INV_CATEGORIA INV_CATEGORIA { get; set; }

        public virtual INV_MARCA INV_MARCA { get; set; }

        public virtual INV_MEDIDA INV_MEDIDA { get; set; }

        public virtual INV_PROVEEDOR INV_PROVEEDOR { get; set; }
    }
}

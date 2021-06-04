namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class INV_PRODUCTO_HIST
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INV_PRODUCTO_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string INV_PRODUCTO_CODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INV_CATEGORIA_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INV_PROVEEDOR_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INV_MARCA_ID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INV_MEDIDA_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        public string INV_DESCRIPCION { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INV_CANTIDAD { get; set; }

        [Key]
        [Column(Order = 8)]
        public float INV_PRECIO_UNITARIO { get; set; }

        [Key]
        [Column(Order = 9)]
        public string INV_USUARIO_INGRESO { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime INV_FECHA_INGRESO { get; set; }

        [Key]
        [Column(Order = 11)]
        public string INV_USUARIO_MODIFICA { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime INV_FECHA_ACTUALIZA { get; set; }
    }
}

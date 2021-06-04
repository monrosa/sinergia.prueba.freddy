namespace entidad.inventario
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelSinergiaInventario : DbContext
    {
        public ModelSinergiaInventario()
            : base("name=ModelSinergiaInventario")
        {
        }

        public virtual DbSet<INV_CATEGORIA> INV_CATEGORIA { get; set; }
        public virtual DbSet<INV_MARCA> INV_MARCA { get; set; }
        public virtual DbSet<INV_MEDIDA> INV_MEDIDA { get; set; }
        public virtual DbSet<INV_PRODUCTO> INV_PRODUCTO { get; set; }
        public virtual DbSet<INV_PROVEEDOR> INV_PROVEEDOR { get; set; }
        public virtual DbSet<INV_PRODUCTO_HIST> INV_PRODUCTO_HIST { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<INV_CATEGORIA>()
                .Property(e => e.INV_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<INV_CATEGORIA>()
                .HasMany(e => e.INV_PRODUCTO)
                .WithRequired(e => e.INV_CATEGORIA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_MARCA>()
                .Property(e => e.INV_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<INV_MARCA>()
                .HasMany(e => e.INV_PRODUCTO)
                .WithRequired(e => e.INV_MARCA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_MEDIDA>()
                .Property(e => e.INV_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<INV_MEDIDA>()
                .HasMany(e => e.INV_PRODUCTO)
                .WithRequired(e => e.INV_MEDIDA)
                .HasForeignKey(e => e.INV_MEDIDA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_PRODUCTO>()
                .Property(e => e.INV_PRODUCTO_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<INV_PROVEEDOR>()
                .Property(e => e.INV_RUC)
                .IsFixedLength();

            modelBuilder.Entity<INV_PROVEEDOR>()
                .Property(e => e.INV_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<INV_PROVEEDOR>()
                .HasMany(e => e.INV_PRODUCTO)
                .WithRequired(e => e.INV_PROVEEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<INV_PRODUCTO_HIST>()
                .Property(e => e.INV_PRODUCTO_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

namespace Model
{
    using System.Data.Entity;
    using Entities;
    public partial class FacturadorContext : DbContext
    {
        public FacturadorContext()
            : base("name=FacturadorContext")
        {
        }

        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<ComprobanteDetalle> ComprobanteDetalle { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprobante>()
                .Property(e => e.Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Comprobante>()
                .HasMany(e => e.ComprobanteDetalle)
                .WithRequired(e => e.Comprobante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.ComprobanteDetalle)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1SphinxCommercial.BL.Entities;


namespace Data
{
    public class SphinxDbContext:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ClientProduct> ClientProducts { get; set; }

        public SphinxDbContext(DbContextOptions<SphinxDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Code)
                .IsUnique();

            modelBuilder.Entity<Client>()
                .Property(c => c.Code)
                .IsRequired()
                .HasMaxLength(9);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            //modelBuilder.Entity<ClientProduct>()
            //    .HasOne(cp => cp.Client)
            //    .WithMany(c => c.ClientProducts)
            //    .HasForeignKey(cp => cp.ClientID);

            //modelBuilder.Entity<ClientProduct>()
            //    .HasOne(cp => cp.Product)
            //    .WithMany(p => p.ClientProducts)
            //    .HasForeignKey(cp => cp.ProductId);
        }
    }
}

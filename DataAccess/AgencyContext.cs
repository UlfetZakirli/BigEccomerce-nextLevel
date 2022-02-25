using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AgencyContext : IdentityDbContext<ECommerceUser>
    {
        public AgencyContext(DbContextOptions opt) : base(opt)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRecord> ProductRecords { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryRecord> CategoryRecords { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<CategoryPicture> CategoryPictures { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ECommerceUser> ECommerceUsers { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageResource> LanguageResources { get; set; }









        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
    }
}

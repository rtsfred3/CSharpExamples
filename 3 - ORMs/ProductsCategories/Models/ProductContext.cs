using System;
using Microsoft.EntityFrameworkCore;

using ProductsCategories.Models;

namespace ProductsCategories.Models{
    public class ProductContext : DbContext{
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ProductCategory> ProductCategories{ get; set; }
    }
}
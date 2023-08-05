using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared1.Models;
using System.Reflection.Emit;

namespace API_Demo.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CreateRole(builder);
            CreateProducts(builder);
            CreateProductCategories(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }


        private void CreateRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Name = "User",
                NormalizedName = "USER"
            });
        }

        private void CreateProducts(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Glossier - Beauty Kit",
                Description = "A kit provided by Glossier, containing skin care, hair care and makeup products",
                ImgURL = "/Images/Beauty/Beauty1.png",
                Price = 100,
                Quantity = 100,
                CategoryId = 1

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Curology - Skin Care Kit",
                Description = "A kit provided by Curology, containing skin care products",
                ImgURL = "/Images/Beauty/Beauty2.png",
                Price = 50,
                Quantity = 45,
                CategoryId = 1

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Cocooil - Organic Coconut Oil",
                Description = "A kit provided by Curology, containing skin care products",
                ImgURL = "/Images/Beauty/Beauty3.png",
                Price = 20,
                Quantity = 30,
                CategoryId = 1

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "Schwarzkopf - Hair Care and Skin Care Kit",
                Description = "A kit provided by Schwarzkopf, containing skin care and hair care products",
                ImgURL = "/Images/Beauty/Beauty4.png",
                Price = 50,
                Quantity = 60,
                CategoryId = 1

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Skin Care Kit",
                Description = "Skin Care Kit, containing skin care and hair care products",
                ImgURL = "/Images/Beauty/Beauty5.png",
                Price = 30,
                Quantity = 85,
                CategoryId = 1

            });
            //Electronics Category
            builder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Name = "Air Pods",
                Description = "Air Pods - in-ear wireless headphones",
                ImgURL = "/Images/Electronic/Electronics1.png",
                Price = 100,
                Quantity = 120,
                CategoryId = 3

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Name = "On-ear Golden Headphones",
                Description = "On-ear Golden Headphones - these headphones are not wireless",
                ImgURL = "/Images/Electronic/Electronics2.png",
                Price = 40,
                Quantity = 200,
                CategoryId = 3

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Name = "On-ear Black Headphones",
                Description = "On-ear Black Headphones - these headphones are not wireless",
                ImgURL = "/Images/Electronic/Electronics3.png",
                Price = 40,
                Quantity = 300,
                CategoryId = 3

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Name = "Sennheiser Digital Camera with Tripod",
                Description = "Sennheiser Digital Camera - High quality digital camera provided by Sennheiser - includes tripod",
                ImgURL = "/Images/Electronic/Electronic4.png",
                Price = 600,
                Quantity = 20,
                CategoryId = 3

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Name = "Canon Digital Camera",
                Description = "Canon Digital Camera - High quality digital camera provided by Canon",
                ImgURL = "/Images/Electronic/Electronic5.png",
                Price = 500,
                Quantity = 15,
                CategoryId = 3

            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Name = "Nintendo Gameboy",
                Description = "Gameboy - Provided by Nintendo",
                ImgURL = "/Images/Electronic/technology6.png",
                Price = 100,
                Quantity = 60,
                CategoryId = 3
            });
            //Furniture Category
            builder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Name = "Black Leather Office Chair",
                Description = "Very comfortable black leather office chair",
                ImgURL = "/Images/Furniture/Furniture1.png",
                Price = 50,
                Quantity = 212,
                CategoryId = 2
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = 13,
                Name = "Pink Leather Office Chair",
                Description = "Very comfortable pink leather office chair",
                ImgURL = "/Images/Furniture/Furniture2.png",
                Price = 50,
                Quantity = 112,
                CategoryId = 2
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 14,
                Name = "Lounge Chair",
                Description = "Very comfortable lounge chair",
                ImgURL = "/Images/Furniture/Furniture3.png",
                Price = 70,
                Quantity = 90,
                CategoryId = 2
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 15,
                Name = "Silver Lounge Chair",
                Description = "Very comfortable Silver lounge chair",
                ImgURL = "/Images/Furniture/Furniture4.png",
                Price = 120,
                Quantity = 95,
                CategoryId = 2
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 16,
                Name = "Porcelain Table Lamp",
                Description = "White and blue Porcelain Table Lamp",
                ImgURL = "/Images/Furniture/Furniture6.png",
                Price = 15,
                Quantity = 100,
                CategoryId = 2
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 17,
                Name = "Office Table Lamp",
                Description = "Office Table Lamp",
                ImgURL = "/Images/Furniture/Furniture7.png",
                Price = 20,
                Quantity = 73,
                CategoryId = 2
            });
            //Shoes Category
            builder.Entity<Product>().HasData(new Product
            {
                Id = 18,
                Name = "Puma Sneakers",
                Description = "Comfortable Puma Sneakers in most sizes",
                ImgURL = "/Images/Shoes/Shoes1.png",
                Price = 100,
                Quantity = 50,
                CategoryId = 4
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 19,
                Name = "Colorful Trainers",
                Description = "Colorful trainsers - available in most sizes",
                ImgURL = "/Images/Shoes/Shoes2.png",
                Price = 150,
                Quantity = 60,
                CategoryId = 4
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 20,
                Name = "Blue Nike Trainers",
                Description = "Blue Nike Trainers - available in most sizes",
                ImgURL = "/Images/Shoes/Shoes3.png",
                Price = 200,
                Quantity = 70,
                CategoryId = 4
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 21,
                Name = "Colorful Hummel Trainers",
                Description = "Colorful Hummel Trainers - available in most sizes",
                ImgURL = "/Images/Shoes/Shoes4.png",
                Price = 120,
                Quantity = 120,
                CategoryId = 4
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 22,
                Name = "Red Nike Trainers",
                Description = "Red Nike Trainers - available in most sizes",
                ImgURL = "/Images/Shoes/Shoes5.png",
                Price = 200,
                Quantity = 100,
                CategoryId = 4
            });
            builder.Entity<Product>().HasData(new Product
            {
                Id = 23,
                Name = "Birkenstock Sandles",
                Description = "Birkenstock Sandles - available in most sizes",
                ImgURL = "/Images/Shoes/Shoes6.png",
                Price = 50,
                Quantity = 150,
                CategoryId = 4
            });
        }

        private void CreateProductCategories(ModelBuilder builder)
        {
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 1,
                Name = "Beauty"
            });
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 2,
                Name = "Furniture"
            });
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 3,
                Name = "Electronics"
            });
            builder.Entity<ProductCategory>().HasData(new ProductCategory
            {
                Id = 4,
                Name = "Shoes"
            });
        }
    }
}

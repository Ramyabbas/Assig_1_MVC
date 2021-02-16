using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assigement_MVC.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext context;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            context = dbContext;

        }
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager) 
        {
            dbContext.Database.Migrate();
            SeedRolles(dbContext);
            SeedUser(userManager);

            SeedProduct(dbContext);
            SeedCategory(dbContext);

        }

        private static void SeedUser(UserManager<IdentityUser> userManager)
        {
            AddUserIfNotExists(userManager, "stefan.holmberg@systementor.se", "Hejsan123#", new string[] { "Admin" });
            AddUserIfNotExists(userManager, "stefan.holmbergmanager@systementor.se", "Hejsan123#", new string[] { "Product Manager" });
            AddUserIfNotExists(userManager, "ramy.abbas@student.se", "Hopp1122!", new string[] { "Admin" });


        }

        private static void AddUserIfNotExists(UserManager<IdentityUser> userManager,
            string userName, string password, string[] roles)
        {
            if (userManager.FindByEmailAsync(userName).Result != null) return;

            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
                EmailConfirmed = true
            };
            var result = userManager.CreateAsync(user, password).Result;
            var r = userManager.AddToRolesAsync(user, roles).Result;
        }


        private static void SeedRolles(ApplicationDbContext dbContext)
        {
            var role = dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
            if (role == null)
            {
                dbContext.Roles.Add(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
            }
            role = dbContext.Roles.FirstOrDefault(r => r.Name == "Product Manager");
            if (role == null)
            {
                dbContext.Roles.Add(new IdentityRole { Name = "Product Manager", NormalizedName = "Product Manager" });
            }
            dbContext.SaveChanges();
        }

        public static void SeedCategory(ApplicationDbContext dbContext)
        {
            var category = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Irakiskt");

            if (category == null)
            {
                dbContext.ProductCategories.Add(new ProductCategory
                {
                    Name = "Irakiskt"
                });
            }

            category = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Grill");

            if (category == null)
            {
                dbContext.ProductCategories.Add(new ProductCategory
                {
                    Name = "Grill"
                });
            }

            category = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Rulle");

            if (category == null)
            {
                dbContext.ProductCategories.Add(new ProductCategory
                {
                    Name = "Rulle"
                });
            }

            category = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Tallrik");

            if (category == null)
            {
                dbContext.ProductCategories.Add(new ProductCategory
                {
                    Name = "Tallrik"
                });
            }

            category = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Hamburgare meny");

            if (category == null)
            {
                dbContext.ProductCategories.Add(new ProductCategory
                {
                    Name = "Hamburgare meny"
                });
            }

            dbContext.SaveChanges();


        }


       public static void SeedProduct(ApplicationDbContext dbContext)
        {
            var product = dbContext.Products.FirstOrDefault(r => r.Name == "Kebab spett");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Kebab spett",
                    Price = 100,
                    Description = "Tre styckna kebab spett med grönsaker och bröd",
                    CategoryId= dbContext.ProductCategories.FirstOrDefault(r=>r.Name=="Grill")

                });
            }
            product = dbContext.Products.FirstOrDefault(r => r.Name == "Kyckling spett");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Kyckling spett",
                    Price = 80,
                    Description = "Två styckna kyckling spett med grönsaker och bröd",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Grill")

                });
            }
            product = dbContext.Products.FirstOrDefault(r => r.Name == "Mix spett");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Mix spett",
                    Price = 110,
                    Description = "Tre styckna kebab spett, kyckling spett och lamm spett med grönsaker och bröd",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Grill")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Lamm spett");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Lamm spett",
                    Price = 100,
                    Description = "Två styckna lamm spett med grönsaker och bröd",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Grill")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Quzie");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Quzie",
                    Price = 100,
                    Description = "Irakisk gryta med lammkött,bröd och ris",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Irakiskt")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Tashrib/Thareed");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Tashrib/Thareed",
                    Price = 90,
                    Description = "Irakisk gryta med lammkött på brödet",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Irakiskt")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Kebab Tallrik");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Kebab tallrik",
                    Price = 80,
                    Description = "Kebab tallrik med pommes eller ris och grönsaker",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name== "Tallrik")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Kyckling Tallrik");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Kyckling tallrik",
                    Price = 80,
                    Description = "Kyckling tallrik med pommes eller ris och grönsaker",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Tallrik")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Falafel Tallrik");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Falafel tallrik",
                    Price = 75,
                    Description = "Falafel tallrik med pommes eller ris och grönsaker",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Tallrik")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Kebab rulle");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Kebab rulle",
                    Price = 75,
                    Description = "Kebab med bröd och grönsaker i",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Rulle")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Kyckling rulle");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Kyckling rulle",
                    Price = 75,
                    Description = "Kyckling med bröd och grönsaker i",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Rulle")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Falafel rulle");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Falafel rulle",
                    Price = 65,
                    Description = "Falafel med bröd och grönsaker i",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Rulle")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Hamburgare 90g");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Hamburgare 90g",
                    Price = 70,
                    Description = "Hamburage med pommes och dricka",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Hamburgare meny")

                });
            }

            product = dbContext.Products.FirstOrDefault(r => r.Name == "Hamburgare 120g");

            if (product == null)
            {
                dbContext.Products.Add(new Product
                {
                    Name = "Hamburgare 120g",
                    Price = 90,
                    Description = "Hamburage med pommes och dricka",
                    CategoryId = dbContext.ProductCategories.FirstOrDefault(r => r.Name == "Hamburgare meny")

                });
            }
            dbContext.SaveChanges();

        }


    }
}

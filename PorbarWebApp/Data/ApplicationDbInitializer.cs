using Microsoft.AspNetCore.Identity;
using PorbarWebApp.Data.Enums;
using PorbarWebApp.Models;

namespace PorbarWebApp.Data
{
    public class ApplicationDbInitializer
    {
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            { 
                var _context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                _context.Database.EnsureCreated();
                if (!_context.Categories.Any())
                {
                    await _context.AddRangeAsync(GetCategories());
                    await _context.SaveChangesAsync();
                }
                if (!_context.Products.Any())
                {
                    await _context.AddRangeAsync(GetProducts(_context.Categories.ToList()));
                    await _context.SaveChangesAsync();
                }
                if (!_context.Addresses.Any())
                {
                    await _context.AddRangeAsync(GetAddresses());
                    await _context.SaveChangesAsync();
                }
            }
        }

        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>
            {
                new Category
                {
                    Name = "ادویه جات"
                },
                new Category
                {
                    Name = "گیاهان دارویی"
                },
                new Category
                {
                    Name = "دمنوش و چای"
                },
                new Category
                {
                    Name = "عرقیات گیاهی"
                },
            };
            return categories;
        }

        public static List<Product> GetProducts(List<Category> categories)
        {
            
            List<Product> products = new List<Product>
            {
                
                new Product
                {
                    Name = "فلفل سیاه",
                    Description = "مصرف فلفل سیاه باعث ثبات ضربان قلب میشود",
                    ImageUrl = "https://origin.club/media/catalog/product/cache/86eaafd287624d270d87c663dd3976d5/b/l/black_pepper_powder_1.jpg",
                    Price = 5000,
                    Quantity = 20,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "ادویه جات").Id,
                },
                new Product
                {
                    Name = "فلفل قرمز",
                    Description = "مصرف فلفل قرمز باعث افزایش جریان خون به پوست سر میشود",
                    ImageUrl = "https://kalory.ir/uploads/img/1689147909-1890.jpg",
                    Price = 6500,
                    Quantity = 5,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "ادویه جات").Id,
                },
                new Product
                {
                    Name = "رازیانه",
                    Description = "مصرف رازیانه باعث تقویت بینایی میشود",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTZdfzjQWZXZ7fPPstT0c6ATwonoRAwyIFVvw&s",
                    Price = 4500,
                    Quantity = 18,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "گیاهان دارویی").Id
                },
                new Product
                {
                    Name = "زیره",
                    Description = "مصرف زیره باعث لاغری و کاهش وزن میشود",
                    ImageUrl = "https://draxe.com/wp-content/uploads/2019/01/Caraway_800x800_Thumbnail.jpg",
                    Price = 4500,
                    Quantity = 15,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "گیاهان دارویی").Id
                },
                new Product
                {
                    Name = "چای سیاه",
                    Description = "مصرف چای سیاه باعث افزایش تمرکز میشود",
                    ImageUrl = "https://sakiproducts.com/cdn/shop/articles/20221114103112-dark-tea-recipe-blog_800x800.jpg?v=1668422229",
                    Price = 10000,
                    Quantity = 10,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "دمنوش و چای").Id
                },
                new Product
                {
                    Name = "چای سبز",
                    Description = "مصرف چای سبز باعث تقویت سیستم گوارشی بدن میشود",
                    ImageUrl = "https://tebikal.com/wp-content/uploads/2021/12/%D8%AE%D8%A7%D8%B5%DB%8C%D8%AA-%DA%86%D8%A7%DB%8C-%D8%B3%D8%A8%D8%B2-min.jpg",
                    Price = 12500,
                    Quantity = 7,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "دمنوش و چای").Id
                },
                new Product
                {
                    Name = "عرق نعناع",
                    Description = "مصرف عرق نعناع باعث بهبود خواب میشود",
                    ImageUrl = "https://nogleghasemi.com/wp-content/uploads/2022/05/%D8%B9%D8%B1%D9%82-%D9%86%D8%B9%D9%86%D8%A7-768x768.jpeg",
                    Price = 6700,
                    Quantity = 13,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "عرقیات گیاهی").Id
                },
                new Product
                {
                    Name = "عرق کاسنی",
                    Description = "مصرف عرق کاسنی باعث کاهش استرس میشود",
                    ImageUrl = "https://nogleghasemi.com/wp-content/uploads/2022/05/WhatsApp-Image-2022-05-19-at-3.19.22-PM.jpeg",
                    Price = 9500,
                    Quantity = 25,
                    CategoryId = categories.FirstOrDefault(c=> c.Name == "عرقیات گیاهی").Id,
                }
            };
            
            
            return products;
        }

        public static List<Address> GetAddresses()
        {
            List<Address> addresses = new List<Address>
            {
                new Address
                {
                    City = "Mashhad",
                    MainStreet = "VakilAbad",
                    Alley = "kucheaval",
                    PostalCode = "1",
                    PlateNumber = "1",
                    UnitNumber = "1"
                },
                new Address
                {
                    City = "Mashhad",
                    MainStreet = "AhamadAbad",
                    Alley = "kuchedovom",
                    PostalCode = "12",
                    PlateNumber = "12",
                    UnitNumber = "12"
                },
                new Address
                {
                    City = "Mashhad",
                    MainStreet = "GhasemAbad",
                    Alley = "kuchesevom",
                    PostalCode = "123",
                    PlateNumber = "123",
                    UnitNumber = "123"
                },
                new Address
                {
                    City = "Tehran",
                    MainStreet = "Azadi",
                    Alley = "kuchechaharom",
                    PostalCode = "1234",
                    PlateNumber = "1234",
                    UnitNumber = "1234"
                }
            };
            return addresses;
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "porbaradmin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        UserName = "porbaradmin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            City = "Mashhad",
                            MainStreet = "VakilAbad",
                            Alley = "valley",
                            PostalCode = "10",
                            PlateNumber = "10",
                            UnitNumber = "10"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "@Admin1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "porbaruser@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        UserName = "porbaruser",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            City = "Mashhad",
                            MainStreet = "AhmadAbad",
                            Alley = "mallen",
                            PostalCode = "100",
                            PlateNumber = "100",
                            UnitNumber = "100"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "@User1234");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

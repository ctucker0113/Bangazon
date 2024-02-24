using Microsoft.EntityFrameworkCore;
using Bangazon.Models;
using System.Runtime.CompilerServices;

public class BangazonDbContext : DbContext
{

    public DbSet<Category>? Categories { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Product>? Products { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<PaymentType>? PaymentTypes { get; set; }
    public DbSet<OrderProduct>? OrderProducts { get; set; }

    public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<Category>().HasData(new Category[]
        {
            new Category {
                ID = 1,
                Name = "Office Supplies"
            },

            new Category {
                ID = 2,
                Name = "Home"
            },
        });

        modelBuilder.Entity<Order>().HasData(new Order [] {
            new Order {
                ID = 1,
                CustomerID = 1,
                PaymentType = 1,
                OrderOpen = true,
                OrderDate = new DateTime(2024, 1, 13)
            },

            new Order {
                ID = 2,
                CustomerID = 1,
                PaymentType = 2,
                OrderOpen = false,
                OrderDate = new DateTime(2024, 1, 6)
            }
        });

        modelBuilder.Entity<PaymentType>().HasData(new PaymentType[] {
            new PaymentType {
                ID = 1,
                Name = "Cash"
            },

            new PaymentType {
                ID = 2,
                Name = "Credit Card"
            },

            new PaymentType{
                ID = 3,
                Name = "Debit Card"
            }
        });

        modelBuilder.Entity<Product>().HasData(new Product[] {

            new Product {
                ID = 1,
                Name = "Stapler",
                Description = "Staple stuff, yo",
                Quantity = 11,
                Price = 10.00M,
                CategoryID = 1,
                TimePosted = new DateTime(2023, 10, 31),
                SellerID = 1
            },

            new Product {
                ID = 2,
                Name = "Wi-Fi Router",
                Description = "Wi-Fi 6 Router, Dual Band Internet, 802.11ax Wireless",
                Quantity = 2,
                Price = 89.00M,
                CategoryID = 2,
                TimePosted = new DateTime(2022, 10, 23),
                SellerID = 2
            }
        });

        modelBuilder.Entity<User>().HasData(new User[] {

            new User {
                ID = 1,
                Name = "Henry Stapler",
                Email = "theStapleGuy@gmail.com",
                IsSeller = true
            },

            new User {
                ID = 2,
                Name = "Ralph Router",
                Email = "howManyRoutersCanARalphRouterRoute@gmail.com",
                IsSeller = true
            }
        });

        modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[] {

            new OrderProduct {
                ID = 1,
                OrderID = 1,
                ProductID = 1
            },

            new OrderProduct {
                ID = 2,
                OrderID = 1,
                ProductID = 2
            }
        });
    }
}

namespace SealTheDeal.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SealTheDeal.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SealTheDeal.Data.ApplicationDbContext context)
        {
            //create some Genders
            Gender[] genders = new Gender[]
            {
                new Gender {Name = "Male"},
                new Gender {Name = "Female"}
            };

            context.Genders.AddOrUpdate(a => a.Name, genders);
            context.SaveChanges();

            //create some Vendors
            Vendor[] vendors = new Vendor[]
            {
                new Vendor
                {
                    Name = "Pink's Pizza",
                    Address = new Address
                    {
                        Street1 = "4701 Calhoun Road",
                        City = "Houston",
                        State = "TX",
                        Zip = "77004"
                    },
                    Website = "http://www.pinkspizza.com/",
                    Phone = "832-831-3145",
                    Longitude = "-95.3395288",
                    Latitude = "29.722559",
                    ClosingTime = DateTime.Today.AddHours(22)
                },
                new Vendor
                {
                    Name = "Calhoun's Rooftop",
                    Address = new Address
                    {
                        Street1 = "4701 Calhoun Road #200",
                        City = "Houston",
                        State = "TX",
                        Zip = "77004"
                    },
                    Website = "http://www.calhounsrooftop.com/",
                    Phone = "832-649-8849",
                    Longitude = "-95.339364",
                    Latitude = "29.7227989",
                    ClosingTime = DateTime.Today.AddHours(2)
                },
                new Vendor
                {
                    Name = "Bohemeo's",
                    Address = new Address
                    {
                        Street1 = "708 Telephone Road",
                        City = "Houston",
                        State = "TX",
                        Zip = "77023"
                    },
                    Website = "http://www.bohemeos.com/",
                    Phone = "713-923-4277",
                    Longitude = "-95.333705",
                    Latitude = "29.734799",
                    ClosingTime = DateTime.Today
                }
            };

            context.Vendors.AddOrUpdate(v => v.Name, vendors);
            context.SaveChanges();

            //Create Admin for each Vendor
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string[] emails = new string[] {"manager@pinkspizza.com", "manager@calhounsrooftop.com", "manager@bohemeos.com"};

            foreach(string email in emails)
            {
                ApplicationUser admin = userManager.FindByName(email);
                if (admin == null)
                {
                    admin = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        Type = new Models.Type { IsManager = true }
                    };

                    userManager.Create(admin, "123456");
                    admin = userManager.FindByName(email);
                }
            }

            context.SaveChanges();
        }
    }
}

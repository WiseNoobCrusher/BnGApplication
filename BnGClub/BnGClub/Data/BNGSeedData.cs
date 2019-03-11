using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using BnGClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BnGClub.Data
{
    public static class BNGSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BnGClubContext(
                serviceProvider.GetRequiredService <DbContextOptions<BnGClubContext>>()))
            {
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                     new User
                     {
                         userFName = "Ethan",
                         userMName = "Rejean",
                         userLName = "Remington",
                         userPhone = 2896545556,
                         userEmail = "eremington@gmail.com"
                     },
                     new User
                     {
                         userFName = "Ciara",
                         userMName = "Madelle",
                         userLName = "Acevedo",
                         userPhone = 9054356782,
                         userEmail = "ciaraace12@hotmail.ca"
                     },
                     new User
                     {
                         userFName = "Jayce",
                         userMName = "Hewe",
                         userLName = "Bruce",
                         userPhone = 2899546598,
                         userEmail = "mvpbruce69@yahoo.com"
                     },
                     new User
                     {
                         userFName = "Micheal",
                         userMName = "Cody",
                         userLName = "Boyd",
                         userPhone = 9056739845,
                         userEmail = "mcody@hotmail.com"
                     },
                     new User
                     {
                         userFName = "Jayleen",
                         userMName = "Jonas",
                         userLName = "Finley",
                         userPhone = 9056663243,
                         userEmail = "jjfinley@outlook.com"
                     });
                    context.SaveChanges();
                }
                if (!context.Childs.Any())
                {
                    context.Childs.AddRange(
                     new Child
                     {
                         childFName = "Ayaan",
                         childMName = "Martelle",
                         childLName = "Acevedo",
                         childDOB = DateTime.Parse("2009-07-23"),
                         userID = context.Users.FirstOrDefault(u => u.userFName == "Ciara").ID
                     },
                     new Child
                     {
                         childFName = "Romeo",
                         childMName = "Athena",
                         childLName = "Remington",
                         childDOB = DateTime.Parse("2010-12-26"),
                         userID = context.Users.FirstOrDefault(u => u.userFName == "Ciara").ID
                     },
                     new Child
                     {
                         childFName = "Brisa",
                         childMName = "Sharia",
                         childLName = "Boyd",
                         childDOB = DateTime.Parse("2011-12-26"),
                         userID = context.Users.FirstOrDefault(u => u.userFName == "Ciara").ID
                     },
                     new Child
                     {
                         childFName = "Raquel",
                         childMName = "Merrel",
                         childLName = "Bruce",
                         childDOB = DateTime.Parse("2017-01-20"),
                         userID = context.Users.FirstOrDefault(u => u.userFName == "Ciara").ID
                     },
                     new Child
                     {
                         childFName = "Henry",
                         childMName = "Matty",
                         childLName = "Finley",
                         childDOB = DateTime.Parse("2018-08-02"),
                         userID = context.Users.FirstOrDefault(u => u.userFName == "Ciara").ID
                     },
                     new Child
                     {
                         childFName = "Angelica",
                         childMName = "Ganny",
                         childLName = "Remington",
                         childDOB = DateTime.Parse("2011-01-07"),
                         userID = context.Users.FirstOrDefault(u => u.userFName == "Ciara").ID
                     });
                    context.SaveChanges();
                }
            }
        }
    }
}

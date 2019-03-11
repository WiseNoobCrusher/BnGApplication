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
                if (!context.Activities.Any())

                {
                    context.Activities.AddRange(
                        new Activitys
                        {
                            actName = "Child Care",
                            actDescription = "The early years of a child’s life are crucial for cognitive, social and emotional development. At the Boys & Girls Club, we make sure kids get off to a great start.",
                            actCode = "CareTaker",
                            actRequirement = " available for children 18 months to and including 12 years of age",
                            actAvailablePlace = "Niagara Falls Centre, 8800 Mcleod Rd., Niagara FallsSt.Gabriel Lalemant Catholic Elementary School, 6121 Vine St.,Niagara Falls"
                        },
                         new Activitys
                         {
                             actName = "Aquatics",
                             actDescription = " the Boys & Girls Club Club provides all Lifesaving Swim programs from structured lessons for Parent & Tot to advanced Aquatic certification and training.",
                             actCode = "swimming",
                             actRequirement = "We also provide opportunities for children and youth to experience open swim with their friends and families, swim team programs, rentals and Aquatic Fitness programs for adults",
                             actAvailablePlace = "We dont want to give out the information on where we have aquatics if your not a member"
                         },
                          new Activitys
                          {
                              actName = "Day Camp",
                              actDescription = "The Boys and Girls Club of Niagara offers fun and exciting day camps during the winter holiday, March Break week and summer holiday.",
                              actCode = "Camp",
                              actRequirement = " available for children from the age of 4 to the age of 18",
                              actAvailablePlace = "Niagara Falls Centre – 905-357-2444 x219 or programs@bgcn.ca"
                          },
                           new Activitys
                           {
                               actName = "Education & Trainings",
                               actDescription = "This course provides a certification in First Aid and Cardiac Pulmonary Resuscitation.",
                               actCode = "health care",
                               actRequirement = "children from the age of 6 to 12",
                               actAvailablePlace = "Niagara Falls Club at 905-357-2444 x221 for dates and times."
                           },
                            new Activitys
                            {
                                actName = "Youth Outreach",
                                actDescription = "we believe kids who are connected to their community, experience a greater sense of connection and belonging.",
                                actCode = "roleModels",
                                actRequirement = "the age requirement for this program ranges from 3 to 18",
                                actAvailablePlace = "Niagara Falls Centre – Mondays, Wednesdays, and Fridays – 6:00-8:30 p.m."
                            },
                             new Activitys
                             {
                                 actName = "Sports and Recreation",
                                 actDescription = "The Boys and Girls Club of Niagara believes child and youth participation in recreation and leisure activities builds confidence, self-esteem and broadens their range of skills and knowledge.",
                                 actCode = "Exercise",
                                 actRequirement = "children from age of 18 months to 18 years old",
                                 actAvailablePlace = "Niagara Falls Centre"
                             },
                              new Activitys
                              {
                                  actName = "Leardership",
                                  actDescription = "leadership development program that provides youth with the knowledge and skills to make positive choices in their lives and make a difference in their Clubs and communities.",
                                  actCode = "mentors",
                                  actRequirement = " from the age of 13-18",
                                  actAvailablePlace = "St. Catharines Centre"
                              },
                               new Activitys

                               {
                                   actName = "Youth Housing",
                                   actDescription = "We believe that all youth deserve opportunities which enable them to reach their full potential.",
                                   actCode = "fostering",
                                   actRequirement = " youth ages from 16 - 30",
                                   actAvailablePlace = "Nightlight programs are open 24 hours/day, 7 days per week. Call us at 905-358-3678."
                               });
                    context.SaveChanges();
                }

            }
        }
    }
}

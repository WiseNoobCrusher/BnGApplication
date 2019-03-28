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
                     new Users
                     {
                         userFName = "Ethan",
                         userMName = "Rejean",
                         userLName = "Remington",
                         userPhone = 2896545556,
                         userEmail = "eremington@gmail.com"
                     },
                     new Users
                     {
                         userFName = "Ciara",
                         userMName = "Madelle",
                         userLName = "Acevedo",
                         userPhone = 9054356782,
                         userEmail = "ciaraace12@hotmail.ca"
                     },
                     new Users
                     {
                         userFName = "Jayce",
                         userMName = "Hewe",
                         userLName = "Bruce",
                         userPhone = 2899546598,
                         userEmail = "mvpbruce69@yahoo.com"
                     },
                     new Users
                     {
                         userFName = "Micheal",
                         userMName = "Cody",
                         userLName = "Boyd",
                         userPhone = 9056739845,
                         userEmail = "mcody@hotmail.com"
                     },
                     new Users
                     {
                         userFName = "Jayleen",
                         userMName = "Jonas",
                         userLName = "Acevedo",
                         userPhone = 9056663243,
                         userEmail = "jjfinley@outlook.com"
                     });
                    context.SaveChanges();
                }
                if (!context.ActTypes.Any())
                {
                    context.ActTypes.AddRange(
                     new ActType
                     {
                         acttypeName = "Child Care",
                         acttypeDescription = "The early years of a child’s life are crucial for " +
                                              "cognitive, social and emotional development. At the Boys " +
                                              "& Girls Club, we make sure kids get off to a great start."
                     },
                     new ActType
                     {
                         acttypeName = "Aquatics",
                         acttypeDescription = "As an authorized service provider for the Lifesaving Society" +
                                              " of Canada, the Boys & Girls Club Club provides all Lifesaving Swim programs from " +
                                              "structured lessons for Parent & Tot to advanced Aquatic certification and training."
                     },
                     new ActType
                     {
                         acttypeName = "Day Camp",
                         acttypeDescription = "The Day Camp experience is hard to beat."
                     },
                     new ActType
                     {
                         acttypeName = "Education & Training",
                         acttypeDescription = "For the certification programs."
                     },
                     new ActType
                     {
                         acttypeName = "Youth Outreach",
                         acttypeDescription = "At the Boys & Girls Club, we believe kids who are connected to their " +
                         "community, experience a greater sense of connection and belonging."
                     });
                    context.SaveChanges();
                }
                if (!context.Leaders.Any())
                {
                    context.Leaders.AddRange(
                     new Leader
                     {
                         leaderFName = "Harry",
                         leaderMName = "James",
                         leaderLName = "Potter",
                         leaderEmail = "harrypotter@yahoo.com",
                         leaderPhone = 6135550184
                     },
                     new Leader
                     {
                         leaderFName = "Ashley",
                         leaderMName = "Mohammed",
                         leaderLName = "Mcdaniel",
                         leaderEmail = "ashleymcdaniel@outlook.com",
                         leaderPhone = 2895550118
                     },
                     new Leader
                     {
                         leaderFName = "Zachery",
                         leaderMName = "Marion",
                         leaderLName = "Yu",
                         leaderEmail = "zacmarion64@hotmail.ca",
                         leaderPhone = 9055550148
                     }, new Leader
                     {
                         leaderFName = "Carlos",
                         leaderMName = "Mendel",
                         leaderLName = "Sweeney",
                         leaderEmail = "carlosmweeney@hotmail.com",
                         leaderPhone = 6135550114
                     },
                     new Leader
                     {
                         leaderFName = "Lila",
                         leaderMName = "Janela",
                         leaderLName = "Mathis",
                         leaderEmail = "lmathis@yahoo.com",
                         leaderPhone = 2895550100
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
                         UserID = context.Users.FirstOrDefault(u => u.userEmail == "ciaraace12@hotmail.ca").ID
                     },
                     new Child
                     {
                         childFName = "Romeo",
                         childMName = "Athena",
                         childLName = "Remington",
                         childDOB = DateTime.Parse("2010-12-26"),
                         UserID = context.Users.FirstOrDefault(u => u.userEmail == "eremington@gmail.com").ID
                     },
                     new Child
                     {
                         childFName = "Brisa",
                         childMName = "Sharia",
                         childLName = "Boyd",
                         childDOB = DateTime.Parse("2011-12-26"),
                         UserID = context.Users.FirstOrDefault(u => u.userEmail == "mcody@hotmail.com").ID
                     },
                     new Child
                     {
                         childFName = "Raquel",
                         childMName = "Merrel",
                         childLName = "Bruce",
                         childDOB = DateTime.Parse("2017-01-20"),
                         UserID = context.Users.FirstOrDefault(u => u.userEmail == "mvpbruce69@yahoo.com").ID
                     },
                     new Child
                     {
                         childFName = "Henry",
                         childMName = "Matty",
                         childLName = "Finley",
                         childDOB = DateTime.Parse("2017-08-02"),
                         UserID = context.Users.FirstOrDefault(u => u.userEmail == "jjfinley@outlook.com").ID
                     },
                     new Child
                     {
                         childFName = "Angelica",
                         childMName = "Elisa",
                         childLName = "Remington",
                         childDOB = DateTime.Parse("2015-05-25"),
                         UserID = context.Users.FirstOrDefault(u => u.userEmail == "eremington@gmail.com").ID
                     });
                    context.SaveChanges();
                }
                if (!context.Activities.Any())
                {
                    context.Activities.AddRange(
                     new Activities
                     {
                         actName = "Pre-School",
                         actDescription = "The Pre-School Program provides children the opportunity to interact, explore and share" +
                                          " learning and skill development activities in a safe supportive environment.",
                         actAvailablePlace = "Gym",
                         actCode = "CC-PS",
                         actRequirement = "2.5 years to 4 years",
                         LeaderID = context.Leaders.FirstOrDefault(l => l.leaderEmail == "ashleymcdaniel@outlook.com").ID,
                         ActTypeID = context.ActTypes.FirstOrDefault(at => at.acttypeName == "Child Care").ID
                     },
                     new Activities
                     {
                         actName = "Bronze Star",
                         actDescription = "Bronze Star is the pre-bronze medallion training standard and excellent preparation for" +
                                          " success in Bronze Medallion. Participants develop problem-solving and decision-making " +
                                          "skills as individuals and in partners. Participants will learn CPR and develop Water Smart, " +
                                          "confidence and the lifesaving skills needed to be a lifeguard.",
                         actAvailablePlace = "Pool",
                         actCode = "A-BS",
                         actRequirement = "completion of Swim Patrol recommended",
                         LeaderID = context.Leaders.FirstOrDefault(l => l.leaderEmail == "carlosmweeney@hotmail.com").ID,
                         ActTypeID = context.ActTypes.FirstOrDefault(at => at.acttypeName == "Aquatics").ID
                     },
                     new Activities
                     {
                         actName = "March Break Camp",
                         actDescription = "A camp during March Break.",
                         actAvailablePlace = "Varies",
                         actCode = "DC-MBC",
                         actRequirement = "Children must attend a minimum of 3 days per week.",
                         LeaderID = context.Leaders.FirstOrDefault(l => l.leaderEmail == "harrypotter@yahoo.com").ID,
                         ActTypeID = context.ActTypes.FirstOrDefault(at => at.acttypeName == "Day Camp").ID
                     },
                     new Activities
                     {
                         actName = "Standard First Aid & CPR-C Full Course",
                         actDescription = "This course provides a certification in First Aid and Cardiac Pulmonary Resuscitation. " +
                                          "The 16 hour course outlines how to deal with wounds, poisoning, head injuries, bone and " +
                                          "joint injuries, heart attacks and strokes. Candidates will also learn 2 man CPR for infants, " +
                                          "children and adults. This course is designed for professional rescuers, health care workers " +
                                          "and lifeguards.",
                         actAvailablePlace = "Gym",
                         actCode = "FA-EDT",
                         actRequirement = "(10 + yrs) Fee: $129 + supplies",
                         LeaderID = context.Leaders.FirstOrDefault(l => l.leaderEmail == "zacmarion64@hotmail.ca").ID,
                         ActTypeID = context.ActTypes.FirstOrDefault(at => at.acttypeName == "Education & Training").ID
                     },
                     new Activities
                     {
                         actName = "Connections Program",
                         actDescription = "The Connections program is designed for individuals with varying abilities. The core focus of " +
                                          "the program is to encourage community integration, friendship and life skill development within " +
                                          "a safe and welcoming atmosphere. Connections is committed to ensuring an inclusive environment which " +
                                          "provides many memorable experiences.",
                         actAvailablePlace = "Lounge",
                         actCode = "CP-YO",
                         actRequirement = "2.5 years to 4 years",
                         LeaderID = context.Leaders.FirstOrDefault(l => l.leaderEmail == "lmathis@yahoo.com").ID,
                         ActTypeID = context.ActTypes.FirstOrDefault(at => at.acttypeName == "Youth Outreach").ID
                     });
                    context.SaveChanges();
                }
                if (!context.Schedules.Any())
                {
                    context.Schedules.AddRange(
                     new Schedules
                     {
                         startTime = DateTime.Parse("18:30"),
                         endTime = DateTime.Parse("19:30"),
                         dateAct = DateTime.Parse("2019-03-13"),
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "Connections Program").ID
                     });
                    context.SaveChanges();
                }
                if (!context.childEnrolleds.Any())
                {
                    context.childEnrolleds.AddRange(
                     new childEnrolled
                     {
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "Standard First Aid & CPR-C Full Course").ID,
                         ChildID = context.Childs.FirstOrDefault(c => c.childFName == "Ayaan" && c.childLName == "Acevedo").ID
                     },
                     new childEnrolled
                     {
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "Connections Program").ID,
                         ChildID = context.Childs.FirstOrDefault(c => c.childFName == "Romeo" && c.childLName == "Remington").ID
                     },
                     new childEnrolled
                     {
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "March Break Camp").ID,
                         ChildID = context.Childs.FirstOrDefault(c => c.childFName == "Brisa" && c.childLName == "Boyd").ID
                     },
                     new childEnrolled
                     {
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "Pre-School").ID,
                         ChildID = context.Childs.FirstOrDefault(c => c.childFName == "Raquel" && c.childLName == "Bruce").ID
                     },
                     new childEnrolled
                     {
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "Bronze Star").ID,
                         ChildID = context.Childs.FirstOrDefault(c => c.childFName == "Henry" && c.childLName == "Finley").ID
                     },
                     new childEnrolled
                     {
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "Connections Program").ID,
                         ChildID = context.Childs.FirstOrDefault(c => c.childFName == "Angelica" && c.childLName == "Remington").ID
                     });
                    context.SaveChanges();
                }
                if (!context.Announcements.Any())
                {
                    context.Announcements.AddRange(
                     new Announcement
                     {
                         annDate = DateTime.Parse("2019-03-08"),
                         annMessage = "Club closed.",
                         LeaderID = context.Leaders.FirstOrDefault(l => l.leaderEmail == "zacmarion64@hotmail.ca").ID,
                         ActID = context.Activities.FirstOrDefault(a => a.actName == "Connections Program").ID
                     });
                    context.SaveChanges();
                }
            }
        }
    }
}

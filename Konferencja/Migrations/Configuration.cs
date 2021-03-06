﻿namespace Konferencja.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Konferencja.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //Debug
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();
        }

        string[] _names = new string[] { "Jan", "Stanisław", "Andrzej", "Józef", "Tadeusz", "Jerzy", "Zbigniew", "Krzysztof", "Henryk", "Ryszard", "Kazimierz", "Marek", "Marian", "Piotr", "Janusz", "Władysław", "Adam", "Wiesław", "Zdzisław", "Edward", "Mieczysław", "Roman", "Mirosław", "Grzegorz", "Czesław", "Dariusz", "Wojciech", "Jacek", "Eugeniusz", "Tomasz", "Stefan", "Zygmunt", "Leszek", "Bogdan", "Antoni", "Paweł", "Franciszek", "Sławomir", "Waldemar", "Jarosław", "Robert", "Mariusz", "Włodzimierz", "Michał", "Zenon", "Bogusław", "Witold", "Aleksander", "Bronisław", "Wacław", "Bolesław", "Ireneusz", "Maciej", "Artur", "Edmund", "Marcin", "Lech", "Karol", "Rafał", "Arkadiusz", "Leon", "Sylwester", "Lucjan", "Julian", "Wiktor", "Romuald", "Bernard", "Ludwik", "Feliks", "Alfred", "Alojzy", "Przemysław", "Cezary", "Daniel", "Mikołaj", "Ignacy", "Lesław", "Radosław", "Konrad", "Bogumił", "Szczepan", "Gerard", "Hieronim", "Krystian", "Leonard", "Wincenty", "Benedykt", "Hubert", "Sebastian", "Norbert", "Adolf", "Łukasz", "Emil", "Teodor", "Rudolf", "Joachim", "Jakub", "Walenty", "Alfons", "Damian" };
        string[] _surnames = new string[] { "Zagrodzki", "Niedzwiecki", "Czajka", "Kiełpiński", "Jastrząb", "Frąckiewicz", "Śmigielski", "Celiński", "Stawski", "Gajos", "Krawczuk", "Turek", "Siekiera", "Serafin", "Kasprzycki", "Szczepański", "Hinc", "Szlęzak", "Suliga", "Pasikowski", "Arciszewski", "Kurpiewski", "Wołek", "Łuniewski", "Florczyk", "Gręda", "Stokłosa", "Bal", "Chruścicki", "Stokowski", "Traczyk", "Legierski", "Antosik", "Malewski", "Borsuk", "Sak", "Słonina", "Filip", "Biskupski", "Gołdyn", "Pogorzelski", "Sroka", "Kołaczek", "Kluza", "Leśniak", "Fiszer", "Kowal", "Kroczek", "Ciszak", "Kapała", "Kołodziej", "Kądziołka", "Wegner", "Gnat", "Pietruczuk", "Gacek", "Szymkiewicz", "Warzocha", "Kapica", "Strzałka", "Liszewski", "Gruchot", "Karbownik", "Orlik", "Czyż", "Kowalczuk", "Rekowski", "Świerczewski", "Czub", "Kubisiak", "Słaboń", "Kałuski", "Ziemiański", "Matecki", "Drężek", "Żaba", "Barański", "Beczek", "Śmiech", "Sulkowski", "Gałązka", "Ociepka", "Wojno", "Nieradka", "Tusiński", "Grodzicki", "Jachym", "Gil", "Kacprzyk", "Gadziński", "Rybakowski", "Chodkowski", "Gierszewski", "Cichoński", "Wolski", "Skulski", "Wojtecki", "Szczecina", "Jurecki", "Herman" };
        string[] _specialisations = new string[] { "Academe / Education", "Administration / Clerical", "Administration / Human Resources", "Administration / Management", "Advertising", "Agriculture", "Airline / Aviation", "Architecture / Interior Design", "Arts / Creative / Graphics", "Athletics / Fitness / Sports & Recreation", "Banking / Finance / Securities", "Biotechnology", "Business / Accounting / Statistics", "Business / Sales", "Customer Service / Call Center", "Editorial / Journalism", "Engineering / Chemical", "Engineering / Civil / Construction & Building", "Engineering / Civil / Construction & Infrastructure", "Engineering / Electrical", "Engineering / Electronics / Communication", "Engineering / Mechanical", "Engineering / Others", "Entertainment", "Food Technology/ Nutrition", "Geology/Geophysics", "Health / Beauty / Personal Care", "Heavy Industries Construction", "Hotel And Restaurant / Food", "Household Service Worker (HSW)", "IT / Computer", "Maintenance / Automotive", "Maintenance / Electrical", "Maintenance / Electronics", "Maintenance / Facilities", "Maintenance / Instruments", "Maintenance / Machinery", "Maintenance / Oil & Gas", "Manufacturing", "Marketing", "Media Relations / Public Relations", "Medical / Caregiver", "Medical / Dentist / Dental Assistant", "Medical / Doctor / Medical Assistant", "Medical / Nurse", "Medical / Others", "Medical / Physical Therapist", "Military / Defense / Security", "Mining", "Oil & Gas Construction", "Petrochemical & Refinery Construction", "Pharmaceutical", "Photography / Video", "Property / Real Estate", "Purchasing / Merchandising", "Science/ Research", "Seabased Jobs", "Secretarial", "Service / Heavy Machinery", "Service / Home Improvement", "Service / Legal", "Service / Others", "Skilled Tradesmen", "Social Services", "Technology / Quality Control", "Telecommunications", "Tourism / Travel Agency", "Transportation / Freight Forwarding" };

        protected override void Seed(Konferencja.Models.ApplicationDbContext context)
        {
            Random ran = new Random();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            //Roles
            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(e => e.Name == "canEdit"))
                rm.Create(new IdentityRole("canEdit"));
            if (!context.Roles.Any(e => e.Name == "canReview"))
                rm.Create(new IdentityRole("canReview"));
            if (!context.Roles.Any(e => e.Name == "canPublish"))
                rm.Create(new IdentityRole("canPublish"));

            //Admin
            var admin = new ApplicationUser
            {
                UserName = "conference_admin@sharklasers.com",
                PhoneNumber = ran.Next(100000000, 999999999).ToString(),
                PhoneNumberConfirmed = true,
                Name = _names[ran.Next(0, _names.Count() - 1)],
                Surname = _surnames[ran.Next(0, _surnames.Count() - 1)],
                City = "Kraków",
                Address = String.Format("Ul. Nieznana {0}", 100),
                PostalCode = "30-340",
                Email = "conference_admin@sharklasers.com",
                EmailConfirmed = true
            };

            IdentityResult res = userManager.Create(admin, "Password@123");
            if (res.Succeeded)
                userManager.AddToRole(admin.Id, "canEdit");

            context.SaveChanges();

            //Users
            for (int i = 0; i < 100; i++)
            {
                string email = string.Format("conference_user{0}@sharklasers.com", i + 1);
                if (!(context.Users.Any(u => u.UserName == email)))
                {
                    var userToInsert = new ApplicationUser
                    {
                        UserName = email,
                        PhoneNumber = ran.Next(100000000, 999999999).ToString(),
                        PhoneNumberConfirmed = true,
                        Name = _names[ran.Next(0, _names.Count() - 1)],
                        Surname = _surnames[ran.Next(0, _surnames.Count() - 1)],
                        City = "Kraków",
                        Address = String.Format("Ul. Nieznana {0}", i + 1),
                        PostalCode = "30-340",
                        Email = email,
                        EmailConfirmed = true
                    };
                    IdentityResult result = userManager.Create(userToInsert, "Password@123");
                    if (result.Succeeded)
                        userManager.AddToRole(userToInsert.Id, "canPublish");
                }
            }

            context.SaveChanges();

            //Reviewers
            for (int i = 0; i < 30; i++)
            {
                var reviewer = new Reviewer
                {
                    Name = _names[ran.Next(0, _names.Count() - 1)],
                    Surname = _surnames[ran.Next(0, _surnames.Count() - 1)],
                    Email = string.Format("conference_reviewer{0}@sharklasers.com", i + 1),
                    Specialisation = _specialisations[ran.Next(0, _specialisations.Count() - 1)],
                    References = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit."
                };

                context.Reviewers.AddOrUpdate(r => r.Email, reviewer);
            }

            context.SaveChanges();

            //Conferences
            var conferences = new List<Conference>
            {
                new Conference { Date = new DateTime(2015, 7, 20), Theme = "Bardzo poważny temat konferencji nr 1"},
                new Conference { Date = new DateTime(2015, 11, 9), Theme = "Bardzo poważny temat konferencji nr 2"},
                new Conference { Date = new DateTime(2016, 1, 7), Theme = "Bardzo poważny temat konferencji nr 3"},
                new Conference { Date = new DateTime(2016, 7, 24), Theme = "Bardzo poważny temat konferencji nr 4"},
                new Conference { Date = new DateTime(2016, 11, 21), Theme = "Bardzo poważny temat konferencji nr 5"},
            };

            conferences.ForEach(a => context.Conferences.AddOrUpdate(c => c.Theme, a));

            context.SaveChanges();

            string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            //Publications
            var publications = new List<Publication>
            {
                new Publication
                {
                    ApplicationUserId = context.Users.Where(u=>u.Email == "conference_user1@sharklasers.com").First().Id,
                    ConferenceID =  4,
                    Title = "Tytuł publikacji 1",
                    Description = lorem,
                    Status = Status.Accepted,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html",
                },

                new Publication
                {
                    ApplicationUserId = context.Users.Where(u=>u.Email == "conference_user1@sharklasers.com").First().Id,
                    ConferenceID =  4,
                    Title = "Tytuł publikacji 2",
                    Description = lorem,
                    Status = Status.Accepted,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html"
                },

                new Publication
                {
                    ApplicationUserId = context.Users.OrderBy(c => Guid.NewGuid()).FirstOrDefault().Id,
                    ConferenceID =  4,
                    Title = "Tytuł publikacji 3",
                    Description = lorem,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html"
                },

                new Publication
                {
                    ApplicationUserId = context.Users.OrderBy(c => Guid.NewGuid()).FirstOrDefault().Id,
                    ConferenceID =  5,
                    Title = "Tytuł publikacji 4",
                    Description = lorem,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html"
                },

                new Publication
                {
                    ApplicationUserId = context.Users.OrderBy(c => Guid.NewGuid()).FirstOrDefault().Id,
                    ConferenceID =  5,
                    Title = "Tytuł publikacji 5",
                    Description = lorem,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html"
                },

                new Publication
                {
                    ApplicationUserId = context.Users.OrderBy(c => Guid.NewGuid()).FirstOrDefault().Id,
                    ConferenceID =  5,
                    Title = "Tytuł publikacji 6",
                    Description = lorem,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html"
                },

                new Publication
                {
                    ApplicationUserId = context.Users.Where(u=>u.Email == "conference_user1@sharklasers.com").First().Id,
                    ConferenceID =  5,
                    Title = "Tytuł publikacji 7",
                    Description = lorem,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html"
                },

                new Publication
                {
                    ApplicationUserId = context.Users.Where(u=>u.Email == "conference_user1@sharklasers.com").First().Id,
                    ConferenceID =  5,
                    Title = "Tytuł publikacji 8",
                    Description = lorem,
                    File = @"http://scigen.csail.mit.edu/scicache/613/scimakelatex.4090.Janusz+Zabek.Krzysztof+Komeda.html"
                }
            };

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                publications.ForEach(p => context.Publications.AddOrUpdate(e => e.Title, p));
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            context.SaveChanges();

            //Reviews
            var reviews = new List<Review>
            {
                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 1",
                    Grade = Grade.A,
                    PublicationID = 1
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 2",
                    PublicationID = 1
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 3",
                    Grade = Grade.B,
                    PublicationID = 2
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 4",
                    PublicationID = 2
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 5",
                    Grade = Grade.F,
                    PublicationID = 3
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 6",
                    PublicationID = 3
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 7",
                    Grade = Grade.A,
                    PublicationID = 4
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 8",
                    PublicationID = 4
                },

               new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 9",
                    Grade = Grade.C,
                    PublicationID = 4
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 10",
                    PublicationID = 5
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 11",
                    Grade = Grade.A,
                    PublicationID = 5,
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 12",
                    PublicationID = 5
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 13",
                    PublicationID = context.Publications.Where(p=>p.Title == "Tytuł publikacji 7").First().ID
                },

                new Review()
                {
                    ReviewerID = ran.Next(1, 30),
                    Description = "Jakiś opis 14",
                    PublicationID = context.Publications.Where(p=>p.Title == "Tytuł publikacji 7").First().ID
                }
            };

            reviews.ForEach(r => context.Reviews.AddOrUpdate(e => e.ID, r));

            context.SaveChanges();
        }
    }
}

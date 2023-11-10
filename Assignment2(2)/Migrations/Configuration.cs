namespace Assignment2_2_.Migrations
{
    using Assignment2_2_.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment2_2_.Data.Assignment2_2_Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Assignment2_2_.Data.Assignment2_2_Context";
        }

        protected override void Seed(Assignment2_2_.Data.Assignment2_2_Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var areas = new List<Category>
            {
                new Category {Name = "Mammalia"},
                new Category {Name = "Aves"},
                new Category {Name = "Reptiles"},
                new Category {Name = "Fish"},
                new Category {Name = "Insects"},
                new Category {Name = "Amphibians"}
            };
            areas.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var pets = new List<Pet>
            {
                new Pet {Name = "Dog", Price = "200-30000", Lifetime = "9-15", CategoryID = areas.Single(c => c.Name == "Mammalia").ID },
                new Pet {Name = "Cat", Price = "100-6000", Lifetime = "15-18", CategoryID = areas.Single(c => c.Name == "Mammalia").ID },
                new Pet {Name = "Cavy", Price = "50-200", Lifetime = "4-5", CategoryID = areas.Single(c => c.Name == "Mammalia").ID },
                new Pet {Name = "Hamster", Price = "10-30", Lifetime = "2-3", CategoryID = areas.Single(c => c.Name == "Mammalia").ID },
                new Pet {Name = "Rabbit", Price = "10-300", Lifetime = "6-10", CategoryID = areas.Single(c => c.Name == "Mammalia").ID },

                new Pet {Name = "Chicken", Price = "30-100",Lifetime = "3-7", CategoryID = areas.Single(c => c.Name == "Aves").ID},
                new Pet {Name = "Cole Duck", Price = "1500-2000",Lifetime = "4-12", CategoryID = areas.Single(c => c.Name == "Aves").ID},
                new Pet {Name = "Parrot", Price = "50-2000",Lifetime = "8-20", CategoryID = areas.Single(c => c.Name == "Aves").ID},
                new Pet {Name = "Dove", Price = "30-80",Lifetime = "15-20", CategoryID = areas.Single(c => c.Name == "Aves").ID},

                new Pet {Name = "Snake", Price = "80-1000",Lifetime = "17-25", CategoryID = areas.Single(c => c.Name == "Reptiles").ID},
                new Pet {Name = "Lizard", Price = "20-300",Lifetime = "2-3", CategoryID = areas.Single(c => c.Name == "Reptiles").ID},
                new Pet {Name = "Turtle", Price = "5-200",Lifetime = "30-100", CategoryID = areas.Single(c => c.Name == "Reptiles").ID},
                new Pet {Name = "Crocodile", Price = "300-2000",Lifetime = "70-80", CategoryID = areas.Single(c => c.Name == "Reptiles").ID},

                new Pet {Name = "Goldfish", Price = "2-10", Lifetime = "6-7", CategoryID = areas.Single(c => c.Name == "Fish").ID},
                new Pet {Name = "Koi", Price = "30-200", Lifetime = "60-70", CategoryID = areas.Single(c => c.Name == "Fish").ID},
                new Pet {Name = "Tropical Fish", Price = "5-50", Lifetime = "2-10", CategoryID = areas.Single(c => c.Name == "Fish").ID},
                new Pet {Name = "Jellyfish", Price = "1-40", Lifetime = "0.4-0.75", CategoryID = areas.Single(c => c.Name == "Fish").ID},

                new Pet {Name = "Spider", Price = "20-300", Lifetime = "2-10", CategoryID = areas.Single(c => c.Name == "Insects").ID},
                new Pet {Name = "Beetle", Price = "15-200", Lifetime = "0.75-5", CategoryID = areas.Single(c => c.Name == "Insects").ID},
                new Pet {Name = "Mantis", Price = "20-150", Lifetime = "0.5-0.7", CategoryID = areas.Single(c => c.Name == "Insects").ID},
                new Pet {Name = "Scorpion", Price = "30-80", Lifetime = "5-8", CategoryID = areas.Single(c => c.Name == "Insects").ID},

                new Pet {Name = "Frog", Price = "20-300", Lifetime = "4-5", CategoryID = areas.Single(c => c.Name == "Amphibians").ID},
                new Pet {Name = "Giant Salamander", Price = "20-100", Lifetime = "50-60", CategoryID = areas.Single(c => c.Name == "Amphibians").ID},
                new Pet {Name = "Toad", Price = "20-50", Lifetime = "10-12", CategoryID = areas.Single(c => c.Name == "Amphibians").ID},
                new Pet {Name = "Newt", Price = "20-300", Lifetime = "100-350", CategoryID = areas.Single(c => c.Name == "Amphibians").ID},
            };
            pets.ForEach(c => context.Pets.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}

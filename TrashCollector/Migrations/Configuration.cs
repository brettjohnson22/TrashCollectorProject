namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrashCollector.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollector.Models.ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrashCollector.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //ApplicationUser employeeUser = context.Users.Where(r => r.UserName == "garbageman").FirstOrDefault();
            //context.Addresses.AddOrUpdate(x => x.Id,
            //    new Address()
            //    {
            //        Id = 1,
            //        LineOne = "123 Trash St.",
            //        City = "Milwaukee",
            //        State = "WI",
            //        ZipCode = 53207
            //    }
            //    );
            //context.Employees.AddOrUpdate(x => x.Id,
            //    new Employee()
            //    {
            //        Name = "Garbage Man",
            //        ApplicationId = employeeUser.Id,
            //        AddressId = 1
            //    }
            //    );
            //context.Days.AddOrUpdate(x => x.Value,
            //new Day() { Value = DayOfWeek.Sunday, Name = "Sunday" },
            //new Day() { Value = DayOfWeek.Monday, Name = "Monday" },
            //new Day() { Value = DayOfWeek.Tuesday, Name = "Tuesday" },
            //new Day() { Value = DayOfWeek.Wednesday, Name = "Wednesday" },
            //new Day() { Value = DayOfWeek.Thursday, Name = "Thursday" },
            //new Day() { Value = DayOfWeek.Friday, Name = "Friday" },
            //new Day() { Value = DayOfWeek.Saturday, Name = "Saturday" }
            //);
        }
    }
}

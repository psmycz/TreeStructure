namespace StrukturaDrzewiasta.Migrations
{
    using StrukturaDrzewiasta.Core.Domain;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistance.DatabaseContext>
    {
        public Configuration()
        {
            // TODO: Setproperties to "false" on production/live enviroment
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Persistance.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region Add Categories

            var louvre = new Category { Name = "Louvre" };
            var child = new Category { Name = "Egyptian Antiquites" };
            louvre.Subcategories.Add(child);
            child = new Category { Name = "Sculptures" };
            louvre.Subcategories.Add(child);
            child = new Category { Name = "Paintings" };
            louvre.Subcategories.Add(child);
            var paris = new Category { Name = "Paris" };
            paris.Subcategories.Add(louvre);
            var vacation = new Category { Name = "Summer Vacation" };
            vacation.Subcategories.Add(paris);
            context.Categories.AddOrUpdate(paris);

            #endregion


        }
    }
}

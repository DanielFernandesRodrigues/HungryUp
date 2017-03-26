namespace HungryUp.Infrastructure.Migrations
{
    using GameEndpoints.Common.Validations;
    using HungryUp.Domain.Model;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<HungryUp.Infrastructure.Data.AppDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HungryUp.Infrastructure.Data.AppDataContext context)
        {
            context.Restaurants.AddOrUpdate(p => p.Name,
                  new Restaurant("Camobi Churrascaria") { RestaurantId = 1 }
                , new Restaurant("Camoburguer") { RestaurantId = 2 }
                , new Restaurant("Nélia Lanches") { RestaurantId = 3 }
                , new Restaurant("Due Frateli") { RestaurantId = 4 }
                , new Restaurant("Via Fornale") { RestaurantId = 5 }
                , new Restaurant("Floriano Lanches") { RestaurantId = 6 }
                , new Restaurant("Piu Piu Lanches") { RestaurantId = 7 }
                , new Restaurant("Porto Belo") { RestaurantId = 8 }
                , new Restaurant("Hellios") { RestaurantId = 9 }
                , new Restaurant("Etnias") { RestaurantId = 10 }
                , new Restaurant("Dariu Lanches") { RestaurantId = 11 }
                );

            context.Users.AddOrUpdate(p => p.Name,
                new User("DbServer Test", "dbserver_test@dbserver.com", PasswordAssertionConcern.Encrypt("dbserver_teste")));
        }
    }
}

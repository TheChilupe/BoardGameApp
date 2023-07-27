using BoardGameApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameApp.Data
{
    public class GameContext : DbContext
    {
        public DbSet<BoardGameModel> BoardGames { get; set; }
        public DbSet<PublisherModel> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BoardGameLibrary;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublisherModel>().HasData(
                new PublisherModel()
                {
                    Id = 1,
                    Name = "Repos Production"
                },
                new PublisherModel()
                {
                    Id = 2,
                    Name = "dlp games"
                },
                new PublisherModel()
                {
                    Id = 3,
                    Name = "IELLO, KOSMOS"
                },
                new PublisherModel()
                {
                    Id = 4,
                    Name = "CD Projekt RED, Go On Board"
                });
            modelBuilder.Entity<BoardGameModel>().HasData(
                new BoardGameModel()
                {
                    Id = 1,
                    Name = "7 Wonders Dual",
                    Description = "Science? Military? What will you draft to win this head-to-head version of 7 Wonders?",
                    ImageURL = "https://cf.geekdo-images.com/zdagMskTF7wJBPjX74XsRw__itemrep/img/x5L93n_pSsxfFZ0Ir-JqtjLf-Jw=/fit-in/246x300/filters:strip_icc()/pic2576399.jpg",
                    PublisherId = 1,

                },
                 new BoardGameModel()
                 {
                     Id = 2,
                     Name = "Orleans",
                     Description = "Craftsmen, scholars & monks can help you reign supreme—but who will turn up to help?",
                     ImageURL = "https://cf.geekdo-images.com/nagl1li6kYt9elV9jbfVQw__itemrep/img/oYYWKekDiHllrWnFNef7En3gP4c=/fit-in/246x300/filters:strip_icc()/pic6228507.jpg",
                     PublisherId = 2,

                 },
                  new BoardGameModel()
                  {
                      Id = 3,
                      Name = "My Gold Mine",
                      Description = "Collect gold nuggets while avoiding the dragon watching over the hoard. ",
                      ImageURL = "https://cf.geekdo-images.com/BHLjzl2saSCs497dgIkUYA__itemrep/img/3drFnqWEU9H16NCoRWDAOtnTkiI=/fit-in/246x300/filters:strip_icc()/pic5986895.jpg",
                      PublisherId = 3,

                  },
                   new BoardGameModel()
                   {
                       Id = 4,
                       Name = "The Witcher: Old World",
                       Description = "Explore the Continent, upgrade your skills, and fight monsters/witchers for trophies.",
                       ImageURL = "https://cf.geekdo-images.com/tQVVSXcmYLvAoI28cp-2Tg__itemrep/img/rxCXKwIjRmHKwONcIo5Ja7iTiKc=/fit-in/246x300/filters:strip_icc()/pic5974859.jpg",
                       PublisherId = 4,

                   },
                    new BoardGameModel()
                    {
                        Id = 5,
                        Name = "Mr. President: The American Presidency",
                        Description = "You are the President of the United States, attempting to govern in a new millennium",
                        ImageURL = "https://cf.geekdo-images.com/xneRUjohOxhdjMhLb6DUAg__itemrep/img/VObDSJEgrYTfB80Wytebf5r4fPM=/fit-in/246x300/filters:strip_icc()/pic6977091.jpg",
                        PublisherId = 3,

                    },
                     new BoardGameModel()
                     {
                         Id = 6,
                         Name = "Pandemic Legacy: Season 1",
                         Description = "Mutating diseases are spreading around the world - can your team save humanity?",
                         ImageURL = "https://cf.geekdo-images.com/-Qer2BBPG7qGGDu6KcVDIw__itemrep/img/Wxe36yaTzpiIVhEefHOYzFv7Ucc=/fit-in/246x300/filters:strip_icc()/pic2452831.png",
                         PublisherId = 2,

                     });

        }

    }
}

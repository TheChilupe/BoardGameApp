using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoardGameApp.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    PublisherModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGames_Publishers_PublisherModelId",
                        column: x => x.PublisherModelId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "Description", "ImageURL", "Name", "PublisherId", "PublisherModelId" },
                values: new object[,]
                {
                    { 1, "Science? Military? What will you draft to win this head-to-head version of 7 Wonders?", "https://cf.geekdo-images.com/zdagMskTF7wJBPjX74XsRw__itemrep/img/x5L93n_pSsxfFZ0Ir-JqtjLf-Jw=/fit-in/246x300/filters:strip_icc()/pic2576399.jpg", "7 Wonders Dual", 1, null },
                    { 2, "Craftsmen, scholars & monks can help you reign supreme—but who will turn up to help?", "https://cf.geekdo-images.com/nagl1li6kYt9elV9jbfVQw__itemrep/img/oYYWKekDiHllrWnFNef7En3gP4c=/fit-in/246x300/filters:strip_icc()/pic6228507.jpg", "Orleans", 2, null },
                    { 3, "Collect gold nuggets while avoiding the dragon watching over the hoard. ", "https://cf.geekdo-images.com/BHLjzl2saSCs497dgIkUYA__itemrep/img/3drFnqWEU9H16NCoRWDAOtnTkiI=/fit-in/246x300/filters:strip_icc()/pic5986895.jpg", "My Gold Mine", 3, null },
                    { 4, "Explore the Continent, upgrade your skills, and fight monsters/witchers for trophies.", "https://cf.geekdo-images.com/tQVVSXcmYLvAoI28cp-2Tg__itemrep/img/rxCXKwIjRmHKwONcIo5Ja7iTiKc=/fit-in/246x300/filters:strip_icc()/pic5974859.jpg", "The Witcher: Old World", 4, null },
                    { 5, "You are the President of the United States, attempting to govern in a new millennium", "https://cf.geekdo-images.com/xneRUjohOxhdjMhLb6DUAg__itemrep/img/VObDSJEgrYTfB80Wytebf5r4fPM=/fit-in/246x300/filters:strip_icc()/pic6977091.jpg", "Mr. President: The American Presidency", 3, null },
                    { 6, "Mutating diseases are spreading around the world - can your team save humanity?", "https://cf.geekdo-images.com/-Qer2BBPG7qGGDu6KcVDIw__itemrep/img/Wxe36yaTzpiIVhEefHOYzFv7Ucc=/fit-in/246x300/filters:strip_icc()/pic2452831.png", "Pandemic Legacy: Season 1", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Repos Production" },
                    { 2, "dlp games" },
                    { 3, "IELLO, KOSMOS" },
                    { 4, "CD Projekt RED, Go On Board" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_PublisherModelId",
                table: "BoardGames",
                column: "PublisherModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGames");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}

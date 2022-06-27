using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCollectionSite.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollectionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageURL = table.Column<string>(type: "TEXT", nullable: true),
                    Acquired = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CollectionItems",
                columns: new[] { "Id", "Acquired", "Description", "ImageURL", "Name" },
                values: new object[] { 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black hat with the classic Atari logo and Japanese text for Atari under the brim", "https://hatcollection.blob.core.windows.net/hat-images/atari.jpg", "Atari" });

            migrationBuilder.InsertData(
                table: "CollectionItems",
                columns: new[] { "Id", "Acquired", "Description", "ImageURL", "Name" },
                values: new object[] { 2, new DateTime(2019, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "White hat with purple Blazor logo", "https://hatcollection.blob.core.windows.net/hat-images/blazor.jpg", "Blazor" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectionItems");
        }
    }
}

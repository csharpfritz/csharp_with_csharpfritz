using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCollectionSite.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "CollectionItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CollectionItems",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCollectionSite.Migrations
{
    public partial class IntroducingVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "CollectionItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "CollectionItems");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApplication.DAL.Migrations
{
    public partial class AddForeignKeyAndIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "fk_city_country_country_id",
                table: "city",
                column: "country_id",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
            
            migrationBuilder.CreateIndex(
                name: "ix_city_country_id",
                table: "city",
                column: "country_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_city_country_country_id", 
                table: "city");
            
            migrationBuilder.DropIndex(
                name: "ix_city_country_id",
                table: "city");
        }
    }
}

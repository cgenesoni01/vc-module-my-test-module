using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCoolCompany.MyTestModule.Data.Migrations
{
    public partial class OrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(name: "NewOrderField", table: "CustomerOrder", maxLength: 128, nullable: true);
            migrationBuilder.AddColumn<string>(name: "Discriminator", table: "CustomerOrder", nullable: false, maxLength: 128, defaultValue: "CustomerOrderV2Entity");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewOrderField",
                table: "CustomerOrder");
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CustomerOrder");
        }
    }
}

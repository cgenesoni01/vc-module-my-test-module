using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCoolCompany.MyTestModule.Data.Migrations
{
    public partial class OrderMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewOrderField",
                table: "CustomerOrder",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewOrderField",
                table: "CustomerOrder");
        }
    }
}

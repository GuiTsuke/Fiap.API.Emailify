using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.API.Emailify.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FL_SENT",
                table: "TBL_EMAIL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FL_SENT",
                table: "TBL_EMAIL",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }
    }
}

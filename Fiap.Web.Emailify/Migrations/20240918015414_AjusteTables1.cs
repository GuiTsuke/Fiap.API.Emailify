using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.API.Emailify.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DS_TO",
                table: "TBL_EMAIL",
                type: "CLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(256)",
                oldMaxLength: 256);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DS_TO",
                table: "TBL_EMAIL",
                type: "NVARCHAR2(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CLOB");
        }
    }
}

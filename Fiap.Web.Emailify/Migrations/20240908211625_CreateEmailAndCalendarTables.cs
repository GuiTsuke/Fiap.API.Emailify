using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.API.Emailify.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmailAndCalendarTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CALENDAR",
                columns: table => new
                {
                    ID_EVENT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    GUID_EVENT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_TITLE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CALENDAR", x => x.ID_EVENT);
                });

            migrationBuilder.CreateTable(
                name: "TBL_EMAIL",
                columns: table => new
                {
                    ID_EMAIL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    GUID_EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_FROM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_TO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DS_SUBJECT = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_BODY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_EMAIL", x => x.ID_EMAIL);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER_PREFERENCES",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_EMAIL = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    DS_THEME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DS_PRIMARY_COLOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_SECONDARY_COLOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_CATEGORIES = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_LABELS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USER_PREFERENCES", x => x.ID_USER);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USER_PREFERENCES_DS_EMAIL",
                table: "TBL_USER_PREFERENCES",
                column: "DS_EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_CALENDAR");

            migrationBuilder.DropTable(
                name: "TBL_EMAIL");

            migrationBuilder.DropTable(
                name: "TBL_USER_PREFERENCES");
        }
    }
}

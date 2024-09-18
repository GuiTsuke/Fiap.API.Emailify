using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.API.Emailify.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
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
                    DS_TITLE = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DS_DESCRIPTION = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DT_START_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_END_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_LOCATION = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false)
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
                    DS_FROM = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    DS_TO = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    DS_SUBJECT = table.Column<string>(type: "NVARCHAR2(512)", maxLength: 512, nullable: false),
                    DS_BODY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DT_DATE = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FL_SENT = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_EMAIL", x => x.ID_EMAIL);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER_PREFERENCES",
                columns: table => new
                {
                    CD_USER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_EMAIL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    DS_THEME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    DS_PRIMARY_COLOR = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DS_SECONDARY_COLOR = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DS_LABELS_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_CATEGORIES_JSON = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FL_DARK_THEME = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FL_ACTIVE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USER_PREFERENCES", x => x.CD_USER);
                });
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

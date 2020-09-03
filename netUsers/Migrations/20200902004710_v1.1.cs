using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netUsers.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataMigracao",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "dnsAntigo",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "dnsNovo",
                table: "Client");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "Client",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ServerId",
                table: "Client",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Server",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dnsAntigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    dnsNovo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    dataMigracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ServerId",
                table: "Client",
                column: "ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_Server_ServerId",
                table: "Client",
                column: "ServerId",
                principalTable: "Server",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_Server_ServerId",
                table: "Client");

            migrationBuilder.DropTable(
                name: "Server");

            migrationBuilder.DropIndex(
                name: "IX_Client_ServerId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ServerId",
                table: "Client");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataMigracao",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "dnsAntigo",
                table: "Client",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "dnsNovo",
                table: "Client",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}

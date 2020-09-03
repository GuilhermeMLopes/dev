using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netUsers.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codCliente = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    dnsAntigo = table.Column<string>(nullable: true),
                    dnsNovo = table.Column<string>(nullable: true),
                    dataMigracao = table.Column<DateTime>(nullable: false),
                    precisouAjuda = table.Column<bool>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Migrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}

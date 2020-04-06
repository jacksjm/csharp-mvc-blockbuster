using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace csharp_mvc_blockbuster.Migrations
{
    public partial class ManyToManyRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Locacoes_LocacaoId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_LocacaoId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "LocacaoId",
                table: "Filmes");

            migrationBuilder.CreateTable(
                name: "FilmeLocacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FilmeId = table.Column<int>(nullable: false),
                    LocacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeLocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmeLocacao_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "FilmeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeLocacao_Locacoes_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "Locacoes",
                        principalColumn: "LocacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacao_FilmeId",
                table: "FilmeLocacao",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeLocacao_LocacaoId",
                table: "FilmeLocacao",
                column: "LocacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmeLocacao");

            migrationBuilder.AddColumn<int>(
                name: "LocacaoId",
                table: "Filmes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_LocacaoId",
                table: "Filmes",
                column: "LocacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Locacoes_LocacaoId",
                table: "Filmes",
                column: "LocacaoId",
                principalTable: "Locacoes",
                principalColumn: "LocacaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

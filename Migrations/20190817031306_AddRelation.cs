using Microsoft.EntityFrameworkCore.Migrations;

namespace Myblog1.Migrations
{
    public partial class AddRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relation_Posts_PostId",
                table: "Relation");

            migrationBuilder.DropForeignKey(
                name: "FK_Relation_Terms_TermId",
                table: "Relation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relation",
                table: "Relation");

            migrationBuilder.RenameTable(
                name: "Relation",
                newName: "Relations");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Terms",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Relation_TermId",
                table: "Relations",
                newName: "IX_Relations_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_Relation_PostId",
                table: "Relations",
                newName: "IX_Relations_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relations",
                table: "Relations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Posts_PostId",
                table: "Relations",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relations_Terms_TermId",
                table: "Relations",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Posts_PostId",
                table: "Relations");

            migrationBuilder.DropForeignKey(
                name: "FK_Relations_Terms_TermId",
                table: "Relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relations",
                table: "Relations");

            migrationBuilder.RenameTable(
                name: "Relations",
                newName: "Relation");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Terms",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_TermId",
                table: "Relation",
                newName: "IX_Relation_TermId");

            migrationBuilder.RenameIndex(
                name: "IX_Relations_PostId",
                table: "Relation",
                newName: "IX_Relation_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relation",
                table: "Relation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relation_Posts_PostId",
                table: "Relation",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Relation_Terms_TermId",
                table: "Relation",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

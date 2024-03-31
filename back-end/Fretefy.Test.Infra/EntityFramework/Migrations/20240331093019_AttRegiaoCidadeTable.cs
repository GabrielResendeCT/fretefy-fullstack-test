using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fretefy.Test.Infra.EntityFramework.Migrations
{
    public partial class AttRegiaoCidadeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "RegiaoCidade");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "RegiaoCidade");

            migrationBuilder.AddColumn<Guid>(
                name: "CidadeId",
                table: "RegiaoCidade",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RegiaoCidade_CidadeId",
                table: "RegiaoCidade",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegiaoCidade_Cidade_CidadeId",
                table: "RegiaoCidade",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegiaoCidade_Cidade_CidadeId",
                table: "RegiaoCidade");

            migrationBuilder.DropIndex(
                name: "IX_RegiaoCidade_CidadeId",
                table: "RegiaoCidade");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "RegiaoCidade");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "RegiaoCidade",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "RegiaoCidade",
                type: "TEXT",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}

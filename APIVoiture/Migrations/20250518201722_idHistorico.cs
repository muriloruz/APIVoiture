﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIVoiture.Migrations
{
    public partial class idHistorico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "VendedorClientes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "VendedorClientes");
        }
    }
}

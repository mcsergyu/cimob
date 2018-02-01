using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cimob.Migrations
{
    public partial class add_Interview_model_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Interview_CandidaturaId",
                table: "Interview",
                column: "CandidaturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Candidatura_CandidaturaId",
                table: "Interview",
                column: "CandidaturaId",
                principalTable: "Candidatura",
                principalColumn: "CandidaturaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Candidatura_CandidaturaId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_CandidaturaId",
                table: "Interview");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cimob.Migrations
{
    public partial class add_Interview_model_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Candidatura_CandidaturaId",
                table: "Interview");

            migrationBuilder.DropIndex(
                name: "IX_Interview_CandidaturaId",
                table: "Interview");

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "Candidatura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Candidatura_InterviewId",
                table: "Candidatura",
                column: "InterviewId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidatura_Interview_InterviewId",
                table: "Candidatura");

            migrationBuilder.DropIndex(
                name: "IX_Candidatura_InterviewId",
                table: "Candidatura");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Candidatura");

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
    }
}

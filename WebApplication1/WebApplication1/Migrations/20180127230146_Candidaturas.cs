using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Cimob.Migrations
{
    public partial class Candidaturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatura",
                columns: table => new
                {
                    CandidaturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastStateDate = table.Column<DateTime>(nullable: false),
                    ProgramId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    SubmissionUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatura", x => x.CandidaturaId);
                    table.ForeignKey(
                        name: "FK_Candidatura_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidatura_AspNetUsers_SubmissionUserId",
                        column: x => x.SubmissionUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatura_ProgramId",
                table: "Candidatura",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatura_SubmissionUserId",
                table: "Candidatura",
                column: "SubmissionUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatura");
        }
    }
}

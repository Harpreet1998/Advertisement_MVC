using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advertisement_MVC_.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_candidate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB_of_candidate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mobile_no_of_candidate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_address_of_candidate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_of_establishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address_of_employer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job_salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Job_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Employe_Name = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apply_job_detail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    Job_DetailId = table.Column<int>(type: "int", nullable: false),
                    Candidate_availabilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Candidate_notice_period = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apply_job_detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apply_job_detail_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apply_job_detail_Jobs_Job_DetailId",
                        column: x => x.Job_DetailId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apply_job_detail_CandidateId",
                table: "Apply_job_detail",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Apply_job_detail_Job_DetailId",
                table: "Apply_job_detail",
                column: "Job_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apply_job_detail");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}

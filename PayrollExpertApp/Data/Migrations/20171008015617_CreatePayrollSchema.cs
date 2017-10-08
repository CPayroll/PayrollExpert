using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PayrollExpertApp.Data.Migrations
{
    public partial class CreatePayrollSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CBABusinessNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Directors = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MailingAddressSameAsHeadOfficeAddress = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OperatingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SigningOfficer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WebsiteURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShareHolder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommonSharePercentage = table.Column<double>(type: "float", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherPercentage = table.Column<double>(type: "float", nullable: false),
                    PreferredSharePercentage = table.Column<double>(type: "float", nullable: false),
                    SINNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareHolder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShareHolder_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    City = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonId",
                table: "Address",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CompanyId",
                table: "People",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShareHolder_CompanyId",
                table: "ShareHolder",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ShareHolder");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}

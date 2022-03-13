﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Finance_D_argent.Migrations
{
    public partial class addFixedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journal_Acounts");

            migrationBuilder.CreateTable(
                name: "Journal_Accounts",
                columns: table => new
                {
                    JAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalId = table.Column<int>(type: "int", nullable: false),
                    JournalizeJournalId = table.Column<int>(type: "int", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal_Accounts", x => x.JAId);
                    table.ForeignKey(
                        name: "FK_Journal_Accounts_journalizes_JournalizeJournalId",
                        column: x => x.JournalizeJournalId,
                        principalTable: "journalizes",
                        principalColumn: "JournalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_Accounts_JournalizeJournalId",
                table: "Journal_Accounts",
                column: "JournalizeJournalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Journal_Accounts");

            migrationBuilder.CreateTable(
                name: "Journal_Acounts",
                columns: table => new
                {
                    JAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalizeJournalId = table.Column<int>(type: "int", nullable: false),
                    AccountName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    JournalId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal_Acounts", x => x.JAId);
                    table.ForeignKey(
                        name: "FK_Journal_Acounts_journalizes_JournalizeJournalId",
                        column: x => x.JournalizeJournalId,
                        principalTable: "journalizes",
                        principalColumn: "JournalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_Acounts_JournalizeJournalId",
                table: "Journal_Acounts",
                column: "JournalizeJournalId");
        }
    }
}
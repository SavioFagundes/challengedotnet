using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WalletAPI.Infrastructure.Data.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                FullName = table.Column<string>(type: "text", nullable: false),
                Email = table.Column<string>(type: "text", nullable: false),
                PasswordHash = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Wallets",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Balance = table.Column<decimal>(type: "numeric", nullable: false),
                UserId = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Wallets", x => x.Id);
                table.ForeignKey(
                    name: "FK_Wallets_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Transactions",
            columns: table => new
            {
                Id = table.Column<int>(type: "integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                FromWalletId = table.Column<int>(type: "integer", nullable: false),
                ToWalletId = table.Column<int>(type: "integer", nullable: false),
                Amount = table.Column<decimal>(type: "numeric", nullable: false),
                Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transactions", x => x.Id);
                table.ForeignKey(
                    name: "FK_Transactions_Wallets_FromWalletId",
                    column: x => x.FromWalletId,
                    principalTable: "Wallets",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Transactions_Wallets_ToWalletId",
                    column: x => x.ToWalletId,
                    principalTable: "Wallets",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_FromWalletId",
            table: "Transactions",
            column: "FromWalletId");

        migrationBuilder.CreateIndex(
            name: "IX_Transactions_ToWalletId",
            table: "Transactions",
            column: "ToWalletId");

        migrationBuilder.CreateIndex(
            name: "IX_Wallets_UserId",
            table: "Wallets",
            column: "UserId",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Transactions");

        migrationBuilder.DropTable(
            name: "Wallets");

        migrationBuilder.DropTable(
            name: "Users");
    }
} 
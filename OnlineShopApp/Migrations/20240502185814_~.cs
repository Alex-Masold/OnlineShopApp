using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopApp.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_STORE",
                table: "ORDERS");

            migrationBuilder.RenameColumn(
                name: "IdStore",
                table: "ORDERS",
                newName: "ID_STORE");

            migrationBuilder.RenameIndex(
                name: "IX_ORDERS_IdStore",
                table: "ORDERS",
                newName: "IX_ORDERS_ID_STORE");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DATE_ORDER",
                table: "ORDERS",
                type: "date",
                nullable: true,
                defaultValue: new DateOnly(2024, 5, 3),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldDefaultValue: new DateOnly(2024, 5, 2));

            migrationBuilder.AddColumn<int>(
                name: "IdEmployee",
                table: "ORDERS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_IdEmployee",
                table: "ORDERS",
                column: "IdEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_EMPLOYEE",
                table: "ORDERS",
                column: "IdEmployee",
                principalTable: "EMPLOYEES",
                principalColumn: "ID_EMPLOYEE");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDERS_STORE",
                table: "ORDERS",
                column: "ID_STORE",
                principalTable: "STORES",
                principalColumn: "ID_STORE");
        }
    }
}

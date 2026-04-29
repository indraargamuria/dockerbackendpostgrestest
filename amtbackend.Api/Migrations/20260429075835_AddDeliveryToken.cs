using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amtbackend.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryToken",
                table: "DeliveryHeaders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryHeaders_DeliveryToken",
                table: "DeliveryHeaders",
                column: "DeliveryToken",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DeliveryHeaders_DeliveryToken",
                table: "DeliveryHeaders");

            migrationBuilder.DropColumn(
                name: "DeliveryToken",
                table: "DeliveryHeaders");
        }
    }
}

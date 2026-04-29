using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace amtbackend.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddReceiverAndDeliveryResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "QuantityDelivered",
                table: "DeliveryLines",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityRejected",
                table: "DeliveryLines",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "QuantityReturned",
                table: "DeliveryLines",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "DeliveryHeaders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverNotes",
                table: "DeliveryHeaders",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityDelivered",
                table: "DeliveryLines");

            migrationBuilder.DropColumn(
                name: "QuantityRejected",
                table: "DeliveryLines");

            migrationBuilder.DropColumn(
                name: "QuantityReturned",
                table: "DeliveryLines");

            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "DeliveryHeaders");

            migrationBuilder.DropColumn(
                name: "ReceiverNotes",
                table: "DeliveryHeaders");
        }
    }
}

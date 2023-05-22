using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class update_register : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_users_UserId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_users_userId",
                table: "contacts");

            

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_registerModels_UserId",
                table: "bookings",
                column: "UserId",
                principalTable: "registerModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

           

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_registerModels_userId",
                table: "contacts",
                column: "userId",
                principalTable: "registerModels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_registerModels_UserId",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_users_UserID",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_registerModels_userId",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_users_UserID",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_UserID",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_bookings_UserID",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "bookings");

       

           
        }
    }
}

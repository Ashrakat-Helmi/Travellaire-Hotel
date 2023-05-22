using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class profile_img : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.RenameColumn(
                name: "exp_date",
                table: "bookings",
                newName: "expDate");

            migrationBuilder.AddColumn<string>(
                name: "userPic",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");


           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "userPic",
                table: "users");

           

            migrationBuilder.RenameColumn(
                name: "expDate",
                table: "bookings",
                newName: "exp_date");



        
        }
    }
}

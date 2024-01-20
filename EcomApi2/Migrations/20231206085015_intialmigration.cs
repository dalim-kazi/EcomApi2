using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomApi2.Migrations
{
    /// <inheritdoc />
    public partial class intialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupones2",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discountAmount = table.Column<double>(type: "float", nullable: false),
                    minAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupones2", x => x.CouponId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupones2");
        }
    }
}

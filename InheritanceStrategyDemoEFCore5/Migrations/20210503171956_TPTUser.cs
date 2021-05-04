using Microsoft.EntityFrameworkCore.Migrations;

namespace InheritanceStrategyDemoEFCore5.Migrations
{
    public partial class TPTUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TPTUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TPTStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CGPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPTStudents_TPTUsers_Id",
                        column: x => x.Id,
                        principalTable: "TPTUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TPTTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPTTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TPTTeachers_TPTUsers_Id",
                        column: x => x.Id,
                        principalTable: "TPTUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TPTStudents");

            migrationBuilder.DropTable(
                name: "TPTTeachers");

            migrationBuilder.DropTable(
                name: "TPTUsers");
        }
    }
}

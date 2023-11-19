using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutType_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutTypeId",
                table: "Workout",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkoutType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workout_WorkoutTypeId",
                table: "Workout",
                column: "WorkoutTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workout_WorkoutType_WorkoutTypeId",
                table: "Workout",
                column: "WorkoutTypeId",
                principalTable: "WorkoutType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workout_WorkoutType_WorkoutTypeId",
                table: "Workout");

            migrationBuilder.DropTable(
                name: "WorkoutType");

            migrationBuilder.DropIndex(
                name: "IX_Workout_WorkoutTypeId",
                table: "Workout");

            migrationBuilder.DropColumn(
                name: "WorkoutTypeId",
                table: "Workout");
        }
    }
}

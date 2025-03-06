using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class EdittingPatientEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalRecordNumber",
                table: "Patients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicalRecordNumber",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}

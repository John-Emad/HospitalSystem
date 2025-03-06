using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonIdtoDoctorandPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Doctors_DoctorId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Patients_PatientId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DoctorId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PatientId",
                table: "People");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_DoctorId",
                table: "People",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PatientId",
                table: "People",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Doctors_DoctorId",
                table: "People",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Patients_PatientId",
                table: "People",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace OwnGiveSave.Data.Migrations
{
    public partial class ChangeBetweenRelationsInPatientBloodAndDonorBlood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blood_Donors_DonorId",
                table: "Blood");

            migrationBuilder.DropForeignKey(
                name: "FK_Blood_Patients_PatientId",
                table: "Blood");

            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Blood_DonorId",
                table: "Blood");

            migrationBuilder.DropIndex(
                name: "IX_Blood_PatientId",
                table: "Blood");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Blood",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonorId",
                table: "Blood",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodId",
                table: "Patients",
                column: "BloodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodId",
                table: "Donors",
                column: "BloodId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_BloodId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Donors_BloodId",
                table: "Donors");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Blood",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonorId",
                table: "Blood",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodId",
                table: "Patients",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodId",
                table: "Donors",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Blood_DonorId",
                table: "Blood",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Blood_PatientId",
                table: "Blood",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blood_Donors_DonorId",
                table: "Blood",
                column: "DonorId",
                principalTable: "Donors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blood_Patients_PatientId",
                table: "Blood",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

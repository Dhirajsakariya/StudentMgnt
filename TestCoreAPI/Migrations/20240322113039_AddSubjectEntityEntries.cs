using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSubjectEntityEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StandardId",
                table: "AdminTeachers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminTeachers",
                keyColumn: "Id",
                keyValue: new Guid("8f66bdc0-e70f-4153-b806-5c4a344e0b47"),
                column: "StandardId",
                value: null);

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "StandardId" },
                values: new object[,]
                {
                    { new Guid("032082cd-95aa-4827-9fa7-9f6b5f6e27fe"), "Science", new Guid("3241a142-031d-41e4-a1ba-239efc8559f7") },
                    { new Guid("0416e0ea-3c21-4ec8-95d4-3fb5750409c8"), "Gujrati", new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40") },
                    { new Guid("08965a20-5133-4973-8abe-880ee4c9d459"), "Gujrati", new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316") },
                    { new Guid("0c1b106e-5cee-4669-b8fc-fe82fa8d8af8"), "Computer", new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316") },
                    { new Guid("111a84aa-bf19-4cb5-970b-87fb6d69de6b"), "Sanskrit", new Guid("b880223f-458f-4e5f-a012-313119be3724") },
                    { new Guid("15565504-cc67-4a0c-95dc-9ba7487f5da7"), "Maths", new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316") },
                    { new Guid("1c932ef0-6e4e-4745-9887-b73148594b40"), "Gujrati", new Guid("b880223f-458f-4e5f-a012-313119be3724") },
                    { new Guid("20be64c7-ec87-4f8f-9589-b01d648872aa"), "Social Science", new Guid("3241a142-031d-41e4-a1ba-239efc8559f7") },
                    { new Guid("25418d7c-0bc0-44fa-af90-716bbfda4fd3"), "Computer", new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40") },
                    { new Guid("26b69dbf-af43-43ee-977f-2d083f905767"), "Maths", new Guid("b880223f-458f-4e5f-a012-313119be3724") },
                    { new Guid("2a0d243d-c7e6-4212-bed6-46a0688995a3"), "Social Science", new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386") },
                    { new Guid("2a3d67ca-41a5-4878-8163-5a55f82242ce"), "Maths", new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40") },
                    { new Guid("32f85ec7-69ad-4a09-9975-5e38d213aa45"), "Hindi", new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c") },
                    { new Guid("34baa2cc-27ae-450a-a68a-879b93a4a19b"), "Sanskrit", new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316") },
                    { new Guid("3d2b8eb5-db35-4e5e-a834-a48cfdfbdef9"), "Computer", new Guid("b880223f-458f-4e5f-a012-313119be3724") },
                    { new Guid("45caf56f-3a19-4ffd-b440-58efe9636348"), "Gujrati", new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386") },
                    { new Guid("48e34651-25a6-4990-a4a6-bef546abc646"), "Science", new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40") },
                    { new Guid("4a543c11-2528-47d9-b6b9-87d6715662f8"), "English", new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316") },
                    { new Guid("4c3b9f1e-c539-472d-b84f-fd99b7fbba19"), "Computer", new Guid("3241a142-031d-41e4-a1ba-239efc8559f7") },
                    { new Guid("5a41defe-5db1-40bc-985a-94e5e6fb716a"), "Maths", new Guid("3241a142-031d-41e4-a1ba-239efc8559f7") },
                    { new Guid("64d5193e-2c83-4074-88ba-4e6dae087e34"), "Social Science", new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c") },
                    { new Guid("6e5eaf49-2569-47c0-93b3-c6f2710f496d"), "Social Science", new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316") },
                    { new Guid("6e64fc17-847c-40cb-cfc0-08dc3dcf00a7"), "Social Science", new Guid("b880223f-458f-4e5f-a012-313119be3724") },
                    { new Guid("7c16a113-f763-4924-b53d-2dd61658fc3e"), "Science", new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c") },
                    { new Guid("81dd90f9-ca23-4cb6-b033-a719e162acbd"), "Science", new Guid("f82ba9d1-5d85-4c20-bca0-142dd07e1316") },
                    { new Guid("85d4c5ed-951e-4071-804a-3f18936ce1ae"), "Science", new Guid("b880223f-458f-4e5f-a012-313119be3724") },
                    { new Guid("86fab670-b1d9-4060-92f5-abf844e7722e"), "Computer", new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386") },
                    { new Guid("8c2c6493-7967-450c-aa4b-1e1b08470dca"), "Gujrati", new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c") },
                    { new Guid("8ede72b7-0489-4767-8527-87da60a15ae2"), "English", new Guid("3241a142-031d-41e4-a1ba-239efc8559f7") },
                    { new Guid("8f66bdc0-e70f-4153-b806-5c4a344e0b47"), "Hindi", new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40") },
                    { new Guid("932978e9-6ebe-46f0-8440-bbc08d4419f4"), "Gujrati", new Guid("3241a142-031d-41e4-a1ba-239efc8559f7") },
                    { new Guid("9e3aca2b-d4eb-43a7-8b97-2530a8cb029d"), "Maths", new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c") },
                    { new Guid("a2b2a0f2-a8c5-4d5b-b805-71a2555804d2"), "Computer", new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c") },
                    { new Guid("a66ecdba-36c5-4501-9737-0d40cdaa264e"), "English", new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40") },
                    { new Guid("bc5c3e5b-7d3d-46fa-9ebc-f98b3b63dfcc"), "English", new Guid("b880223f-458f-4e5f-a012-313119be3724") },
                    { new Guid("c2f93ee2-e912-4b03-8336-7ca346bcc83b"), "Social Science", new Guid("49716b8a-aca6-4ce9-9a74-199ce2a5af40") },
                    { new Guid("c345ea33-ceef-4362-89a2-ec572495a5f1"), "English", new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386") },
                    { new Guid("cf6e4282-70c0-46d4-a37c-215c0dabaf2d"), "Science", new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386") },
                    { new Guid("e9b68c31-2ac3-4b12-84d8-031fe146b10a"), "Sanskrit", new Guid("3241a142-031d-41e4-a1ba-239efc8559f7") },
                    { new Guid("eca06498-6177-4403-a63c-08dc40022339"), "Maths", new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386") },
                    { new Guid("ef966dd1-8455-430c-9a7d-134b564f29ab"), "English", new Guid("a8283465-6ae7-43d6-8eca-09c02ab12b4c") },
                    { new Guid("fdca3b5e-ebf5-4a21-8652-8853e5374b52"), "Hindi", new Guid("1ecc5761-7ddb-4ef7-8b16-28c91845a386") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminTeachers_StandardId",
                table: "AdminTeachers",
                column: "StandardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminTeachers_Standards_StandardId",
                table: "AdminTeachers",
                column: "StandardId",
                principalTable: "Standards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminTeachers_Standards_StandardId",
                table: "AdminTeachers");

            migrationBuilder.DropIndex(
                name: "IX_AdminTeachers_StandardId",
                table: "AdminTeachers");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("032082cd-95aa-4827-9fa7-9f6b5f6e27fe"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("0416e0ea-3c21-4ec8-95d4-3fb5750409c8"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("08965a20-5133-4973-8abe-880ee4c9d459"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("0c1b106e-5cee-4669-b8fc-fe82fa8d8af8"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("111a84aa-bf19-4cb5-970b-87fb6d69de6b"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("15565504-cc67-4a0c-95dc-9ba7487f5da7"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("1c932ef0-6e4e-4745-9887-b73148594b40"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("20be64c7-ec87-4f8f-9589-b01d648872aa"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("25418d7c-0bc0-44fa-af90-716bbfda4fd3"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("26b69dbf-af43-43ee-977f-2d083f905767"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("2a0d243d-c7e6-4212-bed6-46a0688995a3"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("2a3d67ca-41a5-4878-8163-5a55f82242ce"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("32f85ec7-69ad-4a09-9975-5e38d213aa45"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("34baa2cc-27ae-450a-a68a-879b93a4a19b"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("3d2b8eb5-db35-4e5e-a834-a48cfdfbdef9"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("45caf56f-3a19-4ffd-b440-58efe9636348"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("48e34651-25a6-4990-a4a6-bef546abc646"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("4a543c11-2528-47d9-b6b9-87d6715662f8"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("4c3b9f1e-c539-472d-b84f-fd99b7fbba19"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("5a41defe-5db1-40bc-985a-94e5e6fb716a"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("64d5193e-2c83-4074-88ba-4e6dae087e34"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("6e5eaf49-2569-47c0-93b3-c6f2710f496d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("6e64fc17-847c-40cb-cfc0-08dc3dcf00a7"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("7c16a113-f763-4924-b53d-2dd61658fc3e"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("81dd90f9-ca23-4cb6-b033-a719e162acbd"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("85d4c5ed-951e-4071-804a-3f18936ce1ae"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("86fab670-b1d9-4060-92f5-abf844e7722e"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8c2c6493-7967-450c-aa4b-1e1b08470dca"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8ede72b7-0489-4767-8527-87da60a15ae2"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("8f66bdc0-e70f-4153-b806-5c4a344e0b47"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("932978e9-6ebe-46f0-8440-bbc08d4419f4"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("9e3aca2b-d4eb-43a7-8b97-2530a8cb029d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("a2b2a0f2-a8c5-4d5b-b805-71a2555804d2"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("a66ecdba-36c5-4501-9737-0d40cdaa264e"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("bc5c3e5b-7d3d-46fa-9ebc-f98b3b63dfcc"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("c2f93ee2-e912-4b03-8336-7ca346bcc83b"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("c345ea33-ceef-4362-89a2-ec572495a5f1"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("cf6e4282-70c0-46d4-a37c-215c0dabaf2d"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("e9b68c31-2ac3-4b12-84d8-031fe146b10a"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("eca06498-6177-4403-a63c-08dc40022339"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("ef966dd1-8455-430c-9a7d-134b564f29ab"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: new Guid("fdca3b5e-ebf5-4a21-8652-8853e5374b52"));

            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "AdminTeachers");
        }
    }
}

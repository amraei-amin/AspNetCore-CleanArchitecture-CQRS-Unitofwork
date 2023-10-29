using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoyalPersistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialRoyalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceGroupMemberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeviceGroup_Id = table.Column<int>(type: "int", nullable: true),
                    RoyalDevice_ID = table.Column<int>(type: "int", nullable: true),
                    GroupIsRemoved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroupMemberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemoveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DefaultGroup = table.Column<bool>(type: "bit", nullable: false),
                    Owner_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMaster = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoyalDevices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceHardwareId = table.Column<int>(type: "int", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: true),
                    Owner_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastEmployeesUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsiderShowingOrder = table.Column<bool>(type: "bit", nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoyalDevices", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceGroupMemberships");

            migrationBuilder.DropTable(
                name: "DeviceGroups");

            migrationBuilder.DropTable(
                name: "RoyalDevices");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Graduation_Core.Migrations
{
    public partial class IniMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Calc_ID = table.Column<int>(nullable: false),
                    Calc_Weight = table.Column<double>(nullable: false),
                    Calc_fragile = table.Column<double>(nullable: false),
                    Calc_Early = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Calc_ID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    C_ID = table.Column<int>(nullable: false),
                    C_Name = table.Column<string>(maxLength: 30, nullable: true),
                    Day_Of_Travel = table.Column<string>(maxLength: 50, nullable: false),
                    C_Lat = table.Column<double>(nullable: false),
                    C_Long = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.C_ID);
                });

            migrationBuilder.CreateTable(
                name: "Packages_Info",
                columns: table => new
                {
                    P_ID = table.Column<long>(nullable: false),
                    P_WEIGHT = table.Column<int>(nullable: false),
                    P_FARAGIAL = table.Column<string>(maxLength: 50, nullable: false),
                    P_PRICE = table.Column<double>(nullable: false),
                    DESCRIPTION = table.Column<string>(maxLength: 150, nullable: true),
                    EARLYDELIVERY = table.Column<string>(maxLength: 50, nullable: true),
                    DELEVERYDATE = table.Column<DateTime>(type: "date", nullable: true),
                    S_SSN = table.Column<string>(maxLength: 50, nullable: false),
                    R_SSN = table.Column<string>(maxLength: 50, nullable: false),
                    P_DELIVER_STATUS = table.Column<string>(maxLength: 50, nullable: false),
                    P_L_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages_Info", x => x.P_ID);
                });

            migrationBuilder.CreateTable(
                name: "Sender_Info",
                columns: table => new
                {
                    S_ID = table.Column<long>(nullable: false),
                    S_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    S_MOBILE = table.Column<string>(maxLength: 50, nullable: false),
                    S_EMAIL = table.Column<string>(maxLength: 50, nullable: true),
                    S_ADDRESS = table.Column<string>(maxLength: 50, nullable: false),
                    S_SSN = table.Column<string>(maxLength: 50, nullable: false),
                    S_C_ID = table.Column<int>(nullable: false),
                    S_ADDRESS_DETAIL = table.Column<string>(maxLength: 150, nullable: true),
                    S_C_D_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sender_Info", x => x.S_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users_Roles",
                columns: table => new
                {
                    ROLE_ID = table.Column<int>(nullable: false),
                    ROLE_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ROLE_DESC = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    QUERY_ALLOWED = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    INSERT_ALLOWED = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    UPDATE_ALLOWED = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    DELETE_ALLOWED = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Roles", x => x.ROLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City_Details",
                columns: table => new
                {
                    C_D_ID = table.Column<int>(nullable: false),
                    C_ID = table.Column<int>(nullable: false),
                    T_C_NAME = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City_Details", x => x.C_D_ID);
                    table.ForeignKey(
                        name: "FK_City_Details_City",
                        column: x => x.C_ID,
                        principalTable: "City",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    L_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    L_FROM = table.Column<string>(maxLength: 50, nullable: false),
                    L_TO = table.Column<string>(maxLength: 50, nullable: false),
                    PRICE = table.Column<int>(nullable: false),
                    C_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.L_ID);
                    table.ForeignKey(
                        name: "FK_Locations_City",
                        column: x => x.C_ID,
                        principalTable: "City",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receiver_Info",
                columns: table => new
                {
                    R_ID = table.Column<long>(nullable: false),
                    R_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    R_MOBILE = table.Column<string>(maxLength: 50, nullable: false),
                    R_EMAIL = table.Column<string>(maxLength: 50, nullable: true),
                    R_ADDRESS = table.Column<string>(maxLength: 50, nullable: false),
                    R_SSN = table.Column<string>(maxLength: 50, nullable: false),
                    S_ID = table.Column<long>(nullable: false),
                    R_C_ID = table.Column<int>(nullable: false),
                    R_ADDRESS_DETAIL = table.Column<string>(maxLength: 250, nullable: true),
                    R_C_D_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiver_Info", x => x.R_ID);
                    table.ForeignKey(
                        name: "FK_Receiver_Info_Sender_Info",
                        column: x => x.S_ID,
                        principalTable: "Sender_Info",
                        principalColumn: "S_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users_Details",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false),
                    USR_NAME = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    USER_PASSWORD = table.Column<string>(maxLength: 50, nullable: true),
                    USER_FULL_NAME = table.Column<string>(maxLength: 100, nullable: true),
                    ROLE_ID = table.Column<int>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Details", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_Users_Details_Users_Roles",
                        column: x => x.ROLE_ID,
                        principalTable: "Users_Roles",
                        principalColumn: "ROLE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Emp_ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Emp_NAME = table.Column<string>(maxLength: 50, nullable: false),
                    Emp_MOBILE = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Emp_EMAIL = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Emp_ADDRESS = table.Column<string>(maxLength: 50, nullable: false),
                    Emp_SSN = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Emp_C_ID = table.Column<int>(nullable: false),
                    Emp_ADDRESS_DETAILS = table.Column<string>(maxLength: 150, nullable: true),
                    Emp_L_ID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Emp_ID);
                    table.ForeignKey(
                        name: "FK_Employee_City",
                        column: x => x.Emp_C_ID,
                        principalTable: "City",
                        principalColumn: "C_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Locations",
                        column: x => x.Emp_L_ID,
                        principalTable: "Locations",
                        principalColumn: "L_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_Details_C_ID",
                table: "City_Details",
                column: "C_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Emp_C_ID",
                table: "Employee",
                column: "Emp_C_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Emp_L_ID",
                table: "Employee",
                column: "Emp_L_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_C_ID",
                table: "Locations",
                column: "C_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Receiver_Info_S_ID",
                table: "Receiver_Info",
                column: "S_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Details_ROLE_ID",
                table: "Users_Details",
                column: "ROLE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropTable(
                name: "City_Details");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Packages_Info");

            migrationBuilder.DropTable(
                name: "Receiver_Info");

            migrationBuilder.DropTable(
                name: "Users_Details");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Sender_Info");

            migrationBuilder.DropTable(
                name: "Users_Roles");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "taller");

            migrationBuilder.CreateTable(
                name: "Company",
                schema: "taller",
                columns: table => new
                {
                    IdCompany = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LegalName = table.Column<string>(type: "text", nullable: false),
                    TradeName = table.Column<string>(type: "text", nullable: true),
                    TaxId = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.IdCompany);
                    table.CheckConstraint("CK_Company_Address_Length", "length(\"Address\") <= 255");
                    table.CheckConstraint("CK_Company_Email_Length", "length(\"Email\") <= 100");
                    table.CheckConstraint("CK_Company_LegalName_Length", "length(\"LegalName\") <= 150");
                    table.CheckConstraint("CK_Company_LogoUrl_Length", "length(\"LogoUrl\") <= 255");
                    table.CheckConstraint("CK_Company_Phone_Length", "length(\"Phone\") <= 50");
                    table.CheckConstraint("CK_Company_TaxId_Length", "length(\"TaxId\") <= 15");
                    table.CheckConstraint("CK_Company_TradeName_Length", "length(\"TradeName\") <= 150");
                });

            migrationBuilder.CreateTable(
                name: "Module",
                schema: "taller",
                columns: table => new
                {
                    IdModule = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.IdModule);
                    table.CheckConstraint("CK_Module_Name_Length", "length(\"Name\") <= 100");
                });

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                schema: "taller",
                columns: table => new
                {
                    IdProductBrand = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.IdProductBrand);
                    table.CheckConstraint("CK_ProductBrand_Name_Length", "length(\"Name\") <= 100");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                schema: "taller",
                columns: table => new
                {
                    IdService = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Hours = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.IdService);
                    table.CheckConstraint("CK_Service_Description_Length", "length(\"Description\") <= 255");
                    table.CheckConstraint("CK_Service_Name_Length", "length(\"Name\") <= 50");
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "taller",
                columns: table => new
                {
                    IdState = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                    table.CheckConstraint("CK_State_Name_Length", "length(\"Name\") <= 25");
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                schema: "taller",
                columns: table => new
                {
                    IdUnitType = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.IdUnitType);
                    table.CheckConstraint("CK_UnitType_Description_Length", "length(\"Description\") <= 150");
                    table.CheckConstraint("CK_UnitType_Name_Length", "length(\"Name\") <= 200");
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrand",
                schema: "taller",
                columns: table => new
                {
                    IdVehicleBrand = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrand", x => x.IdVehicleBrand);
                    table.CheckConstraint("CK_VehicleBrand_Name_Length", "length(\"Name\") <= 50");
                });

            migrationBuilder.CreateTable(
                name: "Option",
                schema: "taller",
                columns: table => new
                {
                    IdOption = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdModule = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.IdOption);
                    table.CheckConstraint("CK_Option_Name_Length", "length(\"Name\") <= 100");
                    table.ForeignKey(
                        name: "FK_Option_Module_IdModule",
                        column: x => x.IdModule,
                        principalSchema: "taller",
                        principalTable: "Module",
                        principalColumn: "IdModule",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "taller",
                columns: table => new
                {
                    IdCity = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IdState = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.IdCity);
                    table.CheckConstraint("CK_City_Name_Length", "length(\"Name\") <= 25");
                    table.ForeignKey(
                        name: "FK_City_State_IdState",
                        column: x => x.IdState,
                        principalSchema: "taller",
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehicleModel",
                schema: "taller",
                columns: table => new
                {
                    IdVehicleModel = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IdVehicleBrand = table.Column<long>(type: "bigint", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModel", x => x.IdVehicleModel);
                    table.CheckConstraint("CK_VehicleModel_Description_Length", "length(\"Description\") <= 100");
                    table.CheckConstraint("CK_VehicleModel_Name_Length", "length(\"Name\") <= 50");
                    table.ForeignKey(
                        name: "FK_VehicleModel_VehicleBrand_IdVehicleBrand",
                        column: x => x.IdVehicleBrand,
                        principalSchema: "taller",
                        principalTable: "VehicleBrand",
                        principalColumn: "IdVehicleBrand",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "taller",
                columns: table => new
                {
                    IdCustomer = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NationalId = table.Column<string>(type: "text", nullable: true),
                    TaxId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    SecondLastName = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdCity = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IdCustomer);
                    table.CheckConstraint("CK_Customer_Email_Length", "length(\"Email\") <= 50");
                    table.CheckConstraint("CK_Customer_FirstName_Length", "length(\"FirstName\") <= 35");
                    table.CheckConstraint("CK_Customer_LastName_Length", "length(\"LastName\") <= 35");
                    table.CheckConstraint("CK_Customer_MiddleName_Length", "length(\"MiddleName\") <= 35");
                    table.CheckConstraint("CK_Customer_NationalId_Length", "length(\"NationalId\") <= 20");
                    table.CheckConstraint("CK_Customer_Phone_Length", "length(\"Phone\") <= 20");
                    table.CheckConstraint("CK_Customer_SecondLastName_Length", "length(\"SecondLastName\") <= 35");
                    table.CheckConstraint("CK_Customer_TaxId_Length", "length(\"TaxId\") <= 15");
                    table.ForeignKey(
                        name: "FK_Customer_City_IdCity",
                        column: x => x.IdCity,
                        principalSchema: "taller",
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "taller",
                columns: table => new
                {
                    IdEmployee = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    NationalId = table.Column<string>(type: "text", nullable: false),
                    TaxId = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    SecondLastName = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TerminationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: false),
                    IdCity = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.IdEmployee);
                    table.CheckConstraint("CK_Employee_Address_Length", "length(\"Address\") <= 150");
                    table.CheckConstraint("CK_Employee_Code_Length", "length(\"Code\") <= 20");
                    table.CheckConstraint("CK_Employee_FirstName_Length", "length(\"FirstName\") <= 35");
                    table.CheckConstraint("CK_Employee_Gender_Length", "length(\"Gender\") <= 15");
                    table.CheckConstraint("CK_Employee_LastName_Length", "length(\"LastName\") <= 35");
                    table.CheckConstraint("CK_Employee_MiddleName_Length", "length(\"MiddleName\") <= 35");
                    table.CheckConstraint("CK_Employee_NationalId_Length", "length(\"NationalId\") <= 20");
                    table.CheckConstraint("CK_Employee_Phone_Length", "length(\"Phone\") <= 10");
                    table.CheckConstraint("CK_Employee_Position_Length", "length(\"Position\") <= 150");
                    table.CheckConstraint("CK_Employee_SecondLastName_Length", "length(\"SecondLastName\") <= 35");
                    table.CheckConstraint("CK_Employee_TaxId_Length", "length(\"TaxId\") <= 15");
                    table.ForeignKey(
                        name: "FK_Employee_City_IdCity",
                        column: x => x.IdCity,
                        principalSchema: "taller",
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "taller",
                columns: table => new
                {
                    IdSupplier = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    IdCity = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.IdSupplier);
                    table.CheckConstraint("CK_Supplier_Address_Length", "length(\"Address\") <= 150");
                    table.CheckConstraint("CK_Supplier_Name_Length", "length(\"Name\") <= 150");
                    table.CheckConstraint("CK_Supplier_Phone_Length", "length(\"Phone\") <= 15");
                    table.ForeignKey(
                        name: "FK_Supplier_City_IdCity",
                        column: x => x.IdCity,
                        principalSchema: "taller",
                        principalTable: "City",
                        principalColumn: "IdCity",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                schema: "taller",
                columns: table => new
                {
                    IdVehicle = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LicensePlate = table.Column<string>(type: "text", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: true),
                    Engine = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IdVehicleModel = table.Column<long>(type: "bigint", nullable: false),
                    IdCustomer = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.IdVehicle);
                    table.CheckConstraint("CK_Vehicle_Color_Length", "length(\"Color\") <= 50");
                    table.CheckConstraint("CK_Vehicle_Description_Length", "length(\"Description\") <= 255");
                    table.CheckConstraint("CK_Vehicle_Engine_Length", "length(\"Engine\") <= 50");
                    table.CheckConstraint("CK_Vehicle_LicensePlate_Length", "length(\"LicensePlate\") <= 50");
                    table.CheckConstraint("CK_Vehicle_Vin_Length", "length(\"Vin\") <= 17");
                    table.ForeignKey(
                        name: "FK_Vehicle_Customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalSchema: "taller",
                        principalTable: "Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleModel_IdVehicleModel",
                        column: x => x.IdVehicleModel,
                        principalSchema: "taller",
                        principalTable: "VehicleModel",
                        principalColumn: "IdVehicleModel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "taller",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    IdEmployee = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.CheckConstraint("CK_User_Name_Length", "length(\"Name\") <= 50");
                    table.CheckConstraint("CK_User_PasswordHash_Length", "length(\"PasswordHash\") <= 255");
                    table.ForeignKey(
                        name: "FK_User_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalSchema: "taller",
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "taller",
                columns: table => new
                {
                    IdProduct = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CostPrice = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    SalePrice = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    QuantityPerProduct = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IdSupplier = table.Column<long>(type: "bigint", nullable: false),
                    IdProductBrand = table.Column<long>(type: "bigint", nullable: false),
                    IdUnitType = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                    table.CheckConstraint("CK_Product_Code_Length", "length(\"Code\") <= 20");
                    table.CheckConstraint("CK_Product_Description_Length", "length(\"Description\") <= 100");
                    table.CheckConstraint("CK_Product_Name_Length", "length(\"Name\") <= 50");
                    table.CheckConstraint("CK_Product_Status_Length", "length(\"Status\") <= 15");
                    table.CheckConstraint("CK_Product_Stock_NonNegative", "\"Stock\" >= 0");
                    table.ForeignKey(
                        name: "FK_Product_ProductBrand_IdProductBrand",
                        column: x => x.IdProductBrand,
                        principalSchema: "taller",
                        principalTable: "ProductBrand",
                        principalColumn: "IdProductBrand",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_IdSupplier",
                        column: x => x.IdSupplier,
                        principalSchema: "taller",
                        principalTable: "Supplier",
                        principalColumn: "IdSupplier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitType_IdUnitType",
                        column: x => x.IdUnitType,
                        principalSchema: "taller",
                        principalTable: "UnitType",
                        principalColumn: "IdUnitType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intake",
                schema: "taller",
                columns: table => new
                {
                    IdIntake = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IntakeDate = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    ExitDate = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    Mileage = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IdVehicle = table.Column<long>(type: "bigint", nullable: false),
                    IdReceivingEmployee = table.Column<long>(type: "bigint", nullable: false),
                    VoidedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    VoidReason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intake", x => x.IdIntake);
                    table.CheckConstraint("CK_Intake_Code_Length", "length(\"Code\") <= 20");
                    table.CheckConstraint("CK_Intake_Notes_Length", "length(\"Notes\") <= 150");
                    table.CheckConstraint("CK_Intake_Status_Length", "length(\"Status\") <= 15");
                    table.CheckConstraint("CK_Intake_VoidReason_Length", "length(\"VoidReason\") <= 255");
                    table.ForeignKey(
                        name: "FK_Intake_Employee_IdReceivingEmployee",
                        column: x => x.IdReceivingEmployee,
                        principalSchema: "taller",
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Intake_Vehicle_IdVehicle",
                        column: x => x.IdVehicle,
                        principalSchema: "taller",
                        principalTable: "Vehicle",
                        principalColumn: "IdVehicle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "taller",
                columns: table => new
                {
                    IdPermission = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssignedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdOption = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.IdPermission);
                    table.ForeignKey(
                        name: "FK_Permission_Option_IdOption",
                        column: x => x.IdOption,
                        principalSchema: "taller",
                        principalTable: "Option",
                        principalColumn: "IdOption",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permission_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "taller",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quote",
                schema: "taller",
                columns: table => new
                {
                    IdQuote = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Place = table.Column<string>(type: "text", nullable: false),
                    TotalServices = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    TotalProducts = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Balance = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdIntake = table.Column<long>(type: "bigint", nullable: false),
                    IdEmployee = table.Column<long>(type: "bigint", nullable: false),
                    VoidedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    VoidReason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.IdQuote);
                    table.CheckConstraint("CK_Quote_Code_Length", "length(\"Code\") <= 20");
                    table.CheckConstraint("CK_Quote_Comments_Length", "length(\"Comments\") <= 255");
                    table.CheckConstraint("CK_Quote_Place_Length", "length(\"Place\") <= 200");
                    table.CheckConstraint("CK_Quote_Status_Length", "length(\"Status\") <= 15");
                    table.CheckConstraint("CK_Quote_VoidReason_Length", "length(\"VoidReason\") <= 255");
                    table.ForeignKey(
                        name: "FK_Quote_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalSchema: "taller",
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quote_Intake_IdIntake",
                        column: x => x.IdIntake,
                        principalSchema: "taller",
                        principalTable: "Intake",
                        principalColumn: "IdIntake",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quote_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "taller",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Process",
                schema: "taller",
                columns: table => new
                {
                    IdProcess = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hours = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    StartedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    FinishedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IdQuote = table.Column<long>(type: "bigint", nullable: false),
                    IdService = table.Column<long>(type: "bigint", nullable: false),
                    IdEmployee = table.Column<long>(type: "bigint", nullable: false),
                    VoidedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    VoidReason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.IdProcess);
                    table.CheckConstraint("CK_Process_Status_Length", "length(\"Status\") <= 15");
                    table.CheckConstraint("CK_Process_VoidReason_Length", "length(\"VoidReason\") <= 255");
                    table.ForeignKey(
                        name: "FK_Process_Employee_IdEmployee",
                        column: x => x.IdEmployee,
                        principalSchema: "taller",
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Process_Quote_IdQuote",
                        column: x => x.IdQuote,
                        principalSchema: "taller",
                        principalTable: "Quote",
                        principalColumn: "IdQuote",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Process_Service_IdService",
                        column: x => x.IdService,
                        principalSchema: "taller",
                        principalTable: "Service",
                        principalColumn: "IdService",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "taller",
                columns: table => new
                {
                    IdSale = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    ProductCount = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IdCustomer = table.Column<long>(type: "bigint", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdQuote = table.Column<long>(type: "bigint", nullable: true),
                    VoidedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IdSale);
                    table.CheckConstraint("CK_Sale_Code_Length", "length(\"Code\") <= 20");
                    table.CheckConstraint("CK_Sale_Status_Length", "length(\"Status\") <= 15");
                    table.ForeignKey(
                        name: "FK_Sale_Customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalSchema: "taller",
                        principalTable: "Customer",
                        principalColumn: "IdCustomer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_Quote_IdQuote",
                        column: x => x.IdQuote,
                        principalSchema: "taller",
                        principalTable: "Quote",
                        principalColumn: "IdQuote",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sale_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "taller",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instruction",
                schema: "taller",
                columns: table => new
                {
                    IdInstruction = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IdProcess = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruction", x => x.IdInstruction);
                    table.CheckConstraint("CK_Instruction_Description_Length", "length(\"Description\") <= 150");
                    table.ForeignKey(
                        name: "FK_Instruction_Process_IdProcess",
                        column: x => x.IdProcess,
                        principalSchema: "taller",
                        principalTable: "Process",
                        principalColumn: "IdProcess",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcessDetail",
                schema: "taller",
                columns: table => new
                {
                    IdProcessDetail = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    IdProduct = table.Column<long>(type: "bigint", nullable: false),
                    IdProcess = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessDetail", x => x.IdProcessDetail);
                    table.ForeignKey(
                        name: "FK_ProcessDetail_Process_IdProcess",
                        column: x => x.IdProcess,
                        principalSchema: "taller",
                        principalTable: "Process",
                        principalColumn: "IdProcess",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessDetail_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "taller",
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "taller",
                columns: table => new
                {
                    IdPayment = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Concept = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdQuote = table.Column<long>(type: "bigint", nullable: true),
                    IdSale = table.Column<long>(type: "bigint", nullable: true),
                    VoidedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true),
                    VoidReason = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.IdPayment);
                    table.CheckConstraint("CK_Payment_Code_Length", "length(\"Code\") <= 20");
                    table.CheckConstraint("CK_Payment_Concept_Length", "length(\"Concept\") <= 255");
                    table.CheckConstraint("CK_Payment_ExclusiveTarget", "num_nonnulls(\"IdQuote\", \"IdSale\") = 1");
                    table.CheckConstraint("CK_Payment_Status_Length", "length(\"Status\") <= 15");
                    table.CheckConstraint("CK_Payment_VoidReason_Length", "length(\"VoidReason\") <= 255");
                    table.ForeignKey(
                        name: "FK_Payment_Quote_IdQuote",
                        column: x => x.IdQuote,
                        principalSchema: "taller",
                        principalTable: "Quote",
                        principalColumn: "IdQuote",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Sale_IdSale",
                        column: x => x.IdSale,
                        principalSchema: "taller",
                        principalTable: "Sale",
                        principalColumn: "IdSale",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "taller",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                schema: "taller",
                columns: table => new
                {
                    IdSaleDetail = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    IdSale = table.Column<long>(type: "bigint", nullable: false),
                    IdProduct = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.IdSaleDetail);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "taller",
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_IdSale",
                        column: x => x.IdSale,
                        principalSchema: "taller",
                        principalTable: "Sale",
                        principalColumn: "IdSale",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryMovement",
                schema: "taller",
                columns: table => new
                {
                    IdMovement = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitCost = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    IdProduct = table.Column<long>(type: "bigint", nullable: false),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdProcessDetail = table.Column<long>(type: "bigint", nullable: true),
                    IdSaleDetail = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryMovement", x => x.IdMovement);
                    table.CheckConstraint("CK_InventoryMovement_ExclusiveDetail", "num_nonnulls(\"IdProcessDetail\", \"IdSaleDetail\") <= 1");
                    table.CheckConstraint("CK_InventoryMovement_Reference_Length", "length(\"Reference\") <= 50");
                    table.CheckConstraint("CK_InventoryMovement_Type_Length", "length(\"Type\") <= 15");
                    table.ForeignKey(
                        name: "FK_InventoryMovement_ProcessDetail_IdProcessDetail",
                        column: x => x.IdProcessDetail,
                        principalSchema: "taller",
                        principalTable: "ProcessDetail",
                        principalColumn: "IdProcessDetail",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovement_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalSchema: "taller",
                        principalTable: "Product",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovement_SaleDetail_IdSaleDetail",
                        column: x => x.IdSaleDetail,
                        principalSchema: "taller",
                        principalTable: "SaleDetail",
                        principalColumn: "IdSaleDetail",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryMovement_User_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "taller",
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_IdState",
                schema: "taller",
                table: "City",
                column: "IdState");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdCity",
                schema: "taller",
                table: "Customer",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_NationalId",
                schema: "taller",
                table: "Customer",
                column: "NationalId",
                unique: true,
                filter: "\"NationalId\" IS NOT NULL AND \"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Code",
                schema: "taller",
                table: "Employee",
                column: "Code",
                unique: true,
                filter: "\"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdCity",
                schema: "taller",
                table: "Employee",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_IdProcess",
                schema: "taller",
                table: "Instruction",
                column: "IdProcess");

            migrationBuilder.CreateIndex(
                name: "IX_Intake_Code",
                schema: "taller",
                table: "Intake",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Intake_IdReceivingEmployee",
                schema: "taller",
                table: "Intake",
                column: "IdReceivingEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Intake_IdVehicle",
                schema: "taller",
                table: "Intake",
                column: "IdVehicle");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovement_IdProcessDetail",
                schema: "taller",
                table: "InventoryMovement",
                column: "IdProcessDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovement_IdProduct",
                schema: "taller",
                table: "InventoryMovement",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovement_IdSaleDetail",
                schema: "taller",
                table: "InventoryMovement",
                column: "IdSaleDetail");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryMovement_IdUser",
                schema: "taller",
                table: "InventoryMovement",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Option_IdModule",
                schema: "taller",
                table: "Option",
                column: "IdModule");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Code",
                schema: "taller",
                table: "Payment",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdQuote",
                schema: "taller",
                table: "Payment",
                column: "IdQuote");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdSale",
                schema: "taller",
                table: "Payment",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_IdUser",
                schema: "taller",
                table: "Payment",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdOption",
                schema: "taller",
                table: "Permission",
                column: "IdOption");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_IdUser_IdOption",
                schema: "taller",
                table: "Permission",
                columns: new[] { "IdUser", "IdOption" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_IdEmployee",
                schema: "taller",
                table: "Process",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Process_IdQuote",
                schema: "taller",
                table: "Process",
                column: "IdQuote");

            migrationBuilder.CreateIndex(
                name: "IX_Process_IdService",
                schema: "taller",
                table: "Process",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDetail_IdProcess",
                schema: "taller",
                table: "ProcessDetail",
                column: "IdProcess");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessDetail_IdProduct",
                schema: "taller",
                table: "ProcessDetail",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code",
                schema: "taller",
                table: "Product",
                column: "Code",
                unique: true,
                filter: "\"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdProductBrand",
                schema: "taller",
                table: "Product",
                column: "IdProductBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdSupplier",
                schema: "taller",
                table: "Product",
                column: "IdSupplier");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdUnitType",
                schema: "taller",
                table: "Product",
                column: "IdUnitType");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_Code",
                schema: "taller",
                table: "Quote",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quote_IdEmployee",
                schema: "taller",
                table: "Quote",
                column: "IdEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_IdIntake",
                schema: "taller",
                table: "Quote",
                column: "IdIntake");

            migrationBuilder.CreateIndex(
                name: "IX_Quote_IdUser",
                schema: "taller",
                table: "Quote",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_Code",
                schema: "taller",
                table: "Sale",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdCustomer",
                schema: "taller",
                table: "Sale",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdQuote",
                schema: "taller",
                table: "Sale",
                column: "IdQuote");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdUser",
                schema: "taller",
                table: "Sale",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_IdProduct",
                schema: "taller",
                table: "SaleDetail",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_IdSale",
                schema: "taller",
                table: "SaleDetail",
                column: "IdSale");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_IdCity",
                schema: "taller",
                table: "Supplier",
                column: "IdCity");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdEmployee",
                schema: "taller",
                table: "User",
                column: "IdEmployee",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                schema: "taller",
                table: "User",
                column: "Name",
                unique: true,
                filter: "\"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_IdCustomer",
                schema: "taller",
                table: "Vehicle",
                column: "IdCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_IdVehicleModel",
                schema: "taller",
                table: "Vehicle",
                column: "IdVehicleModel");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_LicensePlate",
                schema: "taller",
                table: "Vehicle",
                column: "LicensePlate",
                unique: true,
                filter: "\"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Vin",
                schema: "taller",
                table: "Vehicle",
                column: "Vin",
                unique: true,
                filter: "\"Vin\" IS NOT NULL AND \"DeletedAt\" IS NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_IdVehicleBrand",
                schema: "taller",
                table: "VehicleModel",
                column: "IdVehicleBrand");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Instruction",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "InventoryMovement",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "ProcessDetail",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "SaleDetail",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Option",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Process",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Module",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Service",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "ProductBrand",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "UnitType",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Quote",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Intake",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "User",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Vehicle",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "VehicleModel",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "City",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "VehicleBrand",
                schema: "taller");

            migrationBuilder.DropTable(
                name: "State",
                schema: "taller");
        }
    }
}

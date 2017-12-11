using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TFP.Persistence.Migrations
{
    public partial class _Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.EnsureSchema(
                name: "Workflow");

            migrationBuilder.EnsureSchema(
                name: "Membership");

            migrationBuilder.CreateSequence<int>(
                name: "AlbumId",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "ApiKeyId",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "CommentId",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "IndividualId",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "MessageId",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "PhotoId",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "SocialId",
                incrementBy: 10);

            migrationBuilder.CreateSequence<int>(
                name: "TfpEventId",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairColor",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairColor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroup",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShootingGenre",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShootingGenre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StylistSpecialization",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StylistSpecialization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionSet",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Individual",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    FirstName = table.Column<string>(maxLength: 128, nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    Phone = table.Column<string>(maxLength: 12, nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Individual_Lookup_Category",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Individual_Lookup_City",
                        column: x => x.CityId,
                        principalSchema: "Lookup",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    PermissionGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookup_Permission_Lookup_PermissionGroup",
                        column: x => x.PermissionGroupId,
                        principalSchema: "Lookup",
                        principalTable: "PermissionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())"),
                    Path = table.Column<string>(maxLength: 256, nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Photo_Membership_Individual",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Breast = table.Column<int>(nullable: false),
                    Growth = table.Column<int>(nullable: false),
                    HairColorId = table.Column<int>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())"),
                    Nude = table.Column<bool>(nullable: false),
                    Thighs = table.Column<int>(nullable: false),
                    Waist = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Model_Lookup_HairColor",
                        column: x => x.HairColorId,
                        principalSchema: "Lookup",
                        principalTable: "HairColor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Model_Id_Membership_Individual",
                        column: x => x.Id,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Model_ModifiedId_Membership_Individual",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photographer",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Photographer_Id_Membership_Individual",
                        column: x => x.Id,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Photographer_ModifiedId_Membership_Individual",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Social",
                schema: "Membership",
                columns: table => new
                {
                    IndividualId = table.Column<Guid>(nullable: false),
                    SocialTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Social", x => new { x.IndividualId, x.SocialTypeId });
                    table.ForeignKey(
                        name: "FK_Membership_Social_Membership_Individual",
                        column: x => x.IndividualId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Social_Membership_SocialType",
                        column: x => x.SocialTypeId,
                        principalSchema: "Lookup",
                        principalTable: "SocialType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stylist",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())"),
                    StylistSpecializationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Stylist_Id_Membership_Individual",
                        column: x => x.Id,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Stylist_ModifiedId_Membership_Individual",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Stylist_Lookup_StylistSpecialization",
                        column: x => x.StylistSpecializationId,
                        principalSchema: "Lookup",
                        principalTable: "StylistSpecialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Membership",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comment = table.Column<string>(maxLength: 512, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    InitialPermissionSetId = table.Column<int>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastBlockedOn = table.Column<DateTime>(nullable: true),
                    LastLoginOn = table.Column<DateTime>(nullable: true),
                    LastPasswordChangedOn = table.Column<DateTime>(nullable: true),
                    Login = table.Column<string>(maxLength: 128, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 128, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_User_Membership_Individual",
                        column: x => x.Id,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_User_Membership_PermissionSet",
                        column: x => x.InitialPermissionSetId,
                        principalSchema: "Membership",
                        principalTable: "PermissionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "Workflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())"),
                    RecipientId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_Comment_Membership_Individual",
                        column: x => x.AuthorId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_Comment_Membership_Individual2",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_Comment_Membership_Individual1",
                        column: x => x.RecipientId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Workflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsReaded = table.Column<bool>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())"),
                    RecipientId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_Message_Membership_Individual",
                        column: x => x.AuthorId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_Message_Membership_Individual2",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_Message_Membership_Individual1",
                        column: x => x.RecipientId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionSetPermission",
                schema: "Membership",
                columns: table => new
                {
                    PermissionSetId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionSetPermission", x => new { x.PermissionSetId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_Membership_PermissionSetPermission_Lookup_Permission",
                        column: x => x.PermissionId,
                        principalSchema: "Lookup",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_PermissionSetPermission_Membership_PermissionSet",
                        column: x => x.PermissionSetId,
                        principalSchema: "Membership",
                        principalTable: "PermissionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    IndividualId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())"),
                    Nude = table.Column<bool>(nullable: false),
                    PhotoId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_Album_Membership_Individual",
                        column: x => x.IndividualId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_Album_Membership_Individual1",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_Album_Catalog_Photo",
                        column: x => x.PhotoId,
                        principalSchema: "Catalog",
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TfpEvent",
                schema: "Workflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AuthorId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(maxLength: 512, nullable: true),
                    HeldOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedId = table.Column<Guid>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValueSql: "(sysdatetime())"),
                    PhotoId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TfpEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflow_TfpEvent_Membership_Individual",
                        column: x => x.AuthorId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Individual_Lookup_City",
                        column: x => x.CityId,
                        principalSchema: "Lookup",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_TfpEvent_Membership_Individual1",
                        column: x => x.ModifiedId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_TfpEvent_Catalog_Photo",
                        column: x => x.PhotoId,
                        principalSchema: "Catalog",
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotographerShootingGenre",
                schema: "Membership",
                columns: table => new
                {
                    PhotographerId = table.Column<Guid>(nullable: false),
                    ShootingGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographerShootingGenre", x => new { x.PhotographerId, x.ShootingGenreId });
                    table.ForeignKey(
                        name: "FK_Membership_PhotographerShootingGenre_Membership_Photographer",
                        column: x => x.PhotographerId,
                        principalSchema: "Membership",
                        principalTable: "Photographer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_PhotographerShootingGenre_Membership_ShootingGenre",
                        column: x => x.ShootingGenreId,
                        principalSchema: "Lookup",
                        principalTable: "ShootingGenre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                schema: "Membership",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_Membership_UserPermission_Membership_Permission",
                        column: x => x.PermissionId,
                        principalSchema: "Lookup",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_UserPermission_Membership_User",
                        column: x => x.UserId,
                        principalSchema: "Membership",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlbumPhoto",
                schema: "Catalog",
                columns: table => new
                {
                    AlbumId = table.Column<Guid>(nullable: false),
                    PhotoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumPhoto", x => new { x.AlbumId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_Catalog_AlbumPhoto_Catalog_Album",
                        column: x => x.AlbumId,
                        principalSchema: "Catalog",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Catalog_AlbumPhoto_Catalog_Photo",
                        column: x => x.PhotoId,
                        principalSchema: "Catalog",
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Responded",
                schema: "Workflow",
                columns: table => new
                {
                    TfpEventId = table.Column<Guid>(nullable: false),
                    IndividualId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responded", x => new { x.TfpEventId, x.IndividualId });
                    table.ForeignKey(
                        name: "FK_Workflow_Responded_Membership_Individual",
                        column: x => x.IndividualId,
                        principalSchema: "Membership",
                        principalTable: "Individual",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_Responded_Workflow_TfpEvent",
                        column: x => x.TfpEventId,
                        principalSchema: "Workflow",
                        principalTable: "TfpEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TfpEventPhoto",
                schema: "Workflow",
                columns: table => new
                {
                    TfpEventId = table.Column<Guid>(nullable: false),
                    PhotoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TfpEventPhoto", x => new { x.TfpEventId, x.PhotoId });
                    table.ForeignKey(
                        name: "FK_Workflow_TfpEventPhoto_Catalog_Photo",
                        column: x => x.PhotoId,
                        principalSchema: "Catalog",
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workflow_TfpEventPhoto_Workflow_TfpEvent",
                        column: x => x.TfpEventId,
                        principalSchema: "Workflow",
                        principalTable: "TfpEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IndividualId",
                schema: "Catalog",
                table: "Album",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ModifiedId",
                schema: "Catalog",
                table: "Album",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_PhotoId",
                schema: "Catalog",
                table: "Album",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_AlbumPhoto_AlbumId",
                schema: "Catalog",
                table: "AlbumPhoto",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_AlbumPhoto_PhotoId",
                schema: "Catalog",
                table: "AlbumPhoto",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ModifiedId",
                schema: "Catalog",
                table: "Photo",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_Category_Name",
                schema: "Lookup",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_Category_Order",
                schema: "Lookup",
                table: "Category",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_City_Name",
                schema: "Lookup",
                table: "City",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_City_Order",
                schema: "Lookup",
                table: "City",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_HairColor_Name",
                schema: "Lookup",
                table: "HairColor",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_HairColor_Order",
                schema: "Lookup",
                table: "HairColor",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_Permission_Name",
                schema: "Lookup",
                table: "Permission",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_Permission_Order",
                schema: "Lookup",
                table: "Permission",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_Permission_PermissionGroupId",
                schema: "Lookup",
                table: "Permission",
                column: "PermissionGroupId");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_PermissionGroup_Name",
                schema: "Lookup",
                table: "PermissionGroup",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_CourseStatus_Order",
                schema: "Lookup",
                table: "PermissionGroup",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_ShootingGenre_Name",
                schema: "Lookup",
                table: "ShootingGenre",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_ShootingGenre_Order",
                schema: "Lookup",
                table: "ShootingGenre",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_Social_SocialTypeId",
                schema: "Lookup",
                table: "SocialType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_SocialType_Name",
                schema: "Lookup",
                table: "SocialType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_SocialType_Order",
                schema: "Lookup",
                table: "SocialType",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "UK_Lookup_StylistSpecialization_Name",
                schema: "Lookup",
                table: "StylistSpecialization",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_StylistSpecialization_Order",
                schema: "Lookup",
                table: "StylistSpecialization",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_CategoryId",
                schema: "Membership",
                table: "Individual",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_CityId",
                schema: "Membership",
                table: "Individual",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_Social_IndividualId",
                schema: "Membership",
                table: "Individual",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Model_HairColorId",
                schema: "Membership",
                table: "Model",
                column: "HairColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_ModifiedId",
                schema: "Membership",
                table: "Model",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "UK_Membership_PermissionSet_Name",
                schema: "Membership",
                table: "PermissionSet",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membership_PermissionSetPermission_PermissionId",
                schema: "Membership",
                table: "PermissionSetPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_PermissionSetPermission_UserId",
                schema: "Membership",
                table: "PermissionSetPermission",
                column: "PermissionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Photographer_ModifiedId",
                schema: "Membership",
                table: "Photographer",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_PhotographerShootingGenre_PhotographerId",
                schema: "Membership",
                table: "PhotographerShootingGenre",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_PhotographerShootingGenre_ShootingGenreId",
                schema: "Membership",
                table: "PhotographerShootingGenre",
                column: "ShootingGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Social_SocialTypeId",
                schema: "Membership",
                table: "Social",
                column: "SocialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Stylist_ModifiedId",
                schema: "Membership",
                table: "Stylist",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Stylist_StylistSpecializationId",
                schema: "Membership",
                table: "Stylist",
                column: "StylistSpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_InitialPermissionSetId",
                schema: "Membership",
                table: "User",
                column: "InitialPermissionSetId");

            migrationBuilder.CreateIndex(
                name: "UK_Membership_User_Login",
                schema: "Membership",
                table: "User",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membership_UserPermission_PermissionId",
                schema: "Membership",
                table: "UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_UserPermission_UserId",
                schema: "Membership",
                table: "UserPermission",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                schema: "Workflow",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ModifiedId",
                schema: "Workflow",
                table: "Comment",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_RecipientId",
                schema: "Workflow",
                table: "Comment",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_AuthorId",
                schema: "Workflow",
                table: "Message",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ModifiedId",
                schema: "Workflow",
                table: "Message",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_RecipientId",
                schema: "Workflow",
                table: "Message",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_Responded_IndividualId",
                schema: "Workflow",
                table: "Responded",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_Responded_TfpEventIdId",
                schema: "Workflow",
                table: "Responded",
                column: "TfpEventId");

            migrationBuilder.CreateIndex(
                name: "IX_TfpEvent_AuthorId",
                schema: "Workflow",
                table: "TfpEvent",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_TfpEvent_CityId",
                schema: "Workflow",
                table: "TfpEvent",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TfpEvent_ModifiedId",
                schema: "Workflow",
                table: "TfpEvent",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_TfpEvent_PhotoId",
                schema: "Workflow",
                table: "TfpEvent",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "UK_Workflow_TfpEvent_Name",
                schema: "Workflow",
                table: "TfpEvent",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_TfpEventPhoto_IndividualId",
                schema: "Workflow",
                table: "TfpEventPhoto",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflow_TfpEventPhoto_TfpEventId",
                schema: "Workflow",
                table: "TfpEventPhoto",
                column: "TfpEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumPhoto",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Model",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "PermissionSetPermission",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "PhotographerShootingGenre",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "Social",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "Stylist",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "UserPermission",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "Responded",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "TfpEventPhoto",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "Album",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "HairColor",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Photographer",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "ShootingGenre",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "SocialType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "StylistSpecialization",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "TfpEvent",
                schema: "Workflow");

            migrationBuilder.DropTable(
                name: "PermissionGroup",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "PermissionSet",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "Photo",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Individual",
                schema: "Membership");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Lookup");

            migrationBuilder.DropSequence(
                name: "AlbumId");

            migrationBuilder.DropSequence(
                name: "ApiKeyId");

            migrationBuilder.DropSequence(
                name: "CommentId");

            migrationBuilder.DropSequence(
                name: "IndividualId");

            migrationBuilder.DropSequence(
                name: "MessageId");

            migrationBuilder.DropSequence(
                name: "PhotoId");

            migrationBuilder.DropSequence(
                name: "SocialId");

            migrationBuilder.DropSequence(
                name: "TfpEventId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    PerformerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Information = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.PerformerId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EditorContent = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    ProductionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImdbScore = table.Column<double>(nullable: false),
                    MetaCriticScore = table.Column<int>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    ProductionTypeId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.ProductionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTypes",
                columns: table => new
                {
                    ProductionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTypes", x => x.ProductionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    MemberId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostCategory",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategory", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategory_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProductionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCategory",
                columns: table => new
                {
                    ProductionId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCategory", x => new { x.ProductionId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductionCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionCategory_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionPerformer",
                columns: table => new
                {
                    PerformerId = table.Column<int>(nullable: false),
                    ProductionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPerformer", x => new { x.PerformerId, x.ProductionId });
                    table.ForeignKey(
                        name: "FK_ProductionPerformer_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "PerformerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionPerformer_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ProductionTypes",
                columns: new[] { "ProductionTypeId", "Title" },
                values: new object[,]
                {
                    { 1, "Film" },
                    { 2, "Dizi" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Title" },
                values: new object[,]
                {
                    { 1, "Yayında" },
                    { 2, "Taslak" },
                    { 3, "Silinmiş" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CategoryId",
                table: "Photos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PostId",
                table: "Photos",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProductionId",
                table: "Photos",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategory_CategoryId",
                table: "PostCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCategory_CategoryId",
                table: "ProductionCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionPerformer_ProductionId",
                table: "ProductionPerformer",
                column: "ProductionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "PostCategory");

            migrationBuilder.DropTable(
                name: "ProductionCategory");

            migrationBuilder.DropTable(
                name: "ProductionPerformer");

            migrationBuilder.DropTable(
                name: "ProductionTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "Productions");
        }
    }
}

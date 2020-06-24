using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksAsync.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 150, nullable: false),
                    LastName = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Description = table.Column<string>(maxLength: 2500, nullable: true),
                    AuthorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "George", "RR Martin" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b46"), "Stephen", "Fry" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b57"), "James", "Elroy" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b68"), "Douglas", "Adams" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b11"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "The book that seems impossible to write", "The winds of winter" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b22"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "It is a novel", "A Game of Thrones" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b33"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b46"), "The greek myths", "Mythos" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b44"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b57"), "Is a 1995 novel", "American Tabloid" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b55"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b68"), "Is guide to the galaxy", "The hitchhiker" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}

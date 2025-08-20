using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d902"), null, "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d93a"), null, "Actividades Pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaLimite", "PrioridadTarea", "Puntos", "Titulo" },
                values: new object[] { new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d910"), new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d93a"), null, new DateTime(2025, 8, 20, 10, 30, 42, 382, DateTimeKind.Local).AddTicks(4612), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "Pago de Servicios Publicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "FechaLimite", "PrioridadTarea", "Puntos", "Titulo" },
                values: new object[] { new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d920"), new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d902"), null, new DateTime(2025, 8, 20, 10, 30, 42, 382, DateTimeKind.Local).AddTicks(4627), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Terminar de ver pelicula en Netflix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d910"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d920"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d902"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("3b8b7607-3ef4-4820-8e68-dacc4ea2d93a"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

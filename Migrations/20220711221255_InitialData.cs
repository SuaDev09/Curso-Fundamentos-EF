using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curso_Fundamentos_EF.Migrations
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
                values: new object[] { new Guid("1288fce7-4764-4637-b6f2-9616ebcbe802"), null, "Actividades Personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("1288fce7-4764-4637-b6f2-9616ebcbe89a"), null, "Actividades pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("1288fce7-4764-4637-b6f2-9616ebcbe810"), new Guid("1288fce7-4764-4637-b6f2-9616ebcbe89a"), null, new DateTime(2022, 7, 11, 15, 12, 55, 37, DateTimeKind.Local).AddTicks(4574), 1, "Pago de servicios publicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("1288fce7-4764-4637-b6f2-9616ebcbe811"), new Guid("1288fce7-4764-4637-b6f2-9616ebcbe802"), null, new DateTime(2022, 7, 11, 15, 12, 55, 37, DateTimeKind.Local).AddTicks(4622), 2, "Terminar curso de platzi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("1288fce7-4764-4637-b6f2-9616ebcbe810"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("1288fce7-4764-4637-b6f2-9616ebcbe811"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("1288fce7-4764-4637-b6f2-9616ebcbe802"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("1288fce7-4764-4637-b6f2-9616ebcbe89a"));

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

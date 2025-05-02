using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace To_Do_List.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Habits",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Exercise" },
                    { 2, "Reading" },
                    { 3, "Journaling" },
                    { 4, "Planning" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Health" },
                    { 3, "Personal" },
                    { 4, "Urgent" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedAt", "Description", "DueDate", "IsCompleted", "IsDeleted", "Priority", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete the project report by Friday.", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "High", "Finish project report" },
                    { 2, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete this project by Friday.", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Medium", "Finish software project" },
                    { 3, new DateTime(2025, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read 20 pages of 'Atomic Habits'.", new DateTime(2025, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Low", "Read Book" },
                    { 4, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoom call with product team.", new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "High", "Team Meeting" }
                });

            migrationBuilder.InsertData(
                table: "TaskHabits",
                columns: new[] { "HabitId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "TaskTags",
                columns: new[] { "TagId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 4, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskHabits",
                keyColumns: new[] { "HabitId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TaskHabits",
                keyColumns: new[] { "HabitId", "TaskId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TaskHabits",
                keyColumns: new[] { "HabitId", "TaskId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "TaskHabits",
                keyColumns: new[] { "HabitId", "TaskId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "TaskTags",
                keyColumns: new[] { "TagId", "TaskId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

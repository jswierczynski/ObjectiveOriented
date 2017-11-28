using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAPI.Migrations
{
    public partial class Add2wayrelationshipfortasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Objectives_ObjectiveId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_ObjectiveTaskId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ObjectiveTaskId",
                table: "Tasks",
                newName: "ParentTaskId");

            migrationBuilder.RenameColumn(
                name: "ObjectiveId",
                table: "Tasks",
                newName: "ObjectiveParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ObjectiveTaskId",
                table: "Tasks",
                newName: "IX_Tasks_ParentTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ObjectiveId",
                table: "Tasks",
                newName: "IX_Tasks_ObjectiveParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Objectives_ObjectiveParentId",
                table: "Tasks",
                column: "ObjectiveParentId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_ParentTaskId",
                table: "Tasks",
                column: "ParentTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Objectives_ObjectiveParentId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Tasks_ParentTaskId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ParentTaskId",
                table: "Tasks",
                newName: "ObjectiveTaskId");

            migrationBuilder.RenameColumn(
                name: "ObjectiveParentId",
                table: "Tasks",
                newName: "ObjectiveId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ParentTaskId",
                table: "Tasks",
                newName: "IX_Tasks_ObjectiveTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ObjectiveParentId",
                table: "Tasks",
                newName: "IX_Tasks_ObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Objectives_ObjectiveId",
                table: "Tasks",
                column: "ObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Tasks_ObjectiveTaskId",
                table: "Tasks",
                column: "ObjectiveTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

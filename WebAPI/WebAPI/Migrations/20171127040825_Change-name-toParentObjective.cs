using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAPI.Migrations
{
    public partial class ChangenametoParentObjective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Objectives_ObjectiveParentId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ObjectiveParentId",
                table: "Tasks",
                newName: "ParentObjectiveId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ObjectiveParentId",
                table: "Tasks",
                newName: "IX_Tasks_ParentObjectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Objectives_ParentObjectiveId",
                table: "Tasks",
                column: "ParentObjectiveId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Objectives_ParentObjectiveId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "ParentObjectiveId",
                table: "Tasks",
                newName: "ObjectiveParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ParentObjectiveId",
                table: "Tasks",
                newName: "IX_Tasks_ObjectiveParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Objectives_ObjectiveParentId",
                table: "Tasks",
                column: "ObjectiveParentId",
                principalTable: "Objectives",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

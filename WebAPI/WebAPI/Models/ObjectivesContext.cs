using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class ObjectivesContext : DbContext
    {
		public ObjectivesContext(DbContextOptions<ObjectivesContext> options)
			: base(options)
		{ }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Objective>()
		//		.Ignore(t => t.TaskIds);

		//	modelBuilder.Entity<ObjectiveTask>()
		//		.Ignore(x => x.ParentObjectiveId)
		//		.Ignore(x => x.ParentTaskId)
		//		.Ignore(x => x.SubTaskIds);
		//}

		public DbSet<Objective> Objectives { get; set; }
		public DbSet<ObjectiveTask> Tasks { get; set; }
    }
}

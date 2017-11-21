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

		public DbSet<Objective> Objectives { get; set; }
    }
}

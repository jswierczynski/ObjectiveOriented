using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BaseObjective
    {
		public int Id { get; set; }
		public String Title { get; set; }
		public String Description { get; set; }
	}

	public class BaseObjectiveBinding
	{
		public String Title { get; set; }
		public String Description { get; set; }

		public BaseObjectiveBinding(BaseObjective objective)
		{
			this.Title = objective.Title;
			this.Description = objective.Description;
		}
	}
}

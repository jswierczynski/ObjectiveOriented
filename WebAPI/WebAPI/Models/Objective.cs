using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Objective : BaseObjective
    {
		public Boolean Complete { get; set; }
		public virtual List<ObjectiveTask> Tasks { get; set; }
    }

	public class ObjectiveBinding : BaseObjectiveBinding
	{
		public int Id { get; set; }
		public Boolean Complete { get; set; }
		public List<int> TaskIds { get; set; }

		public ObjectiveBinding(Objective objective)
			: base(objective)
		{
			this.Id = objective.Id;
			this.Complete = objective.Complete;
			if(objective.Tasks != null)
			{
				TaskIds = new List<int>();
				foreach (var task in objective.Tasks)
					TaskIds.Add(task.Id);
			}
		}
	}
}

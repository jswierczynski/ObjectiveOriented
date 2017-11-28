using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Objective : BaseObjective
    {
		public Boolean Complete { get; set; }
		[JsonIgnore]
		public virtual List<ObjectiveTask> Tasks { get; set; }
		[NotMapped]
		public List<int> TaskIds
		{
			get
			{
				if (Tasks != null)
				{
					var ids = new List<int>();
					foreach (var task in Tasks)
						ids.Add(task.Id);

					return ids;
				}
				return null;
			}
		}

		public int OpenTasks
		{
			get
			{
				if (Tasks == null)
					return 0;

				int count = 0;
				foreach (var task in Tasks)
				{
					if (!task.Complete)
						count += task.OpenSubTasks + 1;
				}

				return count;
			}
		}

		public int TotalTasks
		{
			get
			{
				if (Tasks == null)
					return 0;

				int count = 0;
				foreach (var task in Tasks)
					count += task.TotalSubTasks + 1;

				return count;
			}
		}
	}
}

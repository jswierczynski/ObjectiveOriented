using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ObjectiveTask : BaseObjective
    {
		public virtual List<ObjectiveTask> SubTasks { get; set; }
		public virtual Objective ParentObjective { get; set; }
		public virtual ObjectiveTask ParentTask { get; set; }

		public ObjectiveTask()
		{
			SubTasks = new List<ObjectiveTask>();
		}

		public ObjectiveTask(BaseObjectiveTaskBinding baseTask, ObjectivesContext _context)
			: this()
		{
			this.Title = baseTask.Title;
			this.Description = baseTask.Description;

			if (baseTask.ParentObjectiveID > 0)
				this.ParentObjective = _context.Objectives
					.Where(x => x.Id == baseTask.ParentObjectiveID)
					.FirstOrDefault();

			if (baseTask.ParentTaskId > 0)
				this.ParentTask = _context.Tasks
					.Where(x => x.Id == baseTask.ParentTaskId)
					.FirstOrDefault();
		}
	}

	public class BaseObjectiveTaskBinding
	{
		public int ParentObjectiveID { get; set; }
		public int ParentTaskId { get; set; }
		public String Title { get; set; }
		public String Description { get; set; }

		public BaseObjectiveTaskBinding()
		{

		}

		public BaseObjectiveTaskBinding(ObjectiveTask task)
		{
			if (task.ParentObjective != null)
				this.ParentObjectiveID = task.ParentObjective.Id;

			if (task.ParentTask != null)
				this.ParentTaskId = task.ParentTask.Id;

			this.Title = task.Title;
			this.Description = task.Description;
		}
	}

	/// <summary>
	/// Simplified ObjectiveTask class for API
	/// </summary>
	public class ObjectiveTaskBinding : BaseObjectiveTaskBinding
	{
		public int Id { get; set; }
		
		public List<int> SubTaskIds { get; set; }

		public ObjectiveTaskBinding(ObjectiveTask task) 
			: base(task)
		{
			this.Id = task.Id;

			this.SubTaskIds = new List<int>();
			if (task.SubTasks != null)
				foreach (var subTask in task.SubTasks)
					this.SubTaskIds.Add(subTask.Id);
		}
	}
}

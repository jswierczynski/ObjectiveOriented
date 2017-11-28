using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ObjectiveTask : BaseObjective
    {
		[JsonIgnore]
		public virtual List<ObjectiveTask> SubTasks { get; set; }

		[JsonIgnore]
		public virtual Objective ParentObjective { get; set; }

		[JsonIgnore]
		public virtual ObjectiveTask ParentTask { get; set; }

		[NotMapped]
		public List<int> subTaskIds
		{
			get
			{
				if (SubTasks != null)
				{
					var ids = new List<int>();
					foreach (var task in SubTasks)
						ids.Add(task.Id);

					return ids;
				}
				return null;
			}
		}
		[NotMapped]
		public int parentObjectiveId
		{
			get
			{
				if (ParentObjective == null)
					return 0;

				return ParentObjective.Id;
			}
		}
		[NotMapped]
		public int parentTaskId
		{
			get
			{
				if (ParentTask == null)
					return 0;

				return ParentTask.Id;
			}
		}

		public Boolean Complete { get; set; }
		public int OpenSubTasks
		{
			get
			{
				if (SubTasks == null || SubTasks.Count == 0)
					return 0; //No Subtasks to complete

				int count = 0;
				foreach (var task in SubTasks)
					count += task.OpenTasks;

				return count; //Number of Subtasks
			}
		}
		private int OpenTasks
		{
			get
			{
				if (Complete)
					return 0;

				return OpenSubTasks + 1;
			}
		}
		public int TotalSubTasks
		{
			get
			{
				if (SubTasks == null || SubTasks.Count == 0)
					return 0; //No Subtasks to complete

				int count = 0;
				foreach (var task in SubTasks)
					count += task.TotalTasks;

				return count; //Number of Subtasks
			}
		}
		private int TotalTasks
		{
			get
			{
				if (SubTasks == null || SubTasks.Count == 0)
					return 1; //No Subtasks to complete

				int count = 0;
				foreach (var task in SubTasks)
					count += task.TotalTasks;

				return count; //Number of Subtasks
			}
		}

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
	}
}

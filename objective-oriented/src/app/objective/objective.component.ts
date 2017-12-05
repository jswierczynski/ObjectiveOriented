import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { ObjectivesService } from '../services/objectives.service';
import { AppError } from '../Common/app-error';
import { NotFoundError } from '../Common/not-found-error';
import { SubtasksComponent } from '../subtasks/subtasks.component';

@Component({
  selector: 'objective',
  templateUrl: './objective.component.html',
  styleUrls: ['./objective.component.css']
})
export class ObjectiveComponent implements OnInit {
  @Input() objective: {
    complete: Boolean,
    openTasks: number,
    totalTasks: number,
    taskCompletion: number,
    id: number,
    title: string,
    description: string
  };

  @ViewChild(SubtasksComponent)
  subtasks: SubtasksComponent;

  constructor(private service: ObjectivesService) { }

  ngOnInit() {
  }

  completeObjective()
  {
    this.objective.complete = true;

    this.service.update(this.objective)
      .subscribe(
        null,
        (error: AppError) => {
          this.objective.complete = false;

          if(error instanceof NotFoundError)
            alert('This objective is already complete.');
          else throw error;
        });
  }

  receivedTaskCompleted(task) {
    this.objective.openTasks = this.objective.openTasks - 1;
    this.evaluateTaskCompletion();
  }

  evaluateTaskCompletion() {
    if(this.objective.totalTasks > 0) {
      this.objective.taskCompletion = ((this.objective.totalTasks - this.objective.openTasks) / this.objective.totalTasks) * 100;
    } else {
      this.objective.taskCompletion = 0;
    }
  }
}

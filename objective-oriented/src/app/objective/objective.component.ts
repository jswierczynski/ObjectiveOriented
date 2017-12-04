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
  @Input() objective: any;

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
}

import { Component, OnInit } from '@angular/core';
import { ObjectivesService } from '../services/objectives.service';
import { error } from 'selenium-webdriver';
import { AppError } from '../Common/app-error';
import { NotFoundError } from '../Common/not-found-error';

@Component({
  selector: 'objectives',
  templateUrl: './objectives.component.html',
  styleUrls: ['./objectives.component.css']
})
export class ObjectivesComponent implements OnInit {

  objectives: any;

  constructor(private service: ObjectivesService) { }

  ngOnInit() {
    this.service.getAll()
      .subscribe(data => this.objectives = data);
  }

  completeObjective(objective)
  {
    let index = this.objectives.indexOf(objective);
    this.objectives.splice(index, 1);
    
    objective.complete = true;

    this.service.update(objective)
      .subscribe(
        null,
        (error: AppError) => {
          this.objectives.splice(index, 0, objective);

          if(error instanceof NotFoundError)
            alert('This objective is already complete.');
          else throw error;
        });
  }
}

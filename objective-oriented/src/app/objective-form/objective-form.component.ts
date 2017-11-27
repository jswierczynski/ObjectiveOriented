import { Component, OnInit } from '@angular/core';
import { ObjectivesService } from '../services/objectives.service';

@Component({
  selector: 'objective-form',
  templateUrl: './objective-form.component.html',
  styleUrls: ['./objective-form.component.css']
})
export class ObjectiveFormComponent implements OnInit {
  title: string = "New Objective";

  constructor(private service: ObjectivesService) { }

  ngOnInit() {
  }

  createObjective(objective) {
    console.log(objective)
    this.service.create(objective)
      .subscribe(data => {
        console.log(data);
      });
  }

}

import { Component, OnInit } from '@angular/core';
import { ObjectivesService } from '../services/objectives.service';
import { error } from 'selenium-webdriver';

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
}

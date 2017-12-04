import { Component, OnInit, Input } from '@angular/core';
import { TasksService } from '../services/tasks.service';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements AfterViewInit {
  @Input() id: number;
  task: { 
    subTaskIds: number[],
    title: string
  }

  constructor(private service: TasksService) { }

  ngAfterViewInit() {
    this.service.get(this.id)
      .subscribe(data => {
        this.task = data;
      });
  }


}

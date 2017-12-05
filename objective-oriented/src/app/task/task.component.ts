import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TasksService } from '../services/tasks.service';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { error } from 'selenium-webdriver';
import { AppError } from '../Common/app-error';

@Component({
  selector: 'task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements AfterViewInit {
  @Input() id: number;
  @Output() completed: EventEmitter<any> = new EventEmitter();
  task: any;

  constructor(private service: TasksService) { }

  ngAfterViewInit() {
    this.service.get(this.id)
      .subscribe(data => {
        this.task = data;
      });
  }

  completeTask(){
    this.task.complete = true;

    this.service.update(this.task)
      .subscribe(
        (value => {
          this.completed.emit(this.task);
        }),
        (error: AppError) => {
          throw error;
        }
      )
  }
}

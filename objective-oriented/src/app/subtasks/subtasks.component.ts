import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { fail } from 'assert';
import { Console } from '@angular/core/src/console';

@Component({
  selector: 'subtasks',
  templateUrl: './subtasks.component.html',
  styleUrls: ['./subtasks.component.css']
})
export class SubtasksComponent implements OnInit {
  @Input() taskCompletion: number;
  @Input() taskIds: number[];
  @Output() taskCompleted: EventEmitter<any> = new EventEmitter();

  showSubtasks: Boolean = false;

  constructor() { }

  ngOnInit() {
  }

  @Input() toggleShowSubtasks()
  {
    this.showSubtasks = !this.showSubtasks;
  }

  receiveTaskCompletedEvent(task) {
    this.taskCompleted.emit(task);
  }

}

import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'subtasks',
  templateUrl: './subtasks.component.html',
  styleUrls: ['./subtasks.component.css']
})
export class SubtasksComponent implements OnInit {
  @Input() taskCompletion: number;
  @Input() taskIds: number[];

  constructor() { }

  ngOnInit() {
  }

}

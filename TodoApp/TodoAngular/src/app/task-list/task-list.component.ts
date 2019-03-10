import { Component, OnInit } from '@angular/core';
import { TaskListService } from './task-list.service';
import { TaskList } from '../models/task-list';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  title = "Task list";
  taskLists: TaskList[];

  constructor(private taskListService: TaskListService) { }

  ngOnInit() {
    this.taskListService.GetTaskLists().subscribe((data: TaskList[]) => { this.taskLists = data });
  }

}

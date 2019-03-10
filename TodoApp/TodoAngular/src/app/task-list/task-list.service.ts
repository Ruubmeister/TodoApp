import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskList } from '../models/task-list';

@Injectable({
  providedIn: 'root'
})
export class TaskListService {

  apiUrl = 'api/tasklist';

  constructor(private http: HttpClient) {  }
  
  GetTaskLists() {
    return this.http.get<TaskList[]>(this.apiUrl);
  }
}

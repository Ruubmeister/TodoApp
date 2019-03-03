import { TaskList } from './task-list';
import { Comment } from './comment';

export class Task {
  TaskId: number;
  Name: string;
  Description: string;
  FinishedAt: string;
  ParentId: number;
  TaskListId: number;
  Comments: Comment[];
  TaskList: TaskList;
}

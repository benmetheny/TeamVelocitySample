import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ToDoModel } from './ToDoModel';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html'
})
export class ToDoListComponent {
  public todos: ToDoModel[];
  queryUrl = "";
  httpClient: HttpClient;
  newToDo = new ToDoModel();


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.queryUrl = baseUrl + 'todos';
    this.httpClient = http;
  }

  ngOnInit() {
    this.getTodos();
  }

  getTodos() {
    this.httpClient.get<ToDoModel[]>(this.queryUrl).subscribe(result => {
      this.todos = result;
    }, error => console.error(error));
  }

  addToDo() {
      
    this.httpClient.post<number>(this.queryUrl, this.newToDo).subscribe(result => {
      this.newToDo.toDoItemId = result;
      this.todos.push(this.newToDo);
      this.newToDo = new ToDoModel();
    }, error => console.error(error));
    }

  public deleteToDo(todo: ToDoModel) {
    let index = this.todos.indexOf(todo);
    this.todos.splice(index, 1);
    let params = new HttpParams().set("key", todo.toDoItemId.toString());
    this.httpClient.delete(this.queryUrl + "/" + todo.toDoItemId).subscribe(result => {
      console.debug("Deleted item with key=" + todo.toDoItemId);
    }, error => console.error(error));
  }

  public updateToDo(todo: ToDoModel) {
    this.httpClient.put<number>(this.queryUrl, todo).subscribe(result => {
      console.debug("Updated item with key=" + todo.toDoItemId);
    }, error => console.error(error));
  }
}


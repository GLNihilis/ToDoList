import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from '../models/todo';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'https://localhost:5192/api/todo';
  
    constructor(private http: HttpClient) { }
  
    // Lấy danh sách Todo
    getTodos(): Observable<any> {
      return this.http.get<Todo[]>(this.apiUrl);
    }
  
    // Tạo Todo mới
    createTodo(todo: Todo): Observable<any> {
      return this.http.post<Todo>(this.apiUrl, todo);
    }
  
    // Cập nhật Todo
    updateTodo(id: number, todo: Todo): Observable<any> {
      return this.http.put(`${this.apiUrl}/${id}`, todo);
    }
  
    // Xóa Todo
    deleteTodo(id: number): Observable<any> {
      return this.http.delete(`${this.apiUrl}/${id}`);
    }
}

import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo';
import { TodoService } from '../../services/todo.service';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [],
  templateUrl: './todo.html',
  styleUrls: ['./todo.css']
})
export class TodoComponent implements OnInit {
  todos: Todo[] = [];
  newTodoTitle: string = '';
  isLoading: boolean = false;
  errorMessage: string = '';

  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.loadTodos();
  }

  // Tải danh sách Todo
  loadTodos(): void {
    this.isLoading = true;
    this.todoService.getTodos().subscribe({
      next: (data) => {
        this.todos = data;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Lỗi khi tải danh sách Todo';
        console.error('Error:', error);
        this.isLoading = false;
      }
    });
  }

  // Thêm Todo mới
  addTodo(): void {
    if (this.newTodoTitle.trim() === '') {
      alert('Vui lòng nhập tiêu đề công việc!');
      return;
    }

    const newTodo: Todo = {
      id: 0, // API sẽ tự generate
      title: this.newTodoTitle,
      isDone: false
    };

    this.todoService.createTodo(newTodo).subscribe({
      next: (todo) => {
        this.todos.push(todo);
        this.newTodoTitle = ''; // Reset input
      },
      error: (error) => {
        this.errorMessage = 'Lỗi khi thêm Todo';
        console.error('Error:', error);
      }
    });
  }

  // Cập nhật trạng thái Todo
  toggleTodo(todo: Todo): void {
    todo.isDone = !todo.isDone;
    
    this.todoService.updateTodo(todo.id, todo).subscribe({
      next: () => {
        console.log('Cập nhật thành công');
      },
      error: (error) => {
        // Rollback nếu lỗi
        todo.isDone = !todo.isDone;
        this.errorMessage = 'Lỗi khi cập nhật Todo';
        console.error('Error:', error);
      }
    });
  }

  // Xóa Todo
  deleteTodo(id: number): void {
    if (confirm('Bạn có chắc muốn xóa công việc này?')) {
      this.todoService.deleteTodo(id).subscribe({
        next: () => {
          this.todos = this.todos.filter(t => t.id !== id);
        },
        error: (error) => {
          this.errorMessage = 'Lỗi khi xóa Todo';
          console.error('Error:', error);
        }
      });
    }
  }
}
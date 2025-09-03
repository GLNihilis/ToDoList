import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TodoComponent } from './todo.component/todo.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    TodoComponent,
  ],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  
}

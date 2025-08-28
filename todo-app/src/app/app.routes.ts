import { Routes } from '@angular/router';
import { TodoComponent } from './components/todo/todo';


export const routes: Routes = [
    { path: 'todo', component: TodoComponent},
    { path: '', redirectTo: 'todo', pathMatch: 'full'}
];

import { Routes } from '@angular/router';
import { CreateComponent } from '../create/create.component';

export const routes: Routes = [
  { path: 'create', component: CreateComponent, pathMatch: 'full' },
  { path: 'create/:slug', component: CreateComponent, pathMatch: 'full' },
];

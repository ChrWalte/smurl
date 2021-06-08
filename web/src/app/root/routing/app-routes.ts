import { Routes } from '@angular/router';
import { InfoComponent } from '../info/info.component';
import { ReRouteComponent } from '../re-route/re-route.component';
import { ReRouteGuard } from '../re-route/re-route.guard';

export const routes: Routes = [
  { path: '', component: InfoComponent, pathMatch: 'full' },
  { path: 'xyz', component: InfoComponent, pathMatch: 'full' },
  {
    path: 'crud',
    loadChildren: () =>
      import('src/app/crud/crud.module').then((m) => m.CrudModule),
  },
  {
    path: ':slug',
    component: ReRouteComponent,
    canActivate: [ReRouteGuard],
    pathMatch: 'full',
  },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ReflectionComponent } from './components/reflection/reflection.component';
import { reflectionGuard } from './guards/reflection.guard';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'reflection',
    component: ReflectionComponent,
    canActivate: [reflectionGuard]
  }
];

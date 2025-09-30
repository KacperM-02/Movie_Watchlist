import { Routes } from '@angular/router';
import { LoginPage } from './login-page/login-page';
import { BrowsePage } from './browse-page/browse-page';

export const routes: Routes = [
  {
    path: '',
    component: LoginPage,
  },
  {
    path: 'browse',
    component: BrowsePage,
  },
];

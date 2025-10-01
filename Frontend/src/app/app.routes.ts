import { Routes } from '@angular/router';
import { LoginPage } from './pages/login-page/login-page';
import { BrowsePage } from './pages/browse-page/browse-page';

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

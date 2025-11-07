import { Component, inject } from '@angular/core';
import { AuthService } from '../../shared/services/auth';
import { Header } from '../../core/components/header/header';

@Component({
  selector: 'app-browse-page',
  imports: [Header],
  templateUrl: './browse-page.html',
  styleUrl: './browse-page.css',
})
export class BrowsePage {
  auth = inject(AuthService);

  signOut(): void {
    sessionStorage.removeItem('loggedInUser');
    this.auth.signOut();
  }
}

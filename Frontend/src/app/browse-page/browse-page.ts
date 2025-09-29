import { Component, inject } from '@angular/core';
import { AuthService } from '../services/auth';

@Component({
  selector: 'app-browse-page',
  imports: [],
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

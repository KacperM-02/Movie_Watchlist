import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

declare var google: any;
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.html',
  imports: [],
  styleUrl: './login-page.css',
})
export class LoginPage implements OnInit {
  private router = inject(Router);
  handleLogin(response: any) {
    if (response) {
      const payload = this.decodeToken(response.credential);
      sessionStorage.setItem('loggedInUser', JSON.stringify(payload));
      this.router.navigate(['browse']);
    }
  }

  private decodeToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

  ngOnInit(): void {
    const IdConfiguration = {
      client_id: '667934156999-ghcmogbftljiqdugqf9db0n4va57g6j8.apps.googleusercontent.com',
      callback: (response: any) => this.handleLogin(response),
    };
    google.accounts.id.initialize(IdConfiguration);

    const options = {
      type: 'standard',
      theme: 'filled_black',
      size: 'large',
      text: 'continue_with',
      shape: 'pill',
    };
    google.accounts.id.renderButton(document.getElementById('google-btn'), options);
  }
}

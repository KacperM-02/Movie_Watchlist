import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

declare var google: any;
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.html',
  imports: [],
  styleUrl: './login-page.css',
})
export class LoginPage implements OnInit {
  private router = inject(Router);
  private http = inject(HttpClient);

  handleLogin(response: any) {
    if (response && response.credential) {
      const idToken = response.credential;

      this.http.post('http://localhost:5005/Auth', { idToken }).subscribe({
        next: (response) => {
          console.log('Backend response:', response);
          sessionStorage.setItem("loggedInUser", JSON.stringify(response));
          this.router.navigate(['browse']);
        },
        error: (err) => console.error('Login error:', err),
      });
    }
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

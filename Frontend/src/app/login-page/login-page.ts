import { Component, OnInit } from '@angular/core';

declare var google: any;
@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.html',
  imports: [],
  styleUrl: './login-page.css',
})
export class LoginPage implements OnInit {
  ngOnInit(): void {
    const IdConfiguration = {
      client_id: '667934156999-ghcmogbftljiqdugqf9db0n4va57g6j8.apps.googleusercontent.com',
      callback: (response: any) => {
        console.log(response);
      },
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

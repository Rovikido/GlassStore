import { Component } from '@angular/core';
import { AuthService } from '../../../../services/AuthService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(private as: AuthService) { }

  login(email: string, password: string) {
    this.as.login(email, password)
      .subscribe(res => {
      }, error => {
        alert('Wrong login or password.')
      })
  }
  logout() {
    this.as.logout()
  }
}

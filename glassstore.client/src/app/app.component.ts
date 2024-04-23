import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/Auth.service';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',

})
export class AppComponent implements OnInit {
  public get isLoggedIn(): boolean {
    return this.auth.isAuthenticated();
  }


  constructor(private auth: AuthService) {
  }

  ngOnInit(): void {
    
  }
  
  title = 'glassstore.client';
}

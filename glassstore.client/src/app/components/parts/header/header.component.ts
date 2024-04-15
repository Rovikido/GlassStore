import { Component } from '@angular/core';
import { Router, Routes } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  public urls: string[] = [];
  private IgnoreUrls = ['GlassInfo/:id',];


  constructor(private router: Router) {
    const routes: Routes = this.router.config;

    routes.forEach(route => {
      if (route.path !== '**' && route.path !== '' && route.path !== undefined) {
        this.urls.push(route.path);
      }
    });

    this.urls = this.urls.filter(url => !this.IgnoreUrls.includes(url));
    //this.urls.reduce('GlassInfo')
  }

  oninit(): void {}

}

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WeatherComponent } from './components/weather/weather.component';
import { BrowserModule } from '@angular/platform-browser';
import { GlassListComponent } from './components/glass/list/glassList.component';
import { HeaderComponent } from './components/parts/header/header.component';
import { GlassInfoComponent } from './components/glass/info/glassInfo.component';
import { JwtModule } from '@auth0/angular-jwt';
import { environment } from './enviroment';
import { ACCESS_TOKEN } from './services/AuthService';
import { LoginComponent } from './components/parts/Auth/login/login.component';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { UserComponent } from './components/user/user.component';


//const { env } = require('process');

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN);
}

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    HeaderComponent,
    GlassListComponent,
    GlassInfoComponent,
    LoginComponent,
    UserComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,

    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    //JwtModule.forRoot({
    //  config: {
    //    tokenGetter: () => {
    //      return localStorage.getItem('access_token');
    //    },
    //    allowedDomains: ['example.com'],
    //    disallowedRoutes: ['example.com/auth/login'],
    //  },
    //}),
    JwtModule.forRoot({
      config: {
        tokenGetter,
        allowedDomains: environment.apiUrl,
      },
    }),

  ],
  providers: [], // для инжекции сервисов
  bootstrap: [AppComponent]
})
export class AppModule { }

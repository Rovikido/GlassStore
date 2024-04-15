import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WeatherComponent } from './components/weather/weather.component';
import { BrowserModule } from '@angular/platform-browser';
import { GlassListComponent } from './components/glass/list/glassList.component';
import { HeaderComponent } from './components/parts/header/header.component';
import { GlassInfoComponent } from './components/glass/info/glassInfo.component';

@NgModule({
  declarations: [
    AppComponent,
    WeatherComponent,
    GlassListComponent,
    HeaderComponent,
    GlassInfoComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

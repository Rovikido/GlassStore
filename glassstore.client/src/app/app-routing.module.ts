import { NgModule } from '@angular/core';
import { WeatherComponent } from './components/weather/weather.component';
import { RouterModule } from '@angular/router';
import { Routes } from '@angular/router';
import { GlassListComponent } from './components/glass/list/glassList.component';
import { AppComponent } from './app.component';
import { GlassInfoComponent } from './components/glass/info/glassInfo.component';



export const routes: Routes = [
  
  { path: "", component: WeatherComponent },
  { path: "GlassList", component: GlassListComponent },
  { path: "GlassInfo/:id", component: GlassInfoComponent },    
  
  //{ path: "", component: AppComponent, children: [
  //    { path: "glass", component: GlassComponent }
  //  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)], // Используем метод forRoot для настройки маршрутизации в корневом модуле
  exports: [RouterModule] // Экспортируем RouterModule, чтобы его можно было использовать в других модулях
})
export class AppRoutingModule { }

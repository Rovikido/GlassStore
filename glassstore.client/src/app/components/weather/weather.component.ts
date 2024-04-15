import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { WeatherForecast } from '../../models/WeatherForecast';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css'
})
export class WeatherComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}

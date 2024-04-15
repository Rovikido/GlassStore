import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class ApplicationApiContext {


  constructor(private http: HttpClient) {
  }

  private configUrl = 'assets/config.json'

  //getConfig(): Observable<Config> {
  //  console.log(this.http.get(this.configUrl))
  //  return this.http.get(this.configUrl).pipe(
  //    map(res => res as Config)
  //  );
  //}
  getConfig(): Observable<Config> {
    return this.http.get<Config>(this.configUrl);
  }

}


interface Config {
  apsapiurl: string;
  webapi: string;

}

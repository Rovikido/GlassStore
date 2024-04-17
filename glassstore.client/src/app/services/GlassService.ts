import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { DataList } from '../models/DataList';
import { Glasses } from '../models/Glasses';
import { NONE_TYPE } from '@angular/compiler';
//import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class GlassService {
  private baseUrl = this.getApiUrl();

  constructor(private http: HttpClient) { }



  getApiUrl(): string {
    
    //var a = this.http.get<any>('assets/config.json').pipe(
    //  map(config => config.apsapiurl), // Используем оператор map для извлечения только apsapiurl
    //  map(url => url as string) // Преобразуем результат в строку
    //);
    return 'https://localhost:7042'
  }

  getGlasses(): Observable<DataList<Glasses>> {

    return this.http.get<DataList<Glasses>>(`/glasses`);
    
  }

  // Метод для получения списка всех фильмов
  //getMovies(i?: number): Observable<DataList<Movie>> {
  //  return this.http.get<DataList<Movie>>(`glass/${i}`);
  //}

  // Метод для получения информации о конкретном фильме по его ID
  getGlassesById(glassId: string): Observable<Glasses> {
    return this.http.get<Glasses>(`glasses/${glassId}`);
  }

  get_more_Glasses(from: number, to: number): Observable<DataList<Glasses>>{
    //let resalt = this.http.get<Movie[]>(`movie/${from}/${to}`)
      
    return this.http.get<DataList<Glasses>>(`glasses/getslice/${from}/${to}`);
  }

  get_Glass_img(glassId: string): string {
    return `${this.baseUrl}/help/GetImageById/${glassId}`;
  }


  public getGlassUrls(glass: Glasses, getfirst: boolean = false): string[] {
    const id = glass.id;
    const urls: string[] = [];
    if (getfirst) { return [`${this.baseUrl}/Help/GetImageById/${id}/${0}`] }
    for (let i = 0; i < glass.photos.length; i++) {
      //urls.push(`${this.baseUrl}/Help/GetImageById/${id}/${i}`);
      urls.push('/help/GetImageById/' + glass.id + '/' + i);

    }
    return urls;
  }
  //public getGlassesRange(glass: Glasses): number[] {
  //  return Array.from({ length: glass.photos.length }, (v, k) => k);
  //}

  //constructor(private http: HttpClient, private Config: ApplicationApiContext) { }
  //private apiUrl?: string;
  //ngOnInit() {
  //  this.Config.getConfig().subscribe(config => {
  //    this.apiUrl = config.apsapiurl;
  //    console.log(this.apiUrl); // Make sure apiUrl is set correctly
  //  });
  //}
  //// Метод для получения списка всех фильмов
  //getMovies(): Observable<Movie[]> {
  //  return this.http.get<Movie[]>(`${this.apiUrl}/movie`);
  //}

  //// Метод для получения информации о конкретном фильме по его ID
  //getMovieById(movieId: string): Observable<Movie> {
  //  return this.http.get<Movie>(`${this.apiUrl}/movie/${movieId}`);
  //}
}

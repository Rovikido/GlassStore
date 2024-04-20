import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GlassService } from '../../../services/GlassService';
import { Glasses } from '../../../models/Glasses/Glasses';


@Component({
  selector: 'app-glass',
  templateUrl: './glassList.component.html',
  styleUrl: './glassList.component.css',
  

})
export class GlassListComponent {
  public glasses: Glasses[] = [];

  constructor(public glassService: GlassService, private http: HttpClient) {
  }


  ngOnInit(): void {
    
    this.glassService.getGlasses().subscribe(
      (result) => {
        this.glasses = result.data;
      },
      (error) => {
        console.error(error);
      }
    );
  }



  //getmoreMovies(): void {
  //  //to = to + this.i;


  //  this.movieService.get_more_Movies(this.i, to).subscribe(
  //    (res) => {
  //      this.Movies = this.Movies.concat(res.data);
  //    });


  //  console.log(this.i, to, this.ListSize);
  //  this.i += to;

  //  if (this.i >= this.ListSize) {
  //    this.isLoading = true;
  //    return;
  //  }
  //}

}

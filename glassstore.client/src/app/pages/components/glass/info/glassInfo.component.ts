import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Glasses } from '../../../../models/Glasses/Glasses';
import { GlassService } from '../../../../services/Glass.service';
import { environment } from '../../../../enviroment';


@Component({
  selector: 'app-glassInfo',
  templateUrl: './glassInfo.component.html',
  styleUrl: './glassInfo.component.css'
})
export class GlassInfoComponent implements OnInit {
  public glassId: string = '';
  public glass!: Glasses;
  

  constructor(private route: ActivatedRoute, public glassService: GlassService) {
    this.glassId = this.route.snapshot.paramMap.get('id') || '';
  }

  ngOnInit(): void {
    this.glassService.getGlassesById(this.glassId).subscribe(
      (res: Glasses) => {
        this.glass = res;
      });
    console.log(this.glassId)
  }

  private MaskApi: string = environment.maskApi;
  public iframeUrl: string = ''; // URL для загрузки в iframe

  public loadMaskFrame(): void {
    // Здесь определите логику для загрузки URL в iframe
    this.iframeUrl = `${this.MaskApi}/${this.glassId}`;
    console.log(this.iframeUrl);
  }

  public CloseMaskFrame(): void {
    // Закрыть iframe
    this.iframeUrl = `${this.MaskApi}/stop_stream`;
  }
}

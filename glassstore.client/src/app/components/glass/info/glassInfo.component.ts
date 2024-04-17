import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GlassService } from '../../../services/GlassService';
import { Glasses } from '../../../models/Glasses';

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

  private MaskApi: string = 'http://127.0.0.1:5000';
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

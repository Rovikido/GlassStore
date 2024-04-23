import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlassesRoutingModule } from './glasses-routing.module';
import { GlassListComponent } from './list/glassList.component';
import { GlassInfoComponent } from './info/glassInfo.component';
import { GlassService } from '../../../services/Glass.service';




@NgModule({
  declarations: [
    GlassListComponent,
    GlassInfoComponent
  ],
  imports: [
    CommonModule,
    GlassesRoutingModule
  ],
  exports: [],
  providers: [GlassService],
})
export class GlassesModule { }

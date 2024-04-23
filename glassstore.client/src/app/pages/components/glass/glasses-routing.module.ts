import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GlassListComponent } from './list/glassList.component';
import { GlassInfoComponent } from './info/glassInfo.component';



const routes: Routes = [
  { path: "", component: GlassListComponent },
  { path: ":id", component: GlassInfoComponent },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GlassesRoutingModule { }

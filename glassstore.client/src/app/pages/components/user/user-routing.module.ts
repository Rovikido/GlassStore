import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { UserInfoComponent } from './user-info/user-info.component';



const routes: Routes = [
  { path: "", component: UserInfoComponent },
  { path: "Orders", component: OrdersComponent },
  { path: "Basket", component: BasketComponent },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }




import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserRoutingModule } from './user-routing.module';
import { OrdersComponent } from './orders/orders.component';
import { BasketComponent } from './basket/basket.component';
import { UserService } from '../../../services/User.service';
import { UserInfoComponent } from './user-info/user-info.component';






@NgModule({
  declarations: [
    OrdersComponent,
    BasketComponent,
    UserInfoComponent,
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ],
  //exports: [],
  providers: [UserService],
})
export class UserModule { }

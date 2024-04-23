import { Component } from '@angular/core';
import { UserService } from '../../../../services/User.service';


@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  constructor(private userService: UserService) { }
}

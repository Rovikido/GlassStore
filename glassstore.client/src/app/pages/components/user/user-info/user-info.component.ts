import { Component } from '@angular/core';
import { UserService } from '../../../../services/User.service';
import { User } from '../../../../models/User/User';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.css'
})
export class UserInfoComponent {
  public user!: User;

  constructor(public userservise: UserService) { this.getUser(); }
  onInit(): void {

  }


  getUser() {
    this.userservise.getuser().subscribe((res) => { this.user = res; });
  }

}

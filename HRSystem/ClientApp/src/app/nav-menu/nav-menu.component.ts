import { Component } from '@angular/core';
import { map } from 'rxjs';
import { AuthService } from '../shared/auth.service';
import { StatusService } from '../shared/status.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(private authService:AuthService, private statusService:StatusService){}
  isExpanded = false;
  isLoggedIn: boolean = false;
  role!:string;
  status!:string;
  ngOnInit() {
    this.authService.isLoggedIn().subscribe(loggedIn => {
      this.isLoggedIn = loggedIn;
    });
    this.authService.getRole().subscribe(role => {
      // console.log('nav role update');
      this.role = role;
    });
    this.statusService.getStatus().subscribe(status => {
      // console.log('nav role update');
      this.status = status;
      console.log('nav'+status);
    });
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout(){
    this.authService.logout();
  }
}

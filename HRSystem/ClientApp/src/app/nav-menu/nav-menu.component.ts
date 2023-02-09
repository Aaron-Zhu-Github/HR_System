import { Component } from '@angular/core';
import { map } from 'rxjs';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(private authService:AuthService){}
  isExpanded = false;
  isLoggedIn: boolean = false;
  role:string = '';
  ngOnInit() {
    this.authService.isLoggedIn().subscribe(loggedIn => {
      this.isLoggedIn = loggedIn;
    });
    this.authService.getRole().subscribe(role => {
      // console.log('nav role update');
      this.role = role;
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

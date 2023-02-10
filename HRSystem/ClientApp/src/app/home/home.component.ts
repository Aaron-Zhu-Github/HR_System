import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { map, Subscription } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../shared/auth.service';
import { StatusService } from '../shared/status.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  role: string = '';
  status:string=''
  constructor(private authService: AuthService, private http: HttpClient, private router: Router, private statusService: StatusService) {
    this.statusService.getStatus().subscribe(res => {
      if (res === 'Open') {
        this.router.navigate(['/OnBoarding']);
      }
      this.status = res;
      // console.log(this.status);
    });
  }

  ngOnInit() {
    this.authService.getRole().subscribe(role => {
      this.role = role;
    });   
  }
}

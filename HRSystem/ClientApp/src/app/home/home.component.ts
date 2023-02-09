import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from '../shared/auth.service';
import { StatusService } from '../shared/status.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  role:string = '';
  constructor(private authService:AuthService,private http:HttpClient, private router:Router, private statusService:StatusService){}

  ngOnInit(){
    this.authService.getRole().subscribe(role => {
      this.role = role;
    });
    console.log('home init');
    this.http.get<statusResponse>(environment.API_URL+'api/GetStatus')
      .subscribe(
        (res)=>{
          console.log(res.status);          
          this.statusService.setStatus(res.status);
          this.router.navigate(['/home']);
        },
        (err) => {
          console.error(err.error.message);
        }
      )
  }
}

interface statusResponse{
  status:string;
}
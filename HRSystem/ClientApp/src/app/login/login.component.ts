import { Component, Inject, OnInit } from '@angular/core';
import { emptyValidator } from 'src/app/empty.validator';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { environment } from 'src/environments/environment';
import { StatusService } from '../shared/status.service';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  constructor(private statusService:StatusService,private authService:AuthService,private router:Router,private fbuild:FormBuilder,private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.fbuild.group({
      username:['', emptyValidator()],
      password:['', emptyValidator()]
    })
  }

  onSubmit() {
    const loginData = {
      username: this.loginForm.value.username,
      password: this.loginForm.value.password
    };
    this.http.post<TokenResponse>('http://localhost:5000/api/Login', loginData)
    .pipe(
      switchMap((res) => {
        // console.log(res.message);
        localStorage.setItem('token', res.accessToken)
        this.authService.login();
        // console.log(res.role);
        this.authService.setRole(res.role);
        return this.http.get<statusResponse>(environment.API_URL + 'api/GetStatus');
      })
    )
    .subscribe(
      (res) => {
        // console.log(res.status);
        this.statusService.setStatus(res.status);
        if (res.status == 'Open') {
          this.router.navigate(['/OnBoarding'])
        } else {
          this.router.navigate(['/home']);
        }
      },
      (err) => {
        console.error(err.error.message);
      }
    );
  }
}

interface TokenResponse {
  message:string;
  accessToken: string;
  role:string;
}


interface statusResponse {
  status: string;
}
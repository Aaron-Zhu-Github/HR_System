import { Component, Inject, OnInit } from '@angular/core';
import { emptyValidator } from 'src/app/empty.validator';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  constructor(private authService:AuthService,private router:Router,private fbuild:FormBuilder,private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

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
      .subscribe(
        (res)=>{
          console.log(res.message);
          localStorage.setItem('token', res.accessToken)
          this.authService.login();
          console.log(res.role);
          this.authService.setRole(res.role);
          this.router.navigate(['/home']);
        },
        (error) => {
          alert("Login Failed, please check your username and password.")
          console.error(error);
        }
      )
  }
}

interface TokenResponse {
  message:string;
  accessToken: string;
  role:string;
}

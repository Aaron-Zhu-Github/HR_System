import { Component, Inject, OnInit } from '@angular/core';
import { emptyValidator } from 'src/app/empty.validator';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  constructor(private router:Router,private fbuild:FormBuilder,private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

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
          this.router.navigate(['/home']);
        }
      )
  }
}

interface TokenResponse {
  message:string;
  accessToken: string;
}

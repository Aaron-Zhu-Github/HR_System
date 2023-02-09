import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { shareReplay } from 'rxjs';
import { emptyValidator } from '../empty.validator';

@Component({
  selector: 'app-hire',
  templateUrl: './hire.component.html',
  styleUrls: ['./hire.component.css']
})
export class HireComponent {
  constructor(private fbuild: FormBuilder,private http:HttpClient) { }

  tokenGenerateForm!: FormGroup<any>;

  ngOnInit(): void {
    this.tokenGenerateForm = this.fbuild.group({
      email: ['', emptyValidator()],
    })
  }

  onSubmit() {
    const email = this.tokenGenerateForm.value.email;
    console.log(email);
    const endpoint = 'https://localhost:5401/api/Hire?email='+email;
    console.log(endpoint);
    this.http.post(endpoint,{})
      .subscribe(
        (response) => {
          this.tokenGenerateForm.controls.email.setValue('');
          alert("successed");
        },
        (error) => {          
          alert(error.error.message)
        }
      )
  }
}

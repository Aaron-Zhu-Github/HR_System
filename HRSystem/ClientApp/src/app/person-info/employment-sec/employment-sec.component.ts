import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-employment-sec',
  templateUrl: './employment-sec.component.html',
  styleUrls: ['./employment-sec.component.css']
})
export class EmploymentSecComponent implements OnInit {
  employmentSec!:EmploymentSec
  public editMode = false;
  public editForm!: FormGroup; 

  constructor(private http: HttpClient, private formBuilder: FormBuilder) { 
    this.editForm = this.formBuilder.group({
      startDate: ['',Validators.required],
      endDate: ['',Validators.required],
      visaStartDate: ['',Validators.required],
      visaEndDate: ['',Validators.required],
      title: ['',Validators.required],
    });
  }

  ngOnInit(): void {
    this.getEmploymentSec();
  }

  getEmploymentSec(){
    this.http.get<EmploymentSec>('https://localhost:5401/api/PersonalInformation/employment').subscribe(data => {
      this.employmentSec = data;
      console.log(data);
    });
  }

  populateForm() {
    this.editForm.patchValue({
      startDate: this.employmentSec.startDate,
      lastnendDateame: this.employmentSec.endDate,
      visaStartDate: this.employmentSec.visaStartDate,
      visaEndDate: this.employmentSec.visaEndDate,
      title: this.employmentSec.title
    });
  }

  onSubmit(){
    this.employmentSec.startDate = this.editForm.value.startDate;
    this.employmentSec.endDate = this.editForm.value.endDate;
    this.employmentSec.visaStartDate = this.editForm.value.visaStartDate;
    this.employmentSec.visaEndDate = this.editForm.value.visaEndDate;
    this.employmentSec.title = this.editForm.value.title;

    this.http.post<EmploymentSec>('https://localhost:5401/api/PersonalInformation/employment', this.employmentSec)
    .subscribe(data => {
      // this.nameSec = data;
      // this.toggleEdit();
      console.log(this.employmentSec);
      this.editMode = false;
    },
    error => console.error(error));
  }

  cancelEdit() {
    if (window.confirm('Are you sure you want to discard all your changes?')) {
      this.toggleEdit();
    }
  }

  toggleEdit(){
    this.editMode = !this.editMode;
  }
}

interface EmploymentSec {
  startDate: string,
  endDate: string,
  visaStartDate: string,
  visaEndDate: string,
  title: string
}

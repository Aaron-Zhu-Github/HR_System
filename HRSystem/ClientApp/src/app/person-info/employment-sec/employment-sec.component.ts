import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employment-sec',
  templateUrl: './employment-sec.component.html',
  styleUrls: ['./employment-sec.component.css']
})
export class EmploymentSecComponent implements OnInit {
  employmentSec!:EmploymentSec
  @Input() pid!: number;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEmploymentSec(this.pid);
  }

  getEmploymentSec(pid:number){
    this.http.get<EmploymentSec>('https://localhost:5401/api/PersonalInformation/employment/' + pid.toString()).subscribe(data => {
      this.employmentSec = data;
      console.log(data);
    });
  }
}

interface EmploymentSec {
  startDate: string,
  endDate: string,
  visaStartDate: string,
  visaEndDate: string,
  title: string
}

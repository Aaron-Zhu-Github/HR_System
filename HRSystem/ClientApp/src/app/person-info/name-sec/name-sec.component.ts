import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-name-sec',
  templateUrl: './name-sec.component.html',
  styleUrls: ['./name-sec.component.css']
})
export class NameSecComponent implements OnInit {
  public name_res!: NameSec;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<NameSec>(baseUrl + 'api/PersonalInformation/name/3').subscribe(result => {
      this.name_res = result;
      console.log(this.name_res.FirstName);
    }, error => console.error(error));
  }


  ngOnInit(): void {
  }
}

interface NameSec {
    FirstName: string;
    LastName: string;
    MiddleName: string;
    PreferredName: string;
    DOB: string; // 
    Gender: string;
    SSN: string;
}


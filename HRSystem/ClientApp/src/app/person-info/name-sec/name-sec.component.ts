import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-name-sec',
  templateUrl: './name-sec.component.html',
  styleUrls: ['./name-sec.component.css']
})
export class NameSecComponent implements OnInit {
  public nameSec!: NameSec;
  ssn_last4!:string;
  @Input()
  pid!: number;

  constructor(private http: HttpClient) {
  }


  ngOnInit(): void {
    this.getNameSec(this.pid);
  }

  getNameSec(pid:number){
    console.log(this.pid);
    this.http.get<NameSec>('https://localhost:5401/api/PersonalInformation/name/'+ pid.toString()).subscribe(data => {
      this.nameSec = data;
      this.ssn_last4 = this.nameSec?.person.ssn.substring(this.nameSec?.person.ssn.length-4);
    },
    error => console.error(error));
  }
}

interface Person {
    firstname: string;
    lastname: string;
    middlename: string;
    preferredName: string;
    dob: string; // 
    gender: string;
    ssn: string;
}

interface NameSec {
  person: Person;
}



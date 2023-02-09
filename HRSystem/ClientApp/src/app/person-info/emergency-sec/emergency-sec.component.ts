import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-emergency-sec',
  templateUrl: './emergency-sec.component.html',
  styleUrls: ['./emergency-sec.component.css']
})

export class EmergencySecComponent implements OnInit {
  emergencySec!: EmergencySec;
  
  @Input() pid!: number;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEmergencySec(this.pid);
  }

  getEmergencySec(pid: number) {
    this.http.get<EmergencySec>('https://localhost:5401/api/PersonalInformation/emergencycontact/' + pid.toString()).subscribe(data => {
      this.emergencySec = data;
    });
  }

}


interface Person {
  firstname: string;
  lastname: string;
  middlename: string;
  preferredName: string;
  cellPhone: string;
}

interface Address {
  addressLine1: string,
  addressLine2:string,
  city: string,
  zipcode: string,
  stateName: string,
  stateAbbr: string,
}

interface EmergencyContacts {
  person: Person,
  address: Address
}

interface EmergencySec {
  emergencyContacts: EmergencyContacts[]
}




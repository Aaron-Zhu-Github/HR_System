import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PersonInfoComponent } from '../person-info.component'; 

@Component({
  selector: 'app-address-sec',
  templateUrl: './address-sec.component.html',
  styleUrls: ['./address-sec.component.css']
})
export class AddressSecComponent implements OnInit {
  addressSec!: AddressSec;
  @Input() pid!: number;
  
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAddressSec(this.pid);
  }

  getAddressSec(pid: number) {
    this.http.get<AddressSec>('https://localhost:5401/api/PersonalInformation/address/' + pid.toString()).subscribe(data => {
      this.addressSec = data;
    });
  }

}

interface Address {
  id: number,
  addressLine1: string,
  addressLine2:string,
  city: string,
  zipcode: string,
  stateName: string,
  stateAbbr: string,
  personId: number
  isSecondary: boolean
}

interface AddressSec {
  addresses: Address[]
}


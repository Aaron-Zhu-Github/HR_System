import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-emergency-sec',
  templateUrl: './emergency-sec.component.html',
  styleUrls: ['./emergency-sec.component.css']
})

export class EmergencySecComponent implements OnInit {
  emergencySec!: EmergencySec;
  public editMode = false;
  public editForm!: FormGroup;
  public emergencyForm!:FormGroup;
  
  @Input() pid!: number;

  constructor(private http: HttpClient, private formBuilder: FormBuilder) { 
    this.editForm = this.formBuilder.group({
      personArray: this.formBuilder.array([]),
      addressArray: this.formBuilder.array([]),
    });
  }

  get personFormGetter():FormArray {
    return <FormArray> this.editForm.get('personArray');
  }

  get addressFormGetter():FormArray {
    return <FormArray> this.editForm.get('addressArray');
  }

  
  populateForm(){
    for (let item of this.emergencySec.emergencyContacts){
      this.addressFormGetter.push(this.formBuilder.group({
        addressLine1: [item.address.addressLine1],
        addressLine2:[item.address.addressLine2],
        city: [item.address.city],
        zipcode: [item.address.zipcode],
        stateName: [item.address.stateName],
        stateAbbr: [item.address.stateAbbr] }));
      
        this.personFormGetter.push(this.formBuilder.group({
        firstname: [item.person.firstname],
        lastname: [item.person.lastname],
        middlename: [item.person.middlename],
        preferredName: [item.person.preferredName],
        }));
    }
  }

  ngOnInit(): void {
    this.getEmergencySec(this.pid);
  }

  getEmergencySec(pid: number) {
    this.http.get<EmergencySec>('https://localhost:5401/api/PersonalInformation/emergencycontact').subscribe(data => {
      this.emergencySec = data;
    });
  }

  onSubmit(){
    // while (this.addressSec.addresses.length!=0){
    //   this.addressSec.addresses.pop();
    // }
    console.log(this.addressFormGetter.controls[0]);
    let i = 0; 
    for (let item of this.addressFormGetter.controls){
      this.emergencySec.emergencyContacts[i].address.addressLine1 = item.value.addressLine1;
      this.emergencySec.emergencyContacts[i].address.addressLine2 = item.value.addressLine2;
      this.emergencySec.emergencyContacts[i].address.city = item.value.city;
      this.emergencySec.emergencyContacts[i].address.stateName = item.value.stateName;
      this.emergencySec.emergencyContacts[i].address.zipcode = item.value.zipcode;
      this.emergencySec.emergencyContacts[i].address.stateAbbr = item.value.stateAbbr;

      i += 1;
    }
    
    let j = 0;
    for (let item of this.personFormGetter.controls){
      this.emergencySec.emergencyContacts[j].person.firstname = item.value.firstname;
      this.emergencySec.emergencyContacts[j].person.lastname = item.value.lastname;
      this.emergencySec.emergencyContacts[j].person.middlename = item.value.middlename;
      this.emergencySec.emergencyContacts[j].person.preferredName = item.value.preferredName;

      j += 1;
    }

    this.http.post<EmergencySec>('https://localhost:5401/api/PersonalInformation/emergencycontact', this.emergencySec)
    .subscribe(data => {
      // this.nameSec = data;
      // this.toggleEdit();
      console.log(this.emergencySec);
      this.editMode = false;
    },
    error => console.error(error));
  }

  toggleEdit(){
    this.editMode = !this.editMode;
  }

  cancelEdit() {
    if (window.confirm('Are you sure you want to discard all your changes?')) {
      this.toggleEdit();
    }
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




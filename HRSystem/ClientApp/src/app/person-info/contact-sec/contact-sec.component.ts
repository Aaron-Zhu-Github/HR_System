import { Component, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-contact-sec',
  templateUrl: './contact-sec.component.html',
  styleUrls: ['./contact-sec.component.css']
})
export class ContactSecComponent implements OnInit {
  @Input() pid!: number;
  public contactSec!: ContactSec;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getContactSec(this.pid);
  }

  getContactSec(pid: number) {
    this.http.get<ContactSec>('https://localhost:5401/api/PersonalInformation/contact/' + pid.toString()).subscribe(data => {
      this.contactSec = data;
    });
  }
}

interface ContactSec {
  email: string;
  workEmail: string;
  cellPhone: string;
  alternatePhone: string;
}

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-person-info',
  templateUrl: './person-info.component.html',
  styleUrls: ['./person-info.component.css']
})
export class PersonInfoComponent implements OnInit {
  pid:number = 3;

  constructor() { }

  ngOnInit(): void {
  }


}

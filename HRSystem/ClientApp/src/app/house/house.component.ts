import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-house',
  templateUrl: './house.component.html',
  styleUrls: ['./house.component.css']
})
//export class HouseComponent implements OnInit {
//  public houses: HouseDetail[] = [];


//  constructor(private http: HttpClient) { }

//  ngOnInit(): void {
//    this.getHouse();
//  }

//  getHouse() {
//    this.http.get<HouseDetail[]>('https://localhost:5401/houseDetail').subscribe(data => {
//      this.houses = data;
//    });
//  }

//}

export class HouseComponent {
  public houses: HouseDetail[] = [];

  constructor(private http: HttpClient) { 
    http.get<HouseDetail[]>('https://localhost:5401/houseDetail').subscribe(data => {
  this.houses = data;
    }, error => console.error(error));
  }
}

interface HouseDetail {
  id: number;//not show on page
  houseAddress: string;
  preferredName: string;
  phone: string;
}


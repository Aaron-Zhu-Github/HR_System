import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-house',
  templateUrl: './house.component.html',
  styleUrls: ['./house.component.css']
})
export class HouseComponent {
  public houses: HouseDetail[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<HouseDetail[]>(baseUrl + 'houseDetail').subscribe(result => {
      this.houses = result;
    }, error => console.error(error));
  }

}

interface HouseDetail {
  id: number;
  houseAddress: string;
  preferredName: string;
  phone: string;
}
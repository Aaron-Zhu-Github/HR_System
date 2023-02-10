import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-hrhouse-management',
  templateUrl: './hrhouse-management.component.html',
  styleUrls: ['./hrhouse-management.component.css']
})
export class HRHouseManagementComponent {
  public hrhouses: House[] = [];

  constructor(private http: HttpClient) {
    http.get<House[]>('https://localhost:5401/houseDetailHR').subscribe(data => {
      this.hrhouses = data;
    }, error => console.error(error));
  }

}

interface House{
  id: number;//not show on page
  houseAddress: string;
  landlord: string;
  phone: string;
  email: string;
  numberOfEmployee: number;
}






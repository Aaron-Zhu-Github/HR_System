import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { environment } from 'src/environments/environment';
import { StatusService } from '../shared/status.service';

@Component({
  selector: 'app-documentation',
  templateUrl: './documentation.component.html',
  styleUrls: ['./documentation.component.css']
})
export class DocumentationComponent implements OnInit {
  fileUrl: string = environment.FileURL;
  requiredfiles!: Observable<filesResponse[]>;
  reviewFile: boolean = false;
  constructor(private http: HttpClient, private statusService: StatusService, private router: Router) { }
  ngOnInit(): void {
    this.http.get<filesResponse[]>(environment.API_URL + "api/requiredfile").subscribe(
      (res) => {
        this.requiredfiles = of(res);
      },
      error => {
        console.error("Error while fetching required files", error);
      }
    );
  }

  onSubmit() {
    this.reviewFile = true;
  }

  onApplicationSubmit() {
    this.http.post(environment.API_URL + "api/UpdateApplicationStatus?status=pending", {}).subscribe(
      (res) => {
        this.statusService.setStatus("pending");
        this.router.navigate(['home']);
      },
      error => {
        alert('fail to submit');
      }
    );

  }
}

interface filesResponse {
  title: string;
  path: string;
}

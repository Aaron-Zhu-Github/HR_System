import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AuthService } from '../shared/auth.service';
import { AvatarService } from '../shared/avatar.service';
import { StatusService } from '../shared/status.service';

@Component({
  selector: 'app-person-info',
  templateUrl: './person-info.component.html',
  styleUrls: ['./person-info.component.css']
})
export class PersonInfoComponent implements OnInit {
  pid:number = 3;

  fileUrl:string = environment.FileURL
  avatar!: string;

  constructor(private avatarService:AvatarService) {
    this.avatarService.getAvatar().subscribe(avatar => {
      this.avatar = avatar;
    });
    console.log(this.avatar);
  }

  ngOnInit(): void {
    
  }

}

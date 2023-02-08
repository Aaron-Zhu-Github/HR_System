import { Component, OnInit } from '@angular/core';
import { applicationForm } from '../applicationForm';

@Component({
  selector: 'app-on-boarding-insert-form',
  templateUrl: './on-boarding-insert-form.component.html',
  styleUrls: ['./on-boarding-insert-form.component.css']
})
export class OnBoardingInsertFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  genders = ['Male', 'Female', 'Other'];

  model = new applicationForm('', '', '', '', '');

  submitted = false;

  onSubmit(){this.submitted = true;}

}

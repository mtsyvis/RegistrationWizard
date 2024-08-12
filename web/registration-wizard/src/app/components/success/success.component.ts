import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationDataService } from '../../services/registration-data.service';

@Component({
  selector: 'app-success',
  templateUrl: './success.component.html',
  styleUrls: ['./success.component.css']
})
export class SuccessComponent implements OnInit {
  userLogin!: string;

  constructor(
    private router: Router,
    private registrationDataService: RegistrationDataService
  ) {}

  ngOnInit(): void {
    this.userLogin = this.registrationDataService.getStepOneData()?.login || 'User';

    // Clear the data after displaying it
    this.registrationDataService.clearData();
  }

  onRegisterNewUser(): void {
    this.router.navigate(['/step-one']);
  }
}

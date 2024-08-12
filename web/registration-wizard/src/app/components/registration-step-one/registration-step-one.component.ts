import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RegistrationDataService } from '../../services/registration-data.service';


@Component({
  selector: 'app-registration-step-one',
  templateUrl: './registration-step-one.component.html',
  styleUrls: ['./registration-step-one.component.css'],
  imports: [ReactiveFormsModule, CommonModule],
  standalone: true,
})
export class RegistrationStepOneComponent implements OnInit {
  stepOneForm!: FormGroup;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private registrationDataService: RegistrationDataService
  ) {}

  ngOnInit(): void {
    this.stepOneForm = this.formBuilder.group({
      login: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.pattern('^(?=.*[0-9])(?=.*[a-zA-Z]).{6,}$')]],
      confirmPassword: ['', Validators.required],
      agree: [false, Validators.requiredTrue]
    }, {
      validator: this.mustMatch('password', 'confirmPassword')
    });
  }

  get f() { return this.stepOneForm.controls; }

  onNext() {
    this.submitted = true;

    if (this.stepOneForm.invalid) {
      return;
    }

    // Store step one data in the service
    this.registrationDataService.setStepOneData(this.stepOneForm.value);

    // Navigate to the next step
    this.router.navigate(['/step-two']);
    debugger;
  }

  mustMatch(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passControl = formGroup.controls[password];
      const confirmPassControl = formGroup.controls[confirmPassword];

      if (confirmPassControl.errors && !confirmPassControl.errors['mustMatch']) {
        return;
      }

      if (passControl.value !== confirmPassControl.value) {
        confirmPassControl.setErrors({ mustMatch: true });
      } else {
        confirmPassControl.setErrors(null);
      }
    };
  }
}

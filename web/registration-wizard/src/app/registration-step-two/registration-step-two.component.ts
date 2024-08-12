import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RegistrationDataService } from '../services/registration-data.service';
import { Router } from '@angular/router';
import { User } from '../models/user.model';
import { Country } from '../models/country.model';
import { Province } from '../models/province.model';

@Component({
  selector: 'app-registration-step-two',
  templateUrl: './registration-step-two.component.html',
  styleUrls: ['./registration-step-two.component.css'],
  imports: [ReactiveFormsModule, CommonModule],
  standalone: true,
})
export class RegistrationStepTwoComponent implements OnInit {
  stepTwoForm!: FormGroup;
  submitted = false;
  countries: Country[] = [];
  provinces: Province[] = [];
  stepOneData: any;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private registrationDataService: RegistrationDataService,
  ) {}

  ngOnInit(): void {
    this.stepTwoForm = this.formBuilder.group({
      country: ['', Validators.required],
      province: ['', Validators.required]
    });

    this.stepOneData = this.registrationDataService.getStepOneData();

    if (!this.stepOneData) {
      // Redirect back to step one if no data is available
      this.router.navigate(['/step-one']);
    }

    this.loadCountries();
  }

  get f() { return this.stepTwoForm.controls; }

  onCountryChange(event: Event): void {
    const target = event.target as HTMLSelectElement; // Perform the type assertion here
    const selectedCountryId = target.value as unknown as number;

    // Load provinces or perform other actions based on the selected country
    console.log(selectedCountryId, 'Selected country Id:');

    if (selectedCountryId) {
      this.loadProvinces(selectedCountryId);
    } else {
      this.provinces = [];
    }
  }

  onSave() {
    this.submitted = true;

    if (this.stepTwoForm.invalid) {
      return;
    }

    const stepTwoData = this.stepTwoForm.value;

    const userData: User = {
      login: this.stepOneData.login,
      password: this.stepOneData.password,
      agreeToTerms: this.stepOneData.agree,
      countryId: stepTwoData.country,
      provinceId: stepTwoData.province
    };

    this.http.post('https://localhost:44335/api/users', userData)
      .subscribe({
        next: (response) => {
          console.log('User saved successfully', response);
          this.router.navigate(['/success']); // Replace with your actual navigation
        },
        error: (err) => console.error('Error saving user', err)
      });
  }

  loadCountries() {
    this.http.get<Country[]>('https://localhost:44335/api/countries').subscribe((data: Country[]) => {
      this.countries = data;
    });
  }

  loadProvinces(countryId: number) {
    this.http.get<Province[]>(`https://localhost:44335/api/countries/${countryId}/provinces`).subscribe((data: Province[]) => {
      this.provinces = data;
    });
  }
}

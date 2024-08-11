import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface Country {
  id: number;
  name: string;
  // Add other properties as needed
}

interface Province {
  id: number;
  name: string;
  // Add other properties as needed
}

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

  constructor(private formBuilder: FormBuilder, private http: HttpClient) {}

  ngOnInit(): void {
    this.stepTwoForm = this.formBuilder.group({
      country: ['', Validators.required],
      province: ['', Validators.required]
    });

    this.loadCountries();
  }

  get f() { return this.stepTwoForm.controls; }

  // onCountryChange(countryId: string) {
  //   this.loadProvinces(countryId);
  // }

  onCountryChange(event: Event): void {
    const target = event.target as HTMLSelectElement; // Perform the type assertion here
    const selectedCountry = target.value;

    // Load provinces or perform other actions based on the selected country
    console.log('Selected country:', selectedCountry);
  }

  onSave() {
    this.submitted = true;

    if (this.stepTwoForm.invalid) {
      return;
    }

    // Save the data
    this.http.post('/api/registration', this.stepTwoForm.value).subscribe(response => {
      console.log('Registration saved successfully!', response);
    });
  }

  loadCountries() {

    // add fake data for countries
    this.countries = [
      { id: 1, name: 'USA' },
      { id: 2, name: 'Canada' },
      { id: 3, name: 'Mexico' }
    ];

    // this.http.get<Country[]>('/api/countries').subscribe((data: Country[]) => {
    //   this.countries = data;
    // });
  }

  loadProvinces(countryId: string) {
    this.http.get<Province[]>(`/api/provinces?countryId=${countryId}`).subscribe((data: Province[]) => {
      this.provinces = data;
    });
  }
}

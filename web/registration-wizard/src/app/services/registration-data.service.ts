import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class RegistrationDataService {
  private stepOneData: any = null;

  setStepOneData(data: any) {
    this.stepOneData = data;
  }

  getStepOneData() {
    return this.stepOneData;
  }

  clearData() {
    this.stepOneData = null;
  }
}

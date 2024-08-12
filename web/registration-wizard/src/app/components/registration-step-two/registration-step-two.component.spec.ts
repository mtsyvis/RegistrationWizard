import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrationStepTwoComponent } from './registration-step-two.component';

describe('RegistrationStepTwoComponent', () => {
  let component: RegistrationStepTwoComponent;
  let fixture: ComponentFixture<RegistrationStepTwoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegistrationStepTwoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegistrationStepTwoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

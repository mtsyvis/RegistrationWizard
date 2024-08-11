import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationStepOneComponent } from './registration-step-one/registration-step-one.component';
import { RegistrationStepTwoComponent } from './registration-step-two/registration-step-two.component';

const routes: Routes = [
  { path: '', redirectTo: '/step-one', pathMatch: 'full' },
  { path: 'step-one', component: RegistrationStepOneComponent },
  { path: 'step-two', component: RegistrationStepTwoComponent }
];

export { routes };

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

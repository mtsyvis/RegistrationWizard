import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationStepOneComponent } from './registration-step-one/registration-step-one.component';
import { RegistrationStepTwoComponent } from './registration-step-two/registration-step-two.component';
import { SuccessComponent } from './success/success.component';

const routes: Routes = [
  { path: 'step-one', component: RegistrationStepOneComponent },
  { path: 'step-two', component: RegistrationStepTwoComponent },
  { path: 'success', component: SuccessComponent },
  { path: '', redirectTo: '/step-one', pathMatch: 'full' },
  { path: '**', redirectTo: '/step-one' }, // Fallback for unknown routes
];

export { routes };

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

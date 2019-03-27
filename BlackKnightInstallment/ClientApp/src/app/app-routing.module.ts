import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InstallmentCalculatorComponent } from './installment-calculator/installment-calculator.component';

const routes: Routes = [
  { path: '', component: InstallmentCalculatorComponent },
  { path: 'InstallmentCalculation', component: InstallmentCalculatorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

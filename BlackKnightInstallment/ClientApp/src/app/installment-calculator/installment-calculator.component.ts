import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { InstallmentService } from './installment.service';

@Component({
  selector: 'app-installment-calculator',
  templateUrl: './installment-calculator.component.html',
  styleUrls: ['./installment-calculator.component.css']
})
export class InstallmentCalculatorComponent implements OnInit {
  @ViewChild('f') installmentForm: NgForm;
  arrInstallmentAmount: number[];


  constructor(private _installmentService : InstallmentService) { }

  ngOnInit() {
  }

  onSubmit() {
    

    let TotalAmount = +this.installmentForm.value.TotalAmount;
    let NoOfInstallments = +this.installmentForm.value.NoOfInstallments;



    //debugger;

    this._installmentService.getInstallment(TotalAmount, NoOfInstallments).subscribe(data => {
      this.arrInstallmentAmount = data;
    }
    );

  }

}

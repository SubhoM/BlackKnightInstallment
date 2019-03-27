import { async, ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { InstallmentCalculatorComponent } from './installment-calculator.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { InstallmentService } from './installment.service';

describe('InstallmentCalculatorComponent', () => {
  let component: InstallmentCalculatorComponent;
  let fixture: ComponentFixture<InstallmentCalculatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [InstallmentCalculatorComponent],
      imports:[FormsModule, HttpClientModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstallmentCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch data successfully if called asynchronously', fakeAsync(() => {
    let fixture = TestBed.createComponent(InstallmentCalculatorComponent);
    let app = fixture.debugElement.componentInstance;
    let installmentService = fixture.debugElement.injector.get(InstallmentService);

    let spy = spyOn(installmentService, 'getInstallment')
      .and.returnValue(Promise.resolve(undefined));
    fixture.detectChanges();
    tick();
    expect(app.arrInstallmentAmount).toBe(undefined);
  }));

});

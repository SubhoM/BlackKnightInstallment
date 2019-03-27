import { TestBed } from '@angular/core/testing';

import { InstallmentService } from './installment.service';
import { HttpClientModule } from '@angular/common/http';

describe('InstallmentService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientModule]
  }));

  it('should be created', () => {
    const service: InstallmentService = TestBed.get(InstallmentService);
    expect(service).toBeTruthy();
  });
});

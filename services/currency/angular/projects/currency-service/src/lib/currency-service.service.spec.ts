import { TestBed } from '@angular/core/testing';
import { CurrencyServiceService } from './services/currency-service.service';
import { RestService } from '@abp/ng.core';

describe('CurrencyServiceService', () => {
  let service: CurrencyServiceService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(CurrencyServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

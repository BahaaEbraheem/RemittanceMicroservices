import { TestBed } from '@angular/core/testing';
import { CustomerServiceService } from './services/customer-service.service';
import { RestService } from '@abp/ng.core';

describe('CustomerServiceService', () => {
  let service: CustomerServiceService;
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
    service = TestBed.inject(CustomerServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

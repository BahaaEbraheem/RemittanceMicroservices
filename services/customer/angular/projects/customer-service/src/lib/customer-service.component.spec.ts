import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { CustomerServiceComponent } from './components/customer-service.component';
import { CustomerServiceService } from '@e-shop-on-abp/customer-service';
import { of } from 'rxjs';

describe('CustomerServiceComponent', () => {
  let component: CustomerServiceComponent;
  let fixture: ComponentFixture<CustomerServiceComponent>;
  const mockCustomerServiceService = jasmine.createSpyObj('CustomerServiceService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [CustomerServiceComponent],
      providers: [
        {
          provide: CustomerServiceService,
          useValue: mockCustomerServiceService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomerServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { CurrencyServiceComponent } from './components/currency-service.component';
import { CurrencyServiceService } from '@e-shop-on-abp/currency-service';
import { of } from 'rxjs';

describe('CurrencyServiceComponent', () => {
  let component: CurrencyServiceComponent;
  let fixture: ComponentFixture<CurrencyServiceComponent>;
  const mockCurrencyServiceService = jasmine.createSpyObj('CurrencyServiceService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [CurrencyServiceComponent],
      providers: [
        {
          provide: CurrencyServiceService,
          useValue: mockCurrencyServiceService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrencyServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

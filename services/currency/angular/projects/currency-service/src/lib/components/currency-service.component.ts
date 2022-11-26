import { Component, OnInit } from '@angular/core';
import { CurrencyServiceService } from '../services/currency-service.service';

@Component({
  selector: 'lib-currency-service',
  template: ` <p>currency-service works!</p> `,
  styles: [],
})
export class CurrencyServiceComponent implements OnInit {
  constructor(private service: CurrencyServiceService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}

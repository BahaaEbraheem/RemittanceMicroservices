import { Component, OnInit } from '@angular/core';
import { CustomerServiceService } from '../services/customer-service.service';

@Component({
  selector: 'lib-customer-service',
  template: ` <p>customer-service works!</p> `,
  styles: [],
})
export class CustomerServiceComponent implements OnInit {
  constructor(private service: CustomerServiceService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}

import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class CustomerServiceService {
  apiName = 'CustomerService';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/CustomerService/sample' },
      { apiName: this.apiName }
    );
  }
}

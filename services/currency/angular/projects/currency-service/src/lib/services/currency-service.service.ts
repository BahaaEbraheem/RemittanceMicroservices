import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class CurrencyServiceService {
  apiName = 'CurrencyService';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/CurrencyService/sample' },
      { apiName: this.apiName }
    );
  }
}

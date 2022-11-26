import { ModuleWithProviders, NgModule } from '@angular/core';
import { CUSTOMER_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CustomerServiceConfigModule {
  static forRoot(): ModuleWithProviders<CustomerServiceConfigModule> {
    return {
      ngModule: CustomerServiceConfigModule,
      providers: [CUSTOMER_SERVICE_ROUTE_PROVIDERS],
    };
  }
}

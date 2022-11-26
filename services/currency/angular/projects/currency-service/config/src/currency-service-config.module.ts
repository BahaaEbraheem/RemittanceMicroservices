import { ModuleWithProviders, NgModule } from '@angular/core';
import { CURRENCY_SERVICE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CurrencyServiceConfigModule {
  static forRoot(): ModuleWithProviders<CurrencyServiceConfigModule> {
    return {
      ngModule: CurrencyServiceConfigModule,
      providers: [CURRENCY_SERVICE_ROUTE_PROVIDERS],
    };
  }
}

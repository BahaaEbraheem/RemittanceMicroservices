import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CurrencyServiceComponent } from './components/currency-service.component';
import { CurrencyServiceRoutingModule } from './currency-service-routing.module';

@NgModule({
  declarations: [CurrencyServiceComponent],
  imports: [CoreModule, ThemeSharedModule, CurrencyServiceRoutingModule],
  exports: [CurrencyServiceComponent],
})
export class CurrencyServiceModule {
  static forChild(): ModuleWithProviders<CurrencyServiceModule> {
    return {
      ngModule: CurrencyServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CurrencyServiceModule> {
    return new LazyModuleFactory(CurrencyServiceModule.forChild());
  }
}

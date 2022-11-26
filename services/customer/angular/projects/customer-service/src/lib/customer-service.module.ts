import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CustomerServiceComponent } from './components/customer-service.component';
import { CustomerServiceRoutingModule } from './customer-service-routing.module';

@NgModule({
  declarations: [CustomerServiceComponent],
  imports: [CoreModule, ThemeSharedModule, CustomerServiceRoutingModule],
  exports: [CustomerServiceComponent],
})
export class CustomerServiceModule {
  static forChild(): ModuleWithProviders<CustomerServiceModule> {
    return {
      ngModule: CustomerServiceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CustomerServiceModule> {
    return new LazyModuleFactory(CustomerServiceModule.forChild());
  }
}

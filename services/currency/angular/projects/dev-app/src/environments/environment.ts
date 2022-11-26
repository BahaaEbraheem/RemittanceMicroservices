import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CurrencyService',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44380/',
    redirectUri: baseUrl,
    clientId: 'CurrencyService_App',
    responseType: 'code',
    scope: 'offline_access CurrencyService',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44380',
      rootNamespace: 'EShopOnAbp.CurrencyService',
    },
    CurrencyService: {
      url: 'https://localhost:44311',
      rootNamespace: 'EShopOnAbp.CurrencyService',
    },
  },
} as Environment;

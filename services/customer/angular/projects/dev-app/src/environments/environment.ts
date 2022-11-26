import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'CustomerService',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44308/',
    redirectUri: baseUrl,
    clientId: 'CustomerService_App',
    responseType: 'code',
    scope: 'offline_access CustomerService',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44308',
      rootNamespace: 'EShopOnAbp.CustomerService',
    },
    CustomerService: {
      url: 'https://localhost:44375',
      rootNamespace: 'EShopOnAbp.CustomerService',
    },
  },
} as Environment;

import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { LoaderInterceptor } from './loader.interceptors';

export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
];

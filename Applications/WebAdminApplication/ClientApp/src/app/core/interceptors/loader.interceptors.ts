import { Injectable, Injector } from '@angular/core';
import {
    HttpEvent,
    HttpRequest,
    HttpHandler,
    HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { finalize, delay } from 'rxjs/operators';
import { LoaderService } from 'src/app/shared/services/loader.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
    constructor(private injector: Injector) { }
    intercept(
        req: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        if (req.url.includes('i18n')) {
            return next.handle(req).pipe(
                delay(0),
                finalize(() => {})
            );
        }

        const loaderService = this.injector.get(LoaderService);

        loaderService.show();

        return next.handle(req).pipe(
            delay(100),
            finalize(() => loaderService.hide())
        );
    }
}

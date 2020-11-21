import { SafePipe } from './pipes/safe';
import { CurrencyMaskDirective } from './directives/currency-mask.directive';
import { NgModule, ModuleWithProviders, APP_INITIALIZER } from '@angular/core';
import { TranslatePipe } from './pipes/translate.pipe';
import { TranslateService } from './services/translate.service';
import { MaterialModule } from './material.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { httpInterceptorProviders } from '../core/interceptors';
import { ProgressBarLoaderComponent } from './components/loader/progress-bar-loader/progress-bar-loader.component';
import { ProgressSprinnerLoaderComponent } from './components/loader/progress-sprinner-loader/progress-sprinner-loader.component';
import { ConfirmationComponent } from './components/confirmation/confirmation.component';
import { AlertComponent } from './components/alert/alert.component';
import { UppercaseInputDirective } from './directives/uppercase-input.directive';
import { LowercaseInputDirective } from './directives/lowercase-input.directive';
import { PhoneMaskDirective } from './directives/phone-mask.directive';
export function setupTranslateFactory(service: TranslateService) {
    return () => {
        service.use(service.getLanguage());
    };
}

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        // 3rd party
        NgbModule,
        MaterialModule,
    ],
    declarations: [
        TranslatePipe,
        SafePipe,
        ProgressBarLoaderComponent,
        ProgressSprinnerLoaderComponent,
        ConfirmationComponent,
        AlertComponent,
        UppercaseInputDirective,
        LowercaseInputDirective,
        PhoneMaskDirective,
        CurrencyMaskDirective
    ],
    providers: [

    ],
    exports: [
        // module
        TranslatePipe,
        SafePipe,
        MaterialModule,
        NgbModule,
        FormsModule,
        ReactiveFormsModule,

        // components
        ProgressBarLoaderComponent,
        ProgressSprinnerLoaderComponent,
        ConfirmationComponent,

        // directive
        UppercaseInputDirective,
        LowercaseInputDirective,
        PhoneMaskDirective,
        CurrencyMaskDirective
    ],
    entryComponents: [
        ConfirmationComponent,
        AlertComponent,
    ]
})

export class SharedModule {
    static forRoot(): ModuleWithProviders<SharedModule> {
        return {
            ngModule: SharedModule,
            providers: [
                httpInterceptorProviders,
                TranslatePipe,
            ],
        };
    }
}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatNativeDateModule } from '@angular/material/core';
import { TranslateService } from './shared/services/translate.service';
import { DropzoneDirective } from './shared/directives/dropzone.directive';
import { environment } from 'src/environments/environment';
import { SharedModule } from './shared/shared.module';
import { AuthModule } from './modules/auth/auth.module';
import { NavComponent } from './layout/nav/nav.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { ContentComponent } from './layout/content/content.component';
import { MetasearchModule } from './modules/metasearch/metasearch.module';
import { FooterComponent } from './layout/footer/footer.component';
import { HttpService } from './shared/services/http.service';
import { CurrencyPipe } from '@angular/common';
import { KeyboardShortcutsModule } from 'ng-keyboard-shortcuts';
import { ErrorPagesComponent } from './layout/error-pages/error-pages.component';

export function setupTranslateFactory(service: TranslateService) {
  return () => {
    service.use(service.getLanguage());
  };
}

const MAIN_MODULE = [
  BrowserModule,
  FormsModule,
  ReactiveFormsModule,
  NgbModule,
  HttpClientModule,
  BrowserAnimationsModule
];

const MAIN_SERVICE = [HttpService];

const INTERNAL_SERVICE = [
  TranslateService,
  {
    provide: APP_INITIALIZER,
    useFactory: setupTranslateFactory,
    deps: [TranslateService],
    multi: true
  }
];

@NgModule({
  declarations: [
    AppComponent,
    DropzoneDirective,
    NavComponent,
    SidebarComponent,
    ContentComponent,
    FooterComponent,
    ErrorPagesComponent,
  ],
  imports: [
    MAIN_MODULE,
    JwtModule.forRoot({
      config: {
        tokenGetter: jwtTokenGetter
      }
    }),
    AppRoutingModule,
    MatNativeDateModule,
    AuthModule,
    SharedModule.forRoot(),
    MetasearchModule,
    KeyboardShortcutsModule
  ],
  providers: [MAIN_SERVICE, INTERNAL_SERVICE, JwtHelperService, CurrencyPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function jwtTokenGetter() {
  return localStorage.getItem(environment.tokenKey);
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LANGUAGE, Language } from 'src/assets/i18n/lang';

@Injectable({
  providedIn: 'root'
})
export class TranslateService {

  data: any = {};

  constructor(
    private http: HttpClient
  ) { }

  use(lang: string): Promise<{}> {
    localStorage.setItem('lang', lang);
    return new Promise<{}>((resolve, reject) => {
      const langPath = `assets/i18n/lang.${lang || 'en'}.json`;

      this.http.get<{}>(langPath).subscribe(
        translation => {
          this.data = Object.assign({}, translation || {});
          resolve(this.data);
        },
        error => {
          this.data = {};
          resolve(this.data);
        }
      );
    });
  }

  getLanguages(): Language[] {
    return LANGUAGE;
  }

  getLanguage(): string {
    return localStorage.getItem('lang') || LANGUAGE[0].key;
  }
}

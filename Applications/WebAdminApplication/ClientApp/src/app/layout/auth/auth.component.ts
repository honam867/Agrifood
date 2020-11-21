import { Component, OnInit } from '@angular/core';
import { TranslateService } from 'src/app/shared/services/translate.service';
import { Language, LANGUAGE } from 'src/assets/i18n/lang';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  languages: any;
  lang: string;

  constructor(
    private translate: TranslateService
  ) { }

  ngOnInit() {
    this.languages = this.translate.getLanguages();
    this.lang = this.translate.getLanguage();
  }

  changeLanguage(key: string) {
    this.translate.use(key);
  }
}

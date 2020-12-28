import { Injectable, isDevMode } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import * as xml2js from 'xml2js';
@Injectable()
export class HttpService {
  constructor(private http: HttpClient) { }

  private addTokenToHeader(): HttpHeaders {
    let header: HttpHeaders = new HttpHeaders();
    if (localStorage.length !== 0) {
      const token = localStorage.getItem(environment.tokenKey);
      if (token) {
        const accessToken = JSON.parse(token);
        header = header.append(
          'Authorization',
          `Bearer ${accessToken.access_token}`
        );
      }
    }
    header = header.append('Content-type', 'application/json');
    return header;
  }

  private addTokenToHeaderFormData(): HttpHeaders {
    let header: HttpHeaders = new HttpHeaders();
    if (localStorage.length !== 0) {
      const token = localStorage.getItem(environment.tokenKey);
      if (token) {
        const accessToken = JSON.parse(token);
        header = header.append(
          'Authorization',
          `Bearer ${accessToken.access_token}`
        );
      }
    }
    return header;
  }

  public getAbsoluteUrl(path: string): string {
    return environment.apiUrl + path;
  }

  private subscribeForRequest(request: Observable<any>): Observable<any> {
    return request
      .pipe(
        catchError(res => {
          if (res.status === 500) {
          }
          return throwError(res);
        })
      )
      .pipe(finalize(() => { }));
  }

  private beforeSendRequest() { }

  public get(url: string): Observable<any> {
    console.log('GETTT')
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.get(this.getAbsoluteUrl(url), {
        headers: this.addTokenToHeader()
      })
    );
  }

  public getBody(url: string, body: any): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.get(this.getAbsoluteUrl(url), {
        headers: this.addTokenToHeader()
      })
    );
  }

  public getStringValue(url: string): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.get(this.getAbsoluteUrl(url), {
        headers: this.addTokenToHeader(),
        responseType: 'text'
      })
    );
  }

  public post(url: string, body: any): Observable<any> {

    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.post(this.getAbsoluteUrl(url), body, {
        headers: this.addTokenToHeader()
      })
    );
  }

  public postFormData(url: string, body: any): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.post(this.getAbsoluteUrl(url), body, {
        headers: this.addTokenToHeaderFormData()
      })
    );
  }


  public put(url: string, body: any): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.put(this.getAbsoluteUrl(url), body, {
        headers: this.addTokenToHeader()
      }
      )
    );
  }

  public postNotBody(url: string): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.post(this.getAbsoluteUrl(url), null, {
        headers: this.addTokenToHeader()
      })
    );
  }

  public putNoBody(url: string): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.put(this.getAbsoluteUrl(url), null, {
        headers: this.addTokenToHeader()
      })
    );
  }

  public delete(url: string): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.delete(this.getAbsoluteUrl(url), {
        headers: this.addTokenToHeader()
      })
    );
  }

  public post1(url: string, body: any): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.post(this.getAbsoluteUrl(url), body, {
        headers: this.addTokenToHeader()
      })
    );
  }

  // public deleteFromBody(url: string,body: any): Observable<any> {
  //   this.beforeSendRequest();
  //   return this.subscribeForRequest(
  //     this.http.delete(this.getAbsoluteUrl(url), body, {
  //       headers: this.addTokenToHeader()
  //     })
  //   );
  // }

  public path(url: string, body: any): Observable<any> {
    this.beforeSendRequest();
    return this.subscribeForRequest(
      this.http.patch(this.getAbsoluteUrl(url), body, {
        headers: this.addTokenToHeader()
      })
    );
  }
}

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IResponse } from '../../interfaces/IResponse';

@Injectable({
  providedIn: 'root',
})
export class LinkService {
  readonly httpHeader: any = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    withCredentials: true,
  };

  constructor(private http: HttpClient) {}

  getLink(slug: string): Observable<IResponse> {
    return this.http
      .get(`_api/link?slug=${slug}`, this.httpHeader)
      .pipe(map((response: any) => response as IResponse));
  }

  createLink(link: any): Observable<IResponse> {
    return this.http
      .post(`_api/link`, link, this.httpHeader)
      .pipe(map((response: any) => response as IResponse));
  }
}

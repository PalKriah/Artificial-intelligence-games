import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { OnePersonMove } from '../models/OnePersonMove';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OnePersonService {

  baseUrl: string
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl; }

  getSteps(searcher: string): Observable<OnePersonMove[]> {
    return this.http.get<OnePersonMove[]>(this.baseUrl + 'api/OnePerson/' + searcher);
  }
}

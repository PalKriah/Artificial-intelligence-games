import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { TokenColor } from '../models/TokenColor';
import { Point } from '../models/Point';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-type': 'application/json' })
}

@Injectable({
  providedIn: 'root'
})
export class TwoPersonService {

  baseUrl: string
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseUrl = baseUrl; }

  getNextStep(board: TokenColor[][], ai: string): Observable<Point> {
    var body = { "board": board };
    return this.http.post<Point>(this.baseUrl + 'api/TwoPerson/' + ai, body, httpOptions);
  }
}

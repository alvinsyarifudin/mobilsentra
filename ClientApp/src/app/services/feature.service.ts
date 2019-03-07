import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class FeatureService {

  constructor(private http : HttpClient) { }
  getFeatures(){
    return this.http.get("api/getFeatures").pipe(
      map(res => res as any[])
    )
  }
}

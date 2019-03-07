import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { catchError,map } from 'rxjs/operators';
import { Observable,of } from 'rxjs';
@Injectable({
  providedIn: 'root'
})

export class MakeService {

  constructor(
    private http:HttpClient    
  ) { }
  getMakes (){    
    return this.http.get('api/makes')
    .pipe(   
      map(res => res as any[]),
      catchError(this.handleError('getMakes', []))
    );
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {         
      console.error(error); // log to console instead        
      // this.log(`${operation} failed: ${error.message}`);    
      return of(result as T);
    };
  }
}

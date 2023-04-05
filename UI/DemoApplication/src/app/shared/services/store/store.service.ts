import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environment/environment';
import { Store } from 'src/app/models/store';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private http: HttpClient) { }

  getallstoresbycityidasync(cityId: number): Observable<any> {
    return this.http.get(environment.apiurl +'/Store/getallstoresbycityidasync?CityId=' + cityId);
  }

  addstoreasync(store: Store): Observable<any>{
    return this.http.post(environment.apiurl +'/Store/addstoreasync', store);
  }
}

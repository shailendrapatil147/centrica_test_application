import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environment/environment';
import { User, UserRole } from 'src/app/models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getallusersbycityidasync(cityId: number): Observable<any> {
    return this.http.get(environment.apiurl +'/User/getallusersbycityidasync?CityId=' + cityId);
  }

  getallrolesasync(): Observable<any> {
    return this.http.get(environment.apiurl +'/User/getallrolesasync');
  }

  getallusersasync(): Observable<any> {
    return this.http.get(environment.apiurl +'/User/getallusersasync');
  }
  
  adduserasync(user: User): Observable<any>{
    return this.http.post(environment.apiurl +'/User/adduserasync', user);
  }

  adduserroleasync(userrole: UserRole): Observable<any>{
    return this.http.post(environment.apiurl +'/User/adduserroleasync', userrole);
  }
}

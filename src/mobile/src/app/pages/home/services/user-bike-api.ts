import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserBikeApi {
  private bikeApiUrl: string = environment.bikeApi + 'UserBike/';

  constructor(private http: HttpClient) { }

  geBike(): Observable<BikeResource> {
    var url = this.bikeApiUrl;

    return this.http.get<BikeResource>(url);
  }
}

export class BikeResource {
    id: number;
    model: string;
    brand: string;
    friendlyName: string;
    totalDistance: number;
}
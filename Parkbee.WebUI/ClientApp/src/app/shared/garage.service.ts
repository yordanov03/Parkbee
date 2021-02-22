import { Inject, Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Garage } from "../garage/garage.model";

@Injectable({providedIn: 'root'})
export class GarageService{
    @Inject('BASE_URL') baseUrl: string
    garage: any[];
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        // this.getGarage(baseUrl, http)
      }

getGarage(){
   return this.http.get<Garage>("https://localhost:44398/garages");
}
}
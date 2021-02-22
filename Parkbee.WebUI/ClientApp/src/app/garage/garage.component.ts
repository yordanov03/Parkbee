import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Garage } from './garage.model';
import { GarageService } from '../shared/garage.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-garage',
  templateUrl: './garage.component.html',
  styleUrls: ['./garage.component.css']
})
export class GarageComponent implements OnInit {
garage: Garage;
  constructor(public garageService: GarageService, private router: Router){}
  ngOnInit(){
      this.garageService.getGarage().subscribe((result: any) => {
        this.garageService.garage = result;
        this.garage = result;
      }, error => console.error(error));
}

onReload(){
  this.ngOnInit();
}


//   constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//     http.get<Garage>(baseUrl + 'garages').subscribe((result: any) => {
//       this.garage = result;
//       console.log(this.garage)
//     }, error => console.error(error));
//   }
}


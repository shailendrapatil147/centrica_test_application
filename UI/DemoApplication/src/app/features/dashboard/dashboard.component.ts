import { Component, OnInit, ViewChild } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import { MatTable } from '@angular/material/table';
import { City } from 'src/app/models/city';
import { StoreByCity } from 'src/app/models/store';
import { UserByCity } from 'src/app/models/User';
import { CityService } from 'src/app/shared/services/city/city.service';
import { StoreService } from 'src/app/shared/services/store/store.service';
import { UserService } from 'src/app/shared/services/user/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit{
  @ViewChild(MatTable) table: MatTable<UserByCity> | undefined;
  
  cities!: City[];
  userByCity: UserByCity[] = [];
  storeByCity: StoreByCity[] = [];
  cityControl: FormControl = new FormControl();
  form: FormGroup = new FormGroup({city: this.cityControl});
  userTableDisplayedColumns: string[] = ['userId', 'userName', 'cityName', 'roleName'];
  storeTableDisplayedColumns: string[] = ['storeId', 'storeName', 'cityName', 'description'];
  
  constructor(private cityService: CityService, private userService: UserService, private storeService: StoreService){
    this.cityService.getallcityasync().subscribe((cities: City[])=> {
      console.log(cities);
      this.cities = cities;
      this.cityControl = new FormControl(this.cities[0].id);
      new FormGroup({city: this.cityControl});
    });
  }

  ngOnInit(): void {
  }

  onCityChange(value: number){
    this.cityControl.setValue(value);
    this.getUsersByCityId(this.cityControl.value);
  }

  getUsersByCityId(cityId: number){
    this.userService.getallusersbycityidasync(cityId).subscribe((users: UserByCity[])=>{
      this.userByCity = users;
      this.getAllStoresByCityId(cityId);
      this.table?.renderRows();
    });
  }

  getAllStoresByCityId(cityId: number){
    this.storeService.getallstoresbycityidasync(cityId).subscribe((stores: StoreByCity[])=>{
      this.storeByCity = stores;
      //this.table?.renderRows();
    });
  }
}

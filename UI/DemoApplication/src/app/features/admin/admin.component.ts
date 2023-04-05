import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { City } from 'src/app/models/city';
import { Store } from 'src/app/models/store';
import { Role, User } from 'src/app/models/User';
import { CityService } from 'src/app/shared/services/city/city.service';
import { StoreService } from 'src/app/shared/services/store/store.service';
import { UserService } from 'src/app/shared/services/user/user.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  fgAddNewShop!: FormGroup;
  fgAddNewUser!: FormGroup;
  fgAddNewUserRole!: FormGroup;
  submitted = false;
  addNewUserSubmit = false;
  addNewUserRoleSubmit = false;
  cities!: City[];
  users!: User[];
  roles!: Role[];

  get fcAddNewShop() { return this.fgAddNewShop.controls; }
  get fcAddNewUserRole() { return this.fgAddNewUserRole.controls; }
  get fcAddUserShop() { return this.fgAddNewUser.controls; }

  constructor(private cityService: CityService, private userService: UserService, private formBuilder: FormBuilder, private storeService: StoreService){
    this.cityService.getallcityasync().subscribe((cities: City[])=> {
      this.cities = cities;
    });

    this.userService.getallrolesasync().subscribe((roles: Role[])=>{
      this.roles = roles;
    });

    this.userService.getallusersasync().subscribe((users: User[])=>{
      this.users = users;
    });
  }

  ngOnInit() {
      this.fgAddNewShop = this.formBuilder.group({
          cityId: ['', Validators.required],
          name: ['', Validators.required],
          description: ['', Validators.required]
          // dob: ['', [Validators.required, Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/)]],
          // email: ['', [Validators.required, Validators.email]],
          // password: ['', [Validators.required, Validators.minLength(6)]],
          // confirmPassword: ['', Validators.required],
          // acceptTerms: [false, Validators.requiredTrue]
      });

      this.fgAddNewUserRole = this.formBuilder.group({
        cityId: [null, Validators.required],
        userId: [null, Validators.required],
        roleId: [null, Validators.required]
    });

      this.fgAddNewUser = this. formBuilder.group({
          name: ['', Validators.required],
      })
  }
  addStore() {
      this.submitted = true;
      if (this.fgAddNewShop.invalid) {
          return;
      }
      this.storeService.addstoreasync(this.fgAddNewShop.value).subscribe((result: any)=> {
        alert(JSON.stringify(result));
        this.fgAddNewShop.reset();
        this.submitted = false;
        this.fgAddNewShop.clearValidators();
      });
  }

  addUser() {
    this.addNewUserSubmit = true;
    if (this.fgAddNewUser.invalid) {
        return;
    }
    this.userService.adduserasync(this.fgAddNewUser.value).subscribe((result: any)=> {
      alert(JSON.stringify(result));
        this.addNewUserSubmit = false;
        this.fgAddNewUser.reset();
      this.fgAddNewUser.clearValidators();
    });
  }

  addUserRole() {
    this.addNewUserRoleSubmit = true;
    if (this.fgAddNewUserRole.invalid) {
        return;
    }
    this.userService.adduserroleasync(this.fgAddNewUserRole.value).subscribe((result: any)=> {
      alert(JSON.stringify(result));
      this.addNewUserRoleSubmit = false;
      this.fgAddNewUserRole.reset();
      this.fgAddNewUserRole.clearValidators();
    });
}

  onReset() {
      this.submitted = false;
      this.fgAddNewShop.reset();
  }
}

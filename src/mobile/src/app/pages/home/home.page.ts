import { Component, OnInit } from '@angular/core';
import { BikeResource, UserBikeApi } from './services/user-bike-api';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  bike: BikeResource;
  constructor(private userBikeApi: UserBikeApi) { }

  ngOnInit() {
    this.userBikeApi.geBike().subscribe(response => this.bike = response);
  }

}

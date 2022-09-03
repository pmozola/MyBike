import { Component, OnInit } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { AddWishModalComponent } from '../wishlist/add-wish-modal/add-wish-modal.component';
import { BikeResource, UserBikeApi } from './services/user-bike-api';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {

  bike: BikeResource;
  constructor(private userBikeApi: UserBikeApi, private modalCtrl: ModalController) { }

  ngOnInit() {
    this.userBikeApi.geBike().subscribe(response => this.bike = response);
  }

  async addWishClick() {
    console.log('dupa');
    const modal = await this.modalCtrl.create({
      component: AddWishModalComponent,
    });
    modal.present();

  }  
}

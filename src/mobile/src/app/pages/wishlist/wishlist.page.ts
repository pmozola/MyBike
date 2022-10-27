import { Component, OnInit } from '@angular/core';
import { WishApi, WishResponse } from './services/wish-api';
import { switchMap } from "rxjs/operators";
import { ModalController } from '@ionic/angular';
import { AddWishModalComponent } from './add-wish-modal/add-wish-modal.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.page.html',
  styleUrls: ['./wishlist.page.scss'],
})
export class WishlistPage implements OnInit {
  wishes: WishResponse[] = [];
  constructor(private wishApi: WishApi, private modalCtrl: ModalController, private router: Router) { }

  ngOnInit() {
    this.wishApi.getWishList().subscribe(wishesResponse => this.wishes = wishesResponse.wishes)
  }

  deleteWish(id: number) {
    this.wishApi.deleteWish(id).pipe(
      switchMap(_ => this.wishApi.getWishList())
    ).subscribe(wishesResponse => this.wishes = wishesResponse.wishes)
  }

  async addWish() {
    const modal = await this.modalCtrl.create({
      component: AddWishModalComponent,
    });
    modal.onDidDismiss()
      .then(_ => this.wishApi.getWishList().subscribe(wishesResponse => this.wishes = wishesResponse.wishes));

    modal.present();
  }

  navigateToDetail(id: number) {
    console.log("navigate to" + id);
    this.router.navigateByUrl('/wishlist/detail/' + id)
  }

  get categories() {
    return this.wishes.map(x => x.categoryName).filter((v, i, a) => a.indexOf(v) === i);
  }

  getWishForCategory(category: string) {
    return this.wishes.filter(wish => wish.categoryName == category);
  }
}

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { WishlistDetailPageRoutingModule } from './wishlist-detail-routing.module';

import { WishlistDetailPage } from './wishlist-detail.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    WishlistDetailPageRoutingModule
  ],
  declarations: [WishlistDetailPage]
})
export class WishlistDetailPageModule {}

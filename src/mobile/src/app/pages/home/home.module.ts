import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { HomePageRoutingModule } from './home-routing.module';

import { HomePage } from './home.page';
import { AddWishModalComponent } from '../wishlist/add-wish-modal/add-wish-modal.component';
import { AddUserCategoryModalComponent } from '../wishlist/add-user-category-modal/add-user-category-modal.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [
    HomePage,
    AddWishModalComponent,
    AddUserCategoryModalComponent]
})
export class HomePageModule { }

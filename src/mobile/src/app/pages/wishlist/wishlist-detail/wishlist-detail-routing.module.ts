import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WishlistDetailPage } from './wishlist-detail.page';

const routes: Routes = [
  {
    path: ':id',
    component: WishlistDetailPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WishlistDetailPageRoutingModule {}

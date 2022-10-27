import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WishlistPage } from './wishlist.page';

const routes: Routes = [
  {
    path: '',
    component: WishlistPage
  },
  {
    path: 'detail',
    loadChildren: () => import('./wishlist-detail/wishlist-detail.module').then( m => m.WishlistDetailPageModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WishlistPageRoutingModule {}

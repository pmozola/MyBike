import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { WishApi, WishResponse } from '../services/wish-api';

@Component({
  selector: 'app-wishlist-detail',
  templateUrl: './wishlist-detail.page.html',
  styleUrls: ['./wishlist-detail.page.scss'],
})
export class WishlistDetailPage implements OnInit {
  wish: WishResponse = {} as WishResponse;
  constructor(private route: ActivatedRoute, private wishApi: WishApi) { }

  ngOnInit() {
    this.wishApi
      .getWish(+ this.route.snapshot.paramMap.get('id'))
      .subscribe((wishResponse: WishResponse) => this.wish = wishResponse);
  }
}

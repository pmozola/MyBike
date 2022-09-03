import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  public appPages = [
    { title: 'Home', url: '/home', icon: 'home' },
    { title: 'Wishlist', url: '/wishlist', icon: 'star' },
    { title: 'TODO', url: '/folder/Outbox', icon: 'paper-plane' },
    { title: 'TODO', url: '/folder/Favorites', icon: 'heart' },
    { title: 'TODO', url: '/folder/Archived', icon: 'archive' },
    { title: 'TODO', url: '/folder/Trash', icon: 'trash' },
    { title: 'TODO', url: '/folder/Spam', icon: 'warning' },
  ];
  public labels = ['Family', 'Friends', 'Notes', 'Work', 'Travel', 'Reminders'];
  constructor() {}
}

import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-add-wish-modal',
  templateUrl: './add-wish-modal.component.html',
  styleUrls: ['./add-wish-modal.component.scss'],
})
export class AddWishModalComponent {
  name: string;

  constructor(private modalCtrl: ModalController) {}

  cancel() {
    return this.modalCtrl.dismiss(null, 'cancel');
  }

  confirm() {
    return this.modalCtrl.dismiss(this.name, 'confirm');
  }
}
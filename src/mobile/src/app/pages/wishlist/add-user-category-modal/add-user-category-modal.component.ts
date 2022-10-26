import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { Category } from '../add-wish-modal/add-wish-modal.component';
import { AddUserCategoryRequest, WishUserCategoryApi } from '../services/wish-user-category-api';

@Component({
  selector: 'app-add-user-category-modal',
  templateUrl: './add-user-category-modal.component.html',
  styleUrls: ['./add-user-category-modal.component.scss'],
})
export class AddUserCategoryModalComponent implements OnInit {

  constructor(
    private modalCtrl: ModalController,
    private userCategoryApi: WishUserCategoryApi,
    private fb: FormBuilder) { }


  ngOnInit(): void {
  }

  add() {
    let requestBody = { name: this.userCategoryForm.controls['name'].value, categoryId: this.category.id } as AddUserCategoryRequest;
    this.userCategoryApi.addUserCategory(requestBody).subscribe(result => this.modalCtrl.dismiss());
  }

  cancel() {
    return this.modalCtrl.dismiss(null, 'cancel');
  }

  userCategoryForm = this.fb.group({ name: [''] });
  category: Category;
}

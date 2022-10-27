import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ModalController } from '@ionic/angular';
import { AddUserCategoryModalComponent } from '../add-user-category-modal/add-user-category-modal.component';
import { UserCategoryResult, WishUserCategoryApi } from '../services/wish-user-category-api';
import { AddWishRequest, WishApi } from '../services/wish-api';

@Component({
  selector: 'app-add-wish-modal',
  templateUrl: './add-wish-modal.component.html',
  styleUrls: ['./add-wish-modal.component.scss'],
})
export class AddWishModalComponent implements OnInit {
  name: string;
  userCategories: UserCategoryResult[] = [];
  userCategoriesForCategory: UserCategoryResult[] = [];
  isCategorySelected: boolean = false;
  wishForm = this.fb.group({
    name: [''],
    url: [''],
    categoryId: [''],
    userCategoryId: [''],
    description: [''],
  });

  constructor(private modalCtrl: ModalController, private userCategoryApi: WishUserCategoryApi, private wishApi: WishApi, private fb: FormBuilder) { }
  ngOnInit(): void {
    this.userCategoryApi.getUserCategory().subscribe(categoriesResponse => this.userCategories = categoriesResponse.categories)
  }

  cancel() {
    return this.modalCtrl.dismiss(null, 'cancel');
  }

  confirm() {
    debugger;
    let requestBody = {
      name: this.wishForm.controls['name'].value,
      url: this.wishForm.controls['url'].value,
      categoryId: +this.wishForm.controls['categoryId'].value,
      userCategoryId: +this.wishForm.controls['userCategoryId'].value,
      description: this.wishForm.controls['description'].value,
    } as AddWishRequest;

    this.wishApi.add(requestBody).subscribe(_ => this.modalCtrl.dismiss());
  }

  onCategoryChange(value: any) {
    this.userCategoriesForCategory = this.userCategories.filter(category => category.categoryId == value.target.value);
    this.isCategorySelected = true;
  }

  async addNewUserCategory() {
    let category = this.getCategories().filter(category => category.id == +this.wishForm.controls.categoryId.value)[0]
    const modal = await this.modalCtrl.create({
      component: AddUserCategoryModalComponent,
      componentProps: {
        category: category
      }
    });
    modal.onDidDismiss().then(_ =>
      this.userCategoryApi.getUserCategory()
        .subscribe(categoriesResponse => {
          this.userCategories = categoriesResponse.categories;
          this.onCategoryChange({
            target: { value: +this.wishForm.controls.categoryId.value }
          });
        }));
    return await modal.present();
  }

  getCategories(): Category[] {
    return [
      { name: 'Bike', id: 1 } as Category,
      { name: 'Bike Parts', id: 2 } as Category,
      { name: 'Clothes', id: 3 } as Category,
      { name: 'Others', id: 4 } as Category,
    ];
  }
}

export interface Category {
  name: string;
  id: number
}
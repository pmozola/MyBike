import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class WishUserCategoryApi {
    private bikeApiUrl: string = environment.bikeApi + 'UserCategory/';

    constructor(private http: HttpClient) { }

    getUserCategory(): Observable<UserCategoryResultResponse> {
        var url = this.bikeApiUrl;

        return this.http.get<UserCategoryResultResponse>(url);
    }

    addUserCategory(UserCategory: AddUserCategoryRequest): Observable<number> {
        return this.http.post<number>(this.bikeApiUrl, UserCategory)
    }
}
export class UserCategoryResultResponse {
    totalResult: number;
    categories: UserCategoryResult[];
}

export class UserCategoryResult {
    id: number;
    name: string;
    categoryId: number;
}

export class AddUserCategoryRequest {
    name: string;
    categoryId: number;
}
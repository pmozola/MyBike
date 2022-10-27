import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class WishApi {
    private bikeApiUrl: string = environment.bikeApi + 'Wish/';

    constructor(private http: HttpClient) { }

    add(request: AddWishRequest): Observable<number> {
        var url = this.bikeApiUrl;

        return this.http.post<number>(url, request);
    }

    getWishList(): Observable<GetWishesResponse> {
        var url = this.bikeApiUrl;

        return this.http.get<GetWishesResponse>(url);
    }
}

export class AddWishRequest {
    name: string;
    url: string;
    categoryId: number;
    userCategoryId: number;
    description: string;
}

export class GetWishesResponse {
    wishes: WishResponse[];
    totalResult: number;
}

export class WishResponse {
    id: number;
    name: string;
    description: string;
    url: string;
    categoryName: string;
    UserCategoryName: string;
}
import { Injectable } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Category } from '../models/category.model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { UpdateCategoryRequest } from '../models/update-category-request.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }

  addCategory(model: AddCategoryRequest):Observable<void>
  {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/categories`, model);
  }
  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${ environment.apiBaseUrl }/api/categories`);
  }
  getCategoryById(id: string): Observable<Category> {
    return this.http.get<Category>(`${environment.apiBaseUrl}/api/categories/${id}`);
  }

  updateCategory(id: string, updatecategoryrequest: UpdateCategoryRequest): Observable<Category> {
    return this.http.put<Category>(`${environment.apiBaseUrl}/api/Categories/UpdateCategory/${id}`, updatecategoryrequest);
  }

  deleteCategory(id: string): Observable<Category> {
    return this.http.delete<Category>(`${environment.apiBaseUrl}/api/Categories/${id}`);
  }
}

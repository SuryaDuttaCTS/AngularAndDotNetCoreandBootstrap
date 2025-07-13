import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { Category } from '../models/category.model';
import { UpdateCategoryRequest } from '../models/update-category-request.model';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit,OnDestroy {

  id: string | null = null;

  paramssub?: Subscription;

  editcategory?: Subscription;

  deletecategory?: Subscription;

  category?: Category;
  constructor(private route: ActivatedRoute,
    private categoryservice: CategoryService,
    private router: Router
  )
  {

  }
   
    ngOnInit(): void {
      this.paramssub =this.route.paramMap.subscribe({
        next: (params) => {
          this.id = params.get('id');

          if (this.id) {
            this.categoryservice.getCategoryById(this.id)
              .subscribe({
                next: (response) => {
                  this.category = response;
                }
              })
          }
        }
      });
    }
  onFormsubmit(): void {

    /*update category request*/
    const updatecategoryrequest: UpdateCategoryRequest = {
      name: this.category?.name ?? '',
      urlHandle: this.category?.urlHandle ?? '',
    };

    if (this.id) {
      this.editcategory = this.categoryservice.updateCategory(this.id, updatecategoryrequest)
        .subscribe({
          next: (response) => {
            console.log("Update successful:", response);
            this.router.navigateByUrl('/admin/categories');
          }
        });
    }


  }


  ngOnDestroy(): void {
    this.paramssub?.unsubscribe();
    this.editcategory?.unsubscribe();
    this.deletecategory?.unsubscribe();
  }

  onDelete(): void {
    if (this.id) {
      this.deletecategory =this.categoryservice.deleteCategory(this.id)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('/admin/categories');
          }
        });
    }
  }
}

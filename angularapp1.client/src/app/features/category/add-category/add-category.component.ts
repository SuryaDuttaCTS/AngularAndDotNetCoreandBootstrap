import { Component, OnDestroy } from '@angular/core';


@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnDestroy{

  model: AddCategoryRequest;
  private addCategorySubscription?: Subscription;

  constructor(private categoryservice: CategoryService,
    private router:Router
  ) {
    this.model = {
      Name:'',
      UrlHandle:''
    }

  }
    

  onFormSubmit() {
    console.log(this.model);
    this.addCategorySubscription =this.categoryservice.addCategory(this.model)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/categories');
         
        },
        error: (error) => {
        }
      })

   
  }
  ngOnDestroy(): void {
    this.addCategorySubscription?.unsubscribe();
  }

}
import { AddCategoryRequest } from '../models/add-category-request.model';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

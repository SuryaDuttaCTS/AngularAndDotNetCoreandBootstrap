import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post.model';
import { BlogPostService } from '../services/blog-post.service';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { ImageService } from '../../../shared/components/image-selector/image.service';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnInit,OnDestroy{

  model: AddBlogPost;

  blogpostservice?: Subscription;

  Categories$?: Observable<Category[]>;

  imageselector?: Subscription;

  isimageselectorvisible: boolean = false;
  
  constructor(private blogPostService: BlogPostService,
    private router: Router,
    private categoryservice: CategoryService,
    private imageservice: ImageService
  ) {
    this.model = {
      title:'',
      shortDescription:'',
      urlHandle:'',
      content:'',
      featuredImageUrl:'',
      author:'',
      isVisible:true,
      dateCreated: new Date(),
      categories:[]
    }  
  }
    ngOnInit(): void {
      this.Categories$ = this.categoryservice.getAllCategories();
      this.imageselector= this.imageservice.onSelectImage().subscribe({
        next: (selectedImage) => {
          this.model.featuredImageUrl = selectedImage.url;
          this.closeImageselector();
        }
      })
    }

  openImageSelector(): void {
    this.isimageselectorvisible = true;
  }

  closeImageselector(): void {
    this.isimageselectorvisible = false;
  }

  onFormSubmit(): void {
    console.log(this.model);
    this.blogpostservice=this.blogPostService.createBlogPost(this.model).subscribe({
      next: (response) => {
        this.router.navigateByUrl('admin/blogposts');
      }
    });
  }
  ngOnDestroy(): void {
    this.blogpostservice?.unsubscribe();
    this.imageselector?.unsubscribe();
  }
}

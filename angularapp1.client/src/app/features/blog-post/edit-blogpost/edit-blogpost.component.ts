import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { BlogPostService } from '../services/blog-post.service';
import { BlogPost } from '../models/blog-post.model';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { UpdateBlogPost } from '../models/update-blog-post.model';
import { ImageService } from '../../../shared/components/image-selector/image.service';

@Component({
  selector: 'app-edit-blogpost',
  templateUrl: './edit-blogpost.component.html',
  styleUrls: ['./edit-blogpost.component.css']
})
export class EditBlogpostComponent implements OnInit,OnDestroy{

  id: string | null = null;
  routeSubscription?: Subscription;
  model?: BlogPost;
  categories$?: Observable<Category[]>;
  selectedCategories?: string[];
  isimageselectorvisible: boolean = false;

  updatebloggpostsubscription?: Subscription;
  getBlogpostSubscription?: Subscription;
  deleteBlogPostSubscription?: Subscription;
  imageUploadSubscription?: Subscription;

  constructor(private route: ActivatedRoute,
    private blogpostservice: BlogPostService,
    private categoryservice: CategoryService,
    private router: Router,
    private imageservice: ImageService
    )
  {

  }

  onFormSubmit(): void {
    //Convert the model into request object
    if (this.model && this.id) {
      var updateBlogPost: UpdateBlogPost = {
        author: this.model.author,
        content: this.model.content,
        shortDescription: this.model.shortDescription,
        title: this.model.title,
        featuredImageUrl: this.model.featuredImageUrl,
        urlHandle: this.model.urlHandle,
        dateCreated: this.model.dateCreated,
        isVisible: this.model.isVisible,
        categories: this.selectedCategories ?? []
      };

      this.updatebloggpostsubscription=this.blogpostservice.updateblogPost(this.id, updateBlogPost)
        .subscribe({
          next: (response) => {

            this.router.navigateByUrl('/admin/blogposts');
          }
        });

    }
  }

  ngOnInit(): void {

    this.categories$=this.categoryservice.getAllCategories();
    
    this.routeSubscription=this.route.paramMap.subscribe(
      {

        next: (params) => {
          this.id = params.get('id');
          console.log(this.id);

          if (this.id) {
            this.getBlogpostSubscription= this.blogpostservice.getblogPostById(this.id).
              subscribe({
                next: (response) => {
                  this.model = response;
                  this.selectedCategories = response.categories.map(x=>x.id);
                }
              });
            ;
          }
          //get blog post from api
          this.imageUploadSubscription=this.imageservice.onSelectImage().subscribe({
            next: (image) => {
              if (this.model) {
                this.model.featuredImageUrl = image.url;
                this.isimageselectorvisible = false;
              }
            }
          })

        }
      }
    );
 }

  onDelete(): void {
    if (this.id) {
      this.deleteBlogPostSubscription= this.blogpostservice.deleteblogPost(this.id)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('/admin/blogposts');
          }
        });
    }
  }

  openImageSelector(): void {
    this.isimageselectorvisible = true;
  }

  closeImageselector(): void{
  this.isimageselectorvisible = false;
  }

  ngOnDestroy(): void {
    this.routeSubscription?.unsubscribe();
    this.updatebloggpostsubscription?.unsubscribe();
    this.getBlogpostSubscription?.unsubscribe();
    this.deleteBlogPostSubscription?.unsubscribe();
    this.imageUploadSubscription?.unsubscribe();
  }

}

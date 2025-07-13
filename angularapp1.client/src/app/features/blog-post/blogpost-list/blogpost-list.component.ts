import { Component, OnDestroy, OnInit } from '@angular/core';
import { BlogPostService } from '../services/blog-post.service';
import { Observable, Subscription } from 'rxjs';
import { BlogPost } from '../models/blog-post.model';

@Component({
  selector: 'app-blogpost-list',
  templateUrl: './blogpost-list.component.html',
  styleUrls: ['./blogpost-list.component.css']
})
export class BlogpostListComponent implements OnInit{

  blogpost$?: Observable<BlogPost[]>;

  constructor(private blogpostservice: BlogPostService) {

  }
   

  ngOnInit(): void {
    this.blogpost$= this.blogpostservice.getAllBlogPost();
  
  }
  
}

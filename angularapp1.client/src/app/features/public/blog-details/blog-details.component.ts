import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BlogPostService } from '../../blog-post/services/blog-post.service';
import { Observable } from 'rxjs';
import { BlogPost } from '../../blog-post/models/blog-post.model';
@Component({
  selector: 'app-blog-details',
  templateUrl: './blog-details.component.html',
  styleUrls: ['./blog-details.component.css']
})
export class BlogDetailsComponent implements OnInit {

  url: string | null = null;
  BlogpostDetails$?: Observable<BlogPost>;

  constructor(private activatedRoute: ActivatedRoute,
    private blogpostservice : BlogPostService
  ) { }


  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        this.url=params.get('url');
      }
    })
    //fetch blog details by URL
    if (this.url) {
      this.BlogpostDetails$=this.blogpostservice.getBlogPostByUrlHandle(this.url);
    }
    }

}

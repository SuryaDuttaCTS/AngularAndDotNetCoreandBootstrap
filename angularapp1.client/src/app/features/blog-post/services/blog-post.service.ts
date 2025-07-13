import { Injectable, OnDestroy } from '@angular/core';
import { Observable } from 'rxjs';
import { AddBlogPost } from '../models/add-blog-post.model'; // Adjust the import path as necessary
import { BlogPost } from '../models/blog-post.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { UpdateBlogPost } from '../models/update-blog-post.model';

@Injectable({
  providedIn: 'root'
})
export class BlogPostService{

  constructor(private http:HttpClient) { }

  createBlogPost(data: AddBlogPost): Observable<BlogPost> {
    return this.http.post<BlogPost>(`${environment.apiBaseUrl}/api/blogposts`, data);
  }

  getAllBlogPost(): Observable<BlogPost[]> {
    return this.http.get<BlogPost[]>(`${environment.apiBaseUrl}/api/BlogPosts`);
  }

  getblogPostById(id: string): Observable<BlogPost> {
    return this.http.get<BlogPost>(`${environment.apiBaseUrl}/api/BlogPosts/${id}`);
  }

  updateblogPost(id: string, updateblogpost: UpdateBlogPost): Observable<BlogPost> {
    return this.http.put<BlogPost>(`${environment.apiBaseUrl}/api/BlogPosts/${id}`, updateblogpost);
  }

  deleteblogPost(id: string): Observable<BlogPost> {
    return this.http.delete<BlogPost>(`${environment.apiBaseUrl}/api/BlogPosts/${id}`);
  }

  getBlogPostByUrlHandle(urlHandle: string): Observable<BlogPost> {
    return this.http.get<BlogPost>(`${environment.apiBaseUrl}/api/BlogPosts/${urlHandle}`);
  }
}

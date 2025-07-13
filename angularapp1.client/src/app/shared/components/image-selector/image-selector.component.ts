import { Component, OnInit, ViewChild } from '@angular/core';
import { ImageService } from './image.service';
import { Observable } from 'rxjs';
import { BlogImage } from '../../models/blog-image.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-image-selector',
  templateUrl: './image-selector.component.html',
  styleUrls: ['./image-selector.component.css']
})
export class ImageSelectorComponent implements OnInit {

   file?: File;
   fileName: string = '';
  title: string = '';
  images$?: Observable<BlogImage[]>;

  @ViewChild('form', { static: false }) imageUploadForm?: NgForm;
  constructor(private imageservice:ImageService) { }
    ngOnInit(): void {
      this.getImages();
    }

  onFileUploadchange(event: Event): void
  {
    const element = event.currentTarget as HTMLInputElement;
    this.file = element.files?.[0];

  }

  selectImages(image:BlogImage): void {
    this.imageservice.selectImage(image);
  }

  UploadImage(): void {
    console.log(this.fileName+this.title+this.file);
    if (this.file && this.fileName !== '' && this.title !=='') {  
      //Use the service to upload the image
      this.imageservice.uploadImage(this.file, this.fileName, this.title).subscribe({
        next: (response) => {
          this.imageUploadForm?.resetForm();
          this.getImages();
          // Optionally reset the form or provide feedback to the user
          
        }
      });

    }
  }

  private getImages() {
    this.images$ = this.imageservice.GetallImages();
  }
}

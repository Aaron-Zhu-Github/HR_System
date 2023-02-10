import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Input, ViewChild } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css']
})
export class FileUploadComponent {
  @Input() title: string = '';

  constructor(private http: HttpClient) { }
  private selectedFile!: File;

  onFileChange(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files) {
      this.selectedFile = input.files[0];
      console.log(this.selectedFile);
    }
  }

  onClick() {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append("file", this.selectedFile, Date.now().toString() + this.selectedFile.name);
      formData.append("title", this.title);
      this.http.post(environment.API_URL + "api/file/upload", formData)
        .subscribe(
          response => {
            console.log(response);
            alert("file uploaded");
            (document.querySelector("input[type='file']") as HTMLInputElement).value = "";
          },
          (err)=>{
            alert(err.error.message)
          }
        );
    }
  }
}

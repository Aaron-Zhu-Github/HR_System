import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { faFile, faImage, faFilePdf } from '@fortawesome/free-regular-svg-icons';


@Component({
  selector: 'app-file-download',
  templateUrl: './file-download.component.html',
  styleUrls: ['./file-download.component.css']
})
export class FileDownloadComponent {
  constructor(private http: HttpClient, library: FaIconLibrary) {
    library.addIcons(faImage, faFile, faFilePdf);
  }
  files!: Observable<filesResponse[]>;
  fileUrl: string = environment.FileURL


  ngOnInit() {
    this.files = this.http.get<filesResponse[]>(environment.API_URL + "api/file/GetAll");
    this.files.subscribe(
      (res) => {
        // console.log("Response from API", res);
        res.forEach(res => {
          res.fileExtension = this.getFileExtension(res.path);
          // console.log("File extension", res.fileExtension);
        }
        )
      },
      error => {
        console.error("Error while fetching files", error);
      }
    );
  }

  getFileExtension(filename: string) {
    return filename.substr(filename.lastIndexOf('.') + 1);
  }
}

interface filesResponse {
  path: string;
  title: string;
  fileExtension: string;
}

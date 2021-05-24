import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-album-photos',
  templateUrl: './album-photos.component.html',
  styleUrls: ['./album-photos.component.css']
})
export class AlbumPhotosComponent implements OnInit {

  public photos?: Photo[];
  public albumId: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    this.getAlbum();

    http.get<Photo[]>(baseUrl + 'photos/album/' + this.albumId).subscribe(result => {
      this.photos = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

  getAlbum(): void {
    this.albumId = Number(this.route.snapshot.paramMap.get('id'));
  }
}

interface Photo {
  id: number;
  title: string;
  url: string;
}

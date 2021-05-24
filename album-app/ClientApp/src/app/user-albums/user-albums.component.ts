import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-albums',
  templateUrl: './user-albums.component.html',
  styleUrls: ['./user-albums.component.css']
})
export class UserAlbumsComponent implements OnInit {

  public albums?: Album[];
  public userId: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
    this.getUser();

    http.get<Album[]>(baseUrl + 'albums/user/' + this.userId).subscribe(result => { //this is not dynamic yet
      this.albums = result;
    }, error=> console.error(error));
  }


  ngOnInit(): void {

  }

  getUser(): void {
    this.userId = Number(this.route.snapshot.paramMap.get('id'));
  }



}

interface Album {
  id: number;
  title: string;
}


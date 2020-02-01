import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css']
})
export class FavoriteComponent implements OnInit {
  favorite[]:[];
  
    constructor(private httpClient: HttpClient) { }
  
 public getFavorite(){
   
    return this.httpClient.get('https://localhost:44340/api/Favorite');
  }
  deleteFavorite(id)
  {
    const url='https://localhost:44340/api/Favorite?id='+id
    return this.httpClient.delete(url).subscribe((data)=>
    {
      console.log(data)
      alert(data)
    }, (error) => {
      alert(error.error);
  });
  }
  ngOnInit() {
   let o=this.getFavorite().subscribe((data)=>
   {
    this.favorite=data
   }
   )
   
    /*this.favorite=[
  {

    "Id": "215854",
    "Name": "Tel Aviv",
  },
  {
    "Id": "3431644",
    "Name": "Telanaipura",

  },
  {
    "Id": "300558",
    "Name": "Telok Blangah New Town",

  },
  {
    "Id": "325876",
    "Name": "Telford",

  },
  {
    "Id": "169072",
    "Name": "Telavi",
  },

]*/
  }

}

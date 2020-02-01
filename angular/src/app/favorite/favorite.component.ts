import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConstantsService } from '../../app/common/services/constants.service'

@Component({
  selector: 'app-favorite',
  templateUrl: './favorite.component.html',
  styleUrls: ['./favorite.component.css']
})
export class FavoriteComponent implements OnInit {
  favorite[]:[];
  
    constructor(private httpClient: HttpClient,private constantService:ConstantsService) { }
  
 public getFavorite(){
   
    return this.httpClient.get(this.constantService.baseAppUrl+ '/Favorite');
  }
  deleteFavorite(id)
  {
    const url=this.constantService.baseAppUrl+ '/Favorite?id='+id
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
   
    
  }

}

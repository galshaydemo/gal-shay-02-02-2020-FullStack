import { Component, OnInit } from '@angular/core';
import { } from '@angular/router'
import { City,CityAuto,Weather } from './city';
import { HttpClient } from '@angular/common/http';
@Component({
  
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {

  data: CityAuto[] = [];
  favorite[]:[];
  demo: string[] = ["AAA","BBB"]
  cityKey = "";
  cityName = "aaa";
  temp=20.0;
  desc='nice sunny day'

  constructor(private httpClient: HttpClient) { }
public getFavorite(){
   
    return this.httpClient.get('https://localhost:44340/api/Favorite');
  }
  ngOnInit() {
    
    let o=this.getFavorite().subscribe((data)=>
   {
    this.favorite=data
   }
   )
  }
  onItemChange(item) {
    this.cityName = this.data[item.selectedIndex].LocalizedName
    this.cityKey = item.value;
  }
  getWeather(code,name)
  {
    
    if ( code == undefined ) code=this.cityKey;
    if ( name == undefined ) name=this.cityName;
    this.cityName=name;
    this.cityKey=code;
    if ( code == "") 
    {
      alert('Choose City')
      return
    }
    const url='https://localhost:44340/api/Weather/GetCurrentWeather?city='+code;
    this.httpClient.get<Weather>(url).subscribe((data)=>
    {
      this.desc=data.WeatherText;
      this.temp=data.Temp;
      this.cityName=name
      console.log(data)
    }, (error) => {
      console.log(error.status)});
  }
  addFavorite()
  {
    
    const url='https://localhost:44340/api/Favorite'
    const data={Name:this.cityName,Code:this.cityKey}
    this.httpClient.post(url,data).subscribe((data)=>
    {
      console.log(data)
    }, (error) => {
      console.log(error.status)});
  }
  getCityStartWith(str:string) {
    this.httpClient.get<CityAuto[]>('https://localhost:44340/api/Weather/Search?q='+str).subscribe((data)=>
    {
      
      this.data=data
    });
    
  }
}

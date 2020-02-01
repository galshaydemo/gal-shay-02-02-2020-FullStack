export class City {
  id: string;
  name: string;
  code:string
}
export class CityAuto {
  
  LocalizedName: string;
  Key:string
}
export class Weather
{
  Id: number;
  WeatherText:string;
  Temp: number;
  CityCode: string;
  lastCall: string
}
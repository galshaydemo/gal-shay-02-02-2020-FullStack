import { Routes } from '@angular/router';
import { FavoriteComponent } from './favorite/favorite.component';
import { WeatherComponent } from './weather/weather.component';


const appRoutes: Routes = [
  { path: '', 
    component: WeatherComponent 
  },
  { path: 'favorite',
    component: FavoriteComponent
  }
];
export default appRoutes;
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FavoriteComponent} from './favorite/favorite.component'
import { WeatherComponent} from './weather/weather.component'
const routes: Routes = [{ path: '', 
    component: WeatherComponent 
  },
  { path: 'favorite',
    component: FavoriteComponent
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

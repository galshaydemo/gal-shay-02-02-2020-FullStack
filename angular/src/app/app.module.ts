import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { WeatherComponent } from "./weather/weather.component";
import { FavoriteComponent } from "./favorite/favorite.component";
import { ConstantsService } from './common/services/constants.service';

import appRoutes from "./routerConfig";
@NgModule({
  declarations: [AppComponent, WeatherComponent, FavoriteComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule
  ],
  providers: [ConstantsService],
  bootstrap: [AppComponent]
})
export class AppModule {}

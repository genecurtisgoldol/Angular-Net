import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppCustomPreloader } from '@shared/index';

const routes: Routes = [
  {
    path: "",
    redirectTo: "home",
    pathMatch: "full"
  },
  { path: 'home',
 loadChildren: () => import('../features/home/home.module').then(m => m.HomeModule),
 data: {preload: true} },
  {
    path: "**",
    redirectTo: "home"
  }

];

@NgModule({
  imports: [RouterModule.forRoot(
      routes, {
      scrollPositionRestoration: "enabled",
      preloadingStrategy: AppCustomPreloader
    })
  ],
  exports: [RouterModule],
  providers: [AppCustomPreloader] 
})
export class AppRoutingModule { }

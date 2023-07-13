import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { FindVehicleFormComponent } from './find-vehicle-form/find-vehicle-form.component';
import { AdditionalDetailsComponent } from './additional-details/additional-details.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'find-vehicle', component: FindVehicleFormComponent },
  { path: 'additional-details', component: AdditionalDetailsComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    FindVehicleFormComponent,
    AdditionalDetailsComponent,
  ],
  imports: [BrowserModule, HttpClientModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; // Import FormsModule

import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { FindVehicleFormComponent } from './find-vehicle-form/find-vehicle-form.component';
import { AdditionalDetailsComponent } from './additional-details/additional-details.component';
import { ResultsComponent } from './results/results.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'find-vehicle', component: FindVehicleFormComponent },
  { path: 'additional-details', component: AdditionalDetailsComponent },
  { path: 'results', component: ResultsComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    FindVehicleFormComponent,
    AdditionalDetailsComponent,
    ResultsComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule],

  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { VisaStatusManagementComponent } from './visa-status-management/visa-status-management.component';
import { PersonInfoComponent } from './person-info/person-info.component';
import { NameSecComponent } from './person-info/name-sec/name-sec.component';
import { AddressSecComponent } from './person-info/address-sec/address-sec.component';
import { ContactSecComponent } from './person-info/contact-sec/contact-sec.component';
import { EmploymentSecComponent } from './person-info/employment-sec/employment-sec.component';
import { OnBoardingInsertFormComponent } from './on-boarding-insert-form/on-boarding-insert-form.component';
import { JwtInterceptor } from './jwt.interceptor';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonInfoComponent,
    NameSecComponent,
    AddressSecComponent,
    ContactSecComponent,
    EmploymentSecComponent,
    OnBoardingInsertFormComponent,
    LoginComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      {path: 'VisaStatus', component: VisaStatusManagementComponent},
      {path: 'PersonalInformation', component: PersonInfoComponent},
      { path: 'OnBoarding', component: OnBoardingInsertFormComponent},
    ])
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

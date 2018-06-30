import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AppComponent} from './app.component';
import {ApiModule} from "./api/api.module";
import {CollapseModule} from "ngx-bootstrap";
import {SubjectPanelComponent} from './subject-panel/subject-panel.component';
import {RouterModule, Routes} from "@angular/router";
import {LearningProgramComponent} from './learning-program/learning-program.component';
import {CreateLearningProgramComponent} from './create-learning-program/create-learning-program.component';
import {LoginComponent} from './login/login.component';
import {LocationStrategy, HashLocationStrategy} from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthorizationInterceptor } from './api/authorizationInterceptor';

const appRoutes: Routes = [
  {path: '', redirectTo: '/assign-lecturer', pathMatch: 'full'},
  {path: 'assign-lecturer', component: SubjectPanelComponent},
  {path: 'create-program', component: CreateLearningProgramComponent},
  {path: 'learning-program', component: LearningProgramComponent},
  {path: 'login', component: LoginComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    SubjectPanelComponent,
    LearningProgramComponent,
    CreateLearningProgramComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ApiModule,
    CollapseModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule  
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: HashLocationStrategy
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizationInterceptor,
      multi: true
}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

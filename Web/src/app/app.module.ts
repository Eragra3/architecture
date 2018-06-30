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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

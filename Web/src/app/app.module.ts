import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {AppComponent} from './app.component';
import {ApiModule} from "./api/api.module";
import {CollapseModule} from "ngx-bootstrap";
import {SubjectPanelComponent} from './subject-panel/subject-panel.component';
import {RouterModule, Routes} from "@angular/router";


const appRoutes: Routes = [
  {path: '', redirectTo: '/subjects', pathMatch: 'full'},
  {path: 'subjects', component: SubjectPanelComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    SubjectPanelComponent
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

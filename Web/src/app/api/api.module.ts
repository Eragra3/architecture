import {NgModule} from "@angular/core";
import {HttpClientModule} from "@angular/common/http";
import {LecturerService} from "./lecturer.service";
import {SubjectService} from "./subject.service";

@NgModule({
  declarations: [],
  imports: [
    HttpClientModule
  ],
  providers: [LecturerService, SubjectService],
  bootstrap: []
})
export class ApiModule {
}

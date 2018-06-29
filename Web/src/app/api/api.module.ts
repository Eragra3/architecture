import {NgModule} from "@angular/core";
import {HttpClientModule} from "@angular/common/http";
import {LecturerService} from "./lecturer.service";
import {SubjectService} from "./subject.service";
import {LearningProgramService} from "./learning-program.service";

@NgModule({
  declarations: [],
  imports: [
    HttpClientModule
  ],
  providers: [LecturerService, SubjectService, LearningProgramService],
  bootstrap: []
})
export class ApiModule {
}

import {Component, OnInit} from '@angular/core';
import {LearningProgram, LearningProgramService, Level, Mode} from "../api/learning-program.service";

@Component({
  selector: 'app-create-learning-program',
  templateUrl: './create-learning-program.component.html',
  styleUrls: ['./create-learning-program.component.css']
})
export class CreateLearningProgramComponent implements OnInit {

  levels = this.service.getEnumValues(Level);
  modes = this.service.getEnumValues(Mode);

  constructor(private service: LearningProgramService) {
  }

  ngOnInit() {

  }

  submit(value) {
    this.service
      .create(new LearningProgram(undefined, value.name, value.specialization, value.numberOfSemesters, value.level, value.mode, [], value.cnps))
  }

}

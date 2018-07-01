import {Component, OnInit} from '@angular/core';
import {LearningProgram, LearningProgramService, Level, Mode} from "../api/learning-program.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-learning-program',
  templateUrl: './create-learning-program.component.html',
  styleUrls: ['./create-learning-program.component.css']
})
export class CreateLearningProgramComponent implements OnInit {

  levels = this.service.getEnumValues(Level);
  modes = this.service.getEnumValues(Mode);

  showError = false;

  constructor(private service: LearningProgramService, private router: Router) {
  }

  ngOnInit() {

  }

  submit(value) {
    this.showError = false;
    this.service
      .create(new LearningProgram(0, value.name, value.specialization, value.numberOfSemesters, value.level, value.mode, [], value.cnps))
      .subscribe((learningProgram) => {
        if (learningProgram != null) {
          this.router.navigateByUrl('learning-program')
        } else {
          this.showError = true;
        }
      })
  }

}

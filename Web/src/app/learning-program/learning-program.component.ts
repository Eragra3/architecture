import {Component, OnInit} from '@angular/core';
import {LearningProgram, LearningProgramService} from "../api/learning-program.service";

@Component({
  selector: 'app-learning-program',
  templateUrl: './learning-program.component.html',
  styleUrls: ['./learning-program.component.css']
})
export class LearningProgramComponent implements OnInit {

  programs: LearningProgram[] = [];

  constructor(private service: LearningProgramService) {
  }

  ngOnInit() {
    this.service.getList().subscribe(p => this.programs = p)
  }

}

import {Component, OnInit} from '@angular/core';
import {Lecturer, LecturerService} from "../api/lecturer.service";
import {Subject, SubjectService} from "../api/subject.service";
import {FormBuilder, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-subject-panel',
  templateUrl: './subject-panel.component.html',
  styleUrls: ['./subject-panel.component.css']
})
export class SubjectPanelComponent implements OnInit {

  subjects: Subject[];
  lecturers: Lecturer[];
  form: FormGroup;

  constructor(private lecturerService: LecturerService, private subjectService: SubjectService, private fb: FormBuilder) {
  }

  ngOnInit() {
    this.subjectService.getList().subscribe((list) => {
      this.subjects = list;
      this.prepareForm();
    });
    this.lecturerService.getList().subscribe((list) => {
      this.lecturers = list;
      this.prepareForm();
    });
  }

  prepareForm() {
    if (this.subjects && this.lecturers) {
      this.form = this.fb.group({
        lecturers: this.fb.array(
          this.subjects.map(s => this.fb.control(s.id))
        )
      })
    }
  }

  submit() {
    const lects: number[] = this.form.get('lecturers').value;
    lects.forEach((l, i) =>
      this.subjectService.assignLecturer(this.subjects[i].id, l))
  }

}

import {Component, OnInit} from '@angular/core';
import {ResearchFellow, LecturerService} from "../api/lecturer.service";
import {Subject, SubjectService} from "../api/subject.service";
import {FormBuilder, FormGroup} from "@angular/forms";
import { Observable } from 'rxjs';

@Component({
  selector: 'app-subject-panel',
  templateUrl: './subject-panel.component.html',
  styleUrls: ['./subject-panel.component.css']
})
export class SubjectPanelComponent implements OnInit {

  subjects: Subject[];
  lecturers: ResearchFellow[];
  form: FormGroup;

  showError: boolean = false;
  showSuccess: boolean = false;

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
          this.subjects.map(s => this.fb.control(s.supervisorId))
        )
      })
    }
  }

  submit() {
    this.showError = false;
    this.showSuccess = false;

    const lects: number[] = this.form.get('lecturers').value.map(l => {
      if (l == '' || l == null) {
        return null;
      }
      return l;
    });
    
    var jobs = lects.map((l, i) => this.subjectService.assignLecturer(this.subjects[i].id, l));
    
    Observable.forkJoin(jobs).subscribe(results => {
      this.showSuccess = true;
      this.ngOnInit();
    }, err => {
      this.showError = true;
    });
  }

}

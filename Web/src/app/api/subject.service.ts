import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import 'rxjs/add/observable/of';


@Injectable()
export class SubjectService {

  store: Subject[] = [
    new Subject(0, "Subject", 0)
  ];

  constructor(http: HttpClient) {

  }

  getList(): Observable<Subject[]> {
    return Observable.of(this.store);
  }

  addSubject(subject: Subject): Observable<boolean> {
    this.store.push(subject);
    return Observable.of(true);
  }

  assignLecturer(subjectId: number, lecturer: number): Observable<boolean> {
    this.store.map(sub => sub.id === subjectId ? new Subject(sub.id, sub.name, lecturer) : sub);
    return Observable.of(true);
  }

}


export class Subject {
  constructor(public readonly id: number,
              public readonly name: string,
              public readonly lecturerId: number) {
  }
}

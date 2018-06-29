import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import 'rxjs/add/observable/of';


@Injectable()
export class SubjectService {

  store: Subject[] = [
    new Subject(0, "Subject", 0, [new PEK(0, 'PEK_W01'), new PEK(1, 'PEK_L01')]),
    new Subject(1, "Subject1", 1, [new PEK(2, 'PEK_W01'), new PEK(3, 'PEK_L01')]),
    new Subject(2, "Subject2", 2, [new PEK(4, 'PEK_W01')])
  ];

  constructor(http: HttpClient) {

  }

  getList(): Observable<Subject[]> {
    return Observable.of(this.store);
  }

  assignLecturer(subjectId: number, lecturer: number): Observable<boolean> {
    this.store.map(sub => sub.id === subjectId ? new Subject(sub.id, sub.name, lecturer, sub.peks) : sub);
    return Observable.of(true);
  }

}


export class Subject {
  constructor(public readonly id: number,
              public readonly name: string,
              public readonly lecturerId: number,
              public readonly peks: PEK[]) {
  }
}

export class PEK {
  constructor(public readonly id: number,
              public readonly name: string) {
  }
}

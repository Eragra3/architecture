import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import 'rxjs/add/observable/of';
import { environment } from "environments/environment";


@Injectable()
export class SubjectService {

  store: Subject[] = [];

  constructor(private _http: HttpClient) {

  }

  getList(): Observable<Subject[]> {
    return this._http
    .get<Subject[]>(environment.baseUrl + "api/subjects")
    .map(subject => {
      this.store = subject;
      return this.store;
    })
    .catch(err => {
      return Observable.of(null);
    });
  }

  assignLecturer(subjectId: number, lecturer: number | null): Observable<boolean> {
    const lecturerParam = lecturer == null ? 'null' : lecturer;
    return this._http
    .patch<Subject>(environment.baseUrl + `api/subject/${subjectId}/supervisor/${lecturerParam}`,null)
    .map(subject => {
      this.store.map(sub => sub.id === subject.id ? subject : sub);
      return true;
    })
    .catch(err => {
      return Observable.of(false);
    });
  }

}


export class Subject {
  constructor(public readonly id: number,
              public readonly name: string,
              public readonly supervisorId: number,
              public readonly peks: PEK[]) {
  }
}

export class PEK {
  constructor(public readonly id: number,
              public readonly name: string) {
  }
}

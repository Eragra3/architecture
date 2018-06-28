import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import 'rxjs/add/observable/of';


@Injectable()
export class LecturerService {

  store: Lecturer[] = [
    new Lecturer(0, "Kowalski", "Jan"),
    new Lecturer(1, "Kowalski1", "Jan"),
    new Lecturer(2, "Kowalski2", "Jan"),
    new Lecturer(3, "Kowalski3", "Jan"),
    new Lecturer(4, "Kowalski4", "Jan")

  ];

  constructor(http: HttpClient) {

  }

  getList(): Observable<Lecturer[]> {
    return Observable.of(this.store);
  }

  getLecturer(id: number): Observable<Lecturer> {
    return Observable.of(this.store.find(l => l.id === id));
  }

}


export class Lecturer {
  constructor(public readonly id: number,
              public readonly surname: string,
              public readonly name: string) {
  }
}

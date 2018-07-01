import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs/Observable";
import 'rxjs/add/observable/of';
import {environment} from "environments/environment";


@Injectable()
export class LecturerService {

  store: ResearchFellow[] = [];

  constructor(private _http: HttpClient) {

  }

  getList(): Observable<ResearchFellow[]> {
    return this._http
    .get<ResearchFellow[]>(environment.baseUrl + "api/researchFellows")
    .map(researchFellows => {
      this.store = researchFellows;
      return this.store;
    })
    .catch(err => {
      return Observable.of(null);
    });
  }

  getLecturer(id: number): Observable<ResearchFellow> {
    return Observable.of(this.store.find(l => l.id === id));
  }

}

export class ResearchFellow {
  constructor(public readonly id: number,
              public readonly firstName: string,
              public readonly lastName: string,
              public readonly title: string) {
  }
}

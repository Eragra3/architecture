import {Observable} from "rxjs/Observable";
import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";
import { environment } from "environments/environment";

@Injectable()
export class LearningProgramService {

  store: LearningProgram[] = [];

  constructor(private readonly _http: HttpClient) {

  }

  getList(): Observable<LearningProgram[]> {
    return this._http
    .get<LearningProgram[]>(environment.baseUrl + "api/learningPrograms")
    .map(learningPrograms => {
      this.store = learningPrograms;
      return this.store;
    })
    .catch(err => {
      return Observable.of(null);
    });
  }

  create(program: LearningProgram): Observable<boolean> {
    console.log(program);
    this.store.push(program);
    return Observable.of(true);
  }

  getEnumValues(e: any) {
    const keys = Object.keys(e);
    return keys.map(k => e[k]);
  }

}

export class LearningProgram {
  constructor(public readonly id: number,
              public readonly name: string,
              public readonly specialization: string,
              public readonly numberOfSemesters: string,
              public readonly level: Level,
              public readonly mode: Mode,
              public readonly modules: Module[],
              public readonly CNPShours: number) {
  }
}

export class Module {
  constructor(public readonly id: number,
              public readonly name: string) {
  }
}

export enum Mode {
  Stacjonarne = "Stacjonarne", Niestacjonarne = "Niestacjonarne"


}

export enum Level {
  Inzynierske = "Inzynierske", Licencjackie = "Licencjackie", Magisterskie = "Magisterskie"
}

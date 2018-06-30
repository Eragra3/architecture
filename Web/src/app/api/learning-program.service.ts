import {Observable} from "rxjs/Observable";
import {HttpClient} from "@angular/common/http";
import {Injectable} from "@angular/core";

@Injectable()
export class LearningProgramService {

  store: LearningProgram[] = [];

  constructor(http: HttpClient) {

  }

  getList(): Observable<LearningProgram[]> {
    return Observable.of(this.store);
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

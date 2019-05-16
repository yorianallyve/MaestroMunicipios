import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from "@angular/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {

  constructor(private http: Http) { }

  public GetDepartamentoAll() {
    let fullUrl = 'https://localhost:44339/api/v1/Departamentos/GetDepartamentoAll';
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));;
  }

  public SearchDepartamentosbyPaisId(IDDEPART) {
    let fullUrl = "https://localhost:44339/api/v1/Departamentos/SearchDepartamentoByPaisId/" + IDDEPART;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }
}

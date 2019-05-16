import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from "@angular/http";
import { map } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class MunicipioService {

  constructor(private http: Http) { }

  public InsertMunicipio(IMUNI) {
    let fullUrl = "https://localhost:44339/api/v1/Municipios/InsertMunicipio";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(fullUrl, JSON.stringify(IMUNI), options).pipe(map(result => result.json()));
  }


  public UpdateMunicipio(UMUNI) {
    let fullUrl = "https://localhost:44339/api/v1/Municipios/UpdateMunicipio";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(fullUrl, JSON.stringify(UMUNI), options).pipe(map(result => result.json()));
  }

  public SearchMunicipioId(SEARIDMUNI) {
    let fullUrl = "https://localhost:44339/api/v1/Municipios/SearchMunicipioId/" + SEARIDMUNI;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }


  public GetMunicipioAll() {
    let fullUrl = 'https://localhost:44339/api/v1/Municipios/GetMunicipioAll';
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));;
  }

  public DeleteMunicipio(DELEMUNI) {
    let fullUrl = "https://localhost:44339/api/v1/Municipios/DeleteMunicipio/" + DELEMUNI;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.delete(fullUrl, options).pipe(map(result => result.json()));
  }

  
}



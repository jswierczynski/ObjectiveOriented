import { Injectable } from '@angular/core';
//import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import { AppError } from '../Common/app-error';
import { NotFoundError } from '../Common/not-found-error';
import { BadInputError } from '../Common/bad-input-error';
import { RequestOptions } from '@angular/http/src/base_request_options';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

@Injectable()
export class DataService {
  results: string[];

  constructor(private url: string, private http: HttpClient) { }

  getAll() {
    return this.http.get(this.url)
      .catch(this.handleError);
  }

  get(id) {
    return this.http.get(this.url + '/' + id)
      .catch(this.handleError);
  }

  create(resource) {
    return this.http.post(
      this.url, 
      JSON.stringify(resource), 
      { 
        headers: new HttpHeaders().append('Content-Type', 'application/json')
      })
      .catch(this.handleError);
  }

  update(resource ) {
    return this.http.put(
      this.url + '/' + resource.id, 
      JSON.stringify(resource),
      { 
        headers: new HttpHeaders().append('Content-Type', 'application/json')
      })
        .catch(this.handleError);
  }

  delete(id) {
    return this.http.delete(this.url + '/' + id)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
    if(error.status === 404)
      return Observable.throw(new NotFoundError());

    if(error.status === 400)
      return Observable.throw(new BadInputError(error));

    return Observable.throw(new AppError(error));
  }
}

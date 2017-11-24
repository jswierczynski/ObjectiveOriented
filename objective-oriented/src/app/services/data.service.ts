import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import { AppError } from '../Common/app-error';
import { NotFoundError } from '../Common/not-found-error';
import { BadInputError } from '../Common/bad-input-error';

@Injectable()
export class DataService {
  constructor(private url: string, private http: Http) { }

  getAll() {
    return this.http.get(this.url)
        .map(Response => Response.json())
        .catch(this.handleError);
  }

  create(resource) {
    return this.http.post(this.url, JSON.stringify(resource))
        .map(Response => Response.json())
        .catch(this.handleError);
  }

  update(resource ) {
    return this.http.patch(this.url + '/' + resource.id, JSON.stringify(resource))
        .map(Response => Response.json())
        .catch(this.handleError);
  }

  delete(id) {
    return this.http.delete(this.url + '/' + id)
        .map(Response => Response.json())
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

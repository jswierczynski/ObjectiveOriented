import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { Http } from '@angular/http';

@Injectable()
export class ObjectivesService extends DataService {

  constructor(http: Http) {
    super('http://localhost:55694/api/objectives', http);
   }

}

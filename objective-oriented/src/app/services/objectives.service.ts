import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ObjectivesService extends DataService {

  constructor(http: HttpClient) {
    super('http://localhost:55694/api/objectives', http);
   }

}

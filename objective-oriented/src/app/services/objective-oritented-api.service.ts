import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.service';

@Injectable()
export class ObjectiveOritentedApiService extends DataService {

  constructor(http: HttpClient, resource: string) {
    super('http://localhost:55694/api' + resource, http);
   }

}

import { Injectable } from '@angular/core';
import { ObjectiveOritentedApiService } from './objective-oritented-api.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class TasksService extends ObjectiveOritentedApiService {

  constructor(http: HttpClient) {
    super(http, '/tasks');
   }

}

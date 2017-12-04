import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { Http } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { ObjectiveOritentedApiService } from './objective-oritented-api.service';

@Injectable()
export class ObjectivesService extends ObjectiveOritentedApiService {

  constructor(http: HttpClient) {
    super(http, '/objectives');
   }

}

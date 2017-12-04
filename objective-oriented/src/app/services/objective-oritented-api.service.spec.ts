import { TestBed, inject } from '@angular/core/testing';

import { ObjectiveOritentedApiService } from './objective-oritented-api.service';

describe('ObjectiveOritentedApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ObjectiveOritentedApiService]
    });
  });

  it('should be created', inject([ObjectiveOritentedApiService], (service: ObjectiveOritentedApiService) => {
    expect(service).toBeTruthy();
  }));
});

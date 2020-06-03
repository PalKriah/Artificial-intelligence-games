import { TestBed } from '@angular/core/testing';

import { OnePersonService } from './one-person.service';

describe('OnePersonService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: OnePersonService = TestBed.get(OnePersonService);
    expect(service).toBeTruthy();
  });
});

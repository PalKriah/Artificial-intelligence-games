import { TestBed } from '@angular/core/testing';

import { TwoPersonService } from './two-person.service';

describe('TwoPersonService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TwoPersonService = TestBed.get(TwoPersonService);
    expect(service).toBeTruthy();
  });
});

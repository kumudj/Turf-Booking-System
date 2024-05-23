import { TestBed } from '@angular/core/testing';

import { TurfsService } from './turfs.service';

describe('TurfsService', () => {
  let service: TurfsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TurfsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

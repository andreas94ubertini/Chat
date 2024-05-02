import { TestBed } from '@angular/core/testing';

import { MessaggeService } from './message.service';

describe('MessaggeService', () => {
  let service: MessaggeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MessaggeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

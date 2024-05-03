import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendmessaggeComponent } from './sendmessagge.component';

describe('SendmessaggeComponent', () => {
  let component: SendmessaggeComponent;
  let fixture: ComponentFixture<SendmessaggeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SendmessaggeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SendmessaggeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

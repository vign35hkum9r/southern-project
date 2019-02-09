import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LeadtoComponent } from './leadto.component';

describe('LeadtoComponent', () => {
  let component: LeadtoComponent;
  let fixture: ComponentFixture<LeadtoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeadtoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadtoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

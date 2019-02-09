import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TargetsettingComponent } from './targetsetting.component';

describe('TargetsettingComponent', () => {
  let component: TargetsettingComponent;
  let fixture: ComponentFixture<TargetsettingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TargetsettingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TargetsettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import {MatBottomSheet, MatBottomSheetRef} from '@angular/material';

import { MrsComponent } from './mrs.component';

describe('MrsComponent', () => {
  let component: MrsComponent;
  let fixture: ComponentFixture<MrsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MrsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MrsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

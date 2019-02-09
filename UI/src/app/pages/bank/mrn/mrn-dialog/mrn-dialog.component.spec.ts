import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MrnDialogComponent } from './mrn-dialog.component';

describe('MrnDialogComponent', () => {
  let component: MrnDialogComponent;
  let fixture: ComponentFixture<MrnDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MrnDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MrnDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RaiseDraftIndentComponent } from './raise-draft-indent.component';

describe('RaiseDraftIndentComponent', () => {
  let component: RaiseDraftIndentComponent;
  let fixture: ComponentFixture<RaiseDraftIndentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RaiseDraftIndentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RaiseDraftIndentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

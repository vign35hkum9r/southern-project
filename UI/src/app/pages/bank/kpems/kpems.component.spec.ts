import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KpemsComponent } from './kpems.component';

describe('KpemsComponent', () => {
  let component: KpemsComponent;
  let fixture: ComponentFixture<KpemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KpemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KpemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

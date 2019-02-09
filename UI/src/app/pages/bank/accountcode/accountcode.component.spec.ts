import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccountcodeComponent } from './accountcode.component';

describe('AccountcodeComponent', () => {
  let component: AccountcodeComponent;
  let fixture: ComponentFixture<AccountcodeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccountcodeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountcodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LedgerLibraryComponent } from './ledger-library.component';

describe('LedgerLibraryComponent', () => {
  let component: LedgerLibraryComponent;
  let fixture: ComponentFixture<LedgerLibraryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LedgerLibraryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LedgerLibraryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

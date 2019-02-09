import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { LedgerSubledgerComponent } from './ledger-subledger.component';

describe('LedgerSubledgerComponent', () => {
  let component: LedgerSubledgerComponent;
  let fixture: ComponentFixture<LedgerSubledgerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LedgerSubledgerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LedgerSubledgerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

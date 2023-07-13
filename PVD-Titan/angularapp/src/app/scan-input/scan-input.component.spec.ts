import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScanInputComponent } from './scan-input.component';

describe('ScanInputComponent', () => {
  let component: ScanInputComponent;
  let fixture: ComponentFixture<ScanInputComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ScanInputComponent]
    });
    fixture = TestBed.createComponent(ScanInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VinSearchComponent } from './vin-search.component';

describe('VinSearchComponent', () => {
  let component: VinSearchComponent;
  let fixture: ComponentFixture<VinSearchComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VinSearchComponent]
    });
    fixture = TestBed.createComponent(VinSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

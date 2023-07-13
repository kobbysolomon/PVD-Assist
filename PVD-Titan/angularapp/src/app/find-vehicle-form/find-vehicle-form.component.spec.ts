import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindVehicleFormComponent } from './find-vehicle-form.component';

describe('FindVehicleFormComponent', () => {
  let component: FindVehicleFormComponent;
  let fixture: ComponentFixture<FindVehicleFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FindVehicleFormComponent]
    });
    fixture = TestBed.createComponent(FindVehicleFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

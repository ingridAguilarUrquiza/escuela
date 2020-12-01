import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerSalonComponent } from './ver-salon.component';

describe('VerSalonComponent', () => {
  let component: VerSalonComponent;
  let fixture: ComponentFixture<VerSalonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerSalonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VerSalonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarEditarSalonComponent } from './agregar-editar-salon.component';

describe('AgregarEditarSalonComponent', () => {
  let component: AgregarEditarSalonComponent;
  let fixture: ComponentFixture<AgregarEditarSalonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarEditarSalonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarEditarSalonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

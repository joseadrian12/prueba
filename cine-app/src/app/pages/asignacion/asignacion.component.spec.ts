import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Asignacion } from './asignacion.component';

describe('Asignacion', () => {
  let component: Asignacion;
  let fixture: ComponentFixture<Asignacion>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Asignacion],
    }).compileComponents();

    fixture = TestBed.createComponent(Asignacion);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

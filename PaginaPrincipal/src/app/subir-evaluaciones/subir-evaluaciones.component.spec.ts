import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubirEvaluacionesComponent } from './subir-evaluaciones.component';

describe('SubirEvaluacionesComponent', () => {
  let component: SubirEvaluacionesComponent;
  let fixture: ComponentFixture<SubirEvaluacionesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubirEvaluacionesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubirEvaluacionesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

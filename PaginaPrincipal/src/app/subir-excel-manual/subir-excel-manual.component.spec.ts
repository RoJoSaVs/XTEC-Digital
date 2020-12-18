import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubirExcelManualComponent } from './subir-excel-manual.component';

describe('SubirExcelManualComponent', () => {
  let component: SubirExcelManualComponent;
  let fixture: ComponentFixture<SubirExcelManualComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubirExcelManualComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubirExcelManualComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

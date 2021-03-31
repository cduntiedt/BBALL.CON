import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShotTableComponent } from './shot-table.component';

describe('ShotTableComponent', () => {
  let component: ShotTableComponent;
  let fixture: ComponentFixture<ShotTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShotTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShotTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

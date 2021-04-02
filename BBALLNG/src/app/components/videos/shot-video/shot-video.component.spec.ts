import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShotVideoComponent } from './shot-video.component';

describe('ShotVideoComponent', () => {
  let component: ShotVideoComponent;
  let fixture: ComponentFixture<ShotVideoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShotVideoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShotVideoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

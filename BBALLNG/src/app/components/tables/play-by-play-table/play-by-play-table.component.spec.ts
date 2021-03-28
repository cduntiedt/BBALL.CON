import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlayByPlayTableComponent } from './play-by-play-table.component';

describe('PlayByPlayTableComponent', () => {
  let component: PlayByPlayTableComponent;
  let fixture: ComponentFixture<PlayByPlayTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlayByPlayTableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlayByPlayTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

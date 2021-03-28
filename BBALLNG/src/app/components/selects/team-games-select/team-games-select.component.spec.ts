import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamGamesSelectComponent } from './team-games-select.component';

describe('TeamGamesSelectComponent', () => {
  let component: TeamGamesSelectComponent;
  let fixture: ComponentFixture<TeamGamesSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeamGamesSelectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamGamesSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamsSelectComponent } from './teams-select.component';

describe('TeamsSelectComponent', () => {
  let component: TeamsSelectComponent;
  let fixture: ComponentFixture<TeamsSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeamsSelectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamsSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

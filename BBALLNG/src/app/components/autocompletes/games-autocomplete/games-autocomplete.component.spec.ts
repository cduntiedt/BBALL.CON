import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamesAutocompleteComponent } from './games-autocomplete.component';

describe('GamesAutocompleteComponent', () => {
  let component: GamesAutocompleteComponent;
  let fixture: ComponentFixture<GamesAutocompleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamesAutocompleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GamesAutocompleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

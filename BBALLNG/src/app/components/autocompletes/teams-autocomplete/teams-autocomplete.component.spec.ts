import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamsAutocompleteComponent } from './teams-autocomplete.component';

describe('TeamsAutocompleteComponent', () => {
  let component: TeamsAutocompleteComponent;
  let fixture: ComponentFixture<TeamsAutocompleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeamsAutocompleteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamsAutocompleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

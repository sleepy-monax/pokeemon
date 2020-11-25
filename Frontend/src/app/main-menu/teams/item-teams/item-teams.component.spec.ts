import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemTeamsComponent } from './item-teams.component';

describe('ItemTeamsComponent', () => {
  let component: ItemTeamsComponent;
  let fixture: ComponentFixture<ItemTeamsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemTeamsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemTeamsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

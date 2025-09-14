import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JourneyView } from './journey-view';

describe('JourneyView', () => {
  let component: JourneyView;
  let fixture: ComponentFixture<JourneyView>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JourneyView]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JourneyView);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

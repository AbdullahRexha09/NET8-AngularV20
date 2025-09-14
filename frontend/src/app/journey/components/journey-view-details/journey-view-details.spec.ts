import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JourneyViewDetails } from './journey-view-details';

describe('JourneyViewDetails', () => {
  let component: JourneyViewDetails;
  let fixture: ComponentFixture<JourneyViewDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [JourneyViewDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JourneyViewDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

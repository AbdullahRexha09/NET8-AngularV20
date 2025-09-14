import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StopViewDetails } from './stop-view-details';

describe('StopViewDetails', () => {
  let component: StopViewDetails;
  let fixture: ComponentFixture<StopViewDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StopViewDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StopViewDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

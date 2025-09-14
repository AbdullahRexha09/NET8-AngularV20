import { Component, inject, OnDestroy, OnInit, signal} from '@angular/core';
import { takeUntilDestroyed, toObservable, toSignal } from '@angular/core/rxjs-interop';
import { JourneyService } from '../../services/journey.service';
import { Router, RouterLink } from '@angular/router';
import { Subject, switchMap, takeUntil } from 'rxjs';
import { Journey } from '../../models/journey.model';

@Component({
  selector: 'journey-view',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './journey-view.html',
  styleUrl: './journey-view.css'
})
export class JourneyView implements OnInit, OnDestroy{
  #journeyService = inject(JourneyService);
  refreshTrigger = signal(0);
  journeys = signal<Journey[]>([]);
  #destroy$ = new Subject<void>();

  ngOnInit(): void {
   this.#journeyService.getAllJourneys()
       .pipe(
            takeUntil(this.#destroy$)
          ) 
       .subscribe(response =>{
    this.journeys.set(response);
   })
  }
  onDelete(id: string){
    if (confirm("Are you sure you want to delete item?")) {
      this.#journeyService.deleteJourney(id)
      .pipe(
        takeUntil(this.#destroy$)
      ) 
      .subscribe();
      location.reload();
      this.refresh();
    } 
  }

  refresh() {
    this.refreshTrigger.set(Date.now());
  }

  ngOnDestroy(): void {
     this.#destroy$.next();
     this.#destroy$.complete();
  }
}

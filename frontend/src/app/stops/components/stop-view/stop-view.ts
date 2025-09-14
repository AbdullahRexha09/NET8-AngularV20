import { Component, inject, OnDestroy, OnInit, Signal, signal } from '@angular/core';
import { StopService } from '../../services/stop.service';
import { toObservable, toSignal } from '@angular/core/rxjs-interop';
import { Subject, switchMap, takeUntil } from 'rxjs';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Stop } from '../../models/stop.model';

@Component({
  selector: 'app-stop-view',
  imports: [CommonModule, RouterLink],
  templateUrl: './stop-view.html',
  styleUrl: './stop-view.css'
})
export class StopView implements OnInit, OnDestroy{
  #stopService = inject(StopService);
  refreshTrigger = signal(0);
  stops = signal<Stop[]>([]);
  #destroy$ = new Subject<void>();

  
  ngOnInit(): void {
   this.#stopService.getAllStops()
       .pipe(
        takeUntil(this.#destroy$)
       )    
       .subscribe(response =>{
    this.stops.set(response);
   })
  }
  onDelete(id: string){
  if (confirm("Are you sure you want to delete item?")) {
    this.#stopService.deleteStop(id)
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

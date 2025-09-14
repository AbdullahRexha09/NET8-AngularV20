import { Component, inject, OnInit } from '@angular/core';
import { Journey } from '../../models/journey.model';
import { ActivatedRoute, Router } from '@angular/router';
import { JourneyService } from '../../services/journey.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-journey-view-details',
  imports: [FormsModule],
  templateUrl: './journey-view-details.html',
  styleUrl: './journey-view-details.css'
})
export class JourneyViewDetails implements OnInit {
  formData: Partial<Journey> = {};
  journeyId: number = -1;
  #route = inject(ActivatedRoute);
  #router = inject(Router);
  #journeyService = inject(JourneyService);
  #idFromRoute!: string;

  ngOnInit(): void {
     this.#idFromRoute = this.#route.snapshot.paramMap.get('id') ?? '-1';
     if(this.isUpdate){
      this.#journeyService.getJourneyById(this.#idFromRoute).subscribe(response =>{
        this.formData = response;
      })
     }
  }
  submitForm() {
   const navigateCallBack = () =>{
      this.#router.navigate(['/journey'], {
               onSameUrlNavigation: 'reload'
           });
    };
    const updateFormData = {...this.formData, stopCodesInOrder: String(this.formData.stops as any)?.split(',')};

      this.isUpdate ?
          this.#journeyService.updateJourney(this.#idFromRoute, updateFormData).subscribe(_ => navigateCallBack()) :
          this.#journeyService.createJourney(updateFormData).subscribe(_ => navigateCallBack());
  }
  
  get isUpdate(){
    return this.#route.snapshot.paramMap.get('id') != '-1';
  }
}

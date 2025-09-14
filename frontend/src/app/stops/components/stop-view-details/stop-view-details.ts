import { Component, inject, OnInit } from '@angular/core';
import { Stop } from '../../models/stop.model';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StopService } from '../../services/stop.service';

@Component({
  selector: 'app-stop-view-details',
  imports: [FormsModule],
  templateUrl: './stop-view-details.html',
  styleUrl: './stop-view-details.css'
})
export class StopViewDetails implements OnInit {
  formData: Partial<Stop> = {};
  stopId: number = -1;
  #route = inject(ActivatedRoute);
  #router = inject(Router);
  #stopService = inject(StopService);
  #idFromRoute!: string;
  
  ngOnInit(): void {
   this.#idFromRoute = this.#route.snapshot.paramMap.get('id') ?? '-1';
    if(this.isUpdate){
      this.#stopService.getStopById(this.#idFromRoute).subscribe(response =>{
        this.formData = response;
      })
     }
  }
  submitForm(){
    const navigateCallBack = () =>{
      this.#router.navigate(['/stop'], {
               onSameUrlNavigation: 'reload'
           });
    };
      this.isUpdate ?
          this.#stopService.updateStop(this.#idFromRoute, this.formData).subscribe(_ => navigateCallBack()) :
          this.#stopService.createStop(this.formData).subscribe(_ => navigateCallBack());

     
  }

   get isUpdate(){
    return this.#route.snapshot.paramMap.get('id') != '-1';
  }
}

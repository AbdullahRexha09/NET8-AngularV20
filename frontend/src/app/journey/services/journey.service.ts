import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { Journey } from "../models/journey.model";
import { map } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class JourneyService{
  #http = inject(HttpClient);
  #apiUrl = `${environment.backendUrl}/api/v1/Journey`;


  getAllJourneys() {
    return this.#http.get<Journey[]>(this.#apiUrl).pipe(
      map(journeys => {
        return journeys.map(journey => ({
          ...journey,
          stops: journey.stops.map(stop => stop.code)
        }));
      })
    );
  }
  getJourneyById(id: string) {
    return this.#http.get<Journey>(`${this.#apiUrl}/${id}`).pipe(
      map(journey => ({
        ...journey,
        stops: journey.stops.map(stop => stop.code) 
      }))
    );
  }
  
  createJourney(request: any){
    return this.#http.post<Journey>(`${this.#apiUrl}`, request)
  }
  
  updateJourney(id: string, request: any){
    return this.#http.put<Journey>(`${this.#apiUrl}/${id}`, request)
  }
  
  deleteJourney(id: string){
    return this.#http.delete<boolean>(`${this.#apiUrl}/${id}`)
  }
  
}
import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "../../../environments/environment";
import { Stop } from "../models/stop.model";

@Injectable({
  providedIn: 'root'
})
export class StopService{
  #http = inject(HttpClient);
  #apiUrl = `${environment.backendUrl}/api/v1/Stop`;


  getAllStops() {
    return this.#http.get<Stop[]>(this.#apiUrl);
  }

  getStopById(id: string){
    return this.#http.get<Stop>(this.#apiUrl + '/' + id);
  }
  
  createStop(request: any){
      return this.#http.post<Stop>(`${this.#apiUrl}`, request)
  }

  updateStop(id: string, request: any){
      return this.#http.put<Stop>(`${this.#apiUrl}/${id}`, request)
  }

 deleteStop(id: string){
    return this.#http.delete<boolean>(`${this.#apiUrl}/${id}`)
  }
  
}
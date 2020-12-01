import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Salon } from '../models/salon';

@Injectable({
  providedIn: 'root'
})
export class SalonService {
  backendUrl="https://localhost:44389/";
  frontendUrl="api/Salon/";

  httpOptions={
    headers:new HttpHeaders({'Content-Type':'application/json'})
  };
  constructor(
    private _http:HttpClient
    ) {}
  
  getListSalon(): Observable<Salon[]>{
    return this._http.get<Salon[]>(this.backendUrl+this.frontendUrl);
    }
  deleteSalon(id:number): Observable<Salon>{
    return this._http.delete<Salon>(this.backendUrl+this.frontendUrl+id);
  }
  guardarSalon(salon:Salon): Observable<Salon>{
    return this._http.post<Salon>(this.backendUrl+this.frontendUrl,salon,this.httpOptions);
  }
  cargarSalon(id:number):Observable<Salon>{
    return this._http.get<Salon>(this.backendUrl+this.frontendUrl+id);
  }
  actualizarSalon(id:number,alumno:Salon):Observable<Salon>{
    return this._http.put<Salon>(this.backendUrl+this.frontendUrl+id,alumno,this.httpOptions);
  }
}

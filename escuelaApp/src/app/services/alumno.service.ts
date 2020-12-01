import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Alumno } from '../models/alumno';

@Injectable({
  providedIn: 'root'
})
export class AlumnoService {
  backendUrl="https://localhost:44389/";
  frontendUrl="api/Alumno/";

  httpOptions={
    headers:new HttpHeaders({'Content-Type':'application/json'})
  };
  constructor(
    private _http:HttpClient
    ) {}
  
  getListAlumno(): Observable<Alumno[]>{
    return this._http.get<Alumno[]>(this.backendUrl+this.frontendUrl);
    }
  deleteAlumno(id:number): Observable<Alumno>{
    return this._http.delete<Alumno>(this.backendUrl+this.frontendUrl+id);
  }
  guardarAlumno(alumno:Alumno): Observable<Alumno>{
    return this._http.post<Alumno>(this.backendUrl+this.frontendUrl,alumno,this.httpOptions);
  }
  cargarAlumno(id:number):Observable<Alumno>{
    return this._http.get<Alumno>(this.backendUrl+this.frontendUrl+id);
  }
  actualizarAlumno(id:number,alumno:Alumno):Observable<Alumno>{
    return this._http.put<Alumno>(this.backendUrl+this.frontendUrl+id,alumno,this.httpOptions);
  }
}

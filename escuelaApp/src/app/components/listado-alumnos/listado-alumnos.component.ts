import { Component, OnInit } from '@angular/core';
import { Alumno } from 'src/app/models/alumno';
import { AlumnoService } from 'src/app/services/alumno.service';
import {CommonModule} from '@angular/common';
import { Router } from '@angular/router';
import { Respuesta } from 'src/app/models/respuesta';


@Component({
  selector: 'app-listado-alumnos',
  templateUrl: './listado-alumnos.component.html',
  styleUrls: ['./listado-alumnos.component.css']
})
export class ListadoAlumnosComponent implements OnInit {
  list:any;
  loading=false;
  //listSalon:any;

  nombreSalon:any;
  constructor(private alumnoService: AlumnoService,private router:Router) { 
     
  }
  ngOnInit(): void {
   this.cargarAlumno();
  }
  cargarAlumno(){
    this.loading=true;
    this.alumnoService.getListAlumno().subscribe( resp => {
      this.loading=false;
      this.list=resp.data as string[];
   debugger;
    console.log(this.list);
    })
  }
  delete(id: number){
    this.loading=true;
    this.alumnoService.deleteAlumno(id).subscribe(data =>{
      this.loading=false;
      this.cargarAlumno()
    })
  }
  verDetalles(id: number){
    console.log(id);
    this.router.navigate([`editarA/${id}`]);
  }
  verA(id: number){
    //console.log(id);
    this.router.navigate([`ver/${id}`]);
  }
  listadoSalones(){
    //console.log(id);
    this.router.navigate(['listadoSalones']);
  }



}

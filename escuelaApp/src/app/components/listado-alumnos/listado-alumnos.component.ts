import { Component, OnInit } from '@angular/core';
import { Alumno } from 'src/app/models/alumno';
import { AlumnoService } from 'src/app/services/alumno.service';
import {CommonModule} from '@angular/common';
import { Router } from '@angular/router';


@Component({
  selector: 'app-listado-alumnos',
  templateUrl: './listado-alumnos.component.html',
  styleUrls: ['./listado-alumnos.component.css']
})
export class ListadoAlumnosComponent implements OnInit {
  //public lista: Alumno[];//any[];
  //public lista:string[] | undefined;
  //public list!: [Alumno];
  //public list=[];
 // list:any[];
 //public lista: Alumno[];//any[];
  //public lista:string[] | undefined;
  //public list!: [Alumno];
  //public list=[];
  // list:any[];
  list: Alumno[] = [];
  loaging=false;
  constructor(private alumnoService: AlumnoService,private router:Router) { 
     
  }
  ngOnInit(): void {
   this.cargarAlumno();
  }
  cargarAlumno(){
    this.alumnoService.getListAlumno().subscribe( r => {
      this.list= r;
    debugger;
      console.log(this.list);
    })
  }
  delete(id: number){
    this.alumnoService.deleteAlumno(id).subscribe(data =>{
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

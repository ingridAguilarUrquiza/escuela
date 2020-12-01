import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup,Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Alumno } from 'src/app/models/alumno';
import { AlumnoService } from 'src/app/services/alumno.service';

@Component({
  selector: 'app-agregar-editar-alumno',
  templateUrl: './agregar-editar-alumno.component.html',
  styleUrls: ['./agregar-editar-alumno.component.css']
})
export class AgregarEditarAlumnoComponent implements OnInit {
  registroAlumno: FormGroup;
  idAlumno=0;
  accion='Agregar';
  alumno: Alumno | undefined;
  constructor(private formValidar:FormBuilder, private router:ActivatedRoute, 
    private alumnoService:AlumnoService,private routerR:Router) {
     this.registroAlumno=this.formValidar.group({
       nombre:['',Validators.required],
       apellidoPaterno:['',Validators.required],
       apellidoMaterno:['',Validators.required],
       telefono:['',Validators.required],
       edad:['',Validators.required],
       genero:['',Validators.required]
     });
    if(this.router.snapshot.params['id']>0){
      this.idAlumno=this.router.snapshot.params['id'];
    }
   }

  ngOnInit(): void {
    this.editarAlumno();
  }
guardarAlumno(){
  if(this.accion==='Agregar'){
  const alumno:Alumno={
    nombre:this.registroAlumno.get('nombre')?.value,
    apellidoPaterno:this.registroAlumno.get('apellidoPaterno')?.value,
    apellidoMaterno:this.registroAlumno.get('apellidoMaterno')?.value,
    telefono:this.registroAlumno.get('telefono')?.value,
    edad:this.registroAlumno.get('edad')?.value,
    genero:this.registroAlumno.get('genero')?.value
  }
  this.alumnoService.guardarAlumno(alumno).subscribe(data =>{
    this.routerR.navigate(['/']);
  })
  }else{
    const alumno:Alumno={
      nombre:this.registroAlumno.get('nombre')?.value,
      apellidoPaterno:this.registroAlumno.get('apellidoPaterno')?.value,
      apellidoMaterno:this.registroAlumno.get('apellidoMaterno')?.value,
      telefono:this.registroAlumno.get('telefono')?.value,
      edad:this.registroAlumno.get('edad')?.value,
      genero:this.registroAlumno.get('genero')?.value
    }
    //debugger;
    this.alumnoService.actualizarAlumno(this.idAlumno,alumno).subscribe(data=>{
      this.routerR.navigate(['/']);
    });
  
  }
  //console.log(this.registroAlumno);
 
}
editarAlumno(){
 // alert("editar"+this.accion);
  if(this.idAlumno>0){
    this.accion='Editar';
    this.alumnoService.cargarAlumno(this.idAlumno).subscribe(data=>{
      this.alumno=data;
      this.registroAlumno.patchValue({
        id:data.id,
        nombre:data.nombre,
        apellidoPaterno:data.apellidoPaterno,
        apellidoMaterno:data.apellidoMaterno,
        telefono:data.telefono,
        edad:data.edad,
        genero:data.genero
      })
    })
   
  }
}
}

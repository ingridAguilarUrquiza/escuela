import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup,Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Alumno } from 'src/app/models/alumno';
import { AlumnoService } from 'src/app/services/alumno.service';
import { SalonService } from 'src/app/services/salon.service';

@Component({
  selector: 'app-agregar-editar-alumno',
  templateUrl: './agregar-editar-alumno.component.html',
  styleUrls: ['./agregar-editar-alumno.component.css']
})
export class AgregarEditarAlumnoComponent implements OnInit {
  registroAlumno: FormGroup;
  idAlumno=0;
  accion='Agregar';
  loading=false;
  alumno:any;
  listaSalon:any;
  dato:any;
  //salonAsignado:any;
  constructor(private formValidar:FormBuilder, private router:ActivatedRoute, 
    private alumnoService:AlumnoService,private salonService:SalonService,
    private routerR:Router) {
     this.registroAlumno=this.formValidar.group({
       nombre:['',Validators.required],
       apellidoPaterno:['',Validators.required],
       apellidoMaterno:['',Validators.required],
       telefono:['',Validators.required],
       edad:['',Validators.required],
       genero:['',Validators.required],
       salon:['',Validators.required]
     });
    if(this.router.snapshot.params['id']>0){
      this.idAlumno=this.router.snapshot.params['id'];
    }
   }

  ngOnInit(): void {
    //this.editarAlumno();
    this.cargarSalones();
  }
guardarAlumno(){
 if(this.accion==='Agregar'){
    const alumno:Alumno={
    nombre:this.registroAlumno.get('nombre')?.value,
    apellidoPaterno:this.registroAlumno.get('apellidoPaterno')?.value,
    apellidoMaterno:this.registroAlumno.get('apellidoMaterno')?.value,
    telefono:this.registroAlumno.get('telefono')?.value,
    edad:this.registroAlumno.get('edad')?.value,
    genero:this.registroAlumno.get('genero')?.value,
    nombreSalon:this.registroAlumno.get('salon')?.value
  }
  //debugger;
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
      genero:this.registroAlumno.get('genero')?.value,
      nombreSalon:this.registroAlumno.get('salon')?.value

    }
   // debugger;
    this.alumnoService.actualizarAlumno(this.idAlumno,alumno).subscribe(data=>{
      this.routerR.navigate(['/']);
    });

  }
  //console.log(this.registroAlumno);
 
}
/*editarAlumno(){
  //this.cargarSalones();
 // alert("editar"+this.accion);
 if(this.idAlumno>0){
  this.accion='Editar';
  console.log("inicia la carga de alumno");
  this.alumnoService.cargarAlumno(this.idAlumno).subscribe(resp=>{
    this.alumno=resp.data as string[];
    //debugger;
    console.log(this.alumno);
    this.registroAlumno.patchValue({
      nombre:this.alumno.nombre,
      apellidoPaterno:this.alumno.apellidoPaterno,
      apellidoMaterno:this.alumno.apellidoMaterno,
      telefono:this.alumno.telefono,
      edad:this.alumno.edad,
      genero:this.alumno.genero,
      salon:this.alumno.nombreSalon
      //salon.setValue(this.alumno.nombreSalon);
    })
    //salon:this.alumno.setValue("hola");
    //debugger;
      console.log(this.alumno);
  })
  
}
}*/
cargarSalones(){
  //console.log("inicia carga de salones");
  /*this.loading=true;
  this.salonService.getListSalon().subscribe( response => {
    this.loading=false;
    //console.log("salones cargados");
    this.listaSalon= response.data;
    //this.dato=this.listaSalon.nombreSalon
    console.log("se cargaron los salones en editar Alumno");
    console.log(this.listaSalon);*/
  //})
 //console.log("inicia carga de salones");
  this.loading=true;
  this.salonService.getListSalon().subscribe( response => {
    this.loading=false;
    console.log("salones cargados");
    this.listaSalon= response.data;
    console.log("se cargaron los salones en editar Alumno");
    console.log(this.listaSalon);
  if(this.idAlumno>0){
    this.accion='Editar';
    console.log("inicia la carga de alumno");
    this.alumnoService.cargarAlumno(this.idAlumno).subscribe(resp=>{
      this.alumno=resp.data as string[];
      //debugger;
      console.log(this.alumno);
      this.registroAlumno.patchValue({
        nombre:this.alumno.nombre,
        apellidoPaterno:this.alumno.apellidoPaterno,
        apellidoMaterno:this.alumno.apellidoMaterno,
        telefono:this.alumno.telefono,
        edad:this.alumno.edad,
        genero:this.alumno.genero,
        salon:this.alumno.nombreSalon
      })
    })
  } 
    //debugger;
  })
}

}

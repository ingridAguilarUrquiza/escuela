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
  salonAsignado:any;
  constructor(private formValidar:FormBuilder, private router:ActivatedRoute, 
    private alumnoService:AlumnoService,private salonService:SalonService,private routerR:Router) {
     this.registroAlumno=this.formValidar.group({
       nombre:['',Validators.required],
       apellidoPaterno:['',Validators.required],
       apellidoMaterno:['',Validators.required],
       telefono:['',Validators.required],
       edad:['',Validators.required],
       genero:['',Validators.required],
       salonAsignado:['',Validators.required]
     });
    if(this.router.snapshot.params['id']>0){
      this.idAlumno=this.router.snapshot.params['id'];
    }
   }

  ngOnInit(): void {
    this.editarAlumno();
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
    idSalon:parseInt(this.registroAlumno.get('salonAsignado')?.value)
    
  }
  debugger;
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
      idSalon:parseInt(this.registroAlumno.get('salonAsignado')?.value)

    }
   // debugger;
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
    this.alumnoService.cargarAlumno(this.idAlumno).subscribe(resp=>{
      this.alumno=resp.data as string[];
      this.registroAlumno.patchValue({
        id:resp.data.id,
        nombre:resp.data.nombre,
        apellidoPaterno:resp.data.apellidoPaterno,
        apellidoMaterno:resp.data.apellidoMaterno,
        telefono:resp.data.telefono,
        edad:resp.data.edad,
        genero:resp.data.genero,
        idSalon:resp.data.listSalon[0].salonAsignado
      })
    })
   
  }
}
cargarSalones(){
  this.loading=true;
  this.salonService.getListSalon().subscribe( response => {
    this.loading=false;
    this.listaSalon= response.data;
  /*debugger;
    console.log(this.listaSalon);*/
  })
}

}

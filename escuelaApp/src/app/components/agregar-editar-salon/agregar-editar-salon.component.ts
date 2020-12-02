import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup,Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Resp,Salon } from 'src/app/models/salon';
import { SalonService } from 'src/app/services/salon.service';

@Component({
  selector: 'app-agregar-editar-salon',
  templateUrl: './agregar-editar-salon.component.html',
  styleUrls: ['./agregar-editar-salon.component.css']
})
export class AgregarEditarSalonComponent implements OnInit {
  registroSalon: FormGroup;
  idSa=0;
  accion='Agregar';
  salon: Salon | undefined;
  constructor(private formValidar:FormBuilder, private router:ActivatedRoute, 
    private salonService:SalonService,private routerR:Router) {
     this.registroSalon=this.formValidar.group({
       nombre:['',Validators.required],
       descripcion:['',Validators.required],
     });
    if(this.router.snapshot.params['id']>0){
      this.idSa=this.router.snapshot.params['id'];
    }
   }

  ngOnInit(): void {
    this.editarSalon();
  }
guardarSalon(){
  if(this.accion==='Agregar'){
    const salon:Salon={
      nombre:this.registroSalon.get('nombre')?.value,
      descripcion:this.registroSalon.get('descripcion')?.value
    }
    this.salonService.guardarSalon(salon).subscribe(data =>{
      this.routerR.navigate(['/listadoSalones']);
    })
    }else{
      const salon:Salon={
        nombre:this.registroSalon.get('nombre')?.value,
        descripcion:this.registroSalon.get('descripcion')?.value,
      }
      //debugger;
      this.salonService.actualizarSalon(this.idSa,salon).subscribe(data=>{
        this.routerR.navigate(['/ListadoSalones']);
      });
    
    }
  
  
  }
  //console.log(this.registroSalon);
 

editarSalon(){
 
  if(this.idSa>0){
    this.accion='Editar';
    //console.log("e"+this.accion+this.idSa);
    this.salonService.cargarSalonEditar(this.idSa).subscribe(resp=>{
     this.salon = resp;
     //console.log(this.salon);
      this.registroSalon.patchValue({
        id:resp.id,
        nombre:resp.nombre,
        descripcion:resp.descripcion
      })
      console.log(this.salon);
    })
   
  }
}
}

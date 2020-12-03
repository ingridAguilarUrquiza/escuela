import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup,Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Respuesta } from 'src/app/models/respuesta';
import { Salon} from 'src/app/models/salon';
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
  respuesta:any;
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
    this.salonService.guardarSalon(salon).subscribe(resp =>{
      this.routerR.navigate(['/listadoSalones']);
    })
    }else{
      
      const salon:Salon={
        
        nombre:this.registroSalon.get('nombre')?.value,
        descripcion:this.registroSalon.get('descripcion')?.value,
      }

      this.salonService.actualizarSalon(this.idSa,salon).subscribe(resp=>{
        this.routerR.navigate(['/listadoSalones']);
      });
    
    }
  
  
  }
 

editarSalon(){
 
  if(this.idSa>0){
    this.accion='Editar';
    this.salonService.cargarSalon(this.idSa).subscribe(resp=>{
     this.respuesta = resp.data as string[];
      this.registroSalon.patchValue({
        id:resp.data.id,
        nombre:resp.data.nombre,
        descripcion:resp.data.descripcion
      })
      //console.log(this.salon);
    })
   
  }
}
}

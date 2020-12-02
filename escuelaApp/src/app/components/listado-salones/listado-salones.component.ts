import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Resp,Salon } from 'src/app/models/salon';
import { SalonService } from 'src/app/services/salon.service';


@Component({
  selector: 'app-listado-salones',
  templateUrl: './listado-salones.component.html',
  styleUrls: ['./listado-salones.component.css']
})
export class ListadoSalonesComponent implements OnInit {
  lista: Salon[]=[];
  listaSalon:any;
  constructor(private salonService:SalonService, private router:Router) { }

  ngOnInit(): void {
    this.cargarSalones();
  }
  cargarSalones(){
    this.salonService.getListSalon().subscribe( response => {
      this.listaSalon= response.data;
    /*debugger;
      console.log(this.listaSalon);*/
    })
  }
  agregarSalon(){
    //console.log(id);
    this.router.navigate(['agregarSalon']);
  }
  verDetalleSalon(id: number){
    console.log(id);
    this.router.navigate([`editarSalon/${id}`]);
  }
  deleteSalon(id: number){
    this.salonService.deleteSalon(id).subscribe(data =>{
      this.cargarSalones()
    })
  }
}

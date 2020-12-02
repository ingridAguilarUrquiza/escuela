import { Component, OnInit } from '@angular/core';
import { Resp, Salon } from 'src/app/models/salon';
import { SalonService } from 'src/app/services/salon.service';


@Component({
  selector: 'app-listado-salones',
  templateUrl: './listado-salones.component.html',
  styleUrls: ['./listado-salones.component.css']
})
export class ListadoSalonesComponent implements OnInit {
  lista: Salon[]=[];
  listaSalon:any;
  constructor(private salonService:SalonService) { }

  ngOnInit(): void {
    this.cargarSalones();
  }
  cargarSalones(){
    this.salonService.getListSalon().subscribe( response => {
      this.listaSalon= response;
    debugger;
      console.log(this.listaSalon);
    })
  }
}

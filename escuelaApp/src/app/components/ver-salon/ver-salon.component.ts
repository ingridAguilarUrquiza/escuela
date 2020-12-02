import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Salon } from 'src/app/models/salon';
import { SalonService } from 'src/app/services/salon.service';

@Component({
  selector: 'app-ver-salon',
  templateUrl: './ver-salon.component.html',
  styleUrls: ['./ver-salon.component.css']
})
export class VerSalonComponent implements OnInit {
loading=false;
  salon!: Salon;
  idSa!: number;
  constructor(private salonService:SalonService, private router:ActivatedRoute) {
    this.idSa=this.router.snapshot.params['id'];

   }

  ngOnInit(): void {
    this.cargarSalon();
  }
  cargarSalon(){
console.log(this.idSa);
    this.loading=true;
    this.salonService.cargarSalonEditar(this.idSa).subscribe(resp =>{
      this.loading=false;
      this.salon =resp;
    //debugger;
      console.log(this.salon);
    })
  }
}

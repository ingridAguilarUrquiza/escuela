import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Alumno } from 'src/app/models/alumno';
import { AlumnoService } from 'src/app/services/alumno.service';

@Component({
  selector: 'app-ver-alumno',
  templateUrl: './ver-alumno.component.html',
  styleUrls: ['./ver-alumno.component.css']
})
export class VerAlumnoComponent implements OnInit {
  alumno:any;
  idAlumno:number;
  constructor(private alumnoService: AlumnoService, private router:ActivatedRoute) { 
  this.idAlumno=this.router.snapshot.params['id'];
  }
  ngOnInit(): void {
    this.cargarAlumno();
  }
  cargarAlumno(){
    this.alumnoService.cargarAlumno(this.idAlumno).subscribe(resp =>{
      this.alumno =resp.data as string[];
      console.log(this.alumno);
    })
  }

}

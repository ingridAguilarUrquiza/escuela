import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AgregarEditarAlumnoComponent } from './components/agregar-editar-alumno/agregar-editar-alumno.component';
import { AgregarEditarSalonComponent } from './components/agregar-editar-salon/agregar-editar-salon.component';
import { ListadoAlumnosComponent } from './components/listado-alumnos/listado-alumnos.component';
import { VerAlumnoComponent } from './components/ver-alumno/ver-alumno.component';
import {ListadoSalonesComponent} from './components/listado-salones/listado-salones.component';
import { VerSalonComponent } from './components/ver-salon/ver-salon.component';

const routes: Routes = [
  {path:'agregarA',component:AgregarEditarAlumnoComponent},
  {path:'editarA/:id',component:AgregarEditarAlumnoComponent},
  {path:'editarSalon/:id',component:AgregarEditarSalonComponent},
  {path:'listadoA',component:ListadoAlumnosComponent},
  {path:'ver/:id',component:VerAlumnoComponent},
  {path:'listadoSalones',component:ListadoSalonesComponent},
  {path:'agregarSalon',component:AgregarEditarSalonComponent},
  {path:'verSalon/:id',component:VerSalonComponent},
  {path:'',component:ListadoAlumnosComponent,pathMatch:'full'},
  {path:'**',redirectTo:'/'}

  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

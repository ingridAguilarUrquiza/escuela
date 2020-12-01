import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AgregarEditarAlumnoComponent } from './components/agregar-editar-alumno/agregar-editar-alumno.component';
import { AgregarEditarSalonComponent } from './components/agregar-editar-salon/agregar-editar-salon.component';
import { ListadoAlumnosComponent } from './components/listado-alumnos/listado-alumnos.component';
import { ListadoSalonesComponent } from './components/listado-salones/listado-salones.component';
import { VerAlumnoComponent } from './components/ver-alumno/ver-alumno.component';
import { VerSalonComponent } from './components/ver-salon/ver-salon.component';
import {CommonModule} from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    AgregarEditarAlumnoComponent,
    AgregarEditarSalonComponent,
    ListadoAlumnosComponent,
    ListadoSalonesComponent,
    VerAlumnoComponent,
    VerSalonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PaginaDeInicioComponent } from './pagina-de-inicio/pagina-de-inicio.component';
import { LoginEstudianteComponent } from './login-estudiante/login-estudiante.component';
import { LoginProfesorComponent } from './login-profesor/login-profesor.component';
import { NavbarComponent } from './navbar/navbar.component';
import { VistaEstudianteComponent } from './vista-estudiante/vista-estudiante.component';
import { VistaProfesorComponent } from './vista-profesor/vista-profesor.component';
import { VistaAdministradorComponent } from './vista-administrador/vista-administrador.component';

@NgModule({
  declarations: [
    AppComponent,
    PaginaDeInicioComponent,
    LoginEstudianteComponent,
    LoginProfesorComponent,
    NavbarComponent,
    VistaEstudianteComponent,
    VistaProfesorComponent,
    VistaAdministradorComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

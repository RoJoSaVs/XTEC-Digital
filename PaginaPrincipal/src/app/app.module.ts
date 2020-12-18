//imports de la aplicación
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

//imports del usuario
import { PaginaDeInicioComponent } from './pagina-de-inicio/pagina-de-inicio.component';
import { LoginEstudianteComponent } from './login-estudiante/login-estudiante.component';
import { LoginProfesorComponent } from './login-profesor/login-profesor.component';
import { NavbarComponent } from './navbar/navbar.component';
import { VistaEstudianteComponent } from './vista-estudiante/vista-estudiante.component';
import { VistaProfesorComponent } from './vista-profesor/vista-profesor.component';
import { VistaAdministradorComponent } from './vista-administrador/vista-administrador.component';
import { LoginAdministradorComponent } from './login-administrador/login-administrador.component';
import { GestionCursosComponent } from './gestion-cursos/gestion-cursos.component';
import { GestionDocumentosComponent } from './gestion-documentos/gestion-documentos.component';
import { GestionRubrosComponent } from './gestion-rubros/gestion-rubros.component';
import { SubirExcelComponent } from './subir-excel/subir-excel.component';
import { SubirExcelManualComponent } from './subir-excel-manual/subir-excel-manual.component';
import { GestionNoticiasComponent } from './gestion-noticias/gestion-noticias.component';


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
    LoginAdministradorComponent,
    GestionCursosComponent,
    GestionDocumentosComponent,
    GestionRubrosComponent,
    SubirExcelManualComponent,
    GestionNoticiasComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

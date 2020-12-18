
//imports de bibliotecas de angular
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PaginaDeInicioComponent} from './pagina-de-inicio/pagina-de-inicio.component'
import { FormsModule } from '@angular/forms';


//imports de componentes
import { ConnectionService} from 'src/app/services/connection.service'
import { LoginEstudianteComponent } from './login-estudiante/login-estudiante.component';
import { LoginAdministradorComponent} from './login-administrador/login-administrador.component'
import { LoginProfesorComponent } from './login-profesor/login-profesor.component';
import { VistaProfesorComponent } from './vista-profesor/vista-profesor.component';
import { VistaEstudianteComponent } from './vista-estudiante/vista-estudiante.component';
import { VistaAdministradorComponent } from './vista-administrador/vista-administrador.component';
import { GestionDocumentosComponent } from './gestion-documentos/gestion-documentos.component';
import { SubirExcelComponent } from './subir-excel/subir-excel.component';



const routes: Routes = [
  { path: '', component: PaginaDeInicioComponent},
  { path: 'login-profesor', component: LoginProfesorComponent},
  { path: 'login-estudiante', component: LoginEstudianteComponent},
  { path: 'login-administrador', component: LoginAdministradorComponent},
  { path: 'vista-administrador/:id', component: VistaAdministradorComponent },
  { path: 'vista-profesor/:id', component: VistaEstudianteComponent },
  { path: 'vista-estudiante/:id', component: VistaProfesorComponent },
  { path: 'subir-excel/:id', component: SubirExcelComponent },
  { path: 'gestion-documentos/:id', component: GestionDocumentosComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes),FormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }

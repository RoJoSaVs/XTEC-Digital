
//imports de bibliotecas de angular
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PaginaDeInicioComponent} from './pagina-de-inicio/pagina-de-inicio.component'


//imports de componentes
import { ConnectionService} from 'src/app/connection.service'
import { LoginEstudianteComponent } from './login-estudiante/login-estudiante.component';
import { LoginAdministradorComponent} from './login-administrador/login-administrador.component'
import { LoginProfesorComponent } from './login-profesor/login-profesor.component';


const routes: Routes = [
  { path: '', component: PaginaDeInicioComponent},
  { path: 'login-profesor', component: LoginProfesorComponent},
  { path: 'login-estudiante', component: LoginEstudianteComponent},
  { path: 'login-administrador', component: LoginAdministradorComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

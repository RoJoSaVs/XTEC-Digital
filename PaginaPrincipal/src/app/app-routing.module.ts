//imports de bibliotecas de angular
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PaginaDeInicioComponent} from './pagina-de-inicio/pagina-de-inicio.component'

//imports de componentes
import {ConnectionService} from 'src/app/connection.service'



const routes: Routes = [
  { path: '', component: PaginaDeInicioComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

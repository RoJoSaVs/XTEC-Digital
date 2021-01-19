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
import { SubirExcelManualComponent } from './subir-excel-manual/subir-excel-manual.component';
import { GestionNoticiasComponent } from './gestion-noticias/gestion-noticias.component';
import { SubirEvaluacionesComponent } from './subir-evaluaciones/subir-evaluaciones.component';
import { GestionCursosComponent } from './gestion-cursos/gestion-cursos.component';
import { GestionRubrosComponent } from './gestion-rubros/gestion-rubros.component';
import { VisualizarNoticiaComponent } from './visualizar-noticia/visualizar-noticia.component';
import { ReporteEstudiantesComponent } from './reporte-estudiantes/reporte-estudiantes.component';
import { ReporteNotasComponent } from './reporte-notas/reporte-notas.component';
import { NotasEstudianteComponent } from './notas-estudiante/notas-estudiante.component';

/*se definen las rutas para cada componente*/
const routes: Routes = [
  { path: '', component: PaginaDeInicioComponent},
  { path: 'login-profesor', component: LoginProfesorComponent},
  { path: 'login-estudiante', component: LoginEstudianteComponent},
  { path: 'login-administrador', component: LoginAdministradorComponent},
  { path: 'vista-administrador/:id', component: VistaAdministradorComponent },
  { path: 'vista-profesor/:id', component: VistaProfesorComponent },
  { path: 'vista-estudiante/:id', component: VistaEstudianteComponent },
  { path: 'subir-excel/:id', component: SubirExcelComponent },
  { path: 'subir-evaluaciones/:id', component: SubirEvaluacionesComponent },
  { path: 'gestion-noticias/:id', component: GestionNoticiasComponent },
  { path: 'gestion-rubros/:id', component: GestionRubrosComponent },
  { path: 'visualizar-noticias/:id', component: VisualizarNoticiaComponent },
  { path: 'gestion-cursos/:id', component: GestionCursosComponent },
  { path: 'reporte-estudiantes/:id', component: ReporteEstudiantesComponent },
  { path: 'reporte-notas/:id', component: ReporteNotasComponent },
  { path: 'subir-manual/:id', component: SubirExcelManualComponent },
  { path: 'notas-estudiante/:id', component: NotasEstudianteComponent },
  { path: 'gestion-documentos/:id', component: GestionDocumentosComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes),FormsModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }

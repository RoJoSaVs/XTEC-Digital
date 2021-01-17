import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ConnectionService } from '../services/connection.service';
import { EvaluacionModel } from '../subir-evaluaciones/evaluacion.model'

@Component({
  selector: 'app-subir-evaluaciones',
  templateUrl: './subir-evaluaciones.component.html',
  styleUrls: ['./subir-evaluaciones.component.css']
})
export class SubirEvaluacionesComponent implements OnInit {

  //este JSON es modificado desde el HTML para ser enviado al server
  formData: EvaluacionModel= {
    rubro : null,
    fecha_de_entrega: null,
    peso: null,
    idGrupo: null,
    grupal: null,
    especificacion: null,
  };


  //declara "this" de las clases HttpClient y el service de conexión, y el router 
  //para redirigir luego de llenar el form
  constructor(
    private http: HttpClient,
    private service : ConnectionService,
    private router: Router) { } 
  
  //url hacia donde se realizará el post
  readonly rootURL = 'http://localhost:55004/api/athlete';
 
  ngOnInit(): void {
  }

  //se obtiene el post y se envía al service para ser enviado al backend
  onSubmit(form: NgForm) {
      console.log(this.formData);
      this.service.Post(this.formData,this.rootURL).subscribe(res=>{
      });

      alert("sus datos han sido procesados con éxito");
      
      //redirige luego de indicar que se procesaron los datos
      this.router.navigate(['']);
  }
}

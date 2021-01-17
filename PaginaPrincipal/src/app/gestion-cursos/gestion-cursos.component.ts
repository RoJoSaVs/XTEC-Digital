import { Cursos } from './gestion-cursos.model';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConnectionService } from '../services/connection.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-gestion-cursos',
  templateUrl: './gestion-cursos.component.html',
  styleUrls: ['./gestion-cursos.component.css']
})


export class GestionCursosComponent implements OnInit {

  formData: Cursos= {
    codigo: null,
    nombre: null,
    creditos: null,
    carrera: null
  };

  //este form es para actualizar la tabla
  
  formUpdate: Cursos= {
    codigo: null,
    nombre: null,
    creditos: null,
    carrera: null
  };



  constructor(
    private httpClient: HttpClient,
    private service : ConnectionService) { } 

  readonly rootURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/cursos';

  cursos: Cursos[];
  //numero_de_creditos: string;

  ngOnInit(): void {
    this.getcursos();
  }

  onSubmit(form: NgForm) {
    console.log(this.formData);
    this.formData.creditos=Number(this.formData.creditos);
    this.service.Post(this.formData,this.rootURL).subscribe(res=>{
      console.log(res)
    });
    setTimeout(function(){
      window.location.reload();
    }, 5000);
  }

  getcursos(){
    this.httpClient.get<any>(this.rootURL).subscribe(
        response => {
            this.cursos = response;
        },
    );
  }

  
  //elimina un reto existente
  delete(id){
  this.httpClient.delete(this.rootURL+'/'+id).subscribe(
    response => {
      if(response==true){
      window.location.reload();
      }
      else{
        alert("No se logró eliminar el curso. Por favor verifique que el curso no está  asociado con ningún grupo");
      }
    },
    error => {
      alert("No se logró eliminar el curso. Por favor verifique que el curso no está  asociado con ningún grupo");
     }

  );

  
  }
  
  update(form: NgForm) {
    this.formUpdate.creditos=Number(this.formUpdate.creditos);
    this.service.Update(this.formUpdate,this.rootURL+'/'+this.formUpdate.codigo).subscribe(
      response => {
        if(response==true){
        window.location.reload();
        }
        else{
          alert("No se logró actualizar el curso. Por favor verifique que todos los datos son correctos (no hay letras donde debe haber números)");
        }
      },
      error => {
        alert("No se logró actualizar el curso. Por favor verifique que todos los datos son correctos (no hay letras donde debe haber números)");
       }
  );;
  
  }

  save_id(id){
    this.formUpdate.codigo=id;
  }

}

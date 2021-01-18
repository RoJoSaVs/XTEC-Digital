import { NoticiasModel } from '../services/noticias.model';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConnectionService } from '../services/connection.service';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-gestion-noticias',
  templateUrl: './gestion-noticias.component.html',
  styleUrls: ['./gestion-noticias.component.css']
})
export class GestionNoticiasComponent implements OnInit {
  formData: NoticiasModel= {
    noticiaId: null, 
    titulo: null, 
    fecha: null, 
    mensaje: null, 
    grupoId: null, 
    autor: null
  };

  //este form es para actualizar la tabla
  
  formUpdate: NoticiasModel= {
    noticiaId: null, 
    titulo: null, 
    fecha: null, 
    mensaje: null, 
    grupoId: null, 
    autor: null
  };



  constructor(
    private httpClient: HttpClient,
    private service : ConnectionService,
    private route: ActivatedRoute) { } 

  readonly rootURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/noticias';

  noticias: NoticiasModel[];
  
  autor: string;

  ngOnInit(): void {
    this.getnoticias();
    this.autor = this.route.snapshot.paramMap.get("id");
  }

  onSubmit(form: NgForm) {
    this.formData.autor=this.autor;
    this.service.Post(this.formData,this.rootURL).subscribe(res=>{
      console.log(res);
      if(!res){
        alert("Por favor ingrese un rubro con una Id de grupo válido y verifique que el grupo existe en la base de datos");
      }
      else{
        setTimeout(function(){
          window.location.reload();
        }, 5000);
      }
    });

  }

  getnoticias(){
    this.httpClient.get<any>(this.rootURL).subscribe(
        response => {
            this.noticias = response;
        },
    );
  }

  
  //elimina un reto existente
  delete(id){
  this.httpClient.delete(this.rootURL+'/'+id).subscribe(
    response => {
      if(response){
        window.location.reload();
      }
      else{
        alert("No se logró eliminar la noticia");
      }
    },
    error => {
      alert("No se logró eliminar la noticia");
     }

  );

  
  }
  
  update(form: NgForm) {
    console.log(this.formData);
    this.service.Update(this.formUpdate,this.rootURL+'/'+this.formUpdate.noticiaId).subscribe(
      response => {
        if(response){
          window.location.reload();
        } 
        else{
          alert("No se logró actualizar la noticia. Por favor verifique que todos los datos son correctos (no hay letras donde debe haber números)");
        }
      },
      error => {
        alert("No se logró actualizar la noticia. Por favor verifique que todos los datos son correctos (no hay letras donde debe haber números)");
       }
  );;
  
  }

  save_id(noticia_id,grupo_id){
    this.formUpdate.noticiaId=noticia_id;
    this.formUpdate.grupoId=grupo_id;
  }

}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ConnectionService } from '../services/connection.service';
import { RubrosModel } from '../gestion-rubros/rubros.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-gestion-rubros',
  templateUrl: './gestion-rubros.component.html',
  styleUrls: ['./gestion-rubros.component.css']
})
export class GestionRubrosComponent implements OnInit {

  formData: RubrosModel= {
    rubroId: null,
    nombre: null,
    porcentaje: null,
    grupoId: null
  };

  //este form es para actualizar la tabla
  
  formUpdate: RubrosModel= {
    rubroId: null,
    nombre: null,
    porcentaje: null,
    grupoId: null
  };



  constructor(
    private httpClient: HttpClient,
    private service : ConnectionService) { } 

  readonly rootURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/rubros';

  rubros: RubrosModel[];
  //numero_de_creditos: string;

  ngOnInit(): void {
    this.getrubros();
  }

  onSubmit(form: NgForm) {
    console.log(this.formData);
    this.formData.porcentaje=Number(this.formData.porcentaje);
    this.service.Post(this.formData,this.rootURL).subscribe(res=>{
      if(!res){
        alert("Por favor ingrese un rubro con una Id de grupo válido y verifique que todos los campos son correctos (no hay letras donde debería haber números)");
      }
    });
    setTimeout(function(){
      window.location.reload();
    }, 5000);
  }

  getrubros(){
    this.httpClient.get<any>(this.rootURL).subscribe(
        response => {
            this.rubros = response;
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
        alert("No se logró eliminar el rubro. Por favor verifique que el rubro no está  asociado con ninguna evaluación");
      }
    },
    error => {
      alert("No se logró eliminar el rubro. Por favor verifique que el rubro no está  asociado con ninguna evaluación");
     }

  );

  
  }
  
  update(form: NgForm) {
    this.formUpdate.porcentaje=Number(this.formUpdate.porcentaje);
    console.log(this.formUpdate);
    this.service.Update(this.formUpdate,this.rootURL+'/'+this.formUpdate.rubroId).subscribe(
      response => {
        if(response==true){
          window.location.reload();
        }
        else{
          alert("No se logró actualizar el rubro. Por favor verifique que todos los datos son correctos (no hay letras donde debe haber números)");
        }
      },
      error => {
        alert("No se logró actualizar el rubro. Por favor verifique que todos los datos son correctos (no hay letras donde debe haber números)");
       }
  );;
  
  }

  save_id(rubro_id,grupo_id){
    this.formUpdate.rubroId=rubro_id;
    this.formUpdate.grupoId=grupo_id;

  }

}

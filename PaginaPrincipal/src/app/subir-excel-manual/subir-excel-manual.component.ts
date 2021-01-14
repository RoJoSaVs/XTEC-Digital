import { stringify } from '@angular/compiler/src/util';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from '../services/connection.service';
import { ExcelFormModel } from './excel-form.model';

@Component({
  selector: 'app-subir-excel-manual',
  templateUrl: './subir-excel-manual.component.html',
  styleUrls: ['./subir-excel-manual.component.css']
})


export class SubirExcelManualComponent implements OnInit {

  formData: ExcelFormModel= {
    Carnet: null,
    Nombre: null,
    Apellido1: null,
    Apellido2: null,
    IdCurso: null,
    NombreCurso: null,
    Ano: null,
    Semestre: null,
    Grupo: null,
    IdProfesor: null,
    NombreProfesor: null,
    Apellido1Profesor: null,
    Apellido2Profesor: null,
  };

  formData1: ExcelFormModel= {
    Carnet: null,
    Nombre: null,
    Apellido1: null,
    Apellido2: null,
    IdCurso: null,
    NombreCurso: null,
    Ano: null,
    Semestre: null,
    Grupo: null,
    IdProfesor: null,
    NombreProfesor: null,
    Apellido1Profesor: null,
    Apellido2Profesor: null,
  };

  formData2: ExcelFormModel= {
    Carnet: null,
    Nombre: null,
    Apellido1: null,
    Apellido2: null,
    IdCurso: null,
    NombreCurso: null,
    Ano: null,
    Semestre: null,
    Grupo: null,
    IdProfesor: null,
    NombreProfesor: null,
    Apellido1Profesor: null,
    Apellido2Profesor: null,
  };

  formData3: ExcelFormModel= {
    Carnet: null,
    Nombre: null,
    Apellido1: null,
    Apellido2: null,
    IdCurso: null,
    NombreCurso: null,
    Ano: null,
    Semestre: null,
    Grupo: null,
    IdProfesor: null,
    NombreProfesor: null,
    Apellido1Profesor: null,
    Apellido2Profesor: null,
  };

  formData4: ExcelFormModel= {
    Carnet: null,
    Nombre: null,
    Apellido1: null,
    Apellido2: null,
    IdCurso: null,
    NombreCurso: null,
    Ano: null,
    Semestre: null,
    Grupo: null,
    IdProfesor: null,
    NombreProfesor: null,
    Apellido1Profesor: null,
    Apellido2Profesor: null,
  };

  formData5: ExcelFormModel= {
    Carnet: null,
    Nombre: null,
    Apellido1: null,
    Apellido2: null,
    IdCurso: null,
    NombreCurso: null,
    Ano: null,
    Semestre: null,
    Grupo: null,
    IdProfesor: null,
    NombreProfesor: null,
    Apellido1Profesor: null,
    Apellido2Profesor: null,
  };


  readonly excelURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/tableExcel';

  Jsons="";

  constructor(private http: HttpClient,
    private service : ConnectionService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm,n:number) {
    if(n===0){
      if (this.formData.NombreCurso===null){
        alert("Ha ingresado datos nulos, por favor rellene los campos necesarios")
      }
      else{
        this.Jsons=this.Jsons+JSON.stringify(this.formData)+',';
      }
    }


    if(n===1){
      if (this.formData1.NombreCurso===null){
        alert("Ha ingresado datos nulos, por favor rellene los campos necesarios")
      }
      else{
        this.Jsons=this.Jsons+JSON.stringify(this.formData1)+',';
      }
    }


    if(n===2){
      if (this.formData2.NombreCurso===null){
        alert("Ha ingresado datos nulos, por favor rellene los campos necesarios")
      }
      else{
        this.Jsons=this.Jsons+JSON.stringify(this.formData2)+',';
      }
    }

    if(n===3){
      if (this.formData2.NombreCurso===null){
        alert("Ha ingresado datos nulos, por favor rellene los campos necesarios")
      }
      else{
        this.Jsons=this.Jsons+JSON.stringify(this.formData3)+',';
      }
    }

    if(n===4){
      if (this.formData2.NombreCurso===null){
        alert("Ha ingresado datos nulos, por favor rellene los campos necesarios")
      }
      else{
        this.Jsons=this.Jsons+JSON.stringify(this.formData4)+',';
      }
    }

    if(n===5){
      if (this.formData2.NombreCurso===null){
        alert("Ha ingresado datos nulos, por favor rellene los campos necesarios")
      }
      else{
        this.Jsons=this.Jsons+JSON.stringify(this.formData5) +',';
      }
    }
  }

  //boton que envia los jsons de todas las casillas
  enviar() {

    const formated_excel= JSON.parse("["+this.Jsons.slice(0,-1)+"]");
    console.log(formated_excel);
    this.service.Post(formated_excel,this.excelURL).subscribe(
     response => {
        alert(response);
        if( response ===true){
          alert("Datos ingresados con éxito, puede agregar más si lo desea");
          //this.router.navigate(['vista-estudiante', this.formData.username.toString()]);
        }
        else{
          alert("No se logró subir los datos. Por favor verifique: \n -Que todos los datos fueron ingresados \n -Que los tipos son correctos (no hay letras donde debería haber números) \n -Que no se repitan los datos \n -Carné, id-profesor e id-curso deben existir en la base de datos");
        }
     },
     error => {
       alert("no se logro conectar con el servidor");
      }
     );
  }

}

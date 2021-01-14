
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as XLSX from 'xlsx';
import { ConnectionService } from '../services/connection.service';
import { ExcelFormModel } from '../subir-excel-manual/excel-form.model';

@Component({
  selector: 'app-subir-excel',
  templateUrl: './subir-excel.component.html',
  styleUrls: ['./subir-excel.component.css']
})


export class SubirExcelComponent {
  name = 'This is XLSX TO JSON CONVERTER';
  willDownload = false;

  readonly excelURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/tableExcel';
  jsonArray=[];

  constructor(private http: HttpClient,
    private service : ConnectionService,
    private router: Router,
    private route: ActivatedRoute) { }

  onFileChange(ev) {
    let workBook = null;
    let jsonData = null;
    const reader = new FileReader();
    const file = ev.target.files[0];
    reader.onload = (event) => {
      const data = reader.result;
      workBook = XLSX.read(data, { type: 'binary' });
      jsonData = workBook.SheetNames.reduce((initial, name) => {
        const sheet = workBook.Sheets[name];
        initial[name] = XLSX.utils.sheet_to_json(sheet);
        return initial;
      }, {});

      //conversion al formato de envío

      jsonData.Data.forEach(element => {

        for (var k in element)
        {
            if (element.hasOwnProperty(k))
            {
                element[k] = String(element[k]);
            }
        }
        this.jsonArray.push(element)
      });
      
      console.log(this.jsonArray);

      //envia los datos mediante el metodo post
      this.service.Post(this.jsonArray,this.excelURL).subscribe(
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
    reader.readAsBinaryString(file);
  }

}

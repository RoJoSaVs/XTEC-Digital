
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import * as XLSX from 'xlsx';
import { ConnectionService } from '../services/connection.service';

@Component({
  selector: 'app-subir-excel',
  templateUrl: './subir-excel.component.html',
  styleUrls: ['./subir-excel.component.css']
})


export class SubirExcelComponent {
  name = 'This is XLSX TO JSON CONVERTER';
  willDownload = false;

  readonly excelURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/tableExcel';

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


      //aqui puedo obtener los datos, se cortan los agregados de la biblioteca xlsx y se envia como JSON
      const dataString = JSON.stringify(jsonData); 
      const dataString_modified = dataString.slice(8,-1);
      console.log(dataString_modified);
      const ready_json = JSON.parse(dataString_modified);
      

      //envia los datos mediante el metodo post
      this.service.Post(ready_json,this.excelURL).subscribe(
        response => {
           if( response ===true){
             //this.router.navigate(['vista-estudiante', this.formData.username.toString()]);
             alert("Datos ingresados con éxito");
             //window.location.reload();
            }
           else{
             alert("Usuario inválido, por favor verifique los datos");
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

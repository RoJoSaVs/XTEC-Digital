
import { Component } from '@angular/core';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-subir-excel',
  templateUrl: './subir-excel.component.html',
  styleUrls: ['./subir-excel.component.css']
})


export class SubirExcelComponent {
  name = 'This is XLSX TO JSON CONVERTER';
  willDownload = false;

  constructor() { }

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


      //aqui puedo obtener los datos
      const dataString = JSON.stringify(jsonData);
      alert(dataString);
    }
    reader.readAsBinaryString(file);
  }

}

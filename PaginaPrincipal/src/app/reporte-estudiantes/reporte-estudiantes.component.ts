import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from '../services/connection.service';

@Component({
  selector: 'app-reporte-estudiantes',
  templateUrl: './reporte-estudiantes.component.html',
  styleUrls: ['./reporte-estudiantes.component.css']
})
export class ReporteEstudiantesComponent implements OnInit {


  constructor(private http: HttpClient,
    private service : ConnectionService,
    private router: Router,
    private route: ActivatedRoute) { }

  readonly rootURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/MatriculadosCurso/';

  grupo;
  
  ngOnInit(): void {
  }


  onSubmit(form: NgForm) {

    this.service.Post(null,this.rootURL+this.grupo).subscribe(
     response => {
        if(response){
          try{
            window.location.replace(this.rootURL+this.grupo);}
          catch{
            alert("Error, por favor verifique que el código ingresado existe");
          }
        }
        else{
          alert("Error, por favor verifique que el código ingresado existe");
        }
     },
     error => {
      alert("Error, por favor verifique que el código ingresado existe");
      }
     );
    }

}

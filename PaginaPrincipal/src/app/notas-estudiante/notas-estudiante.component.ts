import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from '../services/connection.service';

@Component({
  selector: 'app-notas-estudiante',
  templateUrl: './notas-estudiante.component.html',
  styleUrls: ['./notas-estudiante.component.css']
})
export class NotasEstudianteComponent implements OnInit {

  constructor(
    private http: HttpClient,
    private service : ConnectionService,
    private router: Router,
    private route: ActivatedRoute) { } 
  
  //url hacia donde se realizará el post
  readonly rootURL = 'https://xtecdigitalsqlbdmg5.azurewebsites.net/api/NotasEstudiante/';
  carne;
  grupo;
 
  ngOnInit(): void {
    this.carne= this.route.snapshot.paramMap.get("id")
  }

  /*verifica que el curso exista en la base de datos, y procede a obtener el 
  archivo solicitado*/
  onSubmit(form: NgForm) {

    this.service.Post(null,this.rootURL+this.grupo).subscribe(
     response => {
        console.log(this.rootURL+this.grupo+'/'+this.carne);
        if(response){
          try{
            window.location.replace(this.rootURL+this.grupo+'/'+this.carne);}
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

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from '../services/connection.service';
import { LoginFormModel } from '../services/login-form.model';


@Component({
  selector: 'app-login-estudiante',
  templateUrl: './login-estudiante.component.html',
  styleUrls: ['./login-estudiante.component.css']
})
export class LoginEstudianteComponent implements OnInit {

  formData: LoginFormModel= {
    username: null,
    password: null,
  };

  constructor(private http: HttpClient,
    private service : ConnectionService,
    private router: Router,
    private route: ActivatedRoute) { }

  readonly rootURL = 'http://xtecmongodb.azurewebsites.net/api/estudiante/login';

  ngOnInit(): void {
  }


  onSubmit(form: NgForm) {
    this.service.Post(this.formData,this.rootURL).subscribe(
     response => {
        if( response ===true){
          this.router.navigate(['vista-estudiante', this.formData.username.toString()]);
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
  }
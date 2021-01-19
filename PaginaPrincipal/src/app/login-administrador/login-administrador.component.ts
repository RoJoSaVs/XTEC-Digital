import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConnectionService } from '../services/connection.service';
import { LoginFormModel } from '../services/login-form.model';

@Component({
  selector: 'app-login-administrador',
  templateUrl: './login-administrador.component.html',
  styleUrls: ['./login-administrador.component.css']
})
export class LoginAdministradorComponent implements OnInit {

  formData: LoginFormModel= {
    username: null,
    password: null,
  };

  constructor(private http: HttpClient,
    private service : ConnectionService,
    private router: Router,
    private route: ActivatedRoute) { }

  readonly rootURL = 'http://xtecmongodb.azurewebsites.net/api/admin/login';

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.service.Post(this.formData,this.rootURL).subscribe(
     response => {
       /*verifica si los datos son correctos, y si los son, redirige a una nueva página*/
        if( response ===true){
          /*Dirije a la página de inicio si el login fue correcto*/
          this.router.navigate(['vista-administrador', this.formData.username.toString()]);
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
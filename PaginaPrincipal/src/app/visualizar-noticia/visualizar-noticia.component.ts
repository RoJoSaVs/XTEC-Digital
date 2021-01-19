import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConnectionService } from '../services/connection.service';
import { NoticiasModel } from '../services/noticias.model';

@Component({
  selector: 'app-visualizar-noticia',
  templateUrl: './visualizar-noticia.component.html',
  styleUrls: ['./visualizar-noticia.component.css']
})

/*Este procedimiento carga la tabla con noticias igual que en la gestión de noticias*/
export class VisualizarNoticiaComponent implements OnInit {

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
  }

  getnoticias(){
    this.httpClient.get<any>(this.rootURL).subscribe(
        response => {
            this.noticias = response;
        },
    );
  }

  

}

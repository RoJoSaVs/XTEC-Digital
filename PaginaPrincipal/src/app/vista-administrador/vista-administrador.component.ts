import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';

@Component({
  selector: 'app-vista-administrador',
  templateUrl: './vista-administrador.component.html',
  styleUrls: ['./vista-administrador.component.css']
})
export class VistaAdministradorComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  username:String;  

  ngOnInit(): void {
    this.route.params.subscribe(event => {
      this.username = event.id;
     });
  }

}

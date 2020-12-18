import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-vista-estudiante',
  templateUrl: './vista-estudiante.component.html',
  styleUrls: ['./vista-estudiante.component.css']
})
export class VistaEstudianteComponent implements OnInit {

  username:String;  

  constructor(private route: ActivatedRoute) { }
  
  ngOnInit(): void {
    this.route.params.subscribe(event => {
      this.username = event.id;
     });
  }

}

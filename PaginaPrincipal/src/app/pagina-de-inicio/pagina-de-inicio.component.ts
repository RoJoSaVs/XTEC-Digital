/*notas sobre la documentación:
En muchos componentes se realizan las mismas funciones, por lo tanto,
para evitar redundancia del código ciertas funcionalidades solo se comentaron
en 1 de los algoritmos que la implementan
Se tomará el primer algoritmo por orden alfabético como referencia*/

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pagina-de-inicio',
  templateUrl: './pagina-de-inicio.component.html',
  styleUrls: ['./pagina-de-inicio.component.css']
})
export class PaginaDeInicioComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

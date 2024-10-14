import { Component,  OnInit } from '@angular/core';
import { Cidade } from '../model/cidade';
import { Estado } from '../model/estado';


@Component({
  selector: 'app-pagina-principal',
  templateUrl: './paginaPrincipal.component.html',
  styleUrls: ['./teste.component.scss']
})
export class PaginaPrincipalComponent implements OnInit {

  constructor(){
  }

  estado: Estado = new Estado();
  cidade: Cidade = new Cidade();


  ngOnInit(): void {

  }

}

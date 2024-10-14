import { Component, OnInit, ViewChild } from '@angular/core';
import { PontoTuristico } from '../model/ponto-turistico.model';
import { PontoTuristicoService } from '../services/ponto-turistico.service'; // Certifique-se do caminho correto
import { catchError } from 'rxjs/operators'; // Para tratar erros
import { of } from 'rxjs'; // Para retornar um observable vazio em caso de erro
import { DxDataGridComponent } from 'devextreme-angular';

@Component({
  selector: 'app-ponto-turistico',
  templateUrl: './ponto-turistico.component.html',
  styleUrls: ['./ponto-turistico.component.scss']
})
export class PontoTuristicoComponent implements OnInit {
  @ViewChild('dataGrid', { static: false }) dataGrid!: DxDataGridComponent; // Acesse o DataGrid

  pontosTuristicos: PontoTuristico[] = []; // Lista de pontos turísticos
  searchTerm: string = ''; // Termo de busca

  constructor(private pontoTuristicoService: PontoTuristicoService) {}

  ngOnInit() {
    // Carregar os dados do backend
    this.loadPontosTuristicos();
  }


  loadPontosTuristicos() {
    this.pontoTuristicoService.getPontosTuristicos().subscribe(data => {
      this.pontosTuristicos = data;
    });
    this.dataGrid.instance.refresh(); // Chama refresh no DataGrid
  }
  onRowInserted(event: any) {
    const novoPontoTuristico: PontoTuristico = event.data;
    this.pontoTuristicoService.createPontoTuristico(novoPontoTuristico).subscribe(response => {
      console.log('Ponto turístico adicionado:', response);
      this.loadPontosTuristicos(); // Atualiza a lista após adição
    });
  }

}

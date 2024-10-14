import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import { ConsultaEstadoService } from '../services/consulta-estado.service';
import { ConsultaCidadesService } from '../services/consulta-cidade.service';
import { Estado } from '../model/estado';
import { Cidade } from '../model/cidade';
import { PontoTuristicoService } from '../services/ponto-turistico.service';
import { PontoTuristico } from '../model/ponto-turistico.model';

@Component({
  selector: 'app-cidade-estado',
  templateUrl: './cidade-estado.component.html',
  styleUrls: ['./cidade-estado.component.scss'],
  providers: [ConsultaEstadoService]
})
export class CidadeEstadoComponent implements OnInit {

  estados!: DataSource;
  cidades: Array<Cidade> = [];

  private _estado?: Estado;

  @Input()
  get estado(): Estado {
    return this._estado ? this._estado : new Estado();
  }
  set estado(value: Estado) {
    this._estado = value;
    this.estadoChange.emit(value);
  }

  @Input()
  cidade?: Cidade;

  @Output()
  estadoChange: EventEmitter<Estado> = new EventEmitter<Estado>();
  cidadeChange: EventEmitter<Cidade> = new EventEmitter<Cidade>();

  // Campos adicionais
  nome: string = '';
  descricao: string = '';
  localizacao: string = '';

  constructor(
    private estadoService: ConsultaEstadoService,
    private cidadeService: ConsultaCidadesService,
    private apiService: PontoTuristicoService
  ) {}

  ngOnInit() {
    this.estadoService.getEstados().subscribe(uf => {
      this.estados = new DataSource({
        store: {
          type: "array",
          key: "id",
          data: uf
        }
      });
    });
  }

  listarCidades(ev: any) {
    this.estadoChange.emit(ev.selectedItem);
    const uf = ev.selectedItem.sigla;
    return this.cidadeService
      .getCidades(uf)
      .subscribe(resultado => { this.cidades = resultado });
  }

  getCidadeSelecionada(ev: any) {
    this.cidadeChange.emit(ev.selectedItem);
    const cidadeSelecionada = ev.selectedItem.nome;
    console.log(cidadeSelecionada);
    this.cidade = ev.selectedItem; // Armazena a cidade selecionada
    return cidadeSelecionada;
  }

  salvarInformacoes() {
    const pontoTuristico: PontoTuristico = {
      id: 0, // Ou outro valor conforme a lógica da sua aplicação
      nome: this.nome,
      descricao: this.descricao,
      localizacao: this.localizacao,
      cidade: this.cidade?.nome || '', // Obtendo o nome da cidade selecionada
      estado: this.estado?.getDisplayValue() || '' // Obtendo o nome do estado selecionado
    };

    this.apiService.createPontoTuristico(pontoTuristico).subscribe(
      (response: PontoTuristico) => {
        console.log('Ponto turístico criado com sucesso:', response);
        // Você pode adicionar lógica para lidar com o sucesso, como limpar os campos ou mostrar uma mensagem
      },
      (error: PontoTuristico) => {
        console.error('Erro ao criar ponto turístico:', error);
        // Você pode adicionar lógica para lidar com erros, como mostrar uma mensagem de erro ao usuário
      }
    );

  }
}

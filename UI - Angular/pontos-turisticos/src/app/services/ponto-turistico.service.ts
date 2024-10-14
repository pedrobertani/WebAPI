import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PontoTuristico } from '../model/ponto-turistico.model';

@Injectable({
  providedIn: 'root'
})
export class PontoTuristicoService {
  private apiUrl = 'http://localhost:5011/api/PontosTuristicos'; 
  constructor(private http: HttpClient) { }

  // Método para buscar todos os pontos turísticos
  getPontosTuristicos(): Observable<PontoTuristico[]> {
    return this.http.get<PontoTuristico[]>(`${this.apiUrl}`);
  }

  // Método para buscar um ponto turístico por ID
  getPontoTuristicoById(id: number): Observable<PontoTuristico> {
    return this.http.get<PontoTuristico>(`${this.apiUrl}/${id}`);
  }

  // Método para criar um novo ponto turístico
  createPontoTuristico(pontoTuristico: PontoTuristico): Observable<PontoTuristico> {
    return this.http.post<PontoTuristico>(`${this.apiUrl}`, pontoTuristico);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CrearMovimiento, Movimiento } from './interfaces/movimientos.model';
import { filtroReporte } from '../reportes/interfaces/filtroReporte.model';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {
  private apiUrl = environment.apiUrl + '/movimientos';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Movimiento[]> {
    return this.http.get<Movimiento[]>(`${this.apiUrl}`);
  }

  getByCuentaId(id: number): Observable<Movimiento> {
    return this.http.get<Movimiento>(`${this.apiUrl}/cuenta/${id}`);
  }

  crearMovimiento(nuevoMovimiento: CrearMovimiento): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, nuevoMovimiento);
  }

  filtrarMovimientos(filtroReporte: filtroReporte): Observable<Movimiento[]> {
    return this.http.post<Movimiento[]>(`${this.apiUrl}/reporte`, filtroReporte);
  }

}

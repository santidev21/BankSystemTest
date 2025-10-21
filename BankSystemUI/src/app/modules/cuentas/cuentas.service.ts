import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CrearCuenta, Cuenta } from './interfaces/cuentas.model';

@Injectable({
  providedIn: 'root'
})
export class CuentasService {
  private apiUrl = environment.apiUrl + '/cuentas';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cuenta[]> {
    return this.http.get<Cuenta[]>(`${this.apiUrl}`);
  }

  getById(id: number): Observable<Cuenta> {
    return this.http.get<Cuenta>(`${this.apiUrl}/${id}`);
  }

  crearCuenta(nuevaCuenta: CrearCuenta): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, nuevaCuenta);
  }

  actualizarCuenta(CuentaEditada: Cuenta): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}`, CuentaEditada);
  }

  eliminarCuenta(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}

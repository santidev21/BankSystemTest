import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente, CrearCliente } from './interfaces/Clientes.model';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  private apiUrl = environment.apiUrl + '/clientes';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(`${this.apiUrl}`);
  }

  getById(id: number): Observable<Cliente> {
    return this.http.get<Cliente>(`${this.apiUrl}/${id}`);
  }

  crearCliente(nuevoCliente: CrearCliente): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, nuevoCliente);
  }

  actualizarCliente(clienteEditado: Cliente): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}`, clienteEditado);
  }

  eliminarCliente(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}

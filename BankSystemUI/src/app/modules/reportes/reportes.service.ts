import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { filtroReporte } from './interfaces/filtroReporte.model';

@Injectable({
  providedIn: 'root'
})
export class ReportesService {
  private apiUrl = environment.apiUrl + '/export';

  constructor(private http: HttpClient) { }

  exportarMovimientos(filtroReporte: filtroReporte): Observable<Blob> {
      return this.http.post(`${this.apiUrl}/reporte`, filtroReporte, {
        responseType: 'blob'
      });
  }
}

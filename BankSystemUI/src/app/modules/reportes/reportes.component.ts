import { Component, OnInit } from '@angular/core';
import { Movimiento } from '../movimientos/interfaces/movimientos.model';
import { MovimientosService } from '../movimientos/movimientos.service';
import { Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Cuenta } from '../cuentas/interfaces/cuentas.model';
import { CuentasService } from '../cuentas/cuentas.service';
import { filtroReporte } from './interfaces/filtroReporte.model';
import { ReportesService } from './reportes.service';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.scss']
})
export class ReportesComponent implements OnInit {
  filtroForm: FormGroup = new FormGroup({});
  listamovimientos: Movimiento[] = [];
  listaCuentas: Cuenta[] = [];
  

  constructor(private fb: FormBuilder,
    private movimientosService: MovimientosService,
    private cuentasService: CuentasService,
    private reportesService: ReportesService
  ) { }

  ngOnInit(): void {
    this.filtroForm = this.fb.group({
      cuentaId: [null],
      initialDate: [null, Validators.required],
      finalDate: [null, Validators.required]
    }, {
      validators: [this.validarRangoFechas()]
    });

    this.movimientosService.getAll().subscribe((resp : Movimiento[]) => {
      this.listamovimientos = resp;
    });

    this.cuentasService.getAll().subscribe((resp : Cuenta[]) => {
      this.listaCuentas = resp;
    });
  }

  validarRangoFechas(): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
      const inicio = group.get('initialDate')?.value;
      const fin = group.get('finalDate')?.value;

      if (inicio && fin && new Date(inicio) > new Date(fin)) {
        return { rangoInvalido: true };
      }

      return null;
    };
  }

  onSubmit(): void {
    const filtro = this.getFiltro();
    if (!filtro) return;
    
    this.movimientosService.filtrarMovimientos(filtro).subscribe(resp =>{
      this.listamovimientos = resp;
    });
  }

  exportarMovimientos(){
    const filtro = this.getFiltro();
    if (!filtro) return;
    
    this.reportesService.exportarMovimientos(filtro).subscribe(resp =>{
        const url = window.URL.createObjectURL(resp);
        const a = document.createElement('a');
        a.href = url;
        a.download = 'reporte_movimientos.pdf';
        a.click();
        window.URL.revokeObjectURL(url);

    });
  }

  private getFiltro(): filtroReporte | null {
    if (this.filtroForm.invalid) {
      this.filtroForm.markAllAsTouched();
      return null;
    }

    return {
      cuentaId: this.filtroForm.value.cuentaId,
      limiteInferior: new Date(this.filtroForm.value.initialDate).toISOString(),
      limiteSuperior: new Date(this.filtroForm.value.finalDate).toISOString()
    };
  }
}

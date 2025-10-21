import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CuentasService } from '../../cuentas/cuentas.service';
import { MovimientosService } from '../movimientos.service';
import { Cuenta } from '../../cuentas/interfaces/cuentas.model';

@Component({
  selector: 'app-nuevo-movimiento',
  templateUrl: './nuevo-movimiento.component.html',
  styleUrls: ['./nuevo-movimiento.component.scss']
})
export class NuevoMovimientoComponent implements OnInit {
  movimientosForm: FormGroup = new FormGroup({});
  tipos = ['Debito', 'Credito'];
  listaCuentas: Cuenta[] = [];

  constructor(private fb: FormBuilder,
    private router: Router,
    private cuentasService: CuentasService,
    private movimientosService: MovimientosService
  ) { }

  ngOnInit(): void {  
    this.movimientosForm = this.fb.group({
      tipo: ['', Validators.required],
      valor: ['', [Validators.required , Validators.min(0)]],
      cuentaId: ['', [Validators.required, Validators.min(0)]]
    });

    this.cuentasService.getAll().subscribe((resp : Cuenta[]) => {
      this.listaCuentas = resp;
    });
    
  }

  onSubmit() : void{
    if (this.movimientosForm.valid) {
        let movimientoNuevo = this.movimientosForm.value;
        this.movimientosService.crearMovimiento(movimientoNuevo).subscribe(resp => {this.redirect()});
    } else {
      this.movimientosForm.markAllAsTouched();
      return;
    }
  }

  redirect(): void {
    this.router.navigate(['/movimientos']);
  }
}

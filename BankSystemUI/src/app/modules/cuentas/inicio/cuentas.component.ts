import { Component, OnInit } from '@angular/core';
import { Cuenta } from '../interfaces/cuentas.model';
import { CuentasService } from '../cuentas.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cuentas',
  templateUrl: './cuentas.component.html',
  styleUrls: ['./cuentas.component.scss']
})
export class CuentasComponent implements OnInit {
  listaCuentas: Cuenta[] = [];
  filtro: string = '';

  constructor(private cuentasService: CuentasService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.cuentasService.getAll().subscribe((resp : Cuenta[]) => {
      this.listaCuentas = resp;
    });
  }

  agregarNuevaCuenta() : void{
    this.router.navigate(['/cuentas/nuevo']);
  }

  editarCuenta(id: number) : void{
  this.router.navigate([`/cuentas/editar/${id}`]);
  }

  eliminarCuenta(id: number) : void{
    this.cuentasService.eliminarCuenta(id).subscribe(resp => {
      this.listaCuentas = this.listaCuentas.filter(c => c.personaId !== id);
    });
  }

  get listaCuentasFiltrada() {
    const texto = this.filtro.toLowerCase();
    return this.listaCuentas.filter(p =>
      Object.values(p).some(valor =>
        String(valor).toLowerCase().includes(texto)
      )
    );
  }
}

import { Component, OnInit } from '@angular/core';
import { Movimiento } from '../interfaces/movimientos.model';
import { MovimientosService } from '../movimientos.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movimientos',
  templateUrl: './movimientos.component.html',
  styleUrls: ['./movimientos.component.scss']
})
export class MovimientosComponent implements OnInit {
  listamovimientos: Movimiento[] = [];
  filtro: string = '';

  constructor(private movimientosService: MovimientosService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.movimientosService.getAll().subscribe((resp : Movimiento[]) => {
      this.listamovimientos = resp;
    });
  }

  agregarNuevomovimiento() : void{
    this.router.navigate(['/movimientos/nuevo']);
  }

  get listaMovimientosFiltrada() {
    const texto = this.filtro.toLowerCase();
    return this.listamovimientos.filter(p =>
      Object.values(p).some(valor =>
        String(valor).toLowerCase().includes(texto)
      )
    );
  }
}

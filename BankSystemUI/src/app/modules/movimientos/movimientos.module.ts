import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovimientosComponent } from './inicio/movimientos.component';
import { MovimientosRoutingModule } from './movimientos.routing.module';
import { NuevoMovimientoComponent } from './nuevo-movimiento/nuevo-movimiento.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    MovimientosComponent,
    NuevoMovimientoComponent
  ],
  imports: [
    CommonModule,
    MovimientosRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class MovimientosModule { }

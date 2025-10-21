import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MovimientosComponent } from './movimientos.component';
import { MovimientosRoutingModule } from './movimientos.routing.module';



@NgModule({
  declarations: [
    MovimientosComponent
  ],
  imports: [
    CommonModule,
    MovimientosRoutingModule
  ]
})
export class MovimientosModule { }

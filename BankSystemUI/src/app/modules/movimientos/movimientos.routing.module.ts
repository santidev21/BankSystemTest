import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovimientosComponent } from './inicio/movimientos.component';
import { NuevoMovimientoComponent } from './nuevo-movimiento/nuevo-movimiento.component';

const routes: Routes = [
  { path: 'inicio', component: MovimientosComponent},
  { path: 'nuevo', component: NuevoMovimientoComponent},
  { path: 'editar/:id', component: NuevoMovimientoComponent },
  { path: '**', redirectTo: 'inicio'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MovimientosRoutingModule { }

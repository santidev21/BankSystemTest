import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CuentasComponent } from './inicio/cuentas.component';
import { NuevaCuentaComponent } from './nueva-cuenta/nueva-cuenta.component';


const routes: Routes = [
  { path: 'inicio', component: CuentasComponent},
  { path: 'nuevo', component: NuevaCuentaComponent},
  { path: 'editar/:id', component: NuevaCuentaComponent },
  { path: '**', redirectTo: 'inicio'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CuentasRoutingModule { }

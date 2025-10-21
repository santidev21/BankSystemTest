import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesComponent } from './components/inicio/clientes.component';
import { NuevoClienteComponent } from './components/nuevo-cliente/nuevo-cliente.component';

const routes: Routes = [
  { path: 'inicio', component: ClientesComponent},
  { path: 'nuevo', component: NuevoClienteComponent},
  { path: 'editar/:id', component: NuevoClienteComponent },
  { path: '**', redirectTo: 'inicio'}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClientesRoutingModule { }
